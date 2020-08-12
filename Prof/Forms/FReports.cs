using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FReports : MetroFramework.Forms.MetroForm
    {
        private int[] arrayUserDeparments;
        private int countAll = 0;
        private int countMale = 0;
        private int countFemale = 0;
        private int countChild = 0;
        private readonly int idUser;
        private bool showNoAllPeople = true;
        private DataTable dt_persons = new DataTable();

        private int[] arrayUserDeparmentsForLoadPeople;
        private string arrayUserDeparmentsForLoadPeople_String = "";

        public FReports(int[] arrayUserDeparments, int idUser)
        {
            InitializeComponent();
            this.arrayUserDeparments = arrayUserDeparments;
            this.idUser = idUser;
        }

        private void FillArrayUserDeparmentsForLoadPeople(int id_dep)
        {
            if (showNoAllPeople)
            {
                arrayUserDeparmentsForLoadPeople = new int[1];
                arrayUserDeparmentsForLoadPeople[0] = id_dep;
                arrayUserDeparmentsForLoadPeople_String = $"{id_dep}";
            }
            else
            {
                DataTable dt = get_treeTableAdapter1.GetData(null, id_dep);
                arrayUserDeparmentsForLoadPeople = new int[dt.Rows.Count];
                int i = 0;

                foreach (DataRow dt_row in dt.Rows)
                {
                    for (int k = 1; k <= 10; k++)
                    {
                        if (!dt_row.IsNull("lvl" + k.ToString() + "_id"))
                        {
                            if (Array.IndexOf(arrayUserDeparmentsForLoadPeople, (int)dt_row["lvl" + k.ToString() + "_id"]) == -1)
                            {
                                if (arrayUserDeparmentsForLoadPeople.Length == i)
                                {
                                    int[] tmp = new int[arrayUserDeparmentsForLoadPeople.Length + 1];
                                    for (int l = 0; l < arrayUserDeparmentsForLoadPeople.Length; l++)
                                    {
                                        tmp[l] = arrayUserDeparmentsForLoadPeople[l];
                                    }

                                    arrayUserDeparmentsForLoadPeople = new int[tmp.Length];
                                    for (int l = 0; l < tmp.Length; l++)
                                    {
                                        arrayUserDeparmentsForLoadPeople[l] = tmp[l];
                                    }
                                }
                                arrayUserDeparmentsForLoadPeople[i] = (int)dt_row["lvl" + k.ToString() + "_id"];
                                i++;
                            }
                        }

                        if (!dt_row.IsNull("lvl" + k.ToString() + "_idParent") && k != 1)
                        {
                            if (Array.IndexOf(arrayUserDeparmentsForLoadPeople, (int)dt_row["lvl" + k.ToString() + "_idParent"]) == -1)
                            {
                                if (arrayUserDeparmentsForLoadPeople.Length == i)
                                {
                                    int[] tmp = new int[arrayUserDeparmentsForLoadPeople.Length + 1];
                                    for (int l = 0; l < arrayUserDeparmentsForLoadPeople.Length; l++)
                                    {
                                        tmp[l] = arrayUserDeparmentsForLoadPeople[l];
                                    }

                                    arrayUserDeparmentsForLoadPeople = new int[tmp.Length];
                                    for (int l = 0; l < tmp.Length; l++)
                                    {
                                        arrayUserDeparmentsForLoadPeople[l] = tmp[l];
                                    }
                                }
                                arrayUserDeparmentsForLoadPeople[i] = (int)dt_row["lvl" + k.ToString() + "_idParent"];
                                i++;
                            }
                        }
                    }
                }
                arrayUserDeparmentsForLoadPeople_String = "";
                for (i = 0; i < arrayUserDeparmentsForLoadPeople.Length; i++)
                {
                    if (i == arrayUserDeparmentsForLoadPeople.Length - 1)
                    {
                        arrayUserDeparmentsForLoadPeople_String += arrayUserDeparmentsForLoadPeople[i].ToString();
                    }
                    else
                    {
                        arrayUserDeparmentsForLoadPeople_String += arrayUserDeparmentsForLoadPeople[i].ToString() + ",";
                    }
                }
            }
        }

        private void CreateTree()
        {
            tree_department.Nodes.Clear();
            DataTable dt = get_treeTableAdapter1.GetData(idUser, null);
            arrayUserDeparments = new int[1];

            int i = 0;

            foreach (DataRow dt_row in dt.Rows)
            {
                for (int k = 1; k <= 10; k++)
                {
                    arrayUserDeparments[0] = (int)dt_row["lvl1_id"];
                    if (!dt_row.IsNull("lvl" + k.ToString() + "_id"))
                    {
                        if (findNode(null, dt_row["lvl" + k.ToString() + "_id"].ToString()) == null)
                        {
                            if (!dt_row.IsNull("lvl" + k.ToString() + "_idParent"))
                            {
                                TreeNode treeNode = findNode(null, dt_row["lvl" + k.ToString() + "_idParent"].ToString());
                                if (treeNode == null)
                                {
                                    tree_department.Nodes.Add(dt_row["lvl" + k.ToString() + "_id"].ToString(), dt_row["lvl" + k.ToString() + "_shortName"].ToString());
                                }
                                else
                                {
                                    TreeNode childNode = new TreeNode();
                                    treeNode.Nodes.Add(dt_row["lvl" + k.ToString() + "_id"].ToString(), dt_row["lvl" + k.ToString() + "_shortName"].ToString());
                                }
                            }
                        }
                    }
                }
                i++;
            }
            tree_department.Nodes[0].Expand();
        }

        private void loadLivingConditions()
        {
            clb_livingConditions.SelectedIndexChanged -= clb_socialStatus_SelectedIndexChanged;
            ProfDataSet.TypeLivingConditionsDataTable dt = new ProfDataSet.TypeLivingConditionsDataTable();
            try
            {
                typeLivingConditionsTableAdapter1.Fill(dt);
                clb_livingConditions.DataSource = dt;
                clb_livingConditions.DisplayMember = "name";
                clb_livingConditions.ValueMember = "id";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            clb_livingConditions.SelectedIndexChanged += new System.EventHandler(clb_socialStatus_SelectedIndexChanged);
        }

        private void loadSocialStatus()
        {
            clb_socialStatus.SelectedIndexChanged -= clb_socialStatus_SelectedIndexChanged;
            ProfDataSet.TypeSocialStatusDataTable dt = new ProfDataSet.TypeSocialStatusDataTable();
            try
            {
                typeSocialStatusTableAdapter1.Fill(dt);
                clb_socialStatus.DataSource = dt;
                clb_socialStatus.DisplayMember = "name";
                clb_socialStatus.ValueMember = "id";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            clb_socialStatus.SelectedIndexChanged += new System.EventHandler(clb_socialStatus_SelectedIndexChanged);
        }

        private void FReports_Load(object sender, EventArgs e)
        {
            showNoAllPeople = Properties.Settings.Default.showNoAllPeople;
            tsmi_showNotAll.Checked = showNoAllPeople;
            CreateTree();
            tree_department.SelectedNode = tree_department.Nodes[0];
            dtp_periodStart.Enabled = dtp_periodEnd.Enabled = cb_period.Checked;

            loadSocialStatus();
            loadLivingConditions();
        }

        private void clb_socialStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            preLoadPeople();
        }

        private void ExportDtToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application(); // запускаем Excel для чтения входного файла
            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet); // открываем шаблон указываю документ, в который я буду записывать данные
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveSheet;   //  выбор листа 
            int x = 1; // строка листа excel

            metroProgressBar1.Maximum = dt_persons.Rows.Count + dgv.Columns.Count - 1;
            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                if (dgv.Columns[j].Visible)
                {
                    ws.Cells[1, j + x] = dgv.Columns[j].HeaderText;
                    ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, j + x]).Font.Bold = true;
                    ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, j + x]).Borders.Color = Color.Black;
                }
                else
                {
                    x = 0;
                }

                metroProgressBar1.Value++;
            }
            x = 2;
            foreach (DataRow nc in dt_persons.Rows)
            {
                ws.Cells[x, 1] = nc[1].ToString();
                ws.Cells[x, 2] = nc[2].ToString();
                ws.Cells[x, 3] = nc[3].ToString();
                ws.Cells[x, 4] = nc[4].ToString();
                ws.Cells[x, 5] = nc[5].ToString();
                ws.Cells[x, 6] = nc[6].ToString();
                ws.Cells[x, 7] = nc[7].ToString();
                ws.Cells[x, 8] = nc[8].ToString();
                ws.Cells[x, 9] = nc[9].ToString();
                ws.Cells[x, 10] = nc[10].ToString();
                x++;
                metroProgressBar1.Value++;
            }
            ws.Columns.AutoFit();
            saveFileDialog1.FileName = DateTime.Now.Day + "." +
                DateTime.Now.Month + "." +
                DateTime.Now.Year + ".xlsx";
            saveFileDialog1.ShowDialog();
            wb.SaveAs(saveFileDialog1.FileName);
            xlApp.Visible = true;
            xlApp.Interactive = true;
            xlApp.ScreenUpdating = true;
            xlApp.UserControl = true;
            GC.Collect();
            metroProgressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportDtToExcel();
        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {
            preLoadPeople();
        }

        private void tree_department_AfterSelect(object sender, TreeViewEventArgs e)
        {
            preLoadPeople();
        }

        private void loadPeople()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int idD = Convert.ToInt32(tree_department.SelectedNode.Name);
            SqlConnection conn = DB.GetDBConnection();
            string select = " select distinct p.id, p.famil, p.name, p.otch, p.birthday, p.gender, " +
                         " p.type, " +
                         " (SELECT distinct pw.workPlace FROM prof.PeopleWork pw WHERE (pw.idPeople = p.id) AND (isWorked = 'T') AND (isActual = 'T')) as workPlace, " +
                         " (SELECT distinct pw.doljn FROM prof.PeopleWork pw WHERE (pw.idPeople = p.id) AND (isWorked = 'T') AND (isActual = 'T')) as doljn," +
                         " (select childrens from ( select distinct pc.idPeople, stuff((select ', ' + fioChildren + '( ' + CAST(YEAR(birthday) as VARCHAR) + 'г. )' from prof.PeopleChildren where idPeople = pc.idPeople order by id for XML path('')),1,1,'') childrens from prof.PeopleChildren pc) as www where www.idPeople = p.id) as child, ";
            string from = " from prof.PeopleDepartment pd ";
            string leftJoin = " left join prof.People p on p.id = pd.idPeople ";
            string where = "";
            string whereSocialStatus = "";
            string whereLivingConditions = "";
            FillArrayUserDeparmentsForLoadPeople(idD);
            string paramArr = arrayUserDeparmentsForLoadPeople_String;
            bool ms = false;
            bool do35 = false;
            bool pens = false;

            if (rb_all_prof.Checked)
            {
                if (rb_male.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Муж' ";
                }
                else if (rb_femaly.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Жен' ";
                }
                else
                {
                    where += $" pd.idDepartment in ({paramArr}) ";
                }
            }
            else if (rb_inProf.Checked)
            {
                if (rb_male.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Муж' and p.isProf = 'T' ";
                }
                else if (rb_femaly.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Жен' and p.isProf = 'T' ";
                }
                else
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.isProf = 'T' ";
                }
            }
            else if (rb_exitProf.Checked)
            {
                if (rb_male.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Муж' and p.isProf = 'F' ";
                }
                else if (rb_femaly.Checked)
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.gender = 'Жен' and p.isProf = 'F' ";
                }
                else
                {
                    where += $" pd.idDepartment in ({paramArr}) and p.isProf = 'F' ";
                }
            }

            string socIn = "";
            if (clb_socialStatus.CheckedItems.Count > 0)
            {
                socIn += " where ";
                for (int k = 0; k < clb_socialStatus.CheckedItems.Count; k++)
                {
                    DataRowView drv = (DataRowView)clb_socialStatus.CheckedItems[k];
                    whereSocialStatus += $" pss.idTypeSocialStatus = {drv.Row["id"]} and ";
                    if (k == clb_socialStatus.CheckedItems.Count - 1)
                    {
                        socIn += $" soc.idTypeSocialStatus = {drv.Row["id"]} ";
                    }
                    else
                    {
                        socIn += $" soc.idTypeSocialStatus = {drv.Row["id"]} and ";
                    }
                }
                where += $" and (select count(id) from prof.PeopleSocialStatus pss where {whereSocialStatus} pss.idPeople = p.id ) > 0 ";
            }
            select += $" (select socName from ( select distinct soc.idPeople, stuff((select ', ' + ptss.name from prof.PeopleSocialStatus psoc left join prof.TypeSocialStatus ptss on ptss.id = psoc.idTypeSocialStatus where psoc.idPeople = soc.idPeople order by ptss.id for XML path('')),1,1,'') socName from prof.PeopleSocialStatus soc {socIn}) as www where www.idPeople = p.id) as socialStatus, ";

            string plcIn = "";
            if (clb_livingConditions.CheckedItems.Count > 0)
            {
                plcIn += " where ";
                for (int k = 0; k < clb_livingConditions.CheckedItems.Count; k++)
                {
                    DataRowView drv = (DataRowView)clb_livingConditions.CheckedItems[k];
                    whereLivingConditions += $" plc.idTypeLivingConditions = {drv.Row["id"]} and ";
                    if (k == clb_livingConditions.CheckedItems.Count - 1)
                    {
                        plcIn += $" plcc.idTypeLivingConditions = {drv.Row["id"]} ";
                    }
                    else
                    {
                        plcIn += $" plcc.idTypeLivingConditions = {drv.Row["id"]} and ";
                    }
                }
                where += $" and (select count(id) from prof.PeopleLivingConditions plc where {whereLivingConditions} plc.idPeople = p.id ) > 0 ";
            }
            select += $" (select livName from(select distinct plcc.idPeople, stuff((select ', ' + ptlc.name from prof.PeopleLivingConditions pplc left join prof.TypeLivingConditions ptlc on ptlc.id = pplc.idTypeLivingConditions where pplc.idPeople = plcc.idPeople order by ptlc.id for XML path('')),1,1,'') livName from prof.PeopleLivingConditions plcc {plcIn}) as www where www.idPeople = p.id) as livinCond ";

            if (clb_other.CheckedItems.Count > 0)
            {
                for (int k = 0; k < clb_other.CheckedItems.Count; k++)
                {
                    string nOther = clb_other.CheckedItems[k].ToString();
                    if (nOther.Contains("Молодой специалист (до 3х лет)"))
                    {
                        ms = true;
                        where += $" and (select staj_o.years_out from dbo.get_staj_func(p.id) staj_o ) < 3 " +
                            $" and (select count(pw.idPeople) from prof.PeopleWork pw where pw.idPeople = p.id) <> 0 ";
                    }
                    if (nOther.Contains("До 35 лет"))
                    {
                        do35 = true;
                        where += $" and dbo.fullAge(p.birthday, CURRENT_TIMESTAMP) < 35 ";
                    }
                    else if (nOther.Contains("Пенсионер"))
                    {
                        pens = true;
                        where += $" and p.isPensioner = 'T' ";
                    }
                }
            }

            if (cb_period.Checked)
            {
                where += $" and ((p.dateEnter < '{ dtp_periodStart.Value.ToShortDateString() }' or p.dateEnter > '{ dtp_periodEnd.Value.ToShortDateString() }') ";
                where += $" or (p.dateExit >= '{ dtp_periodStart.Value.ToShortDateString() }' and p.dateExit <= '{ dtp_periodEnd.Value.ToShortDateString() }')) ";
            }
            string sql = select + " " + from + " " + leftJoin + " where " + where;
            SqlCommand sqlCommand = new SqlCommand(sql)
            {
                Connection = conn
            };

            conn.Open();
            using (DbDataReader reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    ProfDataSet.PeopleWorkDataTable dtpw = new ProfDataSet.PeopleWorkDataTable();
                    while (reader.Read())
                    {
                        DataRow dr = dt_persons.NewRow();
                        dr[0] = reader.GetInt32(0);
                        dr[1] = decryptoStr(reader.GetString(1)) + " " + decryptoStr(reader.GetString(2)) + " " + decryptoStr(reader.GetString(3));
                        dr[2] = !reader.IsDBNull(4) ? reader.GetDateTime(4) : DateTime.Now;
                        if (reader.GetString(5).Equals("Муж")) { dr[3] = "Мужской"; countMale++; }
                        else { dr[3] = "Женский"; countFemale++; }
                        dr[4] = !reader.IsDBNull(7) ? reader.GetString(7) : "";
                        dr[5] = !reader.IsDBNull(8) ? reader.GetString(8) : "";
                        dr[6] = reader.GetString(6).Equals("W") ? "Сотрудник" : "Студент";
                        dr[7] = !reader.IsDBNull(10) ? reader.GetString(10) : "";
                        dr[8] = !reader.IsDBNull(11) ? reader.GetString(11) : "";
                        dr[9] = !reader.IsDBNull(9) ? reader.GetString(9) : "";
                        string other = "";
                        other += pens ? "Пенсионер; " : "";
                        other += do35 ? "До 35 лет; " : "";
                        other += ms ? "Молодой специалист (до 35 лет); " : "";
                        dr[10] = other;
                        dt_persons.Rows.Add(dr);
                        countAll++;
                    }
                }
            }
            conn.Close();
            conn.Dispose();

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = string.Format("{0:00}м. {1:00}с. {2:00}мс.", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            speedLoadGrid.Text = "Скорость загрузки таблицы: " + elapsedTime;
        }

        private void tsmi_showNotAll_Click(object sender, EventArgs e)
        {
            showNoAllPeople = !showNoAllPeople;
            tsmi_showNotAll.Checked = showNoAllPeople;
            Properties.Settings.Default.showNoAllPeople = showNoAllPeople;
            Properties.Settings.Default.Save();
            preLoadPeople();
        }

        private TreeNode findNode(TreeNode node, string name)
        {
            bool find = false;
            TreeNode n = null;
            if (!find)
            {
                if (node == null)
                {
                    for (int i = 0; i < tree_department.Nodes.Count; i++)
                    {
                        n = findNode(tree_department.Nodes[i], name);
                        if (n != null)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (node.Name == name)
                    {
                        return node;
                    }
                    else
                    {
                        for (int i = 0; i < node.Nodes.Count; i++)
                        {
                            n = findNode(node.Nodes[i], name);
                            if (n != null)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            return n;
        }

        private void rb_all_prof_CheckedChanged(object sender, EventArgs e)
        {
            preLoadPeople();
        }

        private void cb_period_CheckedChanged(object sender, EventArgs e)
        {
            dtp_periodStart.Enabled = dtp_periodEnd.Enabled = cb_period.Checked;
            preLoadPeople();
        }

        private void dtp_periodStart_ValueChanged(object sender, EventArgs e)
        {
            preLoadPeople();
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
            else
            {
                return "";
            }
        }

        private void preLoadPeople()
        {
            countAll = 0;
            countMale = 0;
            countFemale = 0;
            countChild = 0;

            dt_persons = new DataTable("persons");
            dt_persons.Columns.Add(new DataColumn("id", typeof(int)));
            dt_persons.Columns.Add(new DataColumn("Ф.И.О.", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Дата рождения", typeof(DateTime)));
            dt_persons.Columns.Add(new DataColumn("Пол", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Место работы", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Должность", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Сотрудник / студент", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Социальный статус", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Жилищные условия", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Дети", typeof(string)));
            dt_persons.Columns.Add(new DataColumn("Другое", typeof(string)));

            loadPeople();
            tssl_All.Text = $"Всего: {countAll}";
            tssl_male.Text = $"Мужчин: {countMale}";
            tssl_female.Text = $"Женщин: {countFemale}";
            tssl_Child.Text = $"Детей: {countChild}";

            dgv.Enabled = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.DataSource = dt_persons;
            dgv.Columns[0].Visible = false;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Enabled = true;
        }
    }
}
