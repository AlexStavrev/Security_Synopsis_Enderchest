using Data_Access_Layer.Repository;

namespace Data_Access_Layer.Factories;
public static class ReposFactory
{
    public static T? GetRepository<T>(string connectionString) where T : class
    {
        return typeof(T).Name switch
        {
            "IUserRepo" => new UserRepo(connectionString) as T,
            "IEncryptedFileRepo" => new EncryptedFileRepo(connectionString) as T,
            _ => throw new ArgumentException($"Unknown type {typeof(T).FullName}"),
        };
    }
}
