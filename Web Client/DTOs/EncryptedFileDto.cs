namespace Web_Client.DTOs;

public sealed record EncryptedFileDto
{
    public Guid? Guid { get; set; }
    public byte[]? File { get; set; }
}