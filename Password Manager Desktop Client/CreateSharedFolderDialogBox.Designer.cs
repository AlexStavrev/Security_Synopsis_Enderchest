namespace Password_Manager_Desktop_Client
{
    partial class CreateSharedFolderDialogBox
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
            components = new System.ComponentModel.Container();
            titleLbl = new Label();
            imageAppIcon = new PictureBox();
            minimizeBtn = new Button();
            maximizeBtn = new Button();
            closeBtn = new Button();
            panel2 = new Panel();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            panel1 = new Panel();
            listView1 = new ListView();
            label2 = new Label();
            passwordBox = new TextBox();
            label1 = new Label();
            emailTextBox = new TextBox();
            userName_label = new Label();
            imageList = new ImageList(components);
            panel4 = new Panel();
            showPasswordButton = new Button();
            ((System.ComponentModel.ISupportInitialize)imageAppIcon).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
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
            // 
            // minimizeBtn
            // 
            minimizeBtn.Dock = DockStyle.Right;
            minimizeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            minimizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.Location = new Point(507, 3);
            minimizeBtn.MaximumSize = new Size(40, 29);
            minimizeBtn.MinimumSize = new Size(40, 29);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(40, 29);
            minimizeBtn.TabIndex = 3;
            minimizeBtn.Text = "🗕";
            minimizeBtn.UseVisualStyleBackColor = false;
            minimizeBtn.Click += minimizeBtn_Click_1;
            // 
            // maximizeBtn
            // 
            maximizeBtn.Dock = DockStyle.Right;
            maximizeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
            maximizeBtn.FlatAppearance.BorderSize = 0;
            maximizeBtn.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            maximizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
            maximizeBtn.FlatStyle = FlatStyle.Flat;
            maximizeBtn.Location = new Point(547, 3);
            maximizeBtn.MaximumSize = new Size(40, 29);
            maximizeBtn.MinimumSize = new Size(40, 29);
            maximizeBtn.Name = "maximizeBtn";
            maximizeBtn.Size = new Size(40, 29);
            maximizeBtn.TabIndex = 2;
            maximizeBtn.Text = "🗖";
            maximizeBtn.UseVisualStyleBackColor = false;
            maximizeBtn.Click += maximizeBtn_Click_1;
            // 
            // closeBtn
            // 
            closeBtn.Dock = DockStyle.Right;
            closeBtn.FlatAppearance.BorderColor = Color.FromArgb(45, 45, 50);
            closeBtn.FlatAppearance.BorderSize = 0;
            closeBtn.FlatAppearance.MouseDownBackColor = Color.Crimson;
            closeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 65, 70);
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.Location = new Point(587, 3);
            closeBtn.MaximumSize = new Size(40, 29);
            closeBtn.MinimumSize = new Size(40, 29);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(40, 29);
            closeBtn.TabIndex = 1;
            closeBtn.Text = "✕";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click_1;
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
            panel2.Size = new Size(635, 40);
            panel2.TabIndex = 1;
            panel2.MouseDown += TitleBar_MouseDown;
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
            button2.Location = new Point(453, 0);
            button2.Name = "button2";
            button2.Size = new Size(91, 40);
            button2.TabIndex = 7;
            button2.Text = "Create";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
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
            button1.Location = new Point(544, 0);
            button1.Name = "button1";
            button1.Size = new Size(91, 40);
            button1.TabIndex = 6;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(45, 45, 50);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(button1);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 361);
            panel3.Name = "panel3";
            panel3.Size = new Size(635, 40);
            panel3.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(28, 28, 32);
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(emailTextBox);
            panel1.Controls.Add(userName_label);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 40);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(635, 321);
            panel1.TabIndex = 10;
            // 
            // listView1
            // 
            listView1.BackColor = Color.FromArgb(60, 60, 65);
            listView1.BorderStyle = BorderStyle.FixedSingle;
            listView1.CheckBoxes = true;
            listView1.Cursor = Cursors.Hand;
            listView1.Dock = DockStyle.Fill;
            listView1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.ForeColor = Color.FromArgb(230, 230, 230);
            listView1.FullRowSelect = true;
            listView1.Location = new Point(10, 174);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.Name = "listView1";
            listView1.Size = new Size(615, 137);
            listView1.TabIndex = 8;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(230, 230, 230);
            label2.Location = new Point(10, 143);
            label2.Name = "label2";
            label2.Size = new Size(126, 31);
            label2.TabIndex = 10;
            label2.Text = "Select Files";
            // 
            // passwordBox
            // 
            passwordBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            passwordBox.AutoCompleteSource = AutoCompleteSource.HistoryList;
            passwordBox.BackColor = Color.FromArgb(60, 60, 65);
            passwordBox.BorderStyle = BorderStyle.FixedSingle;
            passwordBox.Dock = DockStyle.Left;
            passwordBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            passwordBox.ForeColor = Color.FromArgb(230, 230, 230);
            passwordBox.Location = new Point(0, 0);
            passwordBox.MaximumSize = new Size(300, 30);
            passwordBox.Name = "passwordBox";
            passwordBox.PlaceholderText = "VeryStrongPassword";
            passwordBox.Size = new Size(300, 30);
            passwordBox.TabIndex = 7;
            passwordBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(230, 230, 230);
            label1.Location = new Point(10, 71);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 6;
            label1.Text = "Password";
            // 
            // emailTextBox
            // 
            emailTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            emailTextBox.AutoCompleteSource = AutoCompleteSource.HistoryList;
            emailTextBox.BackColor = Color.FromArgb(60, 60, 65);
            emailTextBox.BorderStyle = BorderStyle.FixedSingle;
            emailTextBox.Dock = DockStyle.Top;
            emailTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            emailTextBox.ForeColor = Color.FromArgb(230, 230, 230);
            emailTextBox.Location = new Point(10, 41);
            emailTextBox.MaximumSize = new Size(300, 30);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.PlaceholderText = "email@example.com";
            emailTextBox.Size = new Size(300, 30);
            emailTextBox.TabIndex = 5;
            // 
            // userName_label
            // 
            userName_label.AutoSize = true;
            userName_label.Dock = DockStyle.Top;
            userName_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            userName_label.ForeColor = Color.FromArgb(230, 230, 230);
            userName_label.Location = new Point(10, 10);
            userName_label.Name = "userName_label";
            userName_label.Size = new Size(70, 31);
            userName_label.TabIndex = 4;
            userName_label.Text = "Email";
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // panel4
            // 
            panel4.Controls.Add(showPasswordButton);
            panel4.Controls.Add(passwordBox);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(10, 102);
            panel4.Name = "panel4";
            panel4.Size = new Size(615, 41);
            panel4.TabIndex = 11;
            // 
            // showPasswordButton
            // 
            showPasswordButton.BackColor = Color.FromArgb(60, 60, 65);
            showPasswordButton.Dock = DockStyle.Top;
            showPasswordButton.FlatAppearance.BorderColor = Color.FromArgb(90, 90, 90);
            showPasswordButton.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            showPasswordButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            showPasswordButton.FlatStyle = FlatStyle.Flat;
            showPasswordButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            showPasswordButton.ForeColor = Color.FromArgb(230, 230, 230);
            showPasswordButton.Location = new Point(300, 0);
            showPasswordButton.MaximumSize = new Size(30, 30);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(30, 30);
            showPasswordButton.TabIndex = 8;
            showPasswordButton.Text = "👁";
            showPasswordButton.UseVisualStyleBackColor = false;
            showPasswordButton.Click += showPasswordButton_Click;
            // 
            // CreateSharedFolderDialogBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(635, 401);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CreateSharedFolderDialogBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "CreateSharedFolderDialogBox";
            Load += CreateSharedFolderDialogBox_Load;
            ((System.ComponentModel.ISupportInitialize)imageAppIcon).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLbl;
        private PictureBox imageAppIcon;
        private Button minimizeBtn;
        private Button maximizeBtn;
        private Button closeBtn;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Panel panel3;
        private Panel panel1;
        private Label userName_label;
        private TextBox passwordBox;
        private Label label1;
        private TextBox emailTextBox;
        private ListView listView1;
        private Label label2;
        private ImageList imageList;
        private Panel panel4;
        private Button showPasswordButton;
    }
}