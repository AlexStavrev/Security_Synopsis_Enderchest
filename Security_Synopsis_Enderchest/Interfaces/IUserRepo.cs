using Security_Synopsis_Enderchest.Models;

namespace Security_Synopsis_Enderchest.Interfaces;
public interface IUserRepo
{
    Task<Guid?> LoginAsync(User user);
    Task<Guid?> CreateAsync(User user);
    Task<byte[]?> GetSaltAsync(string username);
}
