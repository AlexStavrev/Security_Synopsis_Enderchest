namespace Password_Manager_Desktop_Client;

partial class Form1
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        panel1 = new Panel();
        panel2 = new Panel();
        titleLbl = new Label();
        imageAppIcon = new PictureBox();
        minimizeBtn = new Button();
        maximizeBtn = new Button();
        closeBtn = new Button();
        panel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)imageAppIcon).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Dock = DockStyle.Fill;
        panel1.Location = new Point(0, 40);
        panel1.Name = "panel1";
        panel1.Size = new Size(432, 513);
        panel1.TabIndex = 0;
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
        panel2.Size = new Size(432, 40);
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
        minimizeBtn.Location = new Point(304, 3);
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
        maximizeBtn.Location = new Point(344, 3);
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
        closeBtn.Location = new Point(384, 3);
        closeBtn.MaximumSize = new Size(40, 30);
        closeBtn.MinimumSize = new Size(40, 30);
        closeBtn.Name = "closeBtn";
        closeBtn.Size = new Size(40, 30);
        closeBtn.TabIndex = 1;
        closeBtn.Text = "✕";
        closeBtn.UseVisualStyleBackColor = false;
        closeBtn.Click += closeBtn_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(45, 45, 50);
        ClientSize = new Size(432, 553);
        Controls.Add(panel1);
        Controls.Add(panel2);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(450, 600);
        Name = "Form1";
        Text = "Enderchest";
        Load += Form1_Load;
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
}
