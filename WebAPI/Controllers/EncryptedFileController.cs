using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI.DTOs;
using WebAPI.DTOs.Converters;
using WebAPI.Security;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EncryptedFileController : ControllerBase
{
    private readonly IEncryptedFileRepo _encryptedFileRepo;
    private readonly JWT_Helper _jwtHelper;

    public EncryptedFileController(IEncryptedFileRepo encryptedFileRepo, IConfiguration configuration)
    {
        _encryptedFileRepo = encryptedFileRepo;
        _jwtHelper = new JWT_Helper(configuration);
    }

    // GET api/EncryptedFile/<guid>
    [HttpGet("{ownerGuid}")]
    [Authorize]
    public async Task<ActionResult<EncryptedFileDto>> Get(Guid ownerGuid)
    {
        var validationErrors = GetValidationErrors(ownerGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }

        var files = await _encryptedFileRepo.GetUserFilesAsync(ownerGuid);
        return Ok(DtoConverter<EncryptedFile, EncryptedFileDto>.FromList(files));
    }

    // GET api/EncryptedFile/getShared/<guid>
    [HttpGet("GetShared/{ownerGuid}/folder/{folderGuid}")]
    [Authorize]
    public async Task<ActionResult<EncryptedFileDto>> GetShared(Guid ownerGuid, Guid folderGuid,[FromBody] byte[] shareCode)
    {
        var validationErrors = GetValidationErrors(ownerGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }

        var files = await _encryptedFileRepo.GetSharedFolderFiles(folderGuid, shareCode);
        return Ok(DtoConverter<EncryptedFile, EncryptedFileDto>.FromList(files));
    }

    // POST api/EncryptedFile/create
    [HttpPost("Create/{userGuid}")]
    [Authorize]
    public async Task<ActionResult<Guid>> CreateFileForOwner(Guid userGuid,[FromBody] EncryptedFileDto encryptedFileDto)
    {
        var validationErrors = GetValidationErrors(userGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }
        
        if (encryptedFileDto.OwnerGuid == Guid.Empty || encryptedFileDto.EncryptedFile == null)
        {
            return BadRequest("Owner or file was empty, this is not allowed.");
        }

        var encryptedFile = DtoConverter<EncryptedFileDto, EncryptedFile>.From(encryptedFileDto);
        Guid? returnedGuid = await _encryptedFileRepo.CreateAsync(encryptedFile, userGuid);
        if (returnedGuid.HasValue && returnedGuid != Guid.Empty)
        {
            return Ok(returnedGuid);
        }
        return BadRequest();
    }

    // POST api/EncryptedFile/share
    [HttpPost("Share/{userGuid}/folder/{sharedFolderGuid}")]
    [Authorize]
    public async Task<ActionResult<bool>> ShareFileToShareFolder(Guid userGuid,[FromBody] byte[] file, Guid sharedFolderGuid)
    {
        var validationErrors = GetValidationErrors(userGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }
        if (userGuid == Guid.Empty)
        {
            return BadRequest("user guid or encrypted file guid was empty, this is not allowed.");
        }

        bool isFileShared = await _encryptedFileRepo.AddFileToSharedFolder(file, sharedFolderGuid );
        if (isFileShared)
        {
            return Ok(isFileShared);
        }
        return BadRequest();
    }

    
    // POST api/EncryptedFile/share
    [HttpGet("GetSharedFolderGuids/{userGuid}")]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Guid>>> GetShareFolderGuids(Guid userGuid, [FromBody] Guid encryptedFileGuid)
    {
        var validationErrors = GetValidationErrors(userGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }
        if (userGuid == Guid.Empty || encryptedFileGuid == Guid.Empty)
        {
            return BadRequest("user guid or encrypted file guid was empty, this is not allowed.");
        }
        var files = await _encryptedFileRepo.GetSharedFolderGuidsAsync(userGuid);
        return Ok(files);
    }
    
    
    [HttpGet("Salt/{Guid}")]
    public async Task<ActionResult<byte[]>> GetSaltAsync(Guid sharedFolderGuid)
    {
        if (sharedFolderGuid == Guid.Empty)
        {
            return BadRequest("shared folder guid cannot be null");
        }

        byte[]? returnedSalt = await _encryptedFileRepo.GetSaltAsync(sharedFolderGuid);
        if (returnedSalt != null && returnedSalt.Length == 16)
        {
            return Ok(returnedSalt);
        }
        return BadRequest();
    }

    // POST api/EncryptedFile/create
    [HttpPost("CreateSharedFolder/{userGuid}/owner/{ownerGuid}")]
    [Authorize]
    public async Task<ActionResult<Guid>> CreateSharedFolderAsync(Guid userGuid, Guid ownerGuid,[FromBody] byte[] shareCode)
    {
        var validationErrors = GetValidationErrors(ownerGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }
        if (userGuid == Guid.Empty || ownerGuid == Guid.Empty) 
        {
            return BadRequest("Could not create a shared folder, user or owner guid is empty");
        }

        Guid? returnedGuid = await _encryptedFileRepo.CreateShareFolderAsync(ownerGuid, userGuid, shareCode);
        if (returnedGuid.HasValue && returnedGuid != Guid.Empty)
        {
            return Ok(returnedGuid);
        }
        return BadRequest();
    }
    
    private ActionResult? GetValidationErrors(Guid ownerGuid, IEnumerable<Claim> claims, IHeaderDictionary headers)
    {
        // Validate the JWT
        var getCookiesResult = headers.TryGetValue("Authorization", out var headerValues);
        var tokenBearer = headerValues.FirstOrDefault();
        var token = tokenBearer.Substring(7);
        if (getCookiesResult == false || _jwtHelper.ValidateToken(token) == false)
        {
            return Unauthorized();
        }
        

        // Validate that user guid is in claims
        var userGuidClaim = claims.FirstOrDefault(c => c.Type == "user_guid");
        if (userGuidClaim == null || !Guid.TryParse(userGuidClaim.Value, out Guid authenticatedUserGuid))
        {
            // The owner GUID is missing or invalid.
            return Unauthorized();
        }

        // Validate if the user guid in claims matches the given guid
        if (ownerGuid != authenticatedUserGuid)
        {
            // The owner GUID doesn't match the claim
            return Forbid();
        }
        
        return null;
    }
}

