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
        parameters.Add("UserGuid", ownerGuid);

        return await _connection.QueryAsync<EncryptedFile>("GET_USER_FILES", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Guid> CreateAsync(EncryptedFile file, Guid userGuid)
    {
        Guid generatedGuid = Guid.NewGuid();
        file.Guid = generatedGuid;

        var parameters = new DynamicParameters();
        parameters.Add("FileGuid", file.Guid);
        parameters.Add("File", file.File);
        parameters.Add("UserGuid", userGuid);

        return await _connection.QuerySingleOrDefaultAsync<Guid>("CREATE_FILE", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<Guid?> CreateShareFolderAsync(Guid ownerGuid, Guid userGuid, byte[] shareCode)
    {
        Guid newFolderGuid = Guid.NewGuid();

        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("ShareFolderGuid", newFolderGuid);
            parameters.Add("OwnerGuid", ownerGuid);
            parameters.Add("ShareCode", shareCode);
            parameters.Add("UserGuid", userGuid);

            await _connection.QueryAsync("CREATE_SHARE_FOLDER", parameters, commandType: CommandType.StoredProcedure);

            return newFolderGuid;
        }
        catch
        {
            return null;
        }
    }

    public async Task<IEnumerable<Guid>> GetSharedFolderGuidsAsync(Guid userGuid)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserGuid", userGuid);

        return await _connection.QueryAsync<Guid>("GET_SHARED_FOLDER_GUIDS", parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<byte[]> GetSaltAsync(Guid sharedFolderGuid)
    {
        //Set up DynamicParameters object to pass parameters  
        var parameters = new DynamicParameters();

        parameters.Add("ShareFolderGuid", sharedFolderGuid);

        //Execute stored procedure and map the returned result to a Customer object  
        var returnedPasswordKey = await _connection.QuerySingleOrDefaultAsync<byte[]>("GET_SALT_SHARED_FOLDER", parameters, commandType: CommandType.StoredProcedure);
        if (returnedPasswordKey != null)
        {
            var salt = returnedPasswordKey.Take(16).ToArray();
            return salt;
        }
        return new byte[0];
    }

    public async Task<bool> AddFileToSharedFolder(byte[] file, Guid sharedFolderGuid)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("EncryptedFile", file);
            parameters.Add("FolderGuid", sharedFolderGuid);

            await _connection.QueryAsync("ADD_FILE_TO_SHARED_FOLDER", parameters, commandType: CommandType.StoredProcedure);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<EncryptedFile>> GetSharedFolderFiles(Guid folderGuid, byte[] shareCode)
    {
        var parameters = new DynamicParameters();
        parameters.Add("FolderGuid", folderGuid);
        parameters.Add("ShareCode", shareCode);

        return await _connection.QueryAsync<EncryptedFile>("GET_SHARED_FOLDER", parameters, commandType: CommandType.StoredProcedure);
    }
}
}