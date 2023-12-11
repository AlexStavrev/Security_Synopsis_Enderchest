﻿namespace Web_Client.DTOs;

public sealed record EncryptedFileDto
{
    public Guid Guid { get; set; }
    public byte[]? EncryptedFile { get; set; }
}

public sealed record EncryptedFileDtoNoGuid
{
    //public Guid Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public byte[]? EncryptedFile { get; set; }
}

public sealed record DecryptedFileDto
{
    public Guid Guid { get; set; }
    public string? DecryptedFile { get; set; }
}

public sealed record DecryptedFileDtoNoGuid
{
    //public Guid Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public string? DecryptedFile { get; set; }
}