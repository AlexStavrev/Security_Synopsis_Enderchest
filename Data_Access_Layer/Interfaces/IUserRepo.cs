using Data_Access_Layer.Models;

namespace Data_Access_Layer.Interfaces;
public interface IUserRepo
{
    Task<Guid?> LoginAsync(User user);
    Task<Guid?> CreateAsync(User user);
    Task<byte[]?> GetSaltAsync(string username);
}
