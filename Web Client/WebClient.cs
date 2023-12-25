using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;
using Web_Client.DTOs;

namespace Web_Client;
internal class WebClient : IWebClient
{
    private readonly IRestClient _client;
    private string _jwt;

    public WebClient(IRestClient client)
    {
        _client = client;
    }

    //public async Task<EncryptedFileDto?> GetAsync(Guid? ownerGuid)
    //{
    //    var response = await _client.RequestAsync<EncryptedFileDto?>(Method.Get, $"PasswordVault/{ownerGuid}", jwt: _jwt);

    //    if (!response.IsSuccessful) throw new Exception($"Error retreiving password vault");

    //    return response.Data!;
    //}

    public async Task<Guid?> LoginAsync(UserDto user)
    {
        user.Guid = Guid.Empty;
        var response = await _client.RequestAsync<Guid?>(Method.Post, $"Login/Login", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error logging in");

        if (response.Cookies.Count == 1)
        {
            _jwt = response.Cookies[0].Value;
        }
        return response.Data!;
    }

    public async Task<Guid?> CreateUserAsync(UserDto user)
    {
        var response = await _client.RequestAsync<Guid>(Method.Post, $"Login/Create", body: user);

        if (!response.IsSuccessful) throw new Exception($"Error creating a user in");

        return response.Data!;
    }

    //public async Task<bool> UpdateAsync(Guid? ownerGuid, EncryptedFileDto vault)
    //{
    //    if(_jwt == null)
    //    {
    //        throw new Exception("You need to be authentificated to call this endpoint!");
    //    }
    //    var response = await _client.RequestAsync<bool>(Method.Put, $"PasswordVault/{ownerGuid}", body: vault, jwt: _jwt);

    //    if (!response.IsSuccessful) throw new Exception($"Error updating password vault: {response}");

    //    return response.Data!;
    //}

    public async Task<byte[]> GetSaltAsync(string username)
    {
        var response = await _client.RequestAsync<byte[]>(Method.Get, $"Login/Salt/{username}");

        if (!response.IsSuccessful) throw new Exception($"Error getting salt for {username}");

        return response.Data!;
    }

    public async Task<IEnumerable<EncryptedFileDto>> GetUserFilesAsync(Guid ownerGuid)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<IEnumerable<EncryptedFileDto>>(Method.Get, $"EncryptedFile/{ownerGuid}", jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user files.");
        return response.Data!;
    }

    public async Task<byte[]> GetFolderSaltAsync(Guid folderId)
    {
        var response = await _client.RequestAsync<byte[]>(Method.Get, $"EncryptedFile/Salt/{folderId}");

        if (!response.IsSuccessful) throw new Exception($"Error getting salt for {folderId}");

        return response.Data!;
    }

    public async Task<IEnumerable<Guid>> GetSharedFoldersAsync(Guid userGuid)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<IEnumerable<Guid>>(Method.Get, $"EncryptedFile/GetSharedFolderGuids/{userGuid}", jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        return response.Data!;
    }

    public async Task<Guid> CreateFileAsync(EncryptedFileDto file, Guid userGuid)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }

        var response = await _client.RequestAsync<Guid>(Method.Post, $"EncryptedFile/create/{userGuid}", file, jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        return response.Data!;
    }

    public async Task<bool> ShareFileAsync(Guid userGuid, Guid fileGuid)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<bool>(Method.Post, $"EncryptedFile/share/{userGuid}", fileGuid, jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        return response.Data!;
    }

    public async Task<Guid> CreateSharedFolderAsync(Guid userGuid, Guid ownerGuid, byte[] shareCode, IEnumerable<DecryptedFileDto> files)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<Guid>(Method.Post, $"EncryptedFile/CreateSharedFolder/{userGuid}/owner/{ownerGuid}", shareCode, jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        var createdGuid = response.Data!;

        // TODO: Change this to a single request
        foreach(var file in files)
        {
            await _client.RequestAsync<bool>(Method.Post, $"EncryptedFile/AddFileToSharedFolder/{createdGuid}", file, jwt: _jwt);
        }

        return createdGuid;
    }

    public async Task<SharedFolderDto> GetSharedFolderAsync(Guid userGuid, Guid folderGuid, byte[] shareCode)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<IEnumerable<EncryptedFileDto>>(Method.Get, $"EncryptedFile/GetShared/{userGuid}/folder/{folderGuid}", shareCode, jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        var sharedFolder = new SharedFolderDto
        {
            EncryptedFiles = response.Data!,
            Guid = folderGuid,
            OwenerGuid = response.Data!.FirstOrDefault().OwnerGuid,
        };
        return sharedFolder;
    }

    public async Task<Guid> GetUserIdByEmailAsync(string email)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<Guid>(Method.Get, $"Login/getUserIdByEmail/{email}", jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        return response.Data!;
    }

    public async Task<string> GetEmailByUserIdAsync(Guid userId)
    {
        if (_jwt == null)
        {
            throw new Exception("You need to be authentificated to call this endpoint!");
        }
        var response = await _client.RequestAsync<string>(Method.Get, $"Login/getEmailByUserId/{userId}", jwt: _jwt);
        if (!response.IsSuccessful) throw new Exception($"Error retreiving user shared files.");
        return response.Data!;
    }
}


public static class RestExtentions
{
    public static async Task<RestResponse<T>> RequestAsync<T>(this IRestClient client, Method method, string? resource = null, object? body = null, string? jwt = null)
    {
        var request = new RestRequest(resource, method);
        if (jwt != null)
        {
            request.AddHeader("Authorization", $"Bearer {jwt}");
        }
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync<T>(request, method);
    }

    public static async Task<RestResponse> RequestAsync(this IRestClient client, Method method, string? resource = null, object? body = null, string? jwt = null)
    {
        var request = new RestRequest(resource, method);
        if (jwt != null)
        {
            request.AddHeader("Authorization", $"Bearer {jwt}");
        }
        if (body != null)
        {
            request.AddJsonBody(JsonSerializer.Serialize(body));
        }
        return await client.ExecuteAsync(request, method);
    }
}