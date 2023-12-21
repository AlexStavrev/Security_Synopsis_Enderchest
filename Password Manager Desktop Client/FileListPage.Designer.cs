namespace Password_Manager_Desktop_Client
{
    partial class FileListPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AddNewPassword_Button = new Button();
            logOut_Button = new Button();
            Encrypt = new Button();
            decrypt = new Button();
            listView1 = new ListView();
            panel1 = new Panel();
            buttonsPanel = new Panel();
            imageList = new ImageList(components);
            panel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AddNewPassword_Button
            // 
            AddNewPassword_Button.BackColor = Color.FromArgb(33, 33, 37);
            AddNewPassword_Button.Dock = DockStyle.Left;
            AddNewPassword_Button.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            AddNewPassword_Button.FlatAppearance.BorderSize = 0;
            AddNewPassword_Button.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            AddNewPassword_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            AddNewPassword_Button.FlatStyle = FlatStyle.Flat;
            AddNewPassword_Button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            AddNewPassword_Button.ForeColor = Color.FromArgb(230, 230, 230);
            AddNewPassword_Button.Location = new Point(0, 20);
            AddNewPassword_Button.Margin = new Padding(0);
            AddNewPassword_Button.Name = "AddNewPassword_Button";
            AddNewPassword_Button.Size = new Size(94, 32);
            AddNewPassword_Button.TabIndex = 1;
            AddNewPassword_Button.Text = "Add new";
            AddNewPassword_Button.UseVisualStyleBackColor = false;
            AddNewPassword_Button.Click += AddNewFile_ClickAsync;
            // 
            // logOut_Button
            // 
            logOut_Button.BackColor = Color.FromArgb(33, 33, 37);
            logOut_Button.Dock = DockStyle.Left;
            logOut_Button.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            logOut_Button.FlatAppearance.BorderSize = 0;
            logOut_Button.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            logOut_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            logOut_Button.FlatStyle = FlatStyle.Flat;
            logOut_Button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            logOut_Button.ForeColor = Color.FromArgb(230, 230, 230);
            logOut_Button.Location = new Point(282, 20);
            logOut_Button.Margin = new Padding(0);
            logOut_Button.Name = "logOut_Button";
            logOut_Button.Size = new Size(94, 32);
            logOut_Button.TabIndex = 2;
            logOut_Button.Text = "Log out";
            logOut_Button.UseVisualStyleBackColor = false;
            logOut_Button.Click += LogOut_Button_Click;
            // 
            // Encrypt
            // 
            Encrypt.BackColor = Color.FromArgb(33, 33, 37);
            Encrypt.Dock = DockStyle.Left;
            Encrypt.Enabled = false;
            Encrypt.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            Encrypt.FlatAppearance.BorderSize = 0;
            Encrypt.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            Encrypt.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            Encrypt.FlatStyle = FlatStyle.Flat;
            Encrypt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            Encrypt.ForeColor = Color.FromArgb(230, 230, 230);
            Encrypt.Location = new Point(94, 20);
            Encrypt.Margin = new Padding(0);
            Encrypt.Name = "Encrypt";
            Encrypt.Size = new Size(94, 32);
            Encrypt.TabIndex = 3;
            Encrypt.Text = "Encrypt";
            Encrypt.UseVisualStyleBackColor = false;
            Encrypt.Click += Encrypt_Click;
            // 
            // decrypt
            // 
            decrypt.BackColor = Color.FromArgb(33, 33, 37);
            decrypt.Dock = DockStyle.Left;
            decrypt.Enabled = false;
            decrypt.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            decrypt.FlatAppearance.BorderSize = 0;
            decrypt.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            decrypt.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            decrypt.FlatStyle = FlatStyle.Flat;
            decrypt.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            decrypt.ForeColor = Color.FromArgb(230, 230, 230);
            decrypt.Location = new Point(188, 20);
            decrypt.Margin = new Padding(0);
            decrypt.Name = "decrypt";
            decrypt.Size = new Size(94, 32);
            decrypt.TabIndex = 4;
            decrypt.Text = "Decrypt";
            decrypt.UseVisualStyleBackColor = false;
            decrypt.Click += Decrypt_Click;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(60, 60, 65);
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.Cursor = Cursors.Hand;
            listView1.Dock = DockStyle.Fill;
            listView1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.ForeColor = Color.FromArgb(230, 230, 230);
            listView1.FullRowSelect = true;
            listView1.Location = new Point(20, 87);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(377, 374);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 45, 50);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(buttonsPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(417, 481);
            panel1.TabIndex = 6;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(logOut_Button);
            buttonsPanel.Controls.Add(decrypt);
            buttonsPanel.Controls.Add(Encrypt);
            buttonsPanel.Controls.Add(AddNewPassword_Button);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Location = new Point(20, 20);
            buttonsPanel.Margin = new Padding(10, 20, 10, 20);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 20, 0, 15);
            buttonsPanel.Size = new Size(377, 67);
            buttonsPanel.TabIndex = 6;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // CreateVaultPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 32);
            Controls.Add(panel1);
            Name = "CreateVaultPage";
            Padding = new Padding(10);
            Size = new Size(437, 501);
            Load += CreateVaultPage_Load;
            panel1.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button AddNewPassword_Button;
        private Button logOut_Button;
        private Button Encrypt;
        private Button decrypt;
        private ListView listView1;
        private Panel panel1;
        private Panel buttonsPanel;
        private ImageList imageList;
    }
}
