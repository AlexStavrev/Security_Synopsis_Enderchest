using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;
public interface IFileListPage
{
    Form1 GetMainForm();
    string? GetFileName(string file);
}
