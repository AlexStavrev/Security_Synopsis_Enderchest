using System.Data;
using System.Data.SqlClient;
using Dapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class UserRepo : IUserRepo
{
    private readonly IDbConnection _connection;

    public UserRepo(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<Guid?> LoginAsync(User user)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();
        parameters.Add("Email", user.Email);
        parameters.Add("Password", user.Password);

        //Execute stored procedure and map the returned result to a Customer object  
        return await _connection.QuerySingleOrDefaultAsync<Guid?>("USER_MASTER_LOGIN", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Guid?> CreateAsync(User user)
    {
        Guid generatedGuid = Guid.NewGuid();

        try
        {
            var saving = Convert.ToBase64String(user.Password!);
            var slat = Convert.ToBase64String(user.Password!.Take(16).ToArray());

            var parameters = new DynamicParameters();
            parameters.Add("Guid", generatedGuid);
            parameters.Add("Email", user.Email);
            parameters.Add("Password", user.Password);

            await _connection.QueryAsync("USER_MASTER_CREATE", parameters, commandType: CommandType.StoredProcedure);

            return generatedGuid;
        }
        catch
        {
            return null;
        }
    }

    public async Task<byte[]?> GetSaltAsync(string email)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();

        parameters.Add("Email", email);

        //Execute stored procedure and map the returned result to a Customer object  
        var returnedPasswordKey = await _connection.QuerySingleOrDefaultAsync<byte[]?>("GET_SALT", parameters, commandType: CommandType.StoredProcedure);
        if (returnedPasswordKey != null)
        {
            var salt = returnedPasswordKey.Take(16).ToArray();
            return salt;
        }
        return null;
    }

    public async Task<Guid?> GetUserIdByEmail(string email)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();

        parameters.Add("Email", email);
        
        //Execute stored procedure and map the returned result to a Customer object  
        var returnedUserId = await _connection.QuerySingleOrDefaultAsync<Guid?>("GET_USERID", parameters, commandType: CommandType.StoredProcedure);

        return returnedUserId;
    }

    public async Task<string?> GetEmailByUserId(Guid userId)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();

        parameters.Add("Guid", userId);

        //Execute stored procedure and map the returned result to a Customer object  
        var returnedUserId = await _connection.QuerySingleOrDefaultAsync<string?>("GET_EMAIL", parameters, commandType: CommandType.StoredProcedure);

        return returnedUserId;
    }
}