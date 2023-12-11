using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client
{
    public partial class AddCredentials : UserControl
    {
        private readonly CreateVaultPage _parentUserControl;
        private readonly Form1 _parent;

        public AddCredentials(CreateVaultPage parentUserControl, Form1 parent)
        {
            _parentUserControl = parentUserControl;
            _parent = parent;
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            var credentialDto = CreateCredentialDto();

            _parentUserControl.AddCredentialsToDto(credentialDto);

            ClearFields();

            _= _parent.ShowSuccess("Successfully added the credentials!");
        }

        private void close_Click(object sender, EventArgs e)
        {
            _parent.SetPage(_parentUserControl);
            Dispose();
        }

        private DecryptedCredentialsDto CreateCredentialDto()
        {
            var credentials = new DecryptedCredentialsDto()
            {
                Sitename = siteName.Text,
                Username = userName.Text,
                Password = password.Text
            };

            return credentials;
        }

        private void ClearFields()
        {
            siteName.Text = "";
            userName.Text = "";
            password.Text = "";
        }
    }
}
