namespace Prof
{
	partial class f_DBLogin
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_DBLogin));
            this.but_enter = new MetroFramework.Controls.MetroButton();
            this.but_cancel = new MetroFramework.Controls.MetroButton();
            this.tb_Username = new MetroFramework.Controls.MetroTextBox();
            this.tb_Password = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // but_enter
            // 
            this.but_enter.BackColor = System.Drawing.Color.White;
            this.but_enter.Location = new System.Drawing.Point(23, 130);
            this.but_enter.Name = "but_enter";
            this.but_enter.Size = new System.Drawing.Size(88, 23);
            this.but_enter.TabIndex = 2;
            this.but_enter.Text = "Вход";
            this.but_enter.UseCustomBackColor = true;
            this.but_enter.UseSelectable = true;
            this.but_enter.Click += new System.EventHandler(this.but_enter_Click);
            // 
            // but_cancel
            // 
            this.but_cancel.BackColor = System.Drawing.Color.White;
            this.but_cancel.Location = new System.Drawing.Point(141, 130);
            this.but_cancel.Name = "but_cancel";
            this.but_cancel.Size = new System.Drawing.Size(88, 23);
            this.but_cancel.TabIndex = 3;
            this.but_cancel.Text = "Отмена";
            this.but_cancel.UseCustomBackColor = true;
            this.but_cancel.UseSelectable = true;
            this.but_cancel.Click += new System.EventHandler(this.but_cancel_Click);
            // 
            // tb_Username
            // 
            // 
            // 
            // 
            this.tb_Username.CustomButton.Image = null;
            this.tb_Username.CustomButton.Location = new System.Drawing.Point(184, 1);
            this.tb_Username.CustomButton.Name = "";
            this.tb_Username.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_Username.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_Username.CustomButton.TabIndex = 1;
            this.tb_Username.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_Username.CustomButton.UseSelectable = true;
            this.tb_Username.CustomButton.Visible = false;
            this.tb_Username.Lines = new string[0];
            this.tb_Username.Location = new System.Drawing.Point(23, 63);
            this.tb_Username.MaxLength = 32767;
            this.tb_Username.Name = "tb_Username";
            this.tb_Username.PasswordChar = '\0';
            this.tb_Username.PromptText = "Логин";
            this.tb_Username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_Username.SelectedText = "";
            this.tb_Username.SelectionLength = 0;
            this.tb_Username.SelectionStart = 0;
            this.tb_Username.ShortcutsEnabled = true;
            this.tb_Username.Size = new System.Drawing.Size(206, 23);
            this.tb_Username.TabIndex = 0;
            this.tb_Username.UseSelectable = true;
            this.tb_Username.WaterMark = "Логин";
            this.tb_Username.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_Username.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // tb_Password
            // 
            // 
            // 
            // 
            this.tb_Password.CustomButton.Image = null;
            this.tb_Password.CustomButton.Location = new System.Drawing.Point(184, 1);
            this.tb_Password.CustomButton.Name = "";
            this.tb_Password.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_Password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_Password.CustomButton.TabIndex = 1;
            this.tb_Password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_Password.CustomButton.UseSelectable = true;
            this.tb_Password.Lines = new string[0];
            this.tb_Password.Location = new System.Drawing.Point(23, 92);
            this.tb_Password.MaxLength = 32767;
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '●';
            this.tb_Password.PromptText = "Пароль";
            this.tb_Password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_Password.SelectedText = "";
            this.tb_Password.SelectionLength = 0;
            this.tb_Password.SelectionStart = 0;
            this.tb_Password.ShortcutsEnabled = true;
            this.tb_Password.ShowButton = true;
            this.tb_Password.ShowClearButton = true;
            this.tb_Password.Size = new System.Drawing.Size(206, 23);
            this.tb_Password.TabIndex = 1;
            this.tb_Password.UseSelectable = true;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.WaterMark = "Пароль";
            this.tb_Password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_Password.WaterMarkFont = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Password.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.b_ShowPass_Click);
            this.tb_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Password_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(116, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 15);
            this.panel2.TabIndex = 16;
            this.panel2.DoubleClick += new System.EventHandler(this.Label2_DoubleClick);
            // 
            // f_DBLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 162);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Username);
            this.Controls.Add(this.but_cancel);
            this.Controls.Add(this.but_enter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_DBLogin";
            this.Resizable = false;
            this.Text = "Авторизация";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.f_DBLogin_Load);
            this.ResumeLayout(false);

		}

		#endregion
        private MetroFramework.Controls.MetroButton but_enter;
        private MetroFramework.Controls.MetroButton but_cancel;
        private MetroFramework.Controls.MetroTextBox tb_Username;
        private MetroFramework.Controls.MetroTextBox tb_Password;
        private System.Windows.Forms.Panel panel2;
    }
}

