namespace WebAPI.DTOs;

public sealed record EncryptedFileDto
{
    public Guid? Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public byte[]? File { get; set; }
}

public sealed record EncryptedFileDtoNoGuid   
{
    //public Guid Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public byte[]? EncryptedFile { get; set; }
}