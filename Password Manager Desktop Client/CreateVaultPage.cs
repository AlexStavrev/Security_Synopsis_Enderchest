using Password_Manager_Desktop_Client.crypto;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class CreateVaultPage : UserControl
{
    private string _username;
    private string _password;
    private IWebClient _client;
    private Guid? _userId;
    private PasswordVaultDto? _vault;
    private List<DecryptedCredentialsDto> _decryptedCredentials = new();
    private PasswordVaultDto? Vault
    {
        get 
        {
            if (_vault.DecryptedVault == null)
            {
                _vault.DecryptedVault = new List<DecryptedCredentialsDto>();
            }
            return _vault;
        }
        set
        {
            _vault = value;
            if (_vault.DecryptedVault == null)
            {
                _vault.DecryptedVault = new List<DecryptedCredentialsDto>();
            }
        }
    }
    private IVaultCrypto _vaultCryptoService;
    private Form1 _parent;

    public CreateVaultPage(IWebClient client, IVaultCrypto vaultCryptoService, Guid? userId, string username, string password, Form1 parent)
    {
        _client = client;
        _userId = userId;
        _username = username;
        _password = password;
        _vaultCryptoService = vaultCryptoService;
        _parent = parent;
        InitializeComponent();
        listView1.View = View.Details;
        listView1.Columns.Add("Sitename");
        listView1.Columns.Add("Username");
        listView1.Columns.Add("Password");

        listView1.Columns[0].Width = 130; 
        listView1.Columns[1].Width = 130; 
        listView1.Columns[2].Width = 130; 
    }

    private async void CreateVaultPage_Load(object sender, EventArgs e)
    {
        try
        {
            var newVault = await _client.GetAsync(_userId);
            var decrypted = _vaultCryptoService.DecryptVault(newVault, _username, _password);
            _decryptedCredentials = decrypted.DecryptedVault.ToList();
            foreach (var credential in _decryptedCredentials)
            {
                UpdateListView(credential);
            }
            Vault = decrypted;
        }catch(Exception ex)
        {
            _ = _parent.ShowError($"Unable to retrieve the vault: {ex}", 5000);
        }
        
    }

    private void AddNewPassword_Click(object sender, EventArgs e)
    {
        var addCredentialsPage = new AddCredentials(parentUserControl: this, _parent);
        _parent.SetPage(addCredentialsPage);
    }

    public void AddCredentialsToDto(DecryptedCredentialsDto credentials)
    {
        _decryptedCredentials.Add(credentials);
        UpdateListView(credentials);
    }

    private void UpdateListView(DecryptedCredentialsDto credentialsDto)
    {
         ListViewItem item = new ListViewItem(credentialsDto.Sitename);
         item.SubItems.Add(credentialsDto.Username);
         item.SubItems.Add(credentialsDto.Password);
         
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
        foreach(var credential in Vault.DecryptedVault)
        {
            ListViewItem item = new ListViewItem(credential.Sitename);
            item.SubItems.Add(credential.Username);
            item.SubItems.Add(credential.Password);

            listView1.Items.Add(item);
        }
        
    }

    private async void LogOut_Button_Click(object sender, EventArgs e)
    {
        await _client.UpdateAsync(_userId, Vault);
        _parent.SetPage(new LogInPage(_client, _vaultCryptoService, _parent));
        //TODO encrypt and sync the vault
        Dispose();
    }

    private async void Encrypt_Click(object sender, EventArgs e)
    {
        PasswordVaultDto vault = new PasswordVaultDto()
        {
            //TODO change after api and db works
            OwnerGuid = _userId,
            EncryptedVault = new List<HashedCredentialsDto>(),
            DecryptedVault = _decryptedCredentials
    };

        var encrypted = _vaultCryptoService.EncryptVault(vault, _username, _password);
        Vault = encrypted;
        var updateVault = await _client.UpdateAsync(_userId, Vault);
        if (updateVault)
        {
            _ = _parent.ShowSuccess("Succesfully encrypted and synced vault!");
            try
            {
                var newVault = await _client.GetAsync(_userId);
                Vault = newVault;
            }
            catch (Exception ex)
            {
                _ = _parent.ShowError($"Error while refreshing the vault: {ex}");
            }
            
            
        }
        else
        {
            _ = _parent.ShowError("Error while saving encrypted vault!");
        }
        HideItems();
    }

    private void Decrypt_Click(object sender, EventArgs e)
    {
        try 
        {
            if(Vault.DecryptedVault == null)
            {
                Vault.DecryptedVault = new List<DecryptedCredentialsDto>();
            }
            var decrypted = _vaultCryptoService.DecryptVault(Vault, _username, _password);
            _decryptedCredentials = decrypted.DecryptedVault.ToList();
            Vault = decrypted;
        } catch
        { 
            _ = _parent.ShowError("Issue durring decryption!");
        }
        
        
        ClearListView();
        InitListView();
    }
}
