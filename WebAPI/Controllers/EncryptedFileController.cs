﻿using Data_Access_Layer.Interfaces;
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

        var files = await _encryptedFileRepo.GetAsync(ownerGuid);
        return Ok(DtoConverter<EncryptedFile[], EncryptedFileDto[]>.From(files));
    }

    // GET api/EncryptedFile/getShared/<guid>
    [HttpGet("getShared/{ownerGuid}")]
    [Authorize]
    public async Task<ActionResult<EncryptedFileDto>> GetShared(Guid ownerGuid)
    {
        var validationErrors = GetValidationErrors(ownerGuid, User.Claims, Request.Headers);
        if (validationErrors != null)
        {
            return validationErrors;
        }

        var files = await _encryptedFileRepo.GetAsync(ownerGuid);
        return Ok(DtoConverter<EncryptedFile[], EncryptedFileDto[]>.From(files));
    }

    // PUT api/EncryptedFile/<guid>
    [HttpPut("{ownerGuid}")]
    [Authorize]
    public async Task<IActionResult> Put(Guid ownerGuid, [FromBody] EncryptedFileDto encryptedFileDto)
    {
        if(ownerGuid != encryptedFileDto.OwnerGuid)
        {
            return BadRequest();
        }

        var validationErrors = GetValidationErrors(ownerGuid, User.Claims, Request.Headers);
        if(validationErrors != null)
        {
            return validationErrors;
        }

        var encyptedfile = DtoConverter<EncryptedFile, EncryptedFileDto>(encryptedFileDto);
        var file = new EncryptedFile() {OwnerGuid = encryptedFileDto.OwnerGuid, Encryptedfile = encyptedfile};
        var result = await _encryptedFileRepo.UpdateAsync(ownerGuid, file);

        if(!result)
        {
            // Something went wrong in the DAL and file wasn't updated
            return BadRequest();
        }

        return Ok(result);
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
