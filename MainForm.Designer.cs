namespace anti_ransomware
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnFixAtr = new System.Windows.Forms.Button();
            this.btnFixPath = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFixAtr
            // 
            this.btnFixAtr.Location = new System.Drawing.Point(12, 12);
            this.btnFixAtr.Name = "btnFixAtr";
            this.btnFixAtr.Size = new System.Drawing.Size(100, 23);
            this.btnFixAtr.TabIndex = 0;
            this.btnFixAtr.Text = "Fix Attributes";
            this.btnFixAtr.UseVisualStyleBackColor = true;
            this.btnFixAtr.Click += new System.EventHandler(this.btnFixAtr_Click);
            // 
            // btnFixPath
            // 
            this.btnFixPath.Location = new System.Drawing.Point(195, 12);
            this.btnFixPath.Name = "btnFixPath";
            this.btnFixPath.Size = new System.Drawing.Size(100, 23);
            this.btnFixPath.TabIndex = 1;
            this.btnFixPath.Text = "Fix Path Issues";
            this.btnFixPath.UseVisualStyleBackColor = true;
            this.btnFixPath.Click += new System.EventHandler(this.btnFixPath_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 43);
            this.Controls.Add(this.btnFixPath);
            this.Controls.Add(this.btnFixAtr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Fix Ransomware Issue";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFixAtr;
        private System.Windows.Forms.Button btnFixPath;
    }
}

