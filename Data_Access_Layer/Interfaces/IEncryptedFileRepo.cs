using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IEncryptedFileRepo
{
    Task<IEnumerable<EncryptedFile>> GetUserFilesAsync(Guid ownerGuid);
    Task<Guid> CreateAsync(EncryptedFile file, Guid userGuid);

    Task<Guid?> CreateShareFolderAsync(Guid ownerGuid, Guid userGuid, byte[] shareCode);
    Task<IEnumerable<Guid>> GetSharedFolderGuidsAsync(Guid userGuid);
    Task<byte[]> GetSaltAsync(Guid sharedFolderGuid);
    Task<bool> AddFileToSharedFolder(byte[] file, Guid sharedFolderGuid);
    Task<IEnumerable<EncryptedFile>> GetSharedFolderFiles(Guid folderGuid, byte[] shareCode);
}
