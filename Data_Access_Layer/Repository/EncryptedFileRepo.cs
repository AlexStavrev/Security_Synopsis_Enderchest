using System.Data;
using System.Data.SqlClient;
using Dapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repository;

internal class EncryptedFileRepo : IEncryptedFileRepo
{
    private readonly IDbConnection _connection;

    public EncryptedFileRepo(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
    }

    public async Task<IEnumerable<EncryptedFile>> GetUserFilesAsync(Guid ownerGuid)
    {
        var parameters = new DynamicParameters();
        parameters.Add("OwnerGuid", ownerGuid);

        return await _connection.QueryAsync<EncryptedFile>("GET_USER_FILES", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<SharedFolder>> GetSharedFilesAsync(Guid userGuid)
    {
        /*var parameters = new DynamicParameters();
        parameters.Add("UserGuid", userGuid);

        return await _connection.QueryAsync<EncryptedFile>("GET_SHARED_FILES", parameters, commandType: CommandType.StoredProcedure);
    */
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateAsync(EncryptedFile file, Guid userGuid)
    {
        Guid generatedGuid = Guid.NewGuid();
        file.Guid = generatedGuid;

        var parameters = new DynamicParameters();
        parameters.Add("FileGuid", file.Guid);
        parameters.Add("File", file.File);
        parameters.Add("OwnerGuid", userGuid);

        return await _connection.QuerySingleOrDefaultAsync<Guid>("CREATE_FILE", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> ShareFileAsync(Guid userGuid, EncryptedFile fileGuid, byte[] shareCode)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserGuid", userGuid);
        parameters.Add("FileGuid", fileGuid);

        var result = await _connection.ExecuteAsync("SHARE_FILE", parameters, commandType: CommandType.StoredProcedure);
        return result > 0;
    }

    public async Task<byte[]> GetSharedCodeSaltAsync(Guid sharedFolderGuid)
    {
        throw new NotImplementedException();
    }
}