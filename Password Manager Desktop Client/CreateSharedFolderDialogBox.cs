using Password_Manager_Desktop_Client.crypto;
using System.Runtime.InteropServices;
using Web_Client;
using Web_Client.DTOs;
namespace Password_Manager_Desktop_Client
{
    public partial class CreateSharedFolderDialogBox : Form
    {
        private Size _formSize;
        private readonly int _borderSize;
        private Guid _userId;
        private readonly FileListPage _parent;
        private readonly IWebClient _client;
        private readonly ICryptoHelper _vaultCryptoHelper;

        public CreateSharedFolderDialogBox(IWebClient client, Guid userId, FileListPage parent, ICryptoHelper vaultCryptoHelper)
        {
            _userId = userId;
            _parent = parent;
            _borderSize = 2;
            _client = client;
            InitializeComponent();
        }

        public async Task ShowError(string text, int delayInMilliseconds = 2000)
        {
            var errorBar = new CustomControls.NotificationLabelBar
            {
                BackColor = Color.IndianRed,
                ButtonColor = Color.Maroon,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Location = new Point(0, 40),
                Margin = new Padding(5, 5, 5, 5),
                Name = "notificationLblBar",
                Size = new Size(884, 0),
                TabIndex = 4,
                Text = text
            };
            panel1.Controls.Add(errorBar);
            errorBar.BringToFront();
            await errorBar.ShowNotificationAsync(delayInMilliseconds);
        }


        public async Task ShowSuccess(string text)
        {
            var sucessBar = new CustomControls.NotificationLabelBar
            {
                BackColor = Color.Green,
                ButtonColor = Color.DarkGreen,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Location = new Point(0, 40),
                Margin = new Padding(5, 5, 5, 5),
                Name = "notificationLblBar",
                Size = new Size(884, 0),
                TabIndex = 4,
                Text = text
            };

            panel1.Controls.Add(sucessBar);
            sucessBar.BringToFront();
            await sucessBar.ShowNotificationAsync(2000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Padding = new(_borderSize);
            titleLbl.Text = this.Text;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }

        private void Close()
        {
            Dispose();
        }

        private void Maximise()
        {
            if (WindowState == FormWindowState.Normal)
            {
                _formSize = ClientSize;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Size = _formSize;
            }
        }

        private void Minimise()
        {
            WindowState = FormWindowState.Minimized;
        }

        private void AdjustForm()
        {
            switch (WindowState)
            {
                case FormWindowState.Maximized:
                    Padding = new Padding(8);
                    break;
                case FormWindowState.Normal:
                    if (Padding.Top != _borderSize)
                    {
                        Padding = new Padding(_borderSize);
                    }
                    break;
                default:
                    break;
            }
        }

        private void closeBtn_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void maximizeBtn_Click_1(object sender, EventArgs e)
        {
            Maximise();
        }

        private void minimizeBtn_Click_1(object sender, EventArgs e)
        {
            Minimise();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var password = passwordBox.Text;
            var email = emailTextBox.Text;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                _ = ShowError("Please fill in all the fields!");
                return;
            }
            try
            {
                var salt = _vaultCryptoHelper.GenerateSalt();
                var passwordKey = MasterPasswrodHelper.DerivePasswordKey(salt, password);

            }catch(Exception ex)
            {
                _ = ShowError("Something went wrong!");
            }
        }
    }
}
