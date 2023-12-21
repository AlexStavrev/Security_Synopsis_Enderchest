namespace Password_Manager_Desktop_Client;

partial class FileViewDialogBox
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        MainPanel = new Panel();
        fileViewTextBox = new TextBox();
        BottomPanel = new Panel();
        shareButton = new Button();
        downloadButton = new Button();
        closeButton = new Button();
        panel2 = new Panel();
        titleLbl = new Label();
        imageAppIcon = new PictureBox();
        minimizeBtn = new Button();
        maximizeBtn = new Button();
        closeBtn = new Button();
        panel1 = new Panel();
        characterCount_Label = new Label();
        linesCount_Label = new Label();
        worldCount_Label = new Label();
        MainPanel.SuspendLayout();
        BottomPanel.SuspendLayout();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)imageAppIcon).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // MainPanel
        // 
        MainPanel.BackColor = Color.FromArgb(45, 45, 50);
        MainPanel.Controls.Add(fileViewTextBox);
        MainPanel.Controls.Add(panel1);
        MainPanel.Dock = DockStyle.Fill;
        MainPanel.Location = new Point(0, 40);
        MainPanel.Name = "MainPanel";
        MainPanel.Size = new Size(800, 369);
        MainPanel.TabIndex = 0;
        // 
        // fileViewTextBox
        // 
        fileViewTextBox.BackColor = Color.FromArgb(60, 60, 65);
        fileViewTextBox.BorderStyle = BorderStyle.None;
        fileViewTextBox.Dock = DockStyle.Fill;
        fileViewTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        fileViewTextBox.ForeColor = Color.FromArgb(230, 230, 230);
        fileViewTextBox.Location = new Point(0, 0);
        fileViewTextBox.Multiline = true;
        fileViewTextBox.Name = "fileViewTextBox";
        fileViewTextBox.ReadOnly = true;
        fileViewTextBox.ScrollBars = ScrollBars.Vertical;
        fileViewTextBox.Size = new Size(800, 346);
        fileViewTextBox.TabIndex = 0;
        // 
        // BottomPanel
        // 
        BottomPanel.BackColor = Color.FromArgb(45, 45, 50);
        BottomPanel.Controls.Add(shareButton);
        BottomPanel.Controls.Add(downloadButton);
        BottomPanel.Controls.Add(closeButton);
        BottomPanel.Dock = DockStyle.Bottom;
        BottomPanel.Location = new Point(0, 409);
        BottomPanel.Name = "BottomPanel";
        BottomPanel.Size = new Size(800, 41);
        BottomPanel.TabIndex = 1;
        // 
        // shareButton
        // 
        shareButton.BackColor = Color.FromArgb(33, 33, 37);
        shareButton.Dock = DockStyle.Right;
        shareButton.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        shareButton.FlatAppearance.BorderSize = 3;
        shareButton.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        shareButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
        shareButton.FlatStyle = FlatStyle.Flat;
        shareButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        shareButton.ForeColor = Color.FromArgb(230, 230, 230);
        shareButton.Location = new Point(523, 0);
        shareButton.Name = "shareButton";
        shareButton.Size = new Size(93, 41);
        shareButton.TabIndex = 2;
        shareButton.Text = "Share 🔄";
        shareButton.UseVisualStyleBackColor = false;
        shareButton.Click += shareButton_Click;
        // 
        // downloadButton
        // 
        downloadButton.BackColor = Color.FromArgb(33, 33, 37);
        downloadButton.Dock = DockStyle.Right;
        downloadButton.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        downloadButton.FlatAppearance.BorderSize = 3;
        downloadButton.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        downloadButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
        downloadButton.FlatStyle = FlatStyle.Flat;
        downloadButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        downloadButton.ForeColor = Color.FromArgb(230, 230, 230);
        downloadButton.Location = new Point(616, 0);
        downloadButton.Name = "downloadButton";
        downloadButton.Size = new Size(115, 41);
        downloadButton.TabIndex = 1;
        downloadButton.Text = "Download ⤓";
        downloadButton.UseVisualStyleBackColor = false;
        downloadButton.Click += downloadButton_Click;
        // 
        // closeButton
        // 
        closeButton.BackColor = Color.FromArgb(33, 33, 37);
        closeButton.Dock = DockStyle.Right;
        closeButton.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        closeButton.FlatAppearance.BorderSize = 3;
        closeButton.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
        closeButton.FlatStyle = FlatStyle.Flat;
        closeButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
        closeButton.ForeColor = Color.FromArgb(230, 230, 230);
        closeButton.Location = new Point(731, 0);
        closeButton.Name = "closeButton";
        closeButton.Size = new Size(69, 41);
        closeButton.TabIndex = 0;
        closeButton.Text = "Close";
        closeButton.UseVisualStyleBackColor = false;
        closeButton.Click += closeButton_Click;
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
        panel2.Size = new Size(800, 40);
        panel2.TabIndex = 2;
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
        // 
        // minimizeBtn
        // 
        minimizeBtn.Dock = DockStyle.Right;
        minimizeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
        minimizeBtn.FlatAppearance.BorderSize = 0;
        minimizeBtn.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
        minimizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
        minimizeBtn.FlatStyle = FlatStyle.Flat;
        minimizeBtn.Location = new Point(672, 3);
        minimizeBtn.MaximumSize = new Size(40, 30);
        minimizeBtn.MinimumSize = new Size(40, 30);
        minimizeBtn.Name = "minimizeBtn";
        minimizeBtn.Size = new Size(40, 30);
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
        maximizeBtn.Location = new Point(712, 3);
        maximizeBtn.MaximumSize = new Size(40, 30);
        maximizeBtn.MinimumSize = new Size(40, 30);
        maximizeBtn.Name = "maximizeBtn";
        maximizeBtn.Size = new Size(40, 30);
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
        closeBtn.Location = new Point(752, 3);
        closeBtn.MaximumSize = new Size(40, 30);
        closeBtn.MinimumSize = new Size(40, 30);
        closeBtn.Name = "closeBtn";
        closeBtn.Size = new Size(40, 30);
        closeBtn.TabIndex = 1;
        closeBtn.Text = "✕";
        closeBtn.UseVisualStyleBackColor = false;
        closeBtn.Click += closeBtn_Click_1;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(33, 33, 37);
        panel1.Controls.Add(worldCount_Label);
        panel1.Controls.Add(linesCount_Label);
        panel1.Controls.Add(characterCount_Label);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 346);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 23);
        panel1.TabIndex = 2;
        // 
        // characterCount_Label
        // 
        characterCount_Label.AutoSize = true;
        characterCount_Label.Dock = DockStyle.Right;
        characterCount_Label.ForeColor = Color.FromArgb(230, 230, 230);
        characterCount_Label.Location = new Point(719, 0);
        characterCount_Label.Name = "characterCount_Label";
        characterCount_Label.Size = new Size(81, 20);
        characterCount_Label.TabIndex = 0;
        characterCount_Label.Text = "Characters:";
        // 
        // linesCount_Label
        // 
        linesCount_Label.AutoSize = true;
        linesCount_Label.Dock = DockStyle.Right;
        linesCount_Label.ForeColor = Color.FromArgb(230, 230, 230);
        linesCount_Label.Location = new Point(674, 0);
        linesCount_Label.Name = "linesCount_Label";
        linesCount_Label.Size = new Size(45, 20);
        linesCount_Label.TabIndex = 1;
        linesCount_Label.Text = "Lines:";
        // 
        // worldCount_Label
        // 
        worldCount_Label.AutoSize = true;
        worldCount_Label.Dock = DockStyle.Right;
        worldCount_Label.ForeColor = Color.FromArgb(230, 230, 230);
        worldCount_Label.Location = new Point(620, 0);
        worldCount_Label.Name = "worldCount_Label";
        worldCount_Label.Size = new Size(54, 20);
        worldCount_Label.TabIndex = 2;
        worldCount_Label.Text = "Words:";
        // 
        // FileViewDialogBox
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(33, 33, 37);
        ClientSize = new Size(800, 450);
        Controls.Add(MainPanel);
        Controls.Add(BottomPanel);
        Controls.Add(panel2);
        Name = "FileViewDialogBox";
        Text = "FileViewDialogBox";
        Load += FileViewDialogBox_Load;
        Resize += FileViewDialogBox_Resize;
        MainPanel.ResumeLayout(false);
        MainPanel.PerformLayout();
        BottomPanel.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)imageAppIcon).EndInit();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel MainPanel;
    private TextBox fileViewTextBox;
    private Panel BottomPanel;
    private Button closeButton;
    private Panel panel2;
    private Label titleLbl;
    private PictureBox imageAppIcon;
    private Button minimizeBtn;
    private Button maximizeBtn;
    private Button closeBtn;
    private Button downloadButton;
    private Button shareButton;
    private Panel panel1;
    private Label worldCount_Label;
    private Label linesCount_Label;
    private Label characterCount_Label;
}