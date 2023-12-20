using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IEncryptedFileRepo
{
    Task<IEnumerable<EncryptedFile>> GetUserFilesAsync(Guid ownerGuid);
    Task<IEnumerable<SharedFolder>> GetSharedFilesAsync(Guid userGuid);
    Task<Guid> CreateAsync(EncryptedFile file, Guid userGuid);
    Task<bool> ShareFileAsync(Guid userGuid, EncryptedFile fileGuid, byte[] shareCode);
    Task<byte[]?> GetSharedCodeSaltAsync(Guid sharedFolderGuid);
}
