using Security_Synopsis_Enderchest.Repository;

namespace Security_Synopsis_Enderchest.Factories;
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
