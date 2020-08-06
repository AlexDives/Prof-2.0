using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FSearch : MetroFramework.Forms.MetroForm
    {
        public int idPers = 0;
        public FSearch()
        {
            InitializeComponent();
        }

        private void b_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FSearch_Load(object sender, EventArgs e)
        {
            b_move.Visible = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            ProfDataSet.PeopleDataTable dtPeople = new ProfDataSet.PeopleDataTable();
            peopleTableAdapter1.Fill(dtPeople);
            
            dgv.Rows.Clear();
            if (dtPeople.Rows.Count != 0)
            {
                int i = 0;
                foreach (DataRow pers in dtPeople.Rows)
                {
                    if (decryptoStr(pers["famil"].ToString()).ToLower().StartsWith(tb_search.Text.Trim().ToLower()))
                    {
                        ProfDataSet.PeopleDepartmentDataTable dtDep = new ProfDataSet.PeopleDepartmentDataTable();
                        peopleDepartmentTableAdapter1.FillByPers(dtDep, (int)pers["id"]);
                        if (!dtDep.Rows[0].IsNull("idDepartment"))
                        {
                            dgv.Rows.Add();
                            ProfDataSet.PeopleWorkDataTable dtWork = new ProfDataSet.PeopleWorkDataTable();
                            peopleWorkTableAdapter1.FillByPeopleId(dtWork, (int)pers["id"]);
                            DataRow dr = dtWork.FirstOrDefault(p => p.isActual == "T" && p.isWorked == "T");
                            string workPlace = "";
                            string doljn = "";
                            if (dr != null)
                            {
                                workPlace = dr["workPlace"].ToString();
                                doljn = dr["doljn"].ToString();
                            }
                            dgv[0, i].Value = (int)pers["id"];
                            dgv[1, i].Value = decryptoStr(pers["famil"].ToString()) + " " + decryptoStr(pers["name"].ToString()) + " " + decryptoStr(pers["otch"].ToString());
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
