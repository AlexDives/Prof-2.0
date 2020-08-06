namespace Prof
{
    partial class FUserMeneger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUserMeneger));
            this.dgv = new MetroFramework.Controls.MetroGrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fioPeople = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_close = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_save = new System.Windows.Forms.Button();
            this.b_new = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_pwdSecond = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_department = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_role = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cb_people = new System.Windows.Forms.ComboBox();
            this.rolesTableAdapter1 = new Prof.ProfDataSetTableAdapters.RolesTableAdapter();
            this.userRoleTableAdapter1 = new Prof.ProfDataSetTableAdapters.UserRoleTableAdapter();
            this.userDepartmentTableAdapter1 = new Prof.ProfDataSetTableAdapters.UserDepartmentTableAdapter();
            this.peopleDepartmentTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleDepartmentTableAdapter();
            this.usersTableAdapter1 = new Prof.ProfDataSetTableAdapters.UsersTableAdapter();
            this.peopleTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.login,
            this.fioPeople});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(20, 60);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(314, 257);
            this.dgv.TabIndex = 7;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // login
            // 
            this.login.FillWeight = 50F;
            this.login.HeaderText = "Логин";
            this.login.Name = "login";
            this.login.ReadOnly = true;
            // 
            // fioPeople
            // 
            this.fioPeople.HeaderText = "Ф.И.О.";
            this.fioPeople.Name = "fioPeople";
            this.fioPeople.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_login);
            this.groupBox1.Location = new System.Drawing.Point(343, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 42);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // tb_login
            // 
            this.tb_login.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_login.Location = new System.Drawing.Point(3, 16);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(179, 20);
            this.tb_login.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.b_close);
            this.panel1.Controls.Add(this.b_delete);
            this.panel1.Controls.Add(this.b_save);
            this.panel1.Controls.Add(this.b_new);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(334, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(376, 30);
            this.panel1.TabIndex = 0;
            // 
            // b_close
            // 
            this.b_close.Dock = System.Windows.Forms.DockStyle.Right;
            this.b_close.Location = new System.Drawing.Point(301, 0);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(75, 30);
            this.b_close.TabIndex = 3;
            this.b_close.Text = "Закрыть";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.button4_Click);
            // 
            // b_delete
            // 
            this.b_delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_delete.Location = new System.Drawing.Point(165, 0);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(75, 30);
            this.b_delete.TabIndex = 2;
            this.b_delete.Text = "Удалить";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.B_delete_Click);
            // 
            // b_save
            // 
            this.b_save.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_save.Location = new System.Drawing.Point(90, 0);
            this.b_save.Name = "b_save";
            this.b_save.Size = new System.Drawing.Size(75, 30);
            this.b_save.TabIndex = 1;
            this.b_save.Text = "Сохранить";
            this.b_save.UseVisualStyleBackColor = true;
            this.b_save.Click += new System.EventHandler(this.b_save_Click);
            // 
            // b_new
            // 
            this.b_new.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_new.Location = new System.Drawing.Point(15, 0);
            this.b_new.Name = "b_new";
            this.b_new.Size = new System.Drawing.Size(75, 30);
            this.b_new.TabIndex = 0;
            this.b_new.Text = "Новый";
            this.b_new.UseVisualStyleBackColor = true;
            this.b_new.Click += new System.EventHandler(this.b_new_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_pwdSecond);
            this.groupBox2.Location = new System.Drawing.Point(534, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 42);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Повторить пароль";
            // 
            // tb_pwdSecond
            // 
            this.tb_pwdSecond.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_pwdSecond.Location = new System.Drawing.Point(3, 16);
            this.tb_pwdSecond.Name = "tb_pwdSecond";
            this.tb_pwdSecond.PasswordChar = '*';
            this.tb_pwdSecond.Size = new System.Drawing.Size(167, 20);
            this.tb_pwdSecond.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_pwd);
            this.groupBox3.Location = new System.Drawing.Point(343, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 42);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Пароль";
            // 
            // tb_pwd
            // 
            this.tb_pwd.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_pwd.Location = new System.Drawing.Point(3, 16);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.PasswordChar = '*';
            this.tb_pwd.Size = new System.Drawing.Size(179, 20);
            this.tb_pwd.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_department);
            this.groupBox4.Location = new System.Drawing.Point(343, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(367, 42);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Подразделение";
            // 
            // cb_department
            // 
            this.cb_department.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_department.FormattingEnabled = true;
            this.cb_department.Location = new System.Drawing.Point(3, 16);
            this.cb_department.Name = "cb_department";
            this.cb_department.Size = new System.Drawing.Size(361, 21);
            this.cb_department.TabIndex = 0;
            this.cb_department.SelectedIndexChanged += new System.EventHandler(this.cb_department_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_role);
            this.groupBox5.Location = new System.Drawing.Point(534, 192);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 42);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Роль";
            // 
            // cb_role
            // 
            this.cb_role.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_role.FormattingEnabled = true;
            this.cb_role.Location = new System.Drawing.Point(3, 16);
            this.cb_role.Name = "cb_role";
            this.cb_role.Size = new System.Drawing.Size(167, 21);
            this.cb_role.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cb_people);
            this.groupBox6.Location = new System.Drawing.Point(343, 144);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(367, 42);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ответственный";
            // 
            // cb_people
            // 
            this.cb_people.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_people.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_people.FormattingEnabled = true;
            this.cb_people.Location = new System.Drawing.Point(3, 16);
            this.cb_people.Name = "cb_people";
            this.cb_people.Size = new System.Drawing.Size(361, 21);
            this.cb_people.TabIndex = 1;
            // 
            // rolesTableAdapter1
            // 
            this.rolesTableAdapter1.ClearBeforeFill = true;
            // 
            // userRoleTableAdapter1
            // 
            this.userRoleTableAdapter1.ClearBeforeFill = true;
            // 
            // userDepartmentTableAdapter1
            // 
            this.userDepartmentTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleDepartmentTableAdapter1
            // 
            this.peopleDepartmentTableAdapter1.ClearBeforeFill = true;
            // 
            // usersTableAdapter1
            // 
            this.usersTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleTableAdapter1
            // 
            this.peopleTableAdapter1.ClearBeforeFill = true;
            // 
            // FUserMeneger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 337);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUserMeneger";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Менеджер пользователей";
            this.Load += new System.EventHandler(this.FUserMeneger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroGrid dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn fioPeople;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_pwdSecond;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button b_close;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_save;
        private System.Windows.Forms.Button b_new;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cb_department;
        private System.Windows.Forms.ComboBox cb_people;
        private System.Windows.Forms.ComboBox cb_role;
        private ProfDataSetTableAdapters.RolesTableAdapter rolesTableAdapter1;
        private ProfDataSetTableAdapters.UserRoleTableAdapter userRoleTableAdapter1;
        private ProfDataSetTableAdapters.UserDepartmentTableAdapter userDepartmentTableAdapter1;
        private ProfDataSetTableAdapters.PeopleDepartmentTableAdapter peopleDepartmentTableAdapter1;
        private ProfDataSetTableAdapters.UsersTableAdapter usersTableAdapter1;
        private ProfDataSetTableAdapters.PeopleTableAdapter peopleTableAdapter1;
    }
}