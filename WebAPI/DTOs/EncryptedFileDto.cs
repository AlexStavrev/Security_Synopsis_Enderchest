namespace WebAPI.DTOs
{
    public class EncryptedFileDto
    {
        public Guid Guid { get; set; }
        public Guid OwnerGuid { get; set; }
        public byte[]? EncryptedFile { get; set; }
    }
}
