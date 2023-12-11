using Password_Manager_Desktop_Client.crypto;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class LogInPage : UserControl
{
    private readonly IWebClient _client;
    private readonly IVaultCrypto _vaultCryptoHelper;
    private readonly Form1 _parent;

    public LogInPage(IWebClient client, IVaultCrypto vaultCryptoHelper, Form1 parent)
    {
        _client = client;
        _vaultCryptoHelper = vaultCryptoHelper;
        InitializeComponent();
        _parent = parent;
    }

    private async Task Login(string password, string username)
    {
        try
        {
            byte[] salt = await _client.GetSaltAsync(username);

            var derivedPassword = MasterPasswrodHelper.DerivePasswordKey(password: password, salt: salt);
            //MessageBox.Show($"Derived passwordkey: {Convert.ToBase64String(derivedPassword)}\nsalt: {Convert.ToBase64String(salt)}");
            var _userDTO = CreateUserDTO(username, derivedPassword);
            var userId = await _client.LoginAsync(_userDTO);
            if (!userId.HasValue)
            {
                _ = _parent.ShowError("Error logging in!");
            }
            else
            {
                var createVaultPage = new CreateVaultPage(_client, _vaultCryptoHelper, userId, username, password, _parent);
                _parent.SetPage(createVaultPage);
                _ = _parent.ShowSuccess("Logged In!");
                Dispose();
            }
        }
        catch
        {
            _ = _parent.ShowError("Something went wrong! Check your connection\n and try again.");
        }
    }

    private async void LogInButton_Clicked(object sender, EventArgs e)
    {
        string password = passwordTextBox.Text;
        string username = usernameTextBox.Text;
        await Login(password, username);
    }



    private UserDto CreateUserDTO(string username, byte[] password)
    {
        return new UserDto() { Username = username, Password = password };
    }

    private async void createAcc_Click(object sender, EventArgs e)
    {
        string password = passwordTextBox.Text;
        string username = usernameTextBox.Text;
        try
        {
            var salt = _vaultCryptoHelper.GenerateSalt();
            var passwordKey = MasterPasswrodHelper.DerivePasswordKey(salt, password);
            //MessageBox.Show($"Register passwordkey: {Convert.ToBase64String(passwordKey)}\nsalt: {Convert.ToBase64String(salt)}");
            var newUser = CreateUserDTO(username, passwordKey);
            var userId = await _client.CreateUserAsync(newUser);
            if (!userId.HasValue)
            {
                _ = _parent.ShowError("Error logging in!");
            }
            else
            {
                await Login(password, username);
                _ = _parent.ShowSuccess("User Created!");
            }
        }
        catch
        {
            _ = _parent.ShowError("Something went wrong! Check your connection\n and try again.");
        }
    }
}
