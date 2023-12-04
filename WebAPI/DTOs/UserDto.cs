namespace WebAPI.DTOs;

public sealed record UserDto
{
    public Guid Guid { get; set; }
    public string? Username { get; set; }
    public byte[]? Password { get; set; }
}

public sealed record UserDtoNoGuid
{
    //public Guid Guid { get; set; }
    public string? Username { get; set; }
    public byte[]? Password { get; set; }
}