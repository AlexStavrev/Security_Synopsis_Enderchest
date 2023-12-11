namespace Web_Client.DTOs;

public sealed record SharedFolderDto
{
    public Guid Guid { get; set; }
    public Guid OwenerGuid { get; set; }
    public byte[]? HashedShareCode { get; set; }
    public IEnumerable<EncryptedFileDto>? EncryptedFiles { get; set; }
    public IEnumerable<DecryptedFileDto>? DecryptedFiles { get; set; }
}
