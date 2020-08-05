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
    public partial class FUserMeneger : Form
    {
        int idUser = 0;
        bool newUser = false;
        int[] peopleArray;
        //int[] departmentArray;
        int[] roleArray;
        int[] arrayUserDeparments;
        int rowNum = 0;
        int[] arrayDep;
        public FUserMeneger(int idUser, int[] arrayUserDeparments)
        {
            InitializeComponent();
            this.idUser = idUser;
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
                    cb_department.Items.Clear();
                    arrayDep = new int[arrayUserDeparments.Count() + 1];
                    cb_department.Items.Add("");
                    arrayDep[0] = 0;
                    rowNum = 0;
                    Database.Department d = db.Departments.FirstOrDefault(p => p.id == idDepartment);
                    cb_department.Items.Add(d.fullName);
                    arrayDep[rowNum + 1] = d.id;
                    rowNum++;
                    LoadDepartments(false, idDepartment);
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment).ToList();
                    foreach (Database.Department nd in dd)
                    {
                        cb_department.Items.Add(nd.fullName);
                        int[] tmp = new int[arrayDep.Length + 1];
                        for (int k = 0; k < arrayDep.Length; k++)
                            tmp[k] = arrayDep[k];
                        tmp[rowNum + 1] = nd.id;
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

        private void loadDepartments()
        {
            /*cb_department.Enabled = false;
            using (Database.DataBase db = new Database.DataBase())
            {
                var depart = db.Departments;
                if (depart.Count() > 0)
                {
                    departmentArray = new int[(int)depart.Max(p => p.id)];
                    cb_department.Items.Clear();
                    int i = 0;
                    foreach (Database.Department d in depart)
                    {
                        cb_department.Items.Add(d.fullName);
                        departmentArray[i] = d.id;
                        i++;
                    }
                    cb_department.Enabled = true;
                }
            }*/
        }

        private void loadPeople(int idDepart)
        {
            cb_people.Enabled = false;
            using (Database.DataBase db = new Database.DataBase())
            {
                var people = db.PeopleDepartments.Where(p => p.idDepartment == idDepart).ToList();
                if (people.Count() > 0)
                {
                    peopleArray = new int[(int)people.Max(p => p.idPeople)];
                    int i = 0;
                    cb_people.Items.Clear();
                    foreach (Database.PeopleDepartment pd in people)
                    {
                        peopleArray[i] = (int)pd.idPeople;
                        cb_people.Items.Add($"{decryptoStr(pd.Person.famil)} {decryptoStr(pd.Person.name)} {decryptoStr(pd.Person.otch)}");
                        i++;
                    }
                    cb_people.Enabled = true;
                }
            }
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
            using (Database.DataBase db = new Database.DataBase())
            {
                IQueryable<Database.Role> roles = null;
                switch (db.UserRoles.FirstOrDefault(p => p.idUser == idUser).Role.name)
                {
                    case "GrandAdmin":
                        roles = db.Roles;
                        break;
                    case "Admin":
                        roles = db.Roles.Where(p => p.name == "Admin" || p.name == "Operator");
                        break;
                }
                if (roles != null)
                {
                    roleArray = new int[(int)roles.Max(p => p.id)];
                    int i = 0;
                    cb_role.Items.Clear();
                    foreach (Database.Role r in roles)
                    {
                        cb_role.Items.Add(r.name);
                        roleArray[i] = r.id;
                        i++;
                    }
                }
            }
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
            using (Database.DataBase db = new Database.DataBase())
            {
                dgv.Rows.Clear();
                int i = 0;
                foreach (int indexArray in arrayDep)
                {
                    var userDep = db.UserDepartments.Where(p => p.idDepartments == indexArray && p.User.login != "-").ToList();
                    foreach (Database.UserDepartment ud in userDep)
                    {
                        dgv.Rows.Add();
                        dgv[0, i].Value = ud.id;
                        dgv[1, i].Value = ud.User.login;
                        dgv[2, i].Value = $"{decryptoStr(ud.User.Person.famil)} {decryptoStr(ud.User.Person.name)} {decryptoStr(ud.User.Person.otch)}";
                        i++;
                    }
                }               
            }
        }

        private void FUserMeneger_Load(object sender, EventArgs e)
        {
            //loadDepartments();
            cb_department.Enabled = false;
            for (int i = 0; i < arrayUserDeparments.Length; i++)
            {
                LoadDepartments(true, arrayUserDeparments[i]);
            }
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
            loadPeople(arrayDep[cb_department.SelectedIndex]);
        }

        private void b_new_Click(object sender, EventArgs e)
        {
            newUser = true;
            EnableComponents(true);
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                if (tb_pwd.Text.Trim() == tb_pwdSecond.Text.Trim())
                {
                    if (newUser)
                    {
                        Database.User u = new Database.User();
                        u.login = tb_login.Text;
                        u.idPeople = peopleArray[cb_people.SelectedIndex];
                        u.pwd = sha1(sha1(tb_pwd.Text.Trim() + "$2$4"));
                        u.dateCrt = DateTime.Now;
                        db.Users.Add(u);
                        Database.UserRole ur = new Database.UserRole();
                        ur.idUser = u.id;
                        ur.idRole = roleArray[cb_role.SelectedIndex];
                        db.UserRoles.Add(ur);
                        Database.UserDepartment ud = new Database.UserDepartment();
                        ud.idUser = u.id;
                        ud.idDepartments = arrayDep[cb_department.SelectedIndex];
                        db.UserDepartments.Add(ud);
                        db.SaveChanges();
                    }
                    else
                    {
                        int udId = (int)dgv[0, dgv.CurrentRow.Index].Value;
                        string login = dgv[1, dgv.CurrentRow.Index].Value.ToString();
                        Database.User u = db.Users.FirstOrDefault(p => p.login == login);
                        u.login = tb_login.Text;
                        u.pwd = tb_pwd.Text.Trim() != "" ? sha1(sha1(tb_pwd.Text.Trim() + "$2$4")) : u.pwd;
                        u.idPeople = peopleArray[cb_people.SelectedIndex];
                        Database.UserRole ur = db.UserRoles.FirstOrDefault(p => p.idUser == u.id);
                        ur.idUser = u.id;
                        ur.idRole = roleArray[cb_role.SelectedIndex];
                        Database.UserDepartment ud = db.UserDepartments.FirstOrDefault(p => p.id == udId);
                        ud.idUser = u.id;
                        ud.idDepartments = arrayDep[cb_department.SelectedIndex];
                        db.SaveChanges();
                    }
                    newUser = false;
                    EnableComponents(false);
                    loadGrid();
                }
                else MessageBox.Show("Пароли не совпадают!");  
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            newUser = false;
            EnableComponents(true);
            using (Database.DataBase db = new Database.DataBase())
            {
                int udId = (int)dgv[0, dgv.CurrentRow.Index].Value;
                string login = dgv[1, dgv.CurrentRow.Index].Value.ToString();
                Database.User u = db.Users.FirstOrDefault(p => p.login == login);
                Database.Department d = db.Departments.FirstOrDefault(p => p.id == db.UserDepartments.FirstOrDefault(pp => pp.id == udId).idDepartments);
                cb_department.SelectedIndex = arrayDep != null ? Array.IndexOf(arrayDep, d.id) : 0;
                Database.Person pers = db.People.FirstOrDefault(p => p.id == u.idPeople);
                cb_people.SelectedIndex = peopleArray != null ? Array.IndexOf(peopleArray, pers.id) : 0; ///////////////////////////////////////////////////////////////////////////////////////
                Database.UserRole ur = db.UserRoles.FirstOrDefault(p => p.idUser == u.id);
                Database.Role r = db.Roles.FirstOrDefault(p => p.id == ur.idRole);
                tb_login.Text = u.login;
                cb_role.SelectedIndex = Array.IndexOf(roleArray, r.id);
            }
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
            using (Database.DataBase db = new Database.DataBase())
            {
                int delId = 0;
                delId = (int)dgv[0, dgv.CurrentRow.Index].Value;
                delId = db.UserDepartments.FirstOrDefault(pp => pp.id == delId).idUser;
                
                if (delId != 0 && (MessageBox.Show("Вы уверены в удалении?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
                {
                    if (idUser == delId)
                    {
                        MessageBox.Show("Вы не можете удалить свою учётную запись!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        db.Users.Remove(db.Users.FirstOrDefault(p => p.id == delId));
                        db.SaveChanges();
                        loadGrid();
                    }
                }
            }
        }
    }
}
