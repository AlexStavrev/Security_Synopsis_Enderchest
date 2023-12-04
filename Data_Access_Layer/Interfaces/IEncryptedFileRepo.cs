using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IEncryptedFileRepo
{
    Task<IEnumerable<EncryptedFile>> GetUserFilesAsync(Guid ownerGuid);
    Task<IEnumerable<EncryptedFile>> GetSharedFilesAsync(Guid userGuid);
    Task<Guid> CreateAsync(EncryptedFile file, User user);
    Task<bool> ShareFileAsync(Guid userGuid, Guid fileGuid);
}
