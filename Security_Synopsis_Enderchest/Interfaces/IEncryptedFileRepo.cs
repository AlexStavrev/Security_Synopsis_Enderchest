using Security_Synopsis_Enderchest.Models;

namespace Security_Synopsis_Enderchest.Interfaces;
public interface IEncryptedFileRepo
{
    Task<IEnumerable<EncryptedFile>> GetUserFilesAsync(Guid ownerGuid);
    Task<IEnumerable<EncryptedFile>> GetSharedFilesAsync(Guid userGuid);
    Task<Guid> CreateAsync(EncryptedFile file, User user);
    Task<bool> ShareFileAsync(Guid userGuid, Guid fileGuid);
}
