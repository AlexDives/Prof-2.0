namespace Prof
{
    partial class FDispatcherUpdates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDispatcherUpdates));
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_edit = new System.Windows.Forms.Button();
            this.b_load = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ftp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.активироватьОбновлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деактивироватьОбновлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.b_delete);
            this.panel1.Controls.Add(this.b_edit);
            this.panel1.Controls.Add(this.b_load);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 0;
            // 
            // b_delete
            // 
            this.b_delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_delete.Location = new System.Drawing.Point(243, 0);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(88, 35);
            this.b_delete.TabIndex = 2;
            this.b_delete.Text = "Удалить";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_edit
            // 
            this.b_edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_edit.Location = new System.Drawing.Point(94, 0);
            this.b_edit.Name = "b_edit";
            this.b_edit.Size = new System.Drawing.Size(149, 35);
            this.b_edit.TabIndex = 1;
            this.b_edit.Text = "Отредактировать";
            this.b_edit.UseVisualStyleBackColor = true;
            this.b_edit.Click += new System.EventHandler(this.b_edit_Click);
            // 
            // b_load
            // 
            this.b_load.Dock = System.Windows.Forms.DockStyle.Left;
            this.b_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.b_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.b_load.Location = new System.Drawing.Point(0, 0);
            this.b_load.Name = "b_load";
            this.b_load.Size = new System.Drawing.Size(94, 35);
            this.b_load.TabIndex = 0;
            this.b_load.Text = "Загрузить";
            this.b_load.UseVisualStyleBackColor = true;
            this.b_load.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.project,
            this.ftp,
            this.version,
            this.dateUpdate,
            this.isUse});
            this.dgv.ContextMenuStrip = this.cms;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 37);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(800, 413);
            this.dgv.TabIndex = 1;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // project
            // 
            this.project.FillWeight = 65F;
            this.project.HeaderText = "Проект";
            this.project.Name = "project";
            this.project.ReadOnly = true;
            // 
            // ftp
            // 
            this.ftp.HeaderText = "FTP путь";
            this.ftp.Name = "ftp";
            this.ftp.ReadOnly = true;
            // 
            // version
            // 
            this.version.FillWeight = 50F;
            this.version.HeaderText = "Версия";
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // dateUpdate
            // 
            this.dateUpdate.FillWeight = 64F;
            this.dateUpdate.HeaderText = "Дата обновления";
            this.dateUpdate.Name = "dateUpdate";
            this.dateUpdate.ReadOnly = true;
            // 
            // isUse
            // 
            this.isUse.FillWeight = 50F;
            this.isUse.HeaderText = "Актуальное";
            this.isUse.Name = "isUse";
            this.isUse.ReadOnly = true;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.активироватьОбновлениеToolStripMenuItem,
            this.деактивироватьОбновлениеToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(233, 48);
            // 
            // активироватьОбновлениеToolStripMenuItem
            // 
            this.активироватьОбновлениеToolStripMenuItem.Name = "активироватьОбновлениеToolStripMenuItem";
            this.активироватьОбновлениеToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.активироватьОбновлениеToolStripMenuItem.Text = "Активировать обновление";
            this.активироватьОбновлениеToolStripMenuItem.Click += new System.EventHandler(this.активироватьОбновлениеToolStripMenuItem_Click);
            // 
            // деактивироватьОбновлениеToolStripMenuItem
            // 
            this.деактивироватьОбновлениеToolStripMenuItem.Name = "деактивироватьОбновлениеToolStripMenuItem";
            this.деактивироватьОбновлениеToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.деактивироватьОбновлениеToolStripMenuItem.Text = "Деактивировать обновление";
            this.деактивироватьОбновлениеToolStripMenuItem.Click += new System.EventHandler(this.деактивироватьОбновлениеToolStripMenuItem_Click);
            // 
            // FDispatcherUpdates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FDispatcherUpdates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Диспетчер обновлений";
            this.Load += new System.EventHandler(this.FDispatcherUpdates_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn project;
        private System.Windows.Forms.DataGridViewTextBoxColumn ftp;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn isUse;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_edit;
        private System.Windows.Forms.Button b_load;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem активироватьОбновлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деактивироватьОбновлениеToolStripMenuItem;
    }
}