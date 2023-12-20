namespace Web_Client.DTOs;

public sealed record EncryptedFileDto
{
    public Guid? Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public byte[]? EncryptedFile { get; set; }
}