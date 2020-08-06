namespace Prof
{
    partial class FSearch
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
            this.p_search = new System.Windows.Forms.Panel();
            this.b_close = new System.Windows.Forms.Button();
            this.b_move = new System.Windows.Forms.Button();
            this.b_search = new System.Windows.Forms.Button();
            this.tb_search = new MetroFramework.Controls.MetroTextBox();
            this.dgv = new MetroFramework.Controls.MetroGrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otdelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doljn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleTableAdapter();
            this.peopleDepartmentTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleDepartmentTableAdapter();
            this.peopleWorkTableAdapter1 = new Prof.ProfDataSetTableAdapters.PeopleWorkTableAdapter();
            this.p_search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // p_search
            // 
            this.p_search.Controls.Add(this.b_close);
            this.p_search.Controls.Add(this.b_move);
            this.p_search.Controls.Add(this.b_search);
            this.p_search.Controls.Add(this.tb_search);
            this.p_search.Dock = System.Windows.Forms.DockStyle.Top;
            this.p_search.Location = new System.Drawing.Point(20, 60);
            this.p_search.Name = "p_search";
            this.p_search.Size = new System.Drawing.Size(536, 23);
            this.p_search.TabIndex = 1;
            // 
            // b_close
            // 
            this.b_close.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_close.Location = new System.Drawing.Point(299, 0);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(75, 23);
            this.b_close.TabIndex = 3;
            this.b_close.Text = "Закрыть";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // b_move
            // 
            this.b_move.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_move.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_move.Location = new System.Drawing.Point(224, 0);
            this.b_move.Name = "b_move";
            this.b_move.Size = new System.Drawing.Size(75, 23);
            this.b_move.TabIndex = 2;
            this.b_move.Text = "Перейти";
            this.b_move.UseVisualStyleBackColor = true;
            this.b_move.Click += new System.EventHandler(this.b_move_Click);
            // 
            // b_search
            // 
            this.b_search.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_search.Location = new System.Drawing.Point(149, 0);
            this.b_search.Name = "b_search";
            this.b_search.Size = new System.Drawing.Size(75, 23);
            this.b_search.TabIndex = 1;
            this.b_search.Text = "Найти";
            this.b_search.UseVisualStyleBackColor = true;
            this.b_search.Click += new System.EventHandler(this.b_search_Click);
            // 
            // tb_search
            // 
            // 
            // 
            // 
            this.tb_search.CustomButton.Image = null;
            this.tb_search.CustomButton.Location = new System.Drawing.Point(127, 1);
            this.tb_search.CustomButton.Name = "";
            this.tb_search.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tb_search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_search.CustomButton.TabIndex = 1;
            this.tb_search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_search.CustomButton.UseSelectable = true;
            this.tb_search.CustomButton.Visible = false;
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_search.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tb_search.Lines = new string[0];
            this.tb_search.Location = new System.Drawing.Point(0, 0);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.PasswordChar = '\0';
            //this.tb_search.PromptText = "Фамилия";
            this.tb_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_search.SelectedText = "";
            this.tb_search.SelectionLength = 0;
            this.tb_search.SelectionStart = 0;
            this.tb_search.ShortcutsEnabled = true;
            this.tb_search.Size = new System.Drawing.Size(149, 23);
            this.tb_search.TabIndex = 0;
            this.tb_search.UseSelectable = true;
            this.tb_search.WaterMark = "Фамилия";
            this.tb_search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
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
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fio,
            this.otdelName,
            this.doljn});
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
            this.dgv.Location = new System.Drawing.Point(20, 83);
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
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(536, 185);
            this.dgv.TabIndex = 2;
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fio
            // 
            this.fio.FillWeight = 50F;
            this.fio.HeaderText = "Ф.И.О.";
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            // 
            // otdelName
            // 
            this.otdelName.HeaderText = "Где работает";
            this.otdelName.Name = "otdelName";
            this.otdelName.ReadOnly = true;
            // 
            // doljn
            // 
            this.doljn.HeaderText = "Должность";
            this.doljn.Name = "doljn";
            this.doljn.ReadOnly = true;
            // 
            // peopleTableAdapter1
            // 
            this.peopleTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleDepartmentTableAdapter1
            // 
            this.peopleDepartmentTableAdapter1.ClearBeforeFill = true;
            // 
            // peopleWorkTableAdapter1
            // 
            this.peopleWorkTableAdapter1.ClearBeforeFill = true;
            // 
            // FSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 288);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.p_search);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FSearch";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            this.Load += new System.EventHandler(this.FSearch_Load);
            this.p_search.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_search;
        private System.Windows.Forms.Button b_search;
        private MetroFramework.Controls.MetroTextBox tb_search;
        private System.Windows.Forms.Button b_close;
        private System.Windows.Forms.Button b_move;
        private MetroFramework.Controls.MetroGrid dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn otdelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn doljn;
        private ProfDataSetTableAdapters.PeopleTableAdapter peopleTableAdapter1;
        private ProfDataSetTableAdapters.PeopleDepartmentTableAdapter peopleDepartmentTableAdapter1;
        private ProfDataSetTableAdapters.PeopleWorkTableAdapter peopleWorkTableAdapter1;
    }
}