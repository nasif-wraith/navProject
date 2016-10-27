namespace NavAppDesktopRegistration
{
    partial class signaturePadView
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
            this.BurttonClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.picDraw = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // BurttonClear
            // 
            this.BurttonClear.Location = new System.Drawing.Point(22, 254);
            this.BurttonClear.Name = "BurttonClear";
            this.BurttonClear.Size = new System.Drawing.Size(86, 25);
            this.BurttonClear.TabIndex = 165;
            this.BurttonClear.Text = "Clear";
            this.BurttonClear.UseVisualStyleBackColor = true;
            this.BurttonClear.Click += new System.EventHandler(this.BurttonClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 162;
            this.label1.Text = "Captured Data";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(196, 254);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(82, 23);
            this.Save.TabIndex = 166;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // picDraw
            // 
            this.picDraw.BackColor = System.Drawing.Color.Black;
            this.picDraw.Image = global::NavAppDesktopRegistration.Properties.Resources.whiteBG;
            this.picDraw.InitialImage = global::NavAppDesktopRegistration.Properties.Resources.whiteBG;
            this.picDraw.Location = new System.Drawing.Point(22, 32);
            this.picDraw.Name = "picDraw";
            this.picDraw.Size = new System.Drawing.Size(256, 192);
            this.picDraw.TabIndex = 161;
            this.picDraw.TabStop = false;
            // 
            // signaturePadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::NavAppDesktopRegistration.Properties.Resources.AllBk;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(309, 301);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.BurttonClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picDraw);
            this.Name = "signaturePadView";
            this.Text = "signaturePadView";
            this.Activated += new System.EventHandler(this.MainFrm_Activated);
            this.Deactivate += new System.EventHandler(this.MainFrm_Deactivated);
            this.Load += new System.EventHandler(this.signaturePadView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BurttonClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.Button Save;
    }
}