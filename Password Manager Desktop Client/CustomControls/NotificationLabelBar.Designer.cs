namespace Password_Manager_Desktop_Client.CustomControls;

partial class NotificationLabelBar
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
        this.lblMessage = new System.Windows.Forms.Label();
        this.btnHideNotification = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // lblMessage
        // 
        this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblMessage.Location = new System.Drawing.Point(0, 0);
        this.lblMessage.Name = "lblMessage";
        this.lblMessage.Size = new System.Drawing.Size(675, 28);
        this.lblMessage.TabIndex = 0;
        this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnHideNotification
        // 
        this.btnHideNotification.Dock = System.Windows.Forms.DockStyle.Right;
        this.btnHideNotification.FlatAppearance.BorderSize = 0;
        this.btnHideNotification.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        this.btnHideNotification.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        this.btnHideNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnHideNotification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnHideNotification.ForeColor = System.Drawing.Color.Maroon;
        this.btnHideNotification.Location = new System.Drawing.Point(647, 0);
        this.btnHideNotification.Name = "btnHideNotification";
        this.btnHideNotification.Size = new System.Drawing.Size(28, 28);
        this.btnHideNotification.TabIndex = 1;
        this.btnHideNotification.Text = "✕";
        this.btnHideNotification.UseVisualStyleBackColor = false;
        this.btnHideNotification.Click += new System.EventHandler(this.btnHideNotification_Click);
        // 
        // NotificationLabelBar
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.btnHideNotification);
        this.Controls.Add(this.lblMessage);
        this.Name = "NotificationLabelBar";
        this.Size = new System.Drawing.Size(675, 28);
        this.Load += new System.EventHandler(this.NotificationLabelBar_Load);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblMessage;
    private System.Windows.Forms.Button btnHideNotification;
}