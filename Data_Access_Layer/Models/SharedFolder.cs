namespace Data_Access_Layer.Models;
public sealed record SharedFolder
{
    public Guid Guid { get; set; }
    public Guid OwnerGuid { get; set; }
    public byte[]? ShareCode { get; set; }
    public IEnumerable<EncryptedFile>? SharedFiles { get; set; }
}
