using Password_Manager_Desktop_Client.crypto;
using System.Windows.Forms;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class OpenedFolderListPage : UserControl, IFileListPage
{
    private string _shareCode;
    private Guid _folderGuid;
    private IWebClient _client;
    private List<DecryptedFileDto?> _folderFiles;
    private SharedFolderDto _sharedFolder;
    private FileListPage _backPage;
    private ICryptoHelper _vaultCryptoService;
    private Form1 _parent;

    public OpenedFolderListPage(IWebClient client, ICryptoHelper vaultCryptoService, Form1 parent, FileListPage backPage, string shareCode, Guid folderGuid, SharedFolderDto sharedFolder)
    {
        _shareCode = shareCode;
        _folderGuid = folderGuid;
        _backPage = backPage;
        _client = client;
        _vaultCryptoService = vaultCryptoService;
        _parent = parent;
        _sharedFolder = sharedFolder;
        InitializeComponent();
        listView1.Columns.Add("Id");
        listView1.Columns.Add("Name");
        imageList.Images.Add("fileIcon", Properties.Resources.fileIcon);
        listView1.SmallImageList = imageList;
        _folderFiles = new List<DecryptedFileDto?> { };

        listView1.Columns[0].Width = 100;
        listView1.Columns[1].Width = 1080;
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        try
        {
            DecryptFiles();
            UpdateListView();
        }
        catch
        {
            _ = _parent.ShowError("Error getting and decrypting files");
        }
    }

    private async void DecryptFiles()
    {
        var userEmail = await _client.GetEmailByUserIdAsync(_sharedFolder.OwenerGuid);
        var decryptedFolder = _vaultCryptoService.DecryptSharedFolder(_sharedFolder, userEmail, _shareCode);
        _sharedFolder = decryptedFolder;
    }

    private void UpdateListView()
    {
        foreach (var decryptedFileDto in _sharedFolder.DecryptedFiles)
        {
            ListViewItem item = new ListViewItem(decryptedFileDto.Guid.ToString());
            item.SubItems.Add(GetFileName(decryptedFileDto.EncryptedFile));
            // Set item image to icon from resources
            item.ImageIndex = 0;
            listView1.Items.Add(item);
        }
    }

    private void ClearListView()
    {
        listView1.Items.Clear();
    }

    private async void Back_Button_Click(object sender, EventArgs e)
    {
        _parent.SetPage(_backPage);
        Dispose();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            var selectedGuid = listView1.SelectedItems[0].Text;
            var file = _folderFiles.FirstOrDefault(file => file.Guid.ToString() == selectedGuid);
            if (file != null)
            {
                using var fileViewDialogBox = new FileViewDialogBox(file, _client, this);
                fileViewDialogBox.ShowDialog();
            }
        }
    }

    public Form1 GetMainForm()
    {
        return _parent;
    }

    public string? GetFileName(string fileText)
    {
        using var reader = new StringReader(fileText);
        // Read the first line from the StringReader
        string firstLine = reader.ReadLine();

        return firstLine;
    }
}
