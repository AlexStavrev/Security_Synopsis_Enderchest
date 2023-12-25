namespace Password_Manager_Desktop_Client
{
    partial class LogInPage
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
            userName_label = new Label();
            masterPassword_label = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            button1 = new Button();
            mainPanel = new Panel();
            createAcc = new Button();
            lineBreak2 = new Label();
            passwordPanel = new Panel();
            showPasswordButton = new Button();
            mainPanel.SuspendLayout();
            passwordPanel.SuspendLayout();
            SuspendLayout();
            // 
            // userName_label
            // 
            userName_label.AutoSize = true;
            userName_label.Dock = DockStyle.Top;
            userName_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            userName_label.Location = new Point(50, 100);
            userName_label.Name = "userName_label";
            userName_label.Size = new Size(70, 31);
            userName_label.TabIndex = 0;
            userName_label.Text = "Email";
            // 
            // masterPassword_label
            // 
            masterPassword_label.AutoSize = true;
            masterPassword_label.Dock = DockStyle.Top;
            masterPassword_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            masterPassword_label.Location = new Point(50, 161);
            masterPassword_label.Name = "masterPassword_label";
            masterPassword_label.Size = new Size(187, 31);
            masterPassword_label.TabIndex = 1;
            masterPassword_label.Text = "Master Password";
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
            usernameTextBox.Location = new Point(50, 131);
            usernameTextBox.MaximumSize = new Size(250, 31);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "email@example.com";
            usernameTextBox.Size = new Size(250, 30);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(60, 60, 65);
            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Dock = DockStyle.Left;
            passwordTextBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextBox.ForeColor = Color.FromArgb(230, 230, 230);
            passwordTextBox.Location = new Point(0, 0);
            passwordTextBox.MaximumSize = new Size(250, 31);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.Size = new Size(250, 30);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 33, 37);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(50, 243);
            button1.Name = "button1";
            button1.Size = new Size(769, 35);
            button1.TabIndex = 4;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LogInButton_Clicked;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(45, 45, 50);
            mainPanel.Controls.Add(createAcc);
            mainPanel.Controls.Add(lineBreak2);
            mainPanel.Controls.Add(button1);
            mainPanel.Controls.Add(passwordPanel);
            mainPanel.Controls.Add(masterPassword_label);
            mainPanel.Controls.Add(usernameTextBox);
            mainPanel.Controls.Add(userName_label);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(10, 11);
            mainPanel.Margin = new Padding(0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(50, 100, 50, 100);
            mainPanel.Size = new Size(869, 589);
            mainPanel.TabIndex = 5;
            // 
            // createAcc
            // 
            createAcc.BackColor = Color.FromArgb(33, 33, 37);
            createAcc.Dock = DockStyle.Top;
            createAcc.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            createAcc.FlatAppearance.BorderSize = 0;
            createAcc.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            createAcc.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            createAcc.FlatStyle = FlatStyle.Flat;
            createAcc.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            createAcc.Location = new Point(50, 298);
            createAcc.Name = "createAcc";
            createAcc.Size = new Size(769, 35);
            createAcc.TabIndex = 6;
            createAcc.Text = "Create Account";
            createAcc.UseVisualStyleBackColor = false;
            createAcc.Click += createAcc_Click;
            // 
            // lineBreak2
            // 
            lineBreak2.AutoSize = true;
            lineBreak2.Dock = DockStyle.Top;
            lineBreak2.Location = new Point(50, 278);
            lineBreak2.Name = "lineBreak2";
            lineBreak2.Size = new Size(0, 20);
            lineBreak2.TabIndex = 7;
            // 
            // passwordPanel
            // 
            passwordPanel.Controls.Add(showPasswordButton);
            passwordPanel.Controls.Add(passwordTextBox);
            passwordPanel.Dock = DockStyle.Top;
            passwordPanel.Location = new Point(50, 192);
            passwordPanel.Name = "passwordPanel";
            passwordPanel.Size = new Size(769, 51);
            passwordPanel.TabIndex = 8;
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
            showPasswordButton.Location = new Point(250, 0);
            showPasswordButton.MaximumSize = new Size(30, 30);
            showPasswordButton.Name = "showPasswordButton";
            showPasswordButton.Size = new Size(30, 30);
            showPasswordButton.TabIndex = 5;
            showPasswordButton.Text = "👁";
            showPasswordButton.UseVisualStyleBackColor = false;
            showPasswordButton.Click += button2_Click;
            // 
            // LogInPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 32);
            Controls.Add(mainPanel);
            ForeColor = Color.FromArgb(230, 230, 230);
            Name = "LogInPage";
            Padding = new Padding(10, 11, 10, 11);
            Size = new Size(889, 611);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            passwordPanel.ResumeLayout(false);
            passwordPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label userName_label;
        private Label masterPassword_label;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button button1;
        private Panel mainPanel;
        private Button createAcc;
        private Label lineBreak2;
        private Panel passwordPanel;
        private Button showPasswordButton;
    }
}
