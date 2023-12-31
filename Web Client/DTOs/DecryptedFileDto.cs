﻿namespace Web_Client.DTOs;

public sealed record DecryptedFileDto
{
    public Guid? Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public string? EncryptedFile { get; set; }
}