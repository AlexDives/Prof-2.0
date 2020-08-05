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
    public partial class FSearch : Form
    {
        int[] arrayDep;
        public int idPers = 0;
        int[] arrayUserDeparments;
        int rowNum = 0;
        public FSearch(int[] arrayUserDeparments)
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
                    arrayDep = new int[arrayUserDeparments.Count() + 1];
                    arrayDep[0] = 0;
                    rowNum = 0;
                    Database.Department d = db.Departments.FirstOrDefault(p => p.id == idDepartment);
                    arrayDep[rowNum + 1] = d.id;
                    rowNum++;
                    LoadDepartments(false, idDepartment);
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment);
                    foreach (Database.Department nd in dd)
                    {
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

        private void b_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FSearch_Load(object sender, EventArgs e)
        {
            b_move.Visible = false;
            for (int i = 0; i < arrayUserDeparments.Length; i++)
            {
                LoadDepartments(true, arrayUserDeparments[i]);
            }
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            Database.DataBase db = new Database.DataBase();
            var findPeople = db.People;
            dgv.Rows.Clear();
            if (findPeople.Count() != 0)
            {
                int i = 0;
                foreach (Database.Person pers in findPeople)
                {
                    if (decryptoStr(pers.famil).ToLower().StartsWith(tb_search.Text.Trim().ToLower()))
                    {
                        int depart = Array.IndexOf(arrayDep, db.PeopleDepartments.FirstOrDefault(p => p.idPeople == pers.id).idDepartment);
                        if (depart != -1)
                        {
                            dgv.Rows.Add();
                            Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.idPeople == pers.id && p.isActual == "T" && p.isWorked == "T");
                            string workPlace = "";
                            string doljn = "";
                            if (pw != null)
                            {
                                workPlace = pw.workPlace;
                                doljn = pw.doljn;
                            }
                            dgv[0, i].Value = pers.id;
                            dgv[1, i].Value = decryptoStr(pers.famil) + " " + decryptoStr(pers.name) + " " + decryptoStr(pers.otch);
                            dgv[2, i].Value = workPlace;
                            dgv[3, i].Value = doljn;
                            i++;
                        }
                    }
                }
                if (i == 0)
                {
                    b_move.Visible = false;
                    MessageBox.Show("Не найден!");
                }
                else
                {
                    b_move.Visible = true;
                }
            }
        }
        private string cryptoStr(string str)
        {

            if (str != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                {
                    sb.Append(Convert.ToChar(str[i] << 1));
                }
                return sb.ToString();
            }
            else return "";

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

        private void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                b_search.PerformClick();
        }

        private void b_move_Click(object sender, EventArgs e)
        {
            idPers = (int)dgv[0, dgv.CurrentRow.Index].Value;
            Close();
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            b_move.PerformClick();
        }
    }
}
