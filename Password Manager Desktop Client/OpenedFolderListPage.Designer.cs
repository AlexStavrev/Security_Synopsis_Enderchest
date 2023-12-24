namespace Password_Manager_Desktop_Client
{
    partial class OpenedFolderListPage
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
            back_Button = new Button();
            listView1 = new ListView();
            panel1 = new Panel();
            buttonsPanel = new Panel();
            imageList = new ImageList(components);
            panel1.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // back_Button
            // 
            back_Button.BackColor = Color.FromArgb(33, 33, 37);
            back_Button.Dock = DockStyle.Left;
            back_Button.FlatAppearance.BorderColor = Color.FromArgb(33, 33, 37);
            back_Button.FlatAppearance.BorderSize = 0;
            back_Button.FlatAppearance.MouseDownBackColor = SystemColors.Highlight;
            back_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(25, 25, 30);
            back_Button.FlatStyle = FlatStyle.Flat;
            back_Button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            back_Button.ForeColor = Color.FromArgb(230, 230, 230);
            back_Button.Location = new Point(0, 20);
            back_Button.Margin = new Padding(0);
            back_Button.Name = "back_Button";
            back_Button.Size = new Size(94, 32);
            back_Button.TabIndex = 2;
            back_Button.Text = "Back";
            back_Button.UseVisualStyleBackColor = false;
            back_Button.Click += Back_Button_Click;
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
            listView1.Location = new Point(21, 87);
            listView1.Margin = new Padding(3, 4, 3, 4);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(555, 372);
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
            panel1.Location = new Point(10, 11);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(21, 20, 21, 20);
            panel1.Size = new Size(597, 479);
            panel1.TabIndex = 6;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(back_Button);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Location = new Point(21, 20);
            buttonsPanel.Margin = new Padding(10, 20, 10, 20);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Padding = new Padding(0, 20, 0, 15);
            buttonsPanel.Size = new Size(555, 67);
            buttonsPanel.TabIndex = 6;
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth8Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.TransparentColor = Color.Transparent;
            // 
            // OpenedFolderListPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 32);
            Controls.Add(panel1);
            Name = "OpenedFolderListPage";
            Padding = new Padding(10, 11, 10, 11);
            Size = new Size(617, 501);
            Load += CreateVaultPage_Load;
            panel1.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button back_Button;
        private ListView listView1;
        private Panel panel1;
        private Panel buttonsPanel;
        private ImageList imageList;
    }
}
