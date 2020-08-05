namespace Prof
{
    partial class FUploadUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUploadUpdate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_version = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ftp = new System.Windows.Forms.TextBox();
            this.rtb_updText = new System.Windows.Forms.RichTextBox();
            this.b_save = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.tb_pathReliase = new System.Windows.Forms.TextBox();
            this.b_pathReliase = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_version);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(77, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "version";
            // 
            // tb_version
            // 
            this.tb_version.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_version.Location = new System.Drawing.Point(3, 16);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(71, 20);
            this.tb_version.TabIndex = 0;
            this.tb_version.Text = "0.0.1";
            this.tb_version.TextChanged += new System.EventHandler(this.tb_version_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ftp);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(92, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 47);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FTP-path";
            // 
            // tb_ftp
            // 
            this.tb_ftp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_ftp.Location = new System.Drawing.Point(3, 16);
            this.tb_ftp.Name = "tb_ftp";
            this.tb_ftp.Size = new System.Drawing.Size(408, 20);
            this.tb_ftp.TabIndex = 0;
            // 
            // rtb_updText
            // 
            this.rtb_updText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtb_updText.Location = new System.Drawing.Point(12, 93);
            this.rtb_updText.Name = "rtb_updText";
            this.rtb_updText.Size = new System.Drawing.Size(494, 348);
            this.rtb_updText.TabIndex = 3;
            this.rtb_updText.Text = "";
            // 
            // b_save
            // 
            this.b_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_save.Location = new System.Drawing.Point(12, 447);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(138, 29);
            this.b_save.TabIndex = 4;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_close
            // 
            this.b_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_close.Location = new System.Drawing.Point(365, 447);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(138, 29);
            this.b_close.TabIndex = 5;
            this.b_close.Text = "Закрыть";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // tb_pathReliase
            // 
            this.tb_pathReliase.Location = new System.Drawing.Point(93, 67);
            this.tb_pathReliase.Name = "tb_pathReliase";
            this.tb_pathReliase.Size = new System.Drawing.Size(409, 20);
            this.tb_pathReliase.TabIndex = 6;
            // 
            // b_pathReliase
            // 
            this.b_pathReliase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_pathReliase.Location = new System.Drawing.Point(12, 65);
            this.b_pathReliase.Name = "b_pathReliase";
            this.b_pathReliase.Size = new System.Drawing.Size(75, 23);
            this.b_pathReliase.TabIndex = 7;
            this.b_pathReliase.Text = "Выбрать";
            this.b_pathReliase.UseVisualStyleBackColor = true;
            this.b_pathReliase.Click += new System.EventHandler(this.b_pathReliase_Click);
            // 
            // FUploadUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 482);
            this.Controls.Add(this.b_pathReliase);
            this.Controls.Add(this.tb_pathReliase);
            this.Controls.Add(this.b_close);
            this.Controls.Add(this.b_save);
            this.Controls.Add(this.rtb_updText);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FUploadUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование обновления";
            this.Load += new System.EventHandler(this.FUploadUpdate_Load);
            this.DoubleClick += new System.EventHandler(this.FUploadUpdate_DoubleClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_version;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_ftp;
        private System.Windows.Forms.RichTextBox rtb_updText;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_close;
        private System.Windows.Forms.TextBox tb_pathReliase;
        private System.Windows.Forms.Button b_pathReliase;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}