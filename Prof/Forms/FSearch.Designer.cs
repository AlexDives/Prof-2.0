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
            this.p_search = new System.Windows.Forms.Panel();
            this.b_close = new System.Windows.Forms.Button();
            this.b_move = new System.Windows.Forms.Button();
            this.b_search = new System.Windows.Forms.Button();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otdelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doljn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.p_search.Location = new System.Drawing.Point(0, 0);
            this.p_search.Name = "p_search";
            this.p_search.Size = new System.Drawing.Size(576, 23);
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
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_search.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_search.Location = new System.Drawing.Point(0, 0);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(149, 23);
            this.tb_search.TabIndex = 0;
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fio,
            this.otdelName,
            this.doljn});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 23);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(576, 225);
            this.dgv.TabIndex = 2;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
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
            // FSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 248);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.p_search);
            this.Name = "FSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск";
            this.Load += new System.EventHandler(this.FSearch_Load);
            this.p_search.ResumeLayout(false);
            this.p_search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_search;
        private System.Windows.Forms.Button b_search;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.Button b_close;
        private System.Windows.Forms.Button b_move;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn otdelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn doljn;
    }
}