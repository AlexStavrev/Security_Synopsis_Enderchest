using Password_Manager_Desktop_Client.crypto;
using System.Windows.Forms;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class FileListPage : UserControl
{
    private string _email;
    private string _password;
    private IWebClient _client;
    private Guid _userId;
    private List<EncryptedFileDto?> _encryptedFiles;
    private List<DecryptedFileDto?> _decryptedFiles;
    private List<Guid> _sharedFolders;

    private ICryptoHelper _vaultCryptoService;
    private Form1 _parent;

    public FileListPage(IWebClient client, ICryptoHelper vaultCryptoService, Guid userId, string username, string password, Form1 parent)
    {
        _client = client;
        _userId = userId;
        _email = username;
        _password = password;
        _vaultCryptoService = vaultCryptoService;
        _parent = parent;
        InitializeComponent();
        listView1.Columns.Add("Id");
        listView1.Columns.Add("Name");
        listView2.Columns.Add("Id");
        imageList.Images.Add("fileIcon", Properties.Resources.fileIcon);
        listView1.SmallImageList = imageList;
        _decryptedFiles = new List<DecryptedFileDto?> { };
        _encryptedFiles = new List<EncryptedFileDto?> { };
        _sharedFolders = new List<Guid> { };

        listView1.Columns[0].Width = 100;
        listView1.Columns[1].Width = 1080;
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        try
        {
            var newEncryptedFiles = await _client.GetUserFilesAsync(_userId);
            foreach (var file in newEncryptedFiles)
            {
                var newDecryptedFile = _vaultCryptoService.DecryptSingleFile(file, _email, _password);
                UpdateListView(newDecryptedFile);
            }
            try
            {
                var newSharedFolders = await _client.GetSharedFoldersAsync(_userId);
                foreach (var folder in newSharedFolders)
                {
                    UpdateListView2(folder);
                }
            }
            catch(Exception ex)
            {
                _ = _parent.ShowError($"Unable to retrieve shared folders: {ex}", 5000);
            }
        }
        catch (Exception ex)
        {
            _ = _parent.ShowError($"Unable to retrieve files: {ex}", 5000);
        }

    }

    private async void AddNewFile_ClickAsync(object sender, EventArgs e)
    {
        var fileText = "";
        int size = -1;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.DefaultExt = ".txt";
        openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            string file = openFileDialog1.FileName;
            string fileName = Path.GetFileName(file);
            try
            {
                fileText = $"{fileName}{Environment.NewLine}{File.ReadAllText(file)}";
                size = fileText.Length;
            }
            catch (IOException ex)
            {
                await _parent.ShowError("Unable to read the file!");
            }

            var decryptedFileDto = new DecryptedFileDto
            {
                OwnerGuid = _userId,
                EncryptedFile = fileText
            };

            var encryptedFile = _vaultCryptoService.EncryptSingleFile(decryptedFileDto, _email, _password);
            try
            {
                var response = await _client.CreateFileAsync(encryptedFile, _userId);
                DecryptedFileDto newDecryptedFile = new DecryptedFileDto { OwnerGuid = _userId, EncryptedFile = fileText, Guid = response };
                UpdateListView(newDecryptedFile);
                _ = _parent.ShowSuccess("File created!");
            }
            catch (Exception ex)
            { _ = _parent.ShowError("Unable to upload the file!"); }
        }
    }


    private void UpdateListView(DecryptedFileDto decryptedFileDto)
    {
        _decryptedFiles.Add(decryptedFileDto);
        ListViewItem item = new ListViewItem(decryptedFileDto.Guid.ToString());
        item.SubItems.Add(GetFileName(decryptedFileDto.EncryptedFile));
        // Set item image to icon from resources
        item.ImageIndex = 0;
        listView1.Items.Add(item);
    }

    private void UpdateListView2(Guid sharedFolder)
    {
        _sharedFolders.Add(sharedFolder);
        ListViewItem item = new ListViewItem(sharedFolder.ToString());
        listView2.Items.Add(item);
    }

    private void HideItems()
    {
        foreach (ListViewItem item in listView1.Items)
        {
            item.Text = new string('*', 7);
            item.SubItems[1].Text = new string('*', 7);
            item.SubItems[2].Text = new string('*', 7);
        }
    }

    private void ClearListView()
    {
        listView1.Items.Clear();
    }

    private void InitListView()
    {
        foreach (var file in _decryptedFiles)
        {
            if (file != null) { UpdateListView(file); }
        }

    }

    private async void LogOut_Button_Click(object sender, EventArgs e)
    {
        _parent.SetPage(new LogInPage(_client, _vaultCryptoService, _parent));
        //TODO encrypt and sync the vault
        Dispose();
    }

    private async void CreateSharedFolder_Click(object sender, EventArgs e)
    {
        using var fileViewDialogBox = new CreateSharedFolderDialogBox(_client, _userId, this, _vaultCryptoService);
        fileViewDialogBox.ShowDialog();
    }
    //TODO DELETE
    private void Decrypt_Click(object sender, EventArgs e)
    {
        ClearListView();
        InitListView();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count > 0)
        {
            var selectedGuid = listView1.SelectedItems[0].Text;
            var file = _decryptedFiles.FirstOrDefault(file => file.Guid.ToString() == selectedGuid);
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

    private string? GetFileName(string fileText)
    {
        using var reader = new StringReader(fileText);
        // Read the first line from the StringReader
        string firstLine = reader.ReadLine();

        return firstLine;
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void listView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TODO Open password dialog box and open folder
    }
}
