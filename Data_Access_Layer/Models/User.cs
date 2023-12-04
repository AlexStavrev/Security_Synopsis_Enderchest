namespace Data_Access_Layer.Models;

public sealed record User
{
    public Guid Guid { get; set; }
    public string? Email { get; set; }
    public byte[]? Password { get; set; }
}