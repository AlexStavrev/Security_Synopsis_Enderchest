namespace Web_Client.DTOs;

public sealed record UserDto
{
    public Guid Guid { get; set; }
    public string? Email { get; set; }
    public byte[]? Password { get; set; }
}