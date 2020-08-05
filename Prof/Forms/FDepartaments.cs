using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Prof
{
    public partial class FDepartaments : MetroFramework.Forms.MetroForm
    {
        int[] arrayDep;
        int idDep = 0;
        int[] arrayUserDeparments;
        int rowNum = 0;
        public FDepartaments(int[] arrayUserDeparments)
        {
            InitializeComponent();
            this.arrayUserDeparments = arrayUserDeparments;
        }

        private bool LoadDepartments(bool first, int idDepartment)
        {
            bool result = true;
            using (Database.DataBase db = new Database.DataBase())
            {
                if (first)
                {
                    dgv.Rows.Clear();
                    cb_parent.Items.Clear();
                    arrayDep = new int[arrayUserDeparments.Count()];
                    /*
                    cb_parent.Items.Add("");
                    arrayDep[0] = 0;*/
                    rowNum = 0;
                    Database.Department d = db.Departments.FirstOrDefault(p => p.id == idDepartment);
                    Database.Department dd = db.Departments.FirstOrDefault(p => p.id == d.idParent);
                    string pname = "";
                    if (dd != null)
                        pname = "(" + dd.shortName + ") ";
                    cb_parent.Items.Add(pname + d.fullName);
                    arrayDep[rowNum/* + 1*/] = d.id;
                    rowNum++;
                    LoadDepartments(false, idDepartment);
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment).ToList();
                    foreach (Database.Department nd in dd)
                    {
                        dgv.Rows.Add();
                        dgv[0, rowNum-1].Value = nd.id;
                        dgv[1, rowNum-1].Value = nd.fullName;
                        dgv[2, rowNum-1].Value = nd.idParent != 0 ? db.Departments.FirstOrDefault(p => p.id == nd.idParent).fullName : "";
                        dgv[3, rowNum-1].Value = nd.dateCrt;
                        dgv[4, rowNum-1].Value = nd.idParent;
                        Database.Department ddd = db.Departments.FirstOrDefault(p => p.id == nd.idParent);
                        string pname = "";
                        if (ddd != null)
                            pname = "(" + ddd.shortName + ") ";
                        cb_parent.Items.Add(pname + nd.fullName);
                        int[] tmp = new int[arrayDep.Length + 1];
                        for (int k = 0; k < arrayDep.Length; k++)
                            tmp[k] = arrayDep[k];
                        tmp[rowNum] = nd.id;
                        arrayDep = new int[tmp.Length];
                        for (int k = 0; k < tmp.Length; k++)
                            arrayDep[k] = tmp[k];
                        rowNum++;
                        LoadDepartments(false, nd.id);
                    }
                }
            }
            return result;
        }

        private void loadDepartmentsGrid()
        {
            for (int i = 0; i < arrayUserDeparments.Length; i++)
            {
                LoadDepartments(true, arrayUserDeparments[i]);
            }
            cb_parent.SelectedIndex = 0;
        }
        
        private void FDirectorys_Load(object sender, EventArgs e)
        {
            loadDepartmentsGrid();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                idDep = (int)dgv[0, e.RowIndex].Value;
                Database.Department departments = db.Departments.FirstOrDefault(p => p.id == idDep);
                tb_fullName.Text = departments.fullName;
                tb_shortName.Text = departments.shortName;
                cb_parent.SelectedItem = departments.idParent != 0 ? db.Departments.FirstOrDefault(p => p.id == departments.idParent).fullName : "";
                db.Configuration.AutoDetectChangesEnabled = true;
            }
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            tb_fullName.Clear();
            tb_shortName.Clear();
            cb_parent.SelectedIndex = 0;
            idDep = 0;
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (tb_fullName.Text.Trim() != "")
            {
                /*if (cb_parent.SelectedIndex != 0)
                {*/
                    using (Database.DataBase db = new Database.DataBase())
                    {
                        if (idDep == 0)
                        {
                            Database.Department dep = new Database.Department();
                            dep.fullName = tb_fullName.Text.Trim();
                            dep.shortName = tb_shortName.Text.Trim();
                            dep.idParent = arrayDep[cb_parent.SelectedIndex];
                            dep.dateCrt = DateTime.Now;
                            db.Departments.Add(dep);
                        }
                        else
                        {
                            Database.Department dep = db.Departments.FirstOrDefault(p => p.id == idDep);
                            dep.fullName = tb_fullName.Text.Trim();
                            dep.shortName = tb_shortName.Text.Trim();
                            dep.idParent = arrayDep[cb_parent.SelectedIndex];
                        }
                        db.SaveChanges();
                        loadDepartmentsGrid();
                        dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[1];

                    }
                /*}
                else MessageBox.Show("Нужно выбрать в какое подразделение добавить!");*/
            }
            else MessageBox.Show("Заполните поле \"Полное наименование\"!");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (idDep > 0)
            {
                using (Database.DataBase db = new Database.DataBase())
                {

                    int childDep = db.Departments.Where(p => p.idParent == idDep).Count();
                    int countPeople = db.PeopleDepartments.Where(p => p.idDepartment == idDep).Count();
                    if (childDep == 0)
                    {
                        if (countPeople == 0)
                        {
                            db.Departments.Remove(db.Departments.FirstOrDefault(p => p.id == idDep));
                            db.SaveChanges();
                            loadDepartmentsGrid();
                        }
                        else MessageBox.Show("Вы не можете удалить данное подразделение, т.к. у него есть члены профсоюза!");

                    }
                    else MessageBox.Show("Вы не можете удалить данное подразделение, т.к. у него есть дочерние подразделения!");
                }
            }
            else MessageBox.Show("Не выбрано подразделение!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_search_KeyUp(object sender, KeyEventArgs e)
        {
            // Проходим циклом по всем строкам
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Если в текстовом поле, отвечающем за поиск в первом столбце, что-то есть
                if (textBox_search.Text.Length > 0)
                {
                    // Если текст совпадает
                    if (row.Cells[1].Value.ToString().ToLower().Contains(textBox_search.Text.Trim().ToLower()))
                    {
                        // Выделяем строку
                        row.Visible = true;
                    }
                    else
                        row.Visible = false;
                }
                else row.Visible = true;
            }
        }
    }
}
