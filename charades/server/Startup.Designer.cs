namespace server
{
    partial class Startup
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
            this.btnStartSrvr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartSrvr
            // 
            this.btnStartSrvr.Location = new System.Drawing.Point(337, 269);
            this.btnStartSrvr.Name = "btnStartSrvr";
            this.btnStartSrvr.Size = new System.Drawing.Size(75, 23);
            this.btnStartSrvr.TabIndex = 0;
            this.btnStartSrvr.Text = "Start Server";
            this.btnStartSrvr.UseVisualStyleBackColor = true;
            this.btnStartSrvr.Click += new System.EventHandler(this.btnStartSrvr_Click);
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStartSrvr);
            this.Name = "Startup";
            this.Text = "Startup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartSrvr;
    }
}