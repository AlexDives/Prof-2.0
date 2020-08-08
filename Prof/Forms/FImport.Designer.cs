namespace Prof
{
    partial class FImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FImport));
            this.p_top = new System.Windows.Forms.Panel();
            this.rb_s = new System.Windows.Forms.RadioButton();
            this.rb_w = new System.Windows.Forms.RadioButton();
            this.label45 = new System.Windows.Forms.Label();
            this.cb_dep = new System.Windows.Forms.ComboBox();
            this.p_browse = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.b_import = new System.Windows.Forms.Button();
            this.b_browse = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.famil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberProf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEnter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPens = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.startJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docSer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whoDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propiska = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nagr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obshDejat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hobbies = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleTableAdapter();
            this.departmentsTableAdapter1 = new Prof.ProfDataSetTableAdapters.DepartmentsTableAdapter();
            this.peopleDepartmentTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleDepartmentTableAdapter();
            this.p_top.SuspendLayout();
            this.p_browse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // p_top
            // 
            this.p_top.Controls.Add(this.rb_s);
            this.p_top.Controls.Add(this.rb_w);
            this.p_top.Controls.Add(this.label45);
            this.p_top.Controls.Add(this.cb_dep);
            this.p_top.Controls.Add(this.p_browse);
            this.p_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_top.Location = new System.Drawing.Point(20, 60);
            this.p_top.Name = "p_top";
            this.p_top.Size = new System.Drawing.Size(1207, 59);
            this.p_top.TabIndex = 0;
            // 
            // rb_s
            // 
            this.rb_s.AutoSize = true;
            this.rb_s.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_s.Location = new System.Drawing.Point(771, 32);
            this.rb_s.Name = "rb_s";
            this.rb_s.Size = new System.Drawing.Size(64, 17);
            this.rb_s.TabIndex = 38;
            this.rb_s.Text = "Студент";
            this.rb_s.UseVisualStyleBackColor = true;
            // 
            // rb_w
            // 
            this.rb_w.AutoSize = true;
            this.rb_w.Checked = true;
            this.rb_w.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rb_w.Location = new System.Drawing.Point(688, 32);
            this.rb_w.Name = "rb_w";
            this.rb_w.Size = new System.Drawing.Size(77, 17);
            this.rb_w.TabIndex = 37;
            this.rb_w.TabStop = true;
            this.rb_w.Text = "Сотрудник";
            this.rb_w.UseVisualStyleBackColor = true;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.Location = new System.Drawing.Point(7, 33);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(127, 16);
            this.label45.TabIndex = 36;
            this.label45.Text = "Подразделение";
            // 
            // cb_dep
            // 
            this.cb_dep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dep.FormattingEnabled = true;
            this.cb_dep.Location = new System.Drawing.Point(140, 32);
            this.cb_dep.Name = "cb_dep";
            this.cb_dep.Size = new System.Drawing.Size(532, 21);
            this.cb_dep.TabIndex = 35;
            // 
            // p_browse
            // 
            this.p_browse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_browse.Controls.Add(this.button2);
            this.p_browse.Controls.Add(this.b_import);
            this.p_browse.Controls.Add(this.b_browse);
            this.p_browse.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_browse.Location = new System.Drawing.Point(0, 0);
            this.p_browse.Name = "p_browse";
            this.p_browse.Size = new System.Drawing.Size(1207, 26);
            this.p_browse.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1083, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 24);
            this.button2.TabIndex = 5;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // b_import
            // 
            this.b_import.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_import.Location = new System.Drawing.Point(129, 0);
            this.b_import.Name = "b_import";
            this.b_import.Size = new System.Drawing.Size(122, 24);
            this.b_import.TabIndex = 4;
            this.b_import.Text = "Импортировать";
            this.b_import.UseVisualStyleBackColor = true;
            this.b_import.Click += new System.EventHandler(this.B_import_Click);
            // 
            // b_browse
            // 
            this.b_browse.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_browse.Location = new System.Drawing.Point(0, 0);
            this.b_browse.Name = "b_browse";
            this.b_browse.Size = new System.Drawing.Size(129, 24);
            this.b_browse.TabIndex = 2;
            this.b_browse.Text = "Выбрать файл Excel";
            this.b_browse.UseVisualStyleBackColor = true;
            this.b_browse.Click += new System.EventHandler(this.B_browse_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar1.Location = new System.Drawing.Point(20, 119);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1207, 17);
            this.progressBar1.TabIndex = 1;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.number,
            this.Column1,
            this.Column2,
            this.famil,
            this.name,
            this.otch,
            this.sex,
            this.birthday,
            this.phone,
            this.numberProf,
            this.dateEnter,
            this.isPens,
            this.startJob,
            this.isDoc,
            this.docSer,
            this.docNum,
            this.dateDoc,
            this.whoDoc,
            this.propiska,
            this.nagr,
            this.obshDejat,
            this.hobbies});
            this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv2.Location = new System.Drawing.Point(20, 136);
            this.dgv2.MultiSelect = false;
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.RowHeadersVisible = false;
            this.dgv2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(1207, 294);
            this.dgv2.TabIndex = 3;
            // 
            // number
            // 
            this.number.FillWeight = 64F;
            this.number.Frozen = true;
            this.number.HeaderText = "№";
            this.number.Name = "number";
            this.number.ReadOnly = true;
            this.number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.number.Width = 43;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "СПП";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "СПВ";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // famil
            // 
            this.famil.HeaderText = "Фамилия";
            this.famil.Name = "famil";
            this.famil.ReadOnly = true;
            this.famil.Width = 81;
            // 
            // name
            // 
            this.name.HeaderText = "Имя";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 54;
            // 
            // otch
            // 
            this.otch.HeaderText = "Отчество";
            this.otch.Name = "otch";
            this.otch.ReadOnly = true;
            this.otch.Width = 79;
            // 
            // sex
            // 
            this.sex.HeaderText = "Пол";
            this.sex.Name = "sex";
            this.sex.ReadOnly = true;
            this.sex.Width = 52;
            // 
            // birthday
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.birthday.DefaultCellStyle = dataGridViewCellStyle1;
            this.birthday.HeaderText = "Дата рождения";
            this.birthday.Name = "birthday";
            this.birthday.ReadOnly = true;
            this.birthday.Width = 102;
            // 
            // phone
            // 
            this.phone.HeaderText = "Телефон";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 77;
            // 
            // numberProf
            // 
            this.numberProf.HeaderText = "Ном. проф. билета";
            this.numberProf.Name = "numberProf";
            this.numberProf.ReadOnly = true;
            this.numberProf.Width = 116;
            // 
            // dateEnter
            // 
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.dateEnter.DefaultCellStyle = dataGridViewCellStyle2;
            this.dateEnter.HeaderText = "Дата вступления";
            this.dateEnter.Name = "dateEnter";
            this.dateEnter.ReadOnly = true;
            this.dateEnter.Width = 109;
            // 
            // isPens
            // 
            this.isPens.HeaderText = "Пенсионер";
            this.isPens.Name = "isPens";
            this.isPens.ReadOnly = true;
            this.isPens.Width = 69;
            // 
            // startJob
            // 
            this.startJob.HeaderText = "Начало трудовой деятельности";
            this.startJob.Name = "startJob";
            this.startJob.ReadOnly = true;
            this.startJob.Width = 174;
            // 
            // isDoc
            // 
            this.isDoc.HeaderText = "Тип документа";
            this.isDoc.Name = "isDoc";
            this.isDoc.ReadOnly = true;
            this.isDoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isDoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.isDoc.Width = 80;
            // 
            // docSer
            // 
            this.docSer.HeaderText = "Серия документа";
            this.docSer.Name = "docSer";
            this.docSer.ReadOnly = true;
            this.docSer.Width = 110;
            // 
            // docNum
            // 
            this.docNum.HeaderText = "Номер документа";
            this.docNum.Name = "docNum";
            this.docNum.ReadOnly = true;
            this.docNum.Width = 113;
            // 
            // dateDoc
            // 
            dataGridViewCellStyle3.Format = "d";
            this.dateDoc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dateDoc.HeaderText = "Дата выдачи документа";
            this.dateDoc.Name = "dateDoc";
            this.dateDoc.ReadOnly = true;
            this.dateDoc.Width = 141;
            // 
            // whoDoc
            // 
            this.whoDoc.HeaderText = "Где выдан документ";
            this.whoDoc.Name = "whoDoc";
            this.whoDoc.ReadOnly = true;
            this.whoDoc.Width = 124;
            // 
            // propiska
            // 
            this.propiska.HeaderText = "Прописка";
            this.propiska.Name = "propiska";
            this.propiska.ReadOnly = true;
            this.propiska.Width = 82;
            // 
            // nagr
            // 
            this.nagr.HeaderText = "Нагрузка";
            this.nagr.Name = "nagr";
            this.nagr.ReadOnly = true;
            this.nagr.Width = 80;
            // 
            // obshDejat
            // 
            this.obshDejat.HeaderText = "Общественная деятельность";
            this.obshDejat.Name = "obshDejat";
            this.obshDejat.ReadOnly = true;
            this.obshDejat.Width = 165;
            // 
            // hobbies
            // 
            this.hobbies.HeaderText = "Хобби";
            this.hobbies.Name = "hobbies";
            this.hobbies.ReadOnly = true;
            this.hobbies.Width = 63;
            // 
            // peopleTableAdapter1
            // 
            this.peopleTableAdapter1.ClearBeforeFill = true;
            // 
            // departmentsTableAdapter1
            // 
            this.departmentsTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleDepartmentTableAdapter1
            // 
            this.peopleDepartmentTableAdapter1.ClearBeforeFill = true;
            // 
            // FImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 450);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.p_top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Импорт данных";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FImport_Load);
            this.p_top.ResumeLayout(false);
            this.p_top.PerformLayout();
            this.p_browse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_top;
        private System.Windows.Forms.Panel p_browse;
        private System.Windows.Forms.Button b_browse;
        private System.Windows.Forms.Button b_import;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cb_dep;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rb_s;
        private System.Windows.Forms.RadioButton rb_w;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn famil;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn otch;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberProf;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEnter;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPens;
        private System.Windows.Forms.DataGridViewTextBoxColumn startJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn isDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn docSer;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn whoDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn propiska;
        private System.Windows.Forms.DataGridViewTextBoxColumn nagr;
        private System.Windows.Forms.DataGridViewTextBoxColumn obshDejat;
        private System.Windows.Forms.DataGridViewTextBoxColumn hobbies;
        private ProfDataSetTableAdapters.DepartmentsTableAdapter departmentsTableAdapter1;
        private ProfDataSetTableAdapters.PeopleTableAdapter peopleTableAdapter1;
        private ProfDataSetTableAdapters.PeopleDepartmentTableAdapter peopleDepartmentTableAdapter1;
    }
}