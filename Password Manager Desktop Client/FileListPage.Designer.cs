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
            CreateSharedFolder = new Button();
            listView1 = new ListView();
            panel1 = new Panel();
            listView2 = new ListView();
            userName_label = new Label();
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
            AddNewPassword_Button.Location = new Point(0, 15);
            AddNewPassword_Button.Margin = new Padding(0);
            AddNewPassword_Button.Name = "AddNewPassword_Button";
            AddNewPassword_Button.Size = new Size(82, 24);
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
            logOut_Button.Location = new Point(242, 15);
            logOut_Button.Margin = new Padding(0);
            logOut_Button.Name = "logOut_Button";
            logOut_Button.Size = new Size(82, 24);
            logOut_Button.TabIndex = 2;
            logOut_Button.Text = "Log out";
            logOut_Button.UseVisualStyleBackColor = false;
            logOut_Button.Click += LogOut_Button_Click;
            // 
            // CreateSharedFolder
            // 
            CreateSharedFolder.BackColor = Color.FromArgb(33, 33, 37);
            CreateSharedFolder.Dock = DockStyle.Left;
            CreateSharedFolder.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            CreateSharedFolder.FlatAppearance.BorderSize = 0;
            CreateSharedFolder.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            CreateSharedFolder.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            CreateSharedFolder.FlatStyle = FlatStyle.Flat;
            CreateSharedFolder.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            CreateSharedFolder.ForeColor = Color.FromArgb(230, 230, 230);
            CreateSharedFolder.Location = new Point(82, 15);
            CreateSharedFolder.Margin = new Padding(0);
            CreateSharedFolder.Name = "CreateSharedFolder";
            CreateSharedFolder.Size = new Size(160, 24);
            CreateSharedFolder.TabIndex = 3;
            CreateSharedFolder.Text = "Create shared folder";
            CreateSharedFolder.UseVisualStyleBackColor = false;
            CreateSharedFolder.Click += CreateSharedFolder_Click;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(60, 60, 65);
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.Cursor = Cursors.Hand;
            listView1.Dock = DockStyle.Top;
            listView1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.ForeColor = Color.FromArgb(230, 230, 230);
            listView1.FullRowSelect = true;
            listView1.Location = new Point(18, 65);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(328, 132);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 45, 50);
            panel1.Controls.Add(listView2);
            panel1.Controls.Add(userName_label);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(buttonsPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(9, 8);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(18, 15, 18, 15);
            panel1.Size = new Size(364, 360);
            panel1.TabIndex = 6;
            // 
            // listView2
            // 
            listView2.BackColor = Color.FromArgb(60, 60, 65);
            listView2.BorderStyle = BorderStyle.FixedSingle;
            listView2.Cursor = Cursors.Hand;
            listView2.Dock = DockStyle.Top;
            listView2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listView2.ForeColor = Color.FromArgb(230, 230, 230);
            listView2.FullRowSelect = true;
            listView2.Location = new Point(18, 222);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(328, 120);
            listView2.TabIndex = 8;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            // 
            // userName_label
            // 
            userName_label.AutoSize = true;
            userName_label.Dock = DockStyle.Top;
            userName_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            userName_label.ForeColor = Color.FromArgb(230, 230, 230);
            userName_label.Location = new Point(18, 197);
            userName_label.Name = "userName_label";
            userName_label.Size = new Size(134, 25);
            userName_label.TabIndex = 7;
            userName_label.Text = "Shared folders";
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(logOut_Button);
            buttonsPanel.Controls.Add(CreateSharedFolder);
            buttonsPanel.Controls.Add(AddNewPassword_Button);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Location = new Point(18, 15);
            buttonsPanel.Margin = new Padding(9, 15, 9, 15);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 15, 0, 11);
            buttonsPanel.Size = new Size(328, 50);
            buttonsPanel.TabIndex = 6;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // FileListPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 32);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FileListPage";
            Padding = new Padding(9, 8, 9, 8);
            Size = new Size(382, 376);
            Load += CreateVaultPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button AddNewPassword_Button;
        private Button logOut_Button;
        private Button CreateSharedFolder;
        private ListView listView1;
        private Panel panel1;
        private Panel buttonsPanel;
        private ImageList imageList;
        private Label userName_label;
        private ListView listView2;
    }
}
