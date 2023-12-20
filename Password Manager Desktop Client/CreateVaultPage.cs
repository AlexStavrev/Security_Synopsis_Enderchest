using Password_Manager_Desktop_Client.crypto;
using System.Net;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class CreateVaultPage : UserControl
{
    private string _email;
    private string _password;
    private IWebClient _client;
    private Guid _userId;
    private List<EncryptedFileDto?> _encryptedFiles;
    private List<DecryptedFileDto?> _decryptedFiles;

    private IVaultCrypto _vaultCryptoService;
    private Form1 _parent;

    public CreateVaultPage(IWebClient client, IVaultCrypto vaultCryptoService, Guid userId, string username, string password, Form1 parent)
    {
        _client = client;
        _userId = userId;
        _email = username;
        _password = password;
        _vaultCryptoService = vaultCryptoService;
        _parent = parent;
        InitializeComponent();
        listView1.View = View.Details;
        listView1.Columns.Add("Files");

        listView1.Columns[0].Width = 130; 
        listView1.Columns[1].Width = 130; 
        listView1.Columns[2].Width = 130; 
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        try
        {
            var newEncryptedFiles = await _client.GetUserFilesAsync(_userId);
            foreach(var file in newEncryptedFiles) {
                var newDecryptedFile = _vaultCryptoService.DecryptSingleFile(file, _email, _password);
                _decryptedFiles.Add(newDecryptedFile);
                UpdateListView(newDecryptedFile);
            }

        }catch(Exception ex)
        {
            _ = _parent.ShowError($"Unable to retrieve the vault: {ex}", 5000);
        }
        
    }

    private async void AddNewFile_ClickAsync(object sender, EventArgs e)
    {
        var fileText = "";
        int size = -1;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        if (result == DialogResult.OK) // Test result.
        {
            string file = openFileDialog1.FileName;
            try
            {
                fileText = File.ReadAllText(file);
                size = fileText.Length;
            }
            catch (IOException)
            {
            }

            DecryptedFileDto decryptedFileDto = new DecryptedFileDto
            {
                OwnerGuid = _userId,
                File = fileText
            };

            var encryptedFile = _vaultCryptoService.EncryptSingleFile(decryptedFileDto, _email, _password);
            try
            {
                var response = await _client.CreateFileAsync(encryptedFile, _userId);
                DecryptedFileDto newDecryptedFile = new DecryptedFileDto { OwnerGuid = _userId, File = fileText, Guid = response };
                UpdateListView(newDecryptedFile);
                _ = _parent.ShowSuccess("File created!");
            }
            catch(Exception ex) 
            { _ = _parent.ShowError("Unable to upload the file!"); }
        }
    }


    private void UpdateListView(DecryptedFileDto decryptedFileDto)
    {
         ListViewItem item = new ListViewItem(decryptedFileDto.Guid.ToString());
         item.SubItems.Add(decryptedFileDto.Guid.ToString());
         
         listView1.Items.Add(item);
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
        foreach (var file in _decryptedFiles) {
            if (file != null) { UpdateListView(file); }
        }
  
    }

    private async void LogOut_Button_Click(object sender, EventArgs e)
    {
        _parent.SetPage(new LogInPage(_client, _vaultCryptoService, _parent));
        //TODO encrypt and sync the vault
        Dispose();
    }

    private async void Encrypt_Click(object sender, EventArgs e)
    {
        //TODO change this 
        foreach (var file in _decryptedFiles)
        {
            var encryptedFile= _vaultCryptoService.EncryptSingleFile(file, _email, _password);
            _encryptedFiles.Add(encryptedFile);
        }
        
    }
    //TODO DELETE
    private void Decrypt_Click(object sender, EventArgs e)
    {
        ClearListView();
        InitListView();
    }
}
