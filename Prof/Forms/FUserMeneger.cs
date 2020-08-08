using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FUserMeneger : MetroFramework.Forms.MetroForm
    {
        int idUser = 0;
        bool newUser = false;
        private string arrayUserDeparmentsAll_String;
        public FUserMeneger(int idUser, string arrayUserDeparmentsAll_String)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.arrayUserDeparmentsAll_String = arrayUserDeparmentsAll_String;
        }

        private void LoadDepartments()
        {
            cb_department.Items.Clear();
            SqlConnection conn = DB.GetDBConnection();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = " select dp.id as did, concat('(', d.shortName, ') ', dp.fullName) as fname from prof.Departments d  " +
                         " right join prof.Departments dp on dp.idparent = d.id  " +
                         $" where dp.idParent in ({arrayUserDeparmentsAll_String}) order by d.shortName, dp.fullName ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            conn.Open();
            try
            {
                adapter.Fill(dt);
                cb_department.DataSource = dt;
                cb_department.DisplayMember = "fname";
                cb_department.ValueMember = "did";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void loadPeople(int idDepart)
        {
            cb_people.Enabled = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ProfDataSet.PeopleDepartmentDataTable dt = new ProfDataSet.PeopleDepartmentDataTable();
            peopleDepartmentTableAdapter1.FillByDep(dt, idDepart);

            DataTable dt_n = new DataTable();
            dt_n.Columns.Add("id", typeof(int));
            dt_n.Columns.Add("fio", typeof(string));
            foreach(DataRow dr in dt.Rows)
            {
                DataRow dr_n = dt_n.NewRow();
                dr_n["id"] = dr["pid"];
                dr_n["fio"] = $"{decryptoStr(dr["famil"].ToString())} {decryptoStr(dr["name"].ToString())} {decryptoStr(dr["otch"].ToString())}";
                dt_n.Rows.Add(dr_n);
            }
            cb_people.DataSource = dt_n;
            cb_people.DisplayMember = "fio";
            cb_people.ValueMember = "id";
            
            cb_people.Enabled = true;
        }

        private string decryptoStr(string str)
        {
            if (str != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    sb.Append(Convert.ToChar(str[i] >> 1));
                }
                return sb.ToString();
            }
            else return "";
        }

        private void loadRole()
        {
            ProfDataSet.UserRoleDataTable dtUserRole = new ProfDataSet.UserRoleDataTable();
            userRoleTableAdapter1.FillByUser(dtUserRole, idUser);
            ProfDataSet.RolesDataTable dtRole = new ProfDataSet.RolesDataTable();
            rolesTableAdapter1.FillByUserRole(dtRole, (int)dtUserRole.Rows[0]["idRole"]);
            cb_role.DataSource = dtRole;
            cb_role.DisplayMember = "name";
            cb_role.ValueMember = "id";
        }

        private void EnableComponents(bool flag)
        {
            tb_login.Enabled = flag;
            tb_pwd.Enabled = flag;
            tb_pwdSecond.Enabled = flag;
            cb_department.Enabled = flag;
            cb_people.Enabled = flag;
            cb_role.Enabled = flag;
            tb_login.Clear();
            tb_pwd.Clear();
            tb_pwdSecond.Clear();
        }

        private void loadGrid()
        {
            dgv.Rows.Clear();
            int i = 0;
            SqlConnection conn = DB.GetDBConnection();
            string sql = $"SELECT prof.UserDepartment.id, prof.Users.login, prof.People.famil, prof.People.name, prof.People.otch " +
                $" FROM prof.People LEFT JOIN prof.Users ON prof.People.id = prof.Users.idPeople LEFT OUTER JOIN " +
                $" prof.UserDepartment ON prof.Users.id = prof.UserDepartment.idUser " +
                $" WHERE (prof.Users.login <> '-') and (prof.UserDepartment.idDepartments in ({arrayUserDeparmentsAll_String}))";
            SqlCommand sqlCommand = new SqlCommand(sql);
            sqlCommand.Connection = conn;
            conn.Open();
            using (DbDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgv.Rows.Add();
                        dgv[0, i].Value = reader.GetInt32(0);
                        dgv[1, i].Value = reader.GetString(1);
                        dgv[2, i].Value = $"{decryptoStr(reader.GetString(2))} {decryptoStr(reader.GetString(3))} {decryptoStr(reader.GetString(3))}";
                        i++;
                    }
                }
            }
            conn.Close();
            conn.Dispose();
        }

        private void FUserMeneger_Load(object sender, EventArgs e)
        {
            cb_department.Enabled = false;
            LoadDepartments();
            cb_department.Enabled = true;
            loadRole();
            loadGrid();
            EnableComponents(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_department.SelectedValue.GetType() != typeof(int))
            {
                DataRowView drv = (DataRowView)cb_department.SelectedValue;
                loadPeople((int)drv.Row["did"]);
            }
            else loadPeople((int)cb_department.SelectedValue);
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            newUser = true;
            EnableComponents(true);
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            if (tb_pwd.Text.Trim() == tb_pwdSecond.Text.Trim())
            {
                if (newUser)
                {
                    int idNewUser = 0;
                    SqlConnection conn = DB.GetDBConnection();
                    string sql = $" INSERT INTO prof.Users (login, idPeople, pwd) " +
                                        $" VALUES(@login, @idPeople, @pwd); " +
                                        $" SELECT SCOPE_IDENTITY() as id";

                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.Parameters.Add("@login", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@idPeople", SqlDbType.Int);
                    cmd.Parameters.Add("@pwd", SqlDbType.NVarChar);
                    cmd.Parameters["@login"].Value = tb_login.Text;
                    cmd.Parameters["@idPeople"].Value = (int)cb_people.SelectedValue;
                    cmd.Parameters["@pwd"].Value = sha1(sha1(tb_pwd.Text.Trim() + "$2$4"));
                    cmd.Connection = conn;

                    conn.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            idNewUser = (int)reader.GetDecimal(0);
                        }
                    }
                    userRoleTableAdapter1.Insert(idNewUser, (int)cb_role.SelectedValue);
                    userDepartmentTableAdapter1.Insert(idNewUser, (int)cb_department.SelectedValue);
                }
                else
                {
                    int udId = (int)dgv[0, dgv.CurrentRow.Index].Value;
                    ProfDataSet.UserDepartmentDataTable dtud = new ProfDataSet.UserDepartmentDataTable();
                    userDepartmentTableAdapter1.FillByDep(dtud, udId);
                    ProfDataSet.UsersDataTable udt = new ProfDataSet.UsersDataTable();
                    usersTableAdapter1.FillByUser(udt, (int)dtud.Rows[0]["idUser"]);
                    ProfDataSet.UserRoleDataTable urdt = new ProfDataSet.UserRoleDataTable();
                    userRoleTableAdapter1.FillByUser(urdt, (int)dtud.Rows[0]["idUser"]);
                    DataRow dr = udt.Rows[0];
                    dr["login"] = tb_login.Text;
                    dr["pwd"] = tb_pwd.Text.Trim() != "" ? sha1(sha1(tb_pwd.Text.Trim() + "$2$4")) : dr["pwd"];
                    dr["idPeople"] = (int)cb_people.SelectedValue;
                    usersTableAdapter1.Update(dr);
                    dr = urdt.Rows[0];
                    dr["idUser"] = (int)udt.Rows[0]["id"];
                    dr["idRole"] = (int)cb_role.SelectedValue;
                    userRoleTableAdapter1.Update(dr);
                    dr = dtud.Rows[0];
                    dr["idUser"] = (int)udt.Rows[0]["id"];
                    dr["idDepartments"] = (int)cb_department.SelectedValue;
                    userDepartmentTableAdapter1.Update(dr);
                }
                newUser = false;
                EnableComponents(false);
                loadGrid();
            }
            else MessageBox.Show("Пароли не совпадают!");  
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            newUser = false;
            EnableComponents(true);
            int udId = (int)dgv[0, dgv.CurrentRow.Index].Value;
            ProfDataSet.UserDepartmentDataTable dtud = new ProfDataSet.UserDepartmentDataTable();
            userDepartmentTableAdapter1.FillByDep(dtud, udId);
            ProfDataSet.UsersDataTable udt = new ProfDataSet.UsersDataTable();
            usersTableAdapter1.FillByUser(udt, (int)dtud.Rows[0]["idUser"]);
            ProfDataSet.UserRoleDataTable urdt = new ProfDataSet.UserRoleDataTable();
            userRoleTableAdapter1.FillByUser(urdt, (int)dtud.Rows[0]["idUser"]);
            cb_department.SelectedValue = (int)dtud.Rows[0]["idDepartments"];
            cb_people.SelectedValue = (int)udt.Rows[0]["idPeople"];
            tb_login.Text = udt.Rows[0]["login"].ToString();
            cb_role.SelectedValue = (int)urdt.Rows[0]["idRole"];
        }

        string sha1(string input)
        {
            byte[] hash;
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        private void B_delete_Click(object sender, EventArgs e)
        {  
            int delId;
            delId = (int)dgv[0, dgv.CurrentRow.Index].Value;
            ProfDataSet.UserDepartmentDataTable dtud = new ProfDataSet.UserDepartmentDataTable();
            userDepartmentTableAdapter1.FillByDep(dtud, delId);
            delId = (int)dtud.Rows[0]["idUser"];
                
            if (delId != 0 && (MessageBox.Show("Вы уверены в удалении?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {
                if (idUser == delId)
                {
                    MessageBox.Show("Вы не можете удалить свою учётную запись!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    usersTableAdapter1.DeleteUser(delId);
                    loadGrid();
                    EnableComponents(false);
                }
            }
            
        }
    }
}
