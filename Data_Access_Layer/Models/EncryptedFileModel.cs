namespace Data_Access_Layer.Models;

public sealed record EncryptedFileModel
{
    public Guid Guid { get; set; }
    public byte[]? EncryptedFile { get; set; }
}