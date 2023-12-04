namespace Security_Synopsis_Enderchest.Models;

public sealed record EncryptedFile
{
    public Guid Guid { get; set; }
    public byte[]? File { get; set; }
}