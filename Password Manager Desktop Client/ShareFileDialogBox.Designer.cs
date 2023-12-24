namespace Password_Manager_Desktop_Client;

partial class ShareFileDialogBox
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareFileDialogBox));
        panel1 = new Panel();
        lineBreak = new Label();
        usernameTextBox = new TextBox();
        userName_label = new Label();
        panel3 = new Panel();
        button2 = new Button();
        button1 = new Button();
        panel2 = new Panel();
        titleLbl = new Label();
        imageAppIcon = new PictureBox();
        minimizeBtn = new Button();
        maximizeBtn = new Button();
        closeBtn = new Button();
        panel1.SuspendLayout();
        panel3.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)imageAppIcon).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(28, 28, 32);
        panel1.Controls.Add(lineBreak);
        panel1.Controls.Add(usernameTextBox);
        panel1.Controls.Add(userName_label);
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 40);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(10, 11, 10, 11);
        panel1.Size = new Size(485, 111);
        panel1.TabIndex = 0;
        // 
        // lineBreak
        // 
        lineBreak.AutoSize = true;
        lineBreak.Dock = DockStyle.Top;
        lineBreak.Location = new Point(10, 72);
        lineBreak.Name = "lineBreak";
        lineBreak.Size = new Size(0, 20);
        lineBreak.TabIndex = 7;
        // 
        // usernameTextBox
        // 
        usernameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        usernameTextBox.AutoCompleteSource = AutoCompleteSource.HistoryList;
        usernameTextBox.BackColor = Color.FromArgb(60, 60, 65);
        usernameTextBox.BorderStyle = BorderStyle.FixedSingle;
        usernameTextBox.Dock = DockStyle.Top;
        usernameTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        usernameTextBox.ForeColor = Color.FromArgb(230, 230, 230);
        usernameTextBox.Location = new Point(10, 42);
        usernameTextBox.MaximumSize = new Size(300, 30);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.PlaceholderText = "email@example.com";
        usernameTextBox.Size = new Size(300, 30);
        usernameTextBox.TabIndex = 4;
        // 
        // userName_label
        // 
        userName_label.AutoSize = true;
        userName_label.Dock = DockStyle.Top;
        userName_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
        userName_label.ForeColor = Color.FromArgb(230, 230, 230);
        userName_label.Location = new Point(10, 11);
        userName_label.Name = "userName_label";
        userName_label.Size = new Size(70, 31);
        userName_label.TabIndex = 3;
        userName_label.Text = "Email";
        // 
        // panel3
        // 
        panel3.BackColor = Color.FromArgb(45, 45, 50);
        panel3.Controls.Add(button2);
        panel3.Controls.Add(button1);
        panel3.Dock = DockStyle.Bottom;
        panel3.Location = new Point(0, 151);
        panel3.Name = "panel3";
        panel3.Size = new Size(485, 40);
        panel3.TabIndex = 8;
        // 
        // button2
        // 
        button2.BackColor = Color.FromArgb(33, 33, 37);
        button2.Dock = DockStyle.Right;
        button2.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        button2.FlatAppearance.BorderSize = 3;
        button2.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        button2.ForeColor = Color.FromArgb(230, 230, 230);
        button2.Location = new Point(303, 0);
        button2.Name = "button2";
        button2.Size = new Size(91, 40);
        button2.TabIndex = 7;
        button2.Text = "Share";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // button1
        // 
        button1.BackColor = Color.FromArgb(33, 33, 37);
        button1.Dock = DockStyle.Right;
        button1.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        button1.FlatAppearance.BorderSize = 3;
        button1.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        button1.ForeColor = Color.FromArgb(230, 230, 230);
        button1.Location = new Point(394, 0);
        button1.Name = "button1";
        button1.Size = new Size(91, 40);
        button1.TabIndex = 6;
        button1.Text = "Cancel";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(45, 45, 50);
        panel2.Controls.Add(titleLbl);
        panel2.Controls.Add(imageAppIcon);
        panel2.Controls.Add(minimizeBtn);
        panel2.Controls.Add(maximizeBtn);
        panel2.Controls.Add(closeBtn);
        panel2.Dock = DockStyle.Top;
        panel2.ForeColor = Color.FromArgb(230, 230, 230);
        panel2.Location = new Point(0, 0);
        panel2.MinimumSize = new Size(0, 40);
        panel2.Name = "panel2";
        panel2.Padding = new Padding(10, 3, 8, 0);
        panel2.Size = new Size(485, 40);
        panel2.TabIndex = 0;
        panel2.MouseDown += TitleBar_MouseDown;
        // 
        // titleLbl
        // 
        titleLbl.AutoSize = true;
        titleLbl.Dock = DockStyle.Left;
        titleLbl.Font = new Font("Segoe UI", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
        titleLbl.Location = new Point(43, 3);
        titleLbl.Margin = new Padding(0, 0, 3, 0);
        titleLbl.Name = "titleLbl";
        titleLbl.Size = new Size(68, 30);
        titleLbl.TabIndex = 0;
        titleLbl.Text = "label1";
        titleLbl.MouseDown += TitleBar_MouseDown;
        // 
        // imageAppIcon
        // 
        imageAppIcon.BackColor = Color.Transparent;
        imageAppIcon.Dock = DockStyle.Left;
        imageAppIcon.Image = Properties.Resources.enderchest;
        imageAppIcon.InitialImage = null;
        imageAppIcon.Location = new Point(10, 3);
        imageAppIcon.Margin = new Padding(0);
        imageAppIcon.MaximumSize = new Size(33, 33);
        imageAppIcon.MinimumSize = new Size(33, 33);
        imageAppIcon.Name = "imageAppIcon";
        imageAppIcon.Size = new Size(33, 33);
        imageAppIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        imageAppIcon.TabIndex = 4;
        imageAppIcon.TabStop = false;
        imageAppIcon.MouseDown += TitleBar_MouseDown;
        // 
        // minimizeBtn
        // 
        minimizeBtn.Dock = DockStyle.Right;
        minimizeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        minimizeBtn.FlatAppearance.BorderSize = 0;
        minimizeBtn.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        minimizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
        minimizeBtn.FlatStyle = FlatStyle.Flat;
        minimizeBtn.Location = new Point(357, 3);
        minimizeBtn.MaximumSize = new Size(40, 29);
        minimizeBtn.MinimumSize = new Size(40, 29);
        minimizeBtn.Name = "minimizeBtn";
        minimizeBtn.Size = new Size(40, 29);
        minimizeBtn.TabIndex = 3;
        minimizeBtn.Text = "🗕";
        minimizeBtn.UseVisualStyleBackColor = false;
        minimizeBtn.Click += minimizeBtn_Click;
        // 
        // maximizeBtn
        // 
        maximizeBtn.Dock = DockStyle.Right;
        maximizeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        maximizeBtn.FlatAppearance.BorderSize = 0;
        maximizeBtn.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        maximizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
        maximizeBtn.FlatStyle = FlatStyle.Flat;
        maximizeBtn.Location = new Point(397, 3);
        maximizeBtn.MaximumSize = new Size(40, 29);
        maximizeBtn.MinimumSize = new Size(40, 29);
        maximizeBtn.Name = "maximizeBtn";
        maximizeBtn.Size = new Size(40, 29);
        maximizeBtn.TabIndex = 2;
        maximizeBtn.Text = "🗖";
        maximizeBtn.UseVisualStyleBackColor = false;
        maximizeBtn.Click += maximizeBtn_Click;
        // 
        // closeBtn
        // 
        closeBtn.Dock = DockStyle.Right;
        closeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        closeBtn.FlatAppearance.BorderSize = 0;
        closeBtn.FlatAppearance.MouseDownBackColor = Color.Crimson;
        closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
        closeBtn.FlatStyle = FlatStyle.Flat;
        closeBtn.Location = new Point(437, 3);
        closeBtn.MaximumSize = new Size(40, 29);
        closeBtn.MinimumSize = new Size(40, 29);
        closeBtn.Name = "closeBtn";
        closeBtn.Size = new Size(40, 29);
        closeBtn.TabIndex = 1;
        closeBtn.Text = "✕";
        closeBtn.UseVisualStyleBackColor = false;
        closeBtn.Click += closeBtn_Click;
        // 
        // ShareFileDialogBox
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(28, 28, 32);
        ClientSize = new Size(485, 191);
        Controls.Add(panel1);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        Name = "ShareFileDialogBox";
        Text = "Share File";
        Load += Form1_Load;
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel3.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)imageAppIcon).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Panel panel2;
    private Label titleLbl;
    private Button minimizeBtn;
    private Button maximizeBtn;
    private Button closeBtn;
    private PictureBox imageAppIcon;
    private TextBox usernameTextBox;
    private Label userName_label;
    private Button button1;
    private Panel panel3;
    private Button button2;
    private Label lineBreak;
}
