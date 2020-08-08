namespace Prof
{
    partial class FMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_userMeneger = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_sprav = new System.Windows.Forms.ToolStripMenuItem();
            this.импортИзToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_add = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_search = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистическийОтчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.детиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мастерОтчетовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_showNotAll = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.but_newVersion = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_info = new System.Windows.Forms.Label();
            this.dgv = new MetroFramework.Controls.MetroGrid();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_All = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_inProf = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_OutProf = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Child = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.l_fullDepart = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tree_department = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.refreshTree = new System.Windows.Forms.Button();
            this.rb_exitProf = new System.Windows.Forms.RadioButton();
            this.rb_inProf = new System.Windows.Forms.RadioButton();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.timer_update = new System.Windows.Forms.Timer(this.components);
            this.ds_get_tree = new System.Windows.Forms.BindingSource(this.components);
            this.profDataSet = new Prof.ProfDataSet();
            this.get_treeTableAdapter = new Prof.ProfDataSetTableAdapters.get_treeTableAdapter();
            this.peopleDepartmentTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleDepartmentTableAdapter();
            this.departmentsTableAdapter1 = new Prof.ProfDataSetTableAdapters.DepartmentsTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_get_tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.редактироватьToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_userMeneger,
            this.tsm_sprav,
            this.импортИзToolStripMenuItem,
            this.toolStripSeparator1,
            this.tsm_exit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // tsm_userMeneger
            // 
            this.tsm_userMeneger.Name = "tsm_userMeneger";
            this.tsm_userMeneger.Size = new System.Drawing.Size(229, 22);
            this.tsm_userMeneger.Text = "Менеджер пользователей";
            this.tsm_userMeneger.Click += new System.EventHandler(this.tsm_userMeneger_Click);
            // 
            // tsm_sprav
            // 
            this.tsm_sprav.Name = "tsm_sprav";
            this.tsm_sprav.Size = new System.Drawing.Size(229, 22);
            this.tsm_sprav.Text = "Справочник подразделений";
            this.tsm_sprav.Click += new System.EventHandler(this.tsm_sprav_Click);
            // 
            // импортИзToolStripMenuItem
            // 
            this.импортИзToolStripMenuItem.Name = "импортИзToolStripMenuItem";
            this.импортИзToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.импортИзToolStripMenuItem.Text = "Импорт из ...";
            this.импортИзToolStripMenuItem.Visible = false;
            this.импортИзToolStripMenuItem.Click += new System.EventHandler(this.ИмпортИзToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // tsm_exit
            // 
            this.tsm_exit.Name = "tsm_exit";
            this.tsm_exit.Size = new System.Drawing.Size(229, 22);
            this.tsm_exit.Text = "Закрыть";
            this.tsm_exit.Click += new System.EventHandler(this.tsm_exit_Click);
            // 
            // редактироватьToolStripMenuItem
            // 
            this.редактироватьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_add,
            this.tsm_edit,
            this.tsm_delete,
            this.toolStripSeparator2,
            this.tsm_search});
            this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.редактироватьToolStripMenuItem.Text = "Редактировать";
            // 
            // tsm_add
            // 
            this.tsm_add.Name = "tsm_add";
            this.tsm_add.Size = new System.Drawing.Size(154, 22);
            this.tsm_add.Text = "Добавить";
            this.tsm_add.Click += new System.EventHandler(this.tsm_add_Click);
            // 
            // tsm_edit
            // 
            this.tsm_edit.Enabled = false;
            this.tsm_edit.Name = "tsm_edit";
            this.tsm_edit.Size = new System.Drawing.Size(154, 22);
            this.tsm_edit.Text = "Редактировать";
            this.tsm_edit.Click += new System.EventHandler(this.tsm_edit_Click);
            // 
            // tsm_delete
            // 
            this.tsm_delete.Name = "tsm_delete";
            this.tsm_delete.Size = new System.Drawing.Size(154, 22);
            this.tsm_delete.Text = "Удалить";
            this.tsm_delete.Click += new System.EventHandler(this.tsm_delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // tsm_search
            // 
            this.tsm_search.Name = "tsm_search";
            this.tsm_search.Size = new System.Drawing.Size(154, 22);
            this.tsm_search.Text = "Поиск";
            this.tsm_search.Click += new System.EventHandler(this.tsm_search_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статистическийОтчетToolStripMenuItem,
            this.детиToolStripMenuItem,
            this.мастерОтчетовToolStripMenuItem1});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // статистическийОтчетToolStripMenuItem
            // 
            this.статистическийОтчетToolStripMenuItem.Name = "статистическийОтчетToolStripMenuItem";
            this.статистическийОтчетToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.статистическийОтчетToolStripMenuItem.Text = "Статистический отчет";
            this.статистическийОтчетToolStripMenuItem.Click += new System.EventHandler(this.статистическийОтчетToolStripMenuItem_Click);
            // 
            // детиToolStripMenuItem
            // 
            this.детиToolStripMenuItem.Name = "детиToolStripMenuItem";
            this.детиToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.детиToolStripMenuItem.Text = "Список детей";
            this.детиToolStripMenuItem.Click += new System.EventHandler(this.детиToolStripMenuItem_Click);
            // 
            // мастерОтчетовToolStripMenuItem1
            // 
            this.мастерОтчетовToolStripMenuItem1.Name = "мастерОтчетовToolStripMenuItem1";
            this.мастерОтчетовToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.мастерОтчетовToolStripMenuItem1.Text = "Мастер отчетов";
            this.мастерОтчетовToolStripMenuItem1.Click += new System.EventHandler(this.мастерОтчетовToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_showNotAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(450, 26);
            // 
            // tsmi_showNotAll
            // 
            this.tsmi_showNotAll.Checked = true;
            this.tsmi_showNotAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmi_showNotAll.Name = "tsmi_showNotAll";
            this.tsmi_showNotAll.Size = new System.Drawing.Size(449, 22);
            this.tsmi_showNotAll.Text = "Отображать членов профсоюза только выбранного подразделения";
            this.tsmi_showNotAll.Click += new System.EventHandler(this.tsmi_showNotAll_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.but_newVersion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(20, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 29);
            this.panel2.TabIndex = 3;
            // 
            // but_newVersion
            // 
            this.but_newVersion.BackColor = System.Drawing.Color.Firebrick;
            this.but_newVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_newVersion.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.but_newVersion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.but_newVersion.Location = new System.Drawing.Point(530, 0);
            this.but_newVersion.Name = "but_newVersion";
            this.but_newVersion.Size = new System.Drawing.Size(230, 29);
            this.but_newVersion.TabIndex = 3;
            this.but_newVersion.Text = "Вышло новое обновление!";
            this.but_newVersion.UseCustomBackColor = true;
            this.but_newVersion.UseCustomForeColor = true;
            this.but_newVersion.UseSelectable = true;
            this.but_newVersion.Visible = false;
            this.but_newVersion.Click += new System.EventHandler(this.but_newVersion_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(760, 29);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label_info);
            this.panel4.Controls.Add(this.dgv);
            this.panel4.Controls.Add(this.statusStrip1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(209, 84);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(571, 467);
            this.panel4.TabIndex = 7;
            // 
            // label_info
            // 
            this.label_info.BackColor = System.Drawing.Color.White;
            this.label_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_info.Location = new System.Drawing.Point(0, 59);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(569, 384);
            this.label_info.TabIndex = 8;
            this.label_info.Text = "Для загрузки списка членов профсоюза, требуется выбрать подразделение в списке сл" +
    "ева.";
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(0, 59);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 20;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(569, 384);
            this.dgv.TabIndex = 7;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_All,
            this.toolStripStatusLabel2,
            this.tssl_inProf,
            this.toolStripStatusLabel1,
            this.tssl_OutProf,
            this.toolStripStatusLabel3,
            this.tssl_Child});
            this.statusStrip1.Location = new System.Drawing.Point(0, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssl_All
            // 
            this.tssl_All.Name = "tssl_All";
            this.tssl_All.Size = new System.Drawing.Size(41, 17);
            this.tssl_All.Text = "Всего:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // tssl_inProf
            // 
            this.tssl_inProf.Name = "tssl_inProf";
            this.tssl_inProf.Size = new System.Drawing.Size(84, 17);
            this.tssl_inProf.Text = "В профсоюзе:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssl_OutProf
            // 
            this.tssl_OutProf.Name = "tssl_OutProf";
            this.tssl_OutProf.Size = new System.Drawing.Size(133, 17);
            this.tssl_OutProf.Text = "Вышло из профсоюза:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // tssl_Child
            // 
            this.tssl_Child.Name = "tssl_Child";
            this.tssl_Child.Size = new System.Drawing.Size(77, 17);
            this.tssl_Child.Text = "Всего детей: ";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.l_fullDepart);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(569, 59);
            this.panel5.TabIndex = 2;
            // 
            // l_fullDepart
            // 
            this.l_fullDepart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.l_fullDepart.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_fullDepart.Location = new System.Drawing.Point(0, 0);
            this.l_fullDepart.Name = "l_fullDepart";
            this.l_fullDepart.Size = new System.Drawing.Size(567, 57);
            this.l_fullDepart.TabIndex = 2;
            this.l_fullDepart.Text = "Не выбрано";
            this.l_fullDepart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(204, 84);
            this.splitter1.MinExtra = 5;
            this.splitter1.MinSize = 5;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 467);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tree_department);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(20, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 467);
            this.panel1.TabIndex = 5;
            // 
            // tree_department
            // 
            this.tree_department.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree_department.ContextMenuStrip = this.contextMenuStrip1;
            this.tree_department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_department.Location = new System.Drawing.Point(0, 88);
            this.tree_department.Name = "tree_department";
            this.tree_department.Size = new System.Drawing.Size(182, 377);
            this.tree_department.TabIndex = 1;
            this.tree_department.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_department_AfterSelect);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.refreshTree);
            this.panel3.Controls.Add(this.rb_exitProf);
            this.panel3.Controls.Add(this.rb_inProf);
            this.panel3.Controls.Add(this.rb_all);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 88);
            this.panel3.TabIndex = 0;
            // 
            // refreshTree
            // 
            this.refreshTree.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshTree.Location = new System.Drawing.Point(0, 65);
            this.refreshTree.Name = "refreshTree";
            this.refreshTree.Size = new System.Drawing.Size(182, 23);
            this.refreshTree.TabIndex = 3;
            this.refreshTree.Text = "Обновить";
            this.refreshTree.UseVisualStyleBackColor = true;
            this.refreshTree.Click += new System.EventHandler(this.refreshTree_Click);
            // 
            // rb_exitProf
            // 
            this.rb_exitProf.AutoSize = true;
            this.rb_exitProf.Location = new System.Drawing.Point(11, 47);
            this.rb_exitProf.Name = "rb_exitProf";
            this.rb_exitProf.Size = new System.Drawing.Size(136, 17);
            this.rb_exitProf.TabIndex = 2;
            this.rb_exitProf.Text = "Вышел из профсоюза";
            this.rb_exitProf.UseVisualStyleBackColor = true;
            this.rb_exitProf.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_inProf
            // 
            this.rb_inProf.AutoSize = true;
            this.rb_inProf.Checked = true;
            this.rb_inProf.Location = new System.Drawing.Point(11, 25);
            this.rb_inProf.Name = "rb_inProf";
            this.rb_inProf.Size = new System.Drawing.Size(93, 17);
            this.rb_inProf.TabIndex = 1;
            this.rb_inProf.TabStop = true;
            this.rb_inProf.Text = "В профсоюзе";
            this.rb_inProf.UseVisualStyleBackColor = true;
            this.rb_inProf.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Location = new System.Drawing.Point(11, 4);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(44, 17);
            this.rb_all.TabIndex = 0;
            this.rb_all.Text = "Все";
            this.rb_all.UseVisualStyleBackColor = true;
            this.rb_all.CheckedChanged += new System.EventHandler(this.rb_all_CheckedChanged);
            // 
            // timer_update
            // 
            this.timer_update.Interval = 300000;
            this.timer_update.Tick += new System.EventHandler(this.timer_update_Tick);
            // 
            // ds_get_tree
            // 
            this.ds_get_tree.DataMember = "get_tree";
            this.ds_get_tree.DataSource = this.profDataSet;
            // 
            // profDataSet
            // 
            this.profDataSet.DataSetName = "ProfDataSet";
            this.profDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // get_treeTableAdapter
            // 
            this.get_treeTableAdapter.ClearBeforeFill = true;
            // 
            // peopleDepartmentTableAdapter1
            // 
            this.peopleDepartmentTableAdapter1.ClearBeforeFill = true;
            // 
            // departmentsTableAdapter1
            // 
            this.departmentsTableAdapter1.ClearBeforeFill = true;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(784, 561);
            this.Name = "FMain";
            this.Text = "Профсоюз";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_get_tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm_userMeneger;
        private System.Windows.Forms.ToolStripMenuItem tsm_sprav;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsm_exit;
        private System.Windows.Forms.ToolStripMenuItem редактироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm_add;
        private System.Windows.Forms.ToolStripMenuItem tsm_edit;
        private System.Windows.Forms.ToolStripMenuItem tsm_delete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_showNotAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsm_search;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистическийОтчетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem детиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мастерОтчетовToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_All;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_inProf;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_OutProf;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Child;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label l_fullDepart;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tree_department;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rb_exitProf;
        private System.Windows.Forms.RadioButton rb_inProf;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.ToolStripMenuItem импортИзToolStripMenuItem;
        private System.Windows.Forms.Button refreshTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_update;
        private MetroFramework.Controls.MetroGrid dgv;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.BindingSource ds_get_tree;
        private ProfDataSetTableAdapters.get_treeTableAdapter get_treeTableAdapter;
        private ProfDataSet profDataSet;
        private ProfDataSetTableAdapters.PeopleDepartmentTableAdapter peopleDepartmentTableAdapter1;
        private ProfDataSetTableAdapters.DepartmentsTableAdapter departmentsTableAdapter1;
        private MetroFramework.Controls.MetroButton but_newVersion;
    }
}

