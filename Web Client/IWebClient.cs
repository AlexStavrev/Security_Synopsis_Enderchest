using Web_Client.DTOs;

namespace Web_Client;
public interface IWebClient
{
    // User
    Task<Guid?> LoginAsync(UserDto user);
    Task<Guid?> CreateUserAsync(UserDto user);
    Task<byte[]> GetSaltAsync(string username);

    // File
    Task<IEnumerable<EncryptedFileDto>> GetUserFilesAsync(Guid ownerGuid);
    Task<IEnumerable<EncryptedFileDto>> GetSharedFilesAsync(Guid userGuid);
    Task<Guid> CreateFileAsync(EncryptedFileDtoNoGuid file, Guid userGuid);
    Task<bool> ShareFileAsync(Guid userGuid, Guid fileGuid);
}
