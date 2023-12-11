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
            this.userName_label = new System.Windows.Forms.Label();
            this.masterPassword_label = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createAcc = new System.Windows.Forms.Button();
            this.lineBreak2 = new System.Windows.Forms.Label();
            this.lineBreak = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userName_label
            // 
            this.userName_label.AutoSize = true;
            this.userName_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.userName_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userName_label.Location = new System.Drawing.Point(44, 75);
            this.userName_label.Name = "userName_label";
            this.userName_label.Size = new System.Drawing.Size(97, 25);
            this.userName_label.TabIndex = 0;
            this.userName_label.Text = "Username";
            // 
            // masterPassword_label
            // 
            this.masterPassword_label.AutoSize = true;
            this.masterPassword_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.masterPassword_label.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.masterPassword_label.Location = new System.Drawing.Point(44, 126);
            this.masterPassword_label.Name = "masterPassword_label";
            this.masterPassword_label.Size = new System.Drawing.Size(154, 25);
            this.masterPassword_label.TabIndex = 1;
            this.masterPassword_label.Text = "Master Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.usernameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.usernameTextBox.Location = new System.Drawing.Point(44, 100);
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameTextBox.MaximumSize = new System.Drawing.Size(219, 31);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "Name";
            this.usernameTextBox.Size = new System.Drawing.Size(219, 26);
            this.usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(65)))));
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.passwordTextBox.Location = new System.Drawing.Point(44, 151);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTextBox.MaximumSize = new System.Drawing.Size(219, 31);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.PlaceholderText = "Password";
            this.passwordTextBox.Size = new System.Drawing.Size(219, 26);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(44, 192);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(672, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Log In";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LogInButton_Clicked);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.mainPanel.Controls.Add(this.createAcc);
            this.mainPanel.Controls.Add(this.lineBreak2);
            this.mainPanel.Controls.Add(this.button1);
            this.mainPanel.Controls.Add(this.lineBreak);
            this.mainPanel.Controls.Add(this.passwordTextBox);
            this.mainPanel.Controls.Add(this.masterPassword_label);
            this.mainPanel.Controls.Add(this.usernameTextBox);
            this.mainPanel.Controls.Add(this.userName_label);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(9, 8);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(44, 75, 44, 75);
            this.mainPanel.Size = new System.Drawing.Size(760, 442);
            this.mainPanel.TabIndex = 5;
            // 
            // createAcc
            // 
            this.createAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.createAcc.Dock = System.Windows.Forms.DockStyle.Top;
            this.createAcc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.createAcc.FlatAppearance.BorderSize = 0;
            this.createAcc.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.createAcc.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.createAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createAcc.Location = new System.Drawing.Point(44, 233);
            this.createAcc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createAcc.Name = "createAcc";
            this.createAcc.Size = new System.Drawing.Size(672, 26);
            this.createAcc.TabIndex = 6;
            this.createAcc.Text = "Create Account";
            this.createAcc.UseVisualStyleBackColor = false;
            this.createAcc.Click += new System.EventHandler(this.createAcc_Click);
            // 
            // lineBreak2
            // 
            this.lineBreak2.AutoSize = true;
            this.lineBreak2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineBreak2.Location = new System.Drawing.Point(44, 218);
            this.lineBreak2.Name = "lineBreak2";
            this.lineBreak2.Size = new System.Drawing.Size(0, 15);
            this.lineBreak2.TabIndex = 7;
            // 
            // lineBreak
            // 
            this.lineBreak.AutoSize = true;
            this.lineBreak.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineBreak.Location = new System.Drawing.Point(44, 177);
            this.lineBreak.Name = "lineBreak";
            this.lineBreak.Size = new System.Drawing.Size(0, 15);
            this.lineBreak.TabIndex = 5;
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.mainPanel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogInPage";
            this.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.Size = new System.Drawing.Size(778, 458);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label userName_label;
        private Label masterPassword_label;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button button1;
        private Panel mainPanel;
        private Label lineBreak;
        private Button createAcc;
        private Label lineBreak2;
    }
}
