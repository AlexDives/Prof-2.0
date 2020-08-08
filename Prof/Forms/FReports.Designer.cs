namespace Prof
{
    partial class FReports
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReports));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tree_department = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_showNotAll = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rb_exitProf = new System.Windows.Forms.RadioButton();
            this.rb_inProf = new System.Windows.Forms.RadioButton();
            this.rb_all_prof = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cb_period = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtp_periodStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dtp_periodEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.clb_other = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clb_livingConditions = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clb_socialStatus = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_femaly = new System.Windows.Forms.RadioButton();
            this.rb_male = new System.Windows.Forms.RadioButton();
            this.rb_all = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssl_All = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_male = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_female = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Child = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedLoadGrid = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv = new MetroFramework.Controls.MetroGrid();
            this.peopleWorkTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleWorkTableAdapter();
            this.get_treeTableAdapter1 = new Prof.ProfDataSetTableAdapters.get_treeTableAdapter();
            this.typeSocialStatusTableAdapter1 = new Prof.ProfDataSetTableAdapters.TypeSocialStatusTableAdapter();
            this.typeLivingConditionsTableAdapter1 = new Prof.ProfDataSetTableAdapters.TypeLivingConditionsTableAdapter();
            this.peopleChildrenTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleChildrenTableAdapter();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Export from Prof";
            this.saveFileDialog1.Filter = "Excel |*.xlsx";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tree_department);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(184, 522);
            this.panel3.TabIndex = 7;
            // 
            // tree_department
            // 
            this.tree_department.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tree_department.ContextMenuStrip = this.contextMenuStrip1;
            this.tree_department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_department.Location = new System.Drawing.Point(0, 69);
            this.tree_department.Name = "tree_department";
            this.tree_department.Size = new System.Drawing.Size(182, 451);
            this.tree_department.TabIndex = 1;
            this.tree_department.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_department_AfterSelect);
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
            // panel4
            // 
            this.panel4.Controls.Add(this.rb_exitProf);
            this.panel4.Controls.Add(this.rb_inProf);
            this.panel4.Controls.Add(this.rb_all_prof);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(182, 69);
            this.panel4.TabIndex = 0;
            // 
            // rb_exitProf
            // 
            this.rb_exitProf.AutoSize = true;
            this.rb_exitProf.Location = new System.Drawing.Point(11, 46);
            this.rb_exitProf.Name = "rb_exitProf";
            this.rb_exitProf.Size = new System.Drawing.Size(136, 17);
            this.rb_exitProf.TabIndex = 2;
            this.rb_exitProf.Text = "Вышел из профсоюза";
            this.rb_exitProf.UseVisualStyleBackColor = true;
            this.rb_exitProf.CheckedChanged += new System.EventHandler(this.rb_all_prof_CheckedChanged);
            // 
            // rb_inProf
            // 
            this.rb_inProf.AutoSize = true;
            this.rb_inProf.Checked = true;
            this.rb_inProf.Location = new System.Drawing.Point(11, 24);
            this.rb_inProf.Name = "rb_inProf";
            this.rb_inProf.Size = new System.Drawing.Size(93, 17);
            this.rb_inProf.TabIndex = 1;
            this.rb_inProf.TabStop = true;
            this.rb_inProf.Text = "В профсоюзе";
            this.rb_inProf.UseVisualStyleBackColor = true;
            this.rb_inProf.CheckedChanged += new System.EventHandler(this.rb_all_prof_CheckedChanged);
            // 
            // rb_all_prof
            // 
            this.rb_all_prof.AutoSize = true;
            this.rb_all_prof.Location = new System.Drawing.Point(11, 3);
            this.rb_all_prof.Name = "rb_all_prof";
            this.rb_all_prof.Size = new System.Drawing.Size(44, 17);
            this.rb_all_prof.TabIndex = 0;
            this.rb_all_prof.Text = "Все";
            this.rb_all_prof.UseVisualStyleBackColor = true;
            this.rb_all_prof.CheckedChanged += new System.EventHandler(this.rb_all_prof_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(204, 60);
            this.splitter1.MinExtra = 5;
            this.splitter1.MinSize = 5;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 522);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroProgressBar1);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(209, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 123);
            this.panel2.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cb_period);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(780, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(106, 123);
            this.groupBox5.TabIndex = 52;
            this.groupBox5.TabStop = false;
            // 
            // cb_period
            // 
            this.cb_period.AutoSize = true;
            this.cb_period.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_period.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_period.Location = new System.Drawing.Point(3, 16);
            this.cb_period.Name = "cb_period";
            this.cb_period.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cb_period.Size = new System.Drawing.Size(100, 17);
            this.cb_period.TabIndex = 4;
            this.cb_period.Text = "За период";
            this.cb_period.UseVisualStyleBackColor = true;
            this.cb_period.CheckedChanged += new System.EventHandler(this.cb_period_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtp_periodStart);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 48);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(100, 36);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "От";
            // 
            // dtp_periodStart
            // 
            this.dtp_periodStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtp_periodStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_periodStart.Location = new System.Drawing.Point(3, 16);
            this.dtp_periodStart.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp_periodStart.Name = "dtp_periodStart";
            this.dtp_periodStart.Size = new System.Drawing.Size(94, 20);
            this.dtp_periodStart.TabIndex = 1;
            this.dtp_periodStart.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtp_periodStart.ValueChanged += new System.EventHandler(this.dtp_periodStart_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dtp_periodEnd);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(3, 84);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(100, 36);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "До";
            // 
            // dtp_periodEnd
            // 
            this.dtp_periodEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtp_periodEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_periodEnd.Location = new System.Drawing.Point(3, 16);
            this.dtp_periodEnd.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtp_periodEnd.Name = "dtp_periodEnd";
            this.dtp_periodEnd.Size = new System.Drawing.Size(94, 20);
            this.dtp_periodEnd.TabIndex = 1;
            this.dtp_periodEnd.Value = new System.DateTime(2019, 3, 17, 0, 0, 0, 0);
            this.dtp_periodEnd.ValueChanged += new System.EventHandler(this.dtp_periodStart_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.clb_other);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(555, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 123);
            this.groupBox4.TabIndex = 51;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Другое";
            // 
            // clb_other
            // 
            this.clb_other.CheckOnClick = true;
            this.clb_other.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_other.FormattingEnabled = true;
            this.clb_other.Items.AddRange(new object[] {
            "Младший специалист (до 3х лет)",
            "До 35 лет",
            "Пенсионер"});
            this.clb_other.Location = new System.Drawing.Point(3, 16);
            this.clb_other.Name = "clb_other";
            this.clb_other.Size = new System.Drawing.Size(219, 104);
            this.clb_other.TabIndex = 49;
            this.clb_other.SelectedIndexChanged += new System.EventHandler(this.clb_socialStatus_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clb_livingConditions);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(330, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 123);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Жилищные условия";
            // 
            // clb_livingConditions
            // 
            this.clb_livingConditions.CheckOnClick = true;
            this.clb_livingConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_livingConditions.FormattingEnabled = true;
            this.clb_livingConditions.Location = new System.Drawing.Point(3, 16);
            this.clb_livingConditions.Name = "clb_livingConditions";
            this.clb_livingConditions.Size = new System.Drawing.Size(219, 104);
            this.clb_livingConditions.TabIndex = 45;
            this.clb_livingConditions.SelectedIndexChanged += new System.EventHandler(this.clb_socialStatus_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clb_socialStatus);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(105, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 123);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Социальный статус";
            // 
            // clb_socialStatus
            // 
            this.clb_socialStatus.CheckOnClick = true;
            this.clb_socialStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clb_socialStatus.FormattingEnabled = true;
            this.clb_socialStatus.Location = new System.Drawing.Point(3, 16);
            this.clb_socialStatus.Name = "clb_socialStatus";
            this.clb_socialStatus.Size = new System.Drawing.Size(219, 104);
            this.clb_socialStatus.TabIndex = 43;
            this.clb_socialStatus.SelectedIndexChanged += new System.EventHandler(this.clb_socialStatus_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_femaly);
            this.groupBox2.Controls.Add(this.rb_male);
            this.groupBox2.Controls.Add(this.rb_all);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 123);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пол";
            // 
            // rb_femaly
            // 
            this.rb_femaly.AutoSize = true;
            this.rb_femaly.Location = new System.Drawing.Point(5, 65);
            this.rb_femaly.Name = "rb_femaly";
            this.rb_femaly.Size = new System.Drawing.Size(72, 17);
            this.rb_femaly.TabIndex = 2;
            this.rb_femaly.Text = "Женский";
            this.rb_femaly.UseVisualStyleBackColor = true;
            this.rb_femaly.CheckedChanged += new System.EventHandler(this.rb_male_CheckedChanged);
            // 
            // rb_male
            // 
            this.rb_male.AutoSize = true;
            this.rb_male.Location = new System.Drawing.Point(6, 42);
            this.rb_male.Name = "rb_male";
            this.rb_male.Size = new System.Drawing.Size(71, 17);
            this.rb_male.TabIndex = 1;
            this.rb_male.Text = "Мужской";
            this.rb_male.UseVisualStyleBackColor = true;
            this.rb_male.CheckedChanged += new System.EventHandler(this.rb_male_CheckedChanged);
            // 
            // rb_all
            // 
            this.rb_all.AutoSize = true;
            this.rb_all.Checked = true;
            this.rb_all.Location = new System.Drawing.Point(6, 19);
            this.rb_all.Name = "rb_all";
            this.rb_all.Size = new System.Drawing.Size(44, 17);
            this.rb_all.TabIndex = 0;
            this.rb_all.TabStop = true;
            this.rb_all.Text = "Все";
            this.rb_all.UseVisualStyleBackColor = true;
            this.rb_all.CheckedChanged += new System.EventHandler(this.rb_male_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(892, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Экспорт в Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_All,
            this.toolStripStatusLabel2,
            this.tssl_male,
            this.toolStripStatusLabel1,
            this.tssl_female,
            this.toolStripStatusLabel3,
            this.tssl_Child,
            this.toolStripStatusLabel4,
            this.speedLoadGrid});
            this.statusStrip1.Location = new System.Drawing.Point(209, 560);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 13;
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
            // tssl_male
            // 
            this.tssl_male.Name = "tssl_male";
            this.tssl_male.Size = new System.Drawing.Size(57, 17);
            this.tssl_male.Text = "Мужчин:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssl_female
            // 
            this.tssl_female.Name = "tssl_female";
            this.tssl_female.Size = new System.Drawing.Size(59, 17);
            this.tssl_female.Text = "Женщин:";
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
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // speedLoadGrid
            // 
            this.speedLoadGrid.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.speedLoadGrid.Name = "speedLoadGrid";
            this.speedLoadGrid.Size = new System.Drawing.Size(193, 17);
            this.speedLoadGrid.Text = "Скорость загрузки таблицы: 0 сек";
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
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(209, 183);
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
            this.dgv.RowHeadersWidth = 20;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1008, 377);
            this.dgv.TabIndex = 14;
            // 
            // peopleWorkTableAdapter1
            // 
            this.peopleWorkTableAdapter1.ClearBeforeFill = true;
            // 
            // get_treeTableAdapter1
            // 
            this.get_treeTableAdapter1.ClearBeforeFill = true;
            // 
            // typeSocialStatusTableAdapter1
            // 
            this.typeSocialStatusTableAdapter1.ClearBeforeFill = true;
            // 
            // typeLivingConditionsTableAdapter1
            // 
            this.typeLivingConditionsTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleChildrenTableAdapter1
            // 
            this.peopleChildrenTableAdapter1.ClearBeforeFill = true;
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.FontSize = MetroFramework.MetroProgressBarSize.Small;
            this.metroProgressBar1.Location = new System.Drawing.Point(892, 81);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(110, 12);
            this.metroProgressBar1.TabIndex = 53;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 602);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мастер отчетов";
            this.Load += new System.EventHandler(this.FReports_Load);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView tree_department;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton rb_exitProf;
        private System.Windows.Forms.RadioButton rb_inProf;
        private System.Windows.Forms.RadioButton rb_all_prof;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_showNotAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cb_period;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DateTimePicker dtp_periodStart;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DateTimePicker dtp_periodEnd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox clb_other;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clb_livingConditions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox clb_socialStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_femaly;
        private System.Windows.Forms.RadioButton rb_male;
        private System.Windows.Forms.RadioButton rb_all;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_All;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tssl_male;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssl_female;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Child;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private MetroFramework.Controls.MetroGrid dgv;
        private ProfDataSetTableAdapters.PeopleWorkTableAdapter peopleWorkTableAdapter1;
        private ProfDataSetTableAdapters.get_treeTableAdapter get_treeTableAdapter1;
        private ProfDataSetTableAdapters.TypeSocialStatusTableAdapter typeSocialStatusTableAdapter1;
        private ProfDataSetTableAdapters.TypeLivingConditionsTableAdapter typeLivingConditionsTableAdapter1;
        private ProfDataSetTableAdapters.PeopleChildrenTableAdapter peopleChildrenTableAdapter1;
        private System.Windows.Forms.ToolStripStatusLabel speedLoadGrid;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
    }
}