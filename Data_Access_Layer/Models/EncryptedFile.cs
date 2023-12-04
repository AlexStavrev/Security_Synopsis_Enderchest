namespace Data_Access_Layer.Models;

public sealed record EncryptedFile
{
    public Guid Guid { get; set; }
    public byte[]? File { get; set; }
}