using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prof
{
    public partial class FDepartaments : MetroFramework.Forms.MetroForm
    {
        int idDep = 0;
        private string arrayUserDeparmentsAll_String;
        public FDepartaments(string arrayUserDeparmentsAll_String)
        {
            InitializeComponent();
            this.arrayUserDeparmentsAll_String = arrayUserDeparmentsAll_String;
        }

        private void loadDepartmentsGrid()
        {
            SqlConnection conn = DB.GetDBConnection();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = " select dp.id as mainid, d.fullname as parentname, dp.fullName as mainname, dp.dateCrt, dp.idParent, " +
                " case when CONCAT(d.fullname,'')= '' then dp.fullName else concat('(', d.shortName, ') ', dp.fullName) end as fname" +
                " from prof.Departments d" +
                " right join prof.Departments dp on dp.idparent = d.id" +
                $" where dp.idParent in ({arrayUserDeparmentsAll_String}) order by d.shortName, dp.fullName ";
            DataTable dt = new DataTable();
            DataTable dtC = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            conn.Open();
            try
            {
                adapter.Fill(dt);
                adapter.Fill(dtC);
                dgv.AutoGenerateColumns = false;
                dgv.DataSource = dt;
                dgv.Columns[0].DataPropertyName = "mainid";
                dgv.Columns[1].DataPropertyName = "mainname";
                dgv.Columns[2].DataPropertyName = "parentname";
                dgv.Columns[3].DataPropertyName = "dateCrt";
                dgv.Columns[4].DataPropertyName = "idParent";
                cb_parent.DataSource = dtC;
                cb_parent.DisplayMember = "fname";
                cb_parent.ValueMember = "mainid";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        
        private void FDirectorys_Load(object sender, EventArgs e)
        {
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            loadDepartmentsGrid();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idDep = (int)dgv[0, e.RowIndex].Value;
            ProfDataSet.DepartmentsDataTable dt = new ProfDataSet.DepartmentsDataTable();
            departmentsTableAdapter1.FillById(dt, idDep);
            tb_fullName.Text = dt.Rows[0]["fullName"].ToString();
            tb_shortName.Text = dt.Rows[0]["shortName"].ToString();
            cb_parent.SelectedValue = (int)dt.Rows[0]["idParent"];
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
                if (idDep == 0)
                {
                    departmentsTableAdapter1.Insert(
                        (int)cb_parent.SelectedValue,
                        tb_fullName.Text.Trim(),
                        tb_shortName.Text.Trim(),
                        DateTime.Now
                    );
                }
                else
                {
                    ProfDataSet.DepartmentsDataTable dt = new ProfDataSet.DepartmentsDataTable();
                    departmentsTableAdapter1.FillById(dt, idDep);
                    DataRow dr = dt.Rows[0];
                    dr["fullName"] = tb_fullName.Text.Trim();
                    dr["shortName"] = tb_shortName.Text.Trim();
                    dr["idParent"] = cb_parent.SelectedValue;
                    departmentsTableAdapter1.Update(dr);
                }
                loadDepartmentsGrid();
                dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[1];
                MessageBox.Show("Информация сохранена!");
            }
            else MessageBox.Show("Заполните поле \"Полное наименование\"!");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (idDep > 0)
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    ProfDataSet.DepartmentsDataTable dt = new ProfDataSet.DepartmentsDataTable();
                    departmentsTableAdapter1.FillByDepChild(dt, idDep);
                    ProfDataSet.PeopleDepartmentDataTable dtp = new ProfDataSet.PeopleDepartmentDataTable();
                    peopleDepartmentTableAdapter1.FillByDep(dtp, idDep);
                    int childDep = dt.Rows.Count;
                    int countPeople = dtp.Rows.Count;
                    if (childDep == 0)
                    {
                        if (countPeople == 0)
                        {
                            departmentsTableAdapter1.DeleteByDep(idDep);

                            MessageBox.Show("Информация удалена!");
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
            (dgv.DataSource as DataTable).DefaultView.RowFilter =
                String.Format("mainname like '{0}%'", textBox_search.Text);
        }
    }
}
