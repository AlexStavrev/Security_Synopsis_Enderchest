using Web_Client.DTOs;

namespace Web_Client;
public interface IWebClient
{
    // User
    Task<Guid?> LoginAsync(UserDto user);
    Task<Guid?> CreateUserAsync(UserDto user);
    Task<byte[]> GetSaltAsync(string username);
    Task<Guid> GetUserIdByEmailAsync(string email);

    // File
    Task<IEnumerable<EncryptedFileDto>> GetUserFilesAsync(Guid ownerGuid);
    Task<byte[]> GetFolderSaltAsync(Guid folderId);
    Task<IEnumerable<Guid>> GetSharedFoldersAsync(Guid userGuid);
    Task<Guid> CreateFileAsync(EncryptedFileDto file, Guid userGuid);
    Task<bool> ShareFileAsync(Guid userGuid, Guid fileGuid);
    Task<Guid> CreateSharedFolderAsync(Guid userGuid, Guid ownerGuid, byte[] shareCode);
    Task<IEnumerable<EncryptedFileDto>> GetSharedFolderAsync(Guid userGuid, Guid folderGuid, byte[] shareCode);
}
