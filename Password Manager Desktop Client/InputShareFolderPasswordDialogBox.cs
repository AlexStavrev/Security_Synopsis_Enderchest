using Password_Manager_Desktop_Client.crypto;
using System.Runtime.InteropServices;
using Web_Client;
using Web_Client.DTOs;

namespace Password_Manager_Desktop_Client;

public partial class InputShareFolderPasswordDialogBox : Form
{
    private Size _formSize;
    public IEnumerable<EncryptedFileDto> ResultFiles { get; set; }
    public byte[] ResultShareCode { get; set; }
    private readonly IWebClient _client;
    private Guid _folderId;
    private Guid _userId;
    private FileListPage _parent;

    private readonly int _borderSize;

    public InputShareFolderPasswordDialogBox(IWebClient client, Guid folderId, Guid userId, FileListPage parent)
    {
        ResultFiles = Enumerable.Empty<EncryptedFileDto>();
        ResultShareCode = new byte[] { };
        _borderSize = 2;
        _folderId = folderId;
        _client = client;
        _userId = userId;
        _parent = parent;
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
        this.DialogResult = DialogResult.Cancel;
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

    #region Control Events
    private void TitleBar_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
    private void OnForm_Resize(object sender, EventArgs e) => AdjustForm();
    private void btnExit_Click(object sender, EventArgs e) => Close();
    private void btnMaximise_Click(object sender, EventArgs e) => Maximise();
    private void btnMinimise_Click(object sender, EventArgs e) => Minimise();
    #endregion

    #region Dll Imports
    // Move form by dragging the title bar
    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();
    #endregion

    #region Overrides
    // AeroSnap & Resize
    protected override void WndProc(ref Message m)
    {
        const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
        const int SC_RESTORE = 0xF120; //Restore form (Before)
        const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
        const int resizeAreaSize = 10;
        #region Form Resize
        // Resize/WM_NCHITTEST values
        const int HTCLIENT = 1; //Represents the client area of the window
        const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
        const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
        const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
        const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
        const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
        const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
        const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
        const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
        ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
        if (m.Msg == WM_NCHITTEST)
        { //If the windows m is WM_NCHITTEST
            base.WndProc(ref m);
            if (WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
            {
                if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                {
                    Point screenPoint = new(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                    Point clientPoint = PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                    if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                    {
                        if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                            m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                        else if (clientPoint.X < (Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                            m.Result = (IntPtr)HTTOP; //Resize vertically up
                        else //Resize diagonally to the right
                            m.Result = (IntPtr)HTTOPRIGHT;
                    }
                    else if (clientPoint.Y <= (Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                    {
                        if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                            m.Result = (IntPtr)HTLEFT;
                        else if (clientPoint.X > (Width - resizeAreaSize))//Resize horizontally to the right
                            m.Result = (IntPtr)HTRIGHT;
                    }
                    else
                    {
                        if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else if (clientPoint.X < (Size.Width - resizeAreaSize)) //Resize vertically down
                            m.Result = (IntPtr)HTBOTTOM;
                        else //Resize diagonally to the right
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                    }
                }
            }
            return;
        }
        #endregion
        //Remove border and keep snap window
        if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
        {
            return;
        }
        //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
        if (m.Msg == WM_SYSCOMMAND)
        {
            /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
            /// Quote:
            /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
            /// are used internally by the system.To obtain the correct result when testing 
            /// the value of wParam, an application must combine the value 0xFFF0 with the 
            /// wParam value by using the bitwise AND operator.
            int wParam = (m.WParam.ToInt32() & 0xFFF0);
            if (wParam == SC_MINIMIZE)  //Before
                _formSize = ClientSize;
            if (wParam == SC_RESTORE)// Restored form(Before)
                Size = _formSize;
        }
        base.WndProc(ref m);
    }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            {
                cp.Style |= 0x20000 | 0x80000 | 0x40000; //WS_MINIMIZEBOX | WS_SYSMENU | WS_SIZEBOX;
            }
            cp.ClassStyle |= 0x20000;
            return cp;
        }
    }
    #endregion

    private void closeBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void maximizeBtn_Click(object sender, EventArgs e)
    {
        Maximise();
    }

    private void minimizeBtn_Click(object sender, EventArgs e)
    {
        Minimise();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        if(ResultShareCode != null && ResultFiles != null)
        {
            var password = passwordTextBox.Text;
            try
            {
                var salt = await _client.GetFolderSaltAsync(_folderId);
                var derivedPassword = MasterPasswrodHelper.DerivePasswordKey(password: password, salt: salt);
                var files = await _client.GetSharedFolderAsync(_userId, _folderId, derivedPassword);
                ResultFiles = files;
                ResultShareCode = derivedPassword;
                DialogResult = DialogResult.OK;
            }
            catch
            {
                _ = this.ShowError("Error getting the files!");
            }
            
           
        } else
        {
            _ = this.ShowError("Please enter a password");
        }
    }

    private void passwordTextBox_TextChanged(object sender, EventArgs e)
    {
    }
}
