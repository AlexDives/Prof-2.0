using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FDispatcherUpdates : Form
    {

        public FDispatcherUpdates()
        {
            InitializeComponent();
        }

        private void FDispatcherUpdates_Load(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                dgv.Rows.Clear();
                dgv.Rows.Add(db.ProjectVersions.Count());
                int i = 0;
                foreach (Database.ProjectVersion prv in db.ProjectVersions)
                {
                    dgv[0, i].Value = prv.id;
                    dgv[1, i].Value = "Prof";
                    dgv[2, i].Value = prv.ftpPath;
                    dgv[3, i].Value = prv.version;
                    dgv[4, i].Value = prv.dateUpdate;
                    dgv[5, i].Value = prv.isUse;
                    if (prv.isUse == "T") dgv[5, i].Style.BackColor = Color.LightGreen;
                    else dgv[5, i].Style.BackColor = Color.OrangeRed;
                    i++;
                    
                }
            }
        }

        private void деактивироватьОбновлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                int id = (int)dgv[0, dgv.CurrentRow.Index].Value;
                Database.ProjectVersion pv = db.ProjectVersions.FirstOrDefault(p => p.id == id);
                pv.isUse = "F";
                db.SaveChanges();
                FDispatcherUpdates_Load(sender, e);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv[5, e.RowIndex].Value.Equals("T"))
            {
                активироватьОбновлениеToolStripMenuItem.Enabled = false;
                деактивироватьОбновлениеToolStripMenuItem.Enabled = true;
            }
            else
            {
                активироватьОбновлениеToolStripMenuItem.Enabled = true;
                деактивироватьОбновлениеToolStripMenuItem.Enabled = false;
            }
        }

        private void активироватьОбновлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                int id = (int)dgv[0, dgv.CurrentRow.Index].Value;
                Database.ProjectVersion pv = db.ProjectVersions.FirstOrDefault(p => p.id == id);
                pv.isUse = "T";
                db.SaveChanges();
                FDispatcherUpdates_Load(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FUploadUpdate fUpload = new FUploadUpdate(0);
            fUpload.ShowDialog();
            FDispatcherUpdates_Load(sender, e);
        }

        private void b_edit_Click(object sender, EventArgs e)
        {
            FUploadUpdate fUpload = new FUploadUpdate((int)dgv[0, dgv.CurrentRow.Index].Value);
            fUpload.ShowDialog();
            FDispatcherUpdates_Load(sender, e);
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Уверены что хотите удалить " + 
                                dgv[1, dgv.CurrentRow.Index].Value + 
                                " (" + dgv[3, dgv.CurrentRow.Index].Value + ")",
                                "Удаление", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                int id = (int)dgv[0, dgv.CurrentRow.Index].Value;
                bool rem = false;
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (db.ProjectVersions.Count() != 1)
                    {
                        db.ProjectVersions.Remove(db.ProjectVersions.FirstOrDefault(p => p.id == id));
                        rem = true;
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Последнее обновление нельзя удалить!", "Эй!");
                }
                if (rem)
                {
                    using (Database.DataBase db = new Database.DataBase())
                    {
                        int oldId = db.ProjectVersions.Max(p => p.id);
                        Database.ProjectVersion pv = db.ProjectVersions.FirstOrDefault(p => p.id == oldId);
                        pv.isUse = "T";
                        db.SaveChanges();
                    }
                }
                FDispatcherUpdates_Load(sender, e);
            }
        }
    }
}
