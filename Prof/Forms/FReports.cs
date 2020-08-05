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
    public partial class FReports : Form
    {
        int[] arrayUserDeparments;
        int ii = 0;
        int idDepart = 0;
        int countAll = 0;
        int countMale = 0;
        int countFemale = 0;
        int countChild = 0;


        bool showNoAllPeople = true;

        public FReports(int[] arrayUserDeparments)
        {
            InitializeComponent();
            this.arrayUserDeparments = arrayUserDeparments;
        }

        private void loadTree()
        {
            for (int i = 0; i < arrayUserDeparments.Length; i++)
            {
                CreateTree(null, arrayUserDeparments[i], true);
            }
        }

        private bool CreateTree(TreeNode rootNode, int idDepartment, bool first)
        {
            bool result = true;
            using (Database.DataBase db = new Database.DataBase())
            {
                if (first)
                {
                    tree_department.Nodes.Clear();
                    Database.Department d = db.Departments.FirstOrDefault(p => p.id == idDepartment); // p.isOst == "T"
                    TreeNode node = new TreeNode();
                    tree_department.Nodes.Add(d.id.ToString(), d.shortName);
                    node = tree_department.Nodes[0];
                    CreateTree(node, idDepartment, false);
                    node.Expand();
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment).ToList();
                    int i = 0;
                    foreach (Database.Department nd in dd)
                    {
                        TreeNode childNode = new TreeNode();
                        rootNode.Nodes.Add(nd.id.ToString(), nd.shortName);
                        childNode = rootNode.Nodes[i];
                        if (CreateTree(childNode, nd.id, false))
                        {
                            var peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == nd.id).ToList();
                            if (peopleDep != null)
                            {
                                if (peopleDep.Where(p => p.Person.type == "W").Count() > 0)
                                {
                                    TreeNode endNode = new TreeNode();
                                    endNode.Name = "W";
                                    endNode.Text = "Сотрудники";
                                    childNode.Nodes.Add("W", "Сотрудники");
                                }
                                if (peopleDep.Where(p => p.Person.type == "S").Count() > 0)
                                {
                                    TreeNode endNode = new TreeNode();
                                    endNode.Name = "S";
                                    endNode.Text = "Студенты";
                                    childNode.Nodes.Add("S", "Студенты");
                                }
                            }
                        }
                        i++;
                    }

                }
            }
            return result;
        }

        private void loadLivingConditions()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                clb_livingConditions.Items.Clear();
                var livingConditions = db.TypeLivingConditions.ToList();
                foreach (Database.TypeLivingCondition lc in livingConditions)
                {
                    clb_livingConditions.Items.Add(lc.name, false);
                }
            }
        }

        private void loadSocialStatus()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                clb_socialStatus.Items.Clear();
                var socialStatus = db.TypeSocialStatus.ToList();
                foreach (Database.TypeSocialStatu ss in socialStatus)
                {
                    clb_socialStatus.Items.Add(ss.name, false);
                }
            }
        }

        private void FReports_Load(object sender, EventArgs e)
        {
            showNoAllPeople = Properties.Settings.Default.showNoAllPeople;
            tsmi_showNotAll.Checked = showNoAllPeople;
            loadTree();
            Visible = true;
            tree_department.SelectedNode = tree_department.Nodes[0];
            dtp_periodStart.Enabled = dtp_periodEnd.Enabled = cb_period.Checked;

            loadSocialStatus();
            loadLivingConditions();
        }

        public bool loadWorks(int idPerson)
        {
            bool molSpece = false;
            DataTable works = peopleWorkTableAdapter1.GetDataByPeopleId(idPerson);
            if (works.Rows.Count != 0)
            {
                int[] stajObsh = new int[3];
                int[] pStaj = new int[3];
                int[] npStaj = new int[3];
                int[] tmp;
                foreach (DataRow pk in works.Rows)
                {
                    if (pk["stajObsh"].ToString().Equals("T") && pk["isActual"].ToString().Equals("T"))
                    {
                        tmp = getStaj(Convert.ToDateTime(pk["dateStart"]), !pk.IsNull("dateEnd") ? Convert.ToDateTime(pk["dateEnd"]) : DateTime.Now);
                        stajObsh[0] += tmp[0];
                        stajObsh[1] += tmp[1];
                        stajObsh[2] += tmp[2];
                    }
                    if (pk["stajPed"].ToString().Equals("T"))
                    {
                        tmp = getStaj(Convert.ToDateTime(pk["dateStart"]), !pk.IsNull("dateEnd") ? Convert.ToDateTime(pk["dateEnd"]) : DateTime.Now);
                        pStaj[0] += tmp[0];
                        pStaj[1] += tmp[1];
                        pStaj[2] += tmp[2];
                    }
                    if (pk["stajNPed"].ToString().Equals("T"))
                    {
                        tmp = getStaj(Convert.ToDateTime(pk["dateStart"]), !pk.IsNull("dateEnd") ? Convert.ToDateTime(pk["dateEnd"]) : DateTime.Now);
                        npStaj[0] += tmp[0];
                        npStaj[1] += tmp[1];
                        npStaj[2] += tmp[2];
                    }
                }
                while (stajObsh[0] > 31)
                {
                    stajObsh[1]++;
                    stajObsh[0] -= 30;
                }
                while (stajObsh[1] > 12)
                {
                    stajObsh[2]++;
                    stajObsh[1] -= 12;
                }
                while (pStaj[0] > 31)
                {
                    pStaj[1]++;
                    pStaj[0] -= 30;
                }
                while (pStaj[1] > 12)
                {
                    pStaj[2]++;
                    pStaj[1] -= 12;
                }
                while (npStaj[0] > 31)
                {
                    npStaj[1]++;
                    npStaj[0] -= 30;
                }
                while (npStaj[1] > 12)
                {
                    npStaj[2]++;
                    npStaj[1] -= 12;
                }

                if (stajObsh[2] < 3) molSpece = true;
                else molSpece = false;
            }
            return molSpece;
        }

        private int[] getStaj(DateTime startDate, DateTime endTime)
        {
            int[] staj = new int[3];
            DateTime dt2 = endTime;
            DateTime tmp = startDate;
            int years = 0;
            int months = 0;
            int day = 0;
            while (tmp < dt2)
            {
                years++;
                tmp = tmp.AddYears(1);
            }
            years--;
            tmp = startDate.AddYears(years);
            while (tmp < dt2)
            {
                months++;
                tmp = tmp.AddMonths(1);
            }
            if (startDate.Day < dt2.Day) months--;

            day = dt2.Day - startDate.Day;
            if (day < 0)
            {
                months--;
                day = 30 + day;
            }
            DateTime.IsLeapYear(startDate.Year);
            staj[0] = day;
            staj[1] = months;
            staj[2] = years;
            return staj;
        }

        public int getAge(DateTime startDate, DateTime endTime)
        {
            DateTime dt2 = endTime;
            DateTime tmp = startDate;
            int years = 0;
            int months = 0;
            int day = 0;
            while (tmp < dt2)
            {
                years++;
                tmp = tmp.AddYears(1);
            }
            years--;
            tmp = startDate.AddYears(years);
            while (tmp < dt2)
            {
                months++;
                tmp = tmp.AddMonths(1);
            }
            if (startDate.Day < dt2.Day) months--;

            day = dt2.Day - startDate.Day;
            if (day < 0)
            {
                months--;
                day = 30 + day;
            }
            DateTime.IsLeapYear(startDate.Year);

            return years;
        }

        private void clb_socialStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            preLoadPeople();
        }

        // функция экспорта в Excel файл
        private void ExportToExcel()
        {
            // Книга Excel.
            Microsoft.Office.Interop.Excel.Workbook m_workBook = null;
            // Страница Excel.
            Microsoft.Office.Interop.Excel.Worksheet m_workSheet = null;
            Microsoft.Office.Interop.Excel._Application m_app = null;
            saveFileDialog1.FileName = DateTime.Now.Day + "." +
                DateTime.Now.Month + "." +
                DateTime.Now.Year + ".xlsx";// по умолчанию сохраняет в корень диска С:
            saveFileDialog1.ShowDialog();
            try
            {
                // Создание приложения Excel.
                m_app = new Microsoft.Office.Interop.Excel.Application();
                // Приложение "невидимо".
                m_app.Visible = false;
                // Приложение управляется пользователем.
                m_app.UserControl = true;
                // Добавление книги Excel.
                m_workBook = m_app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                // Связь со страницей Excel.
                m_workSheet = (Microsoft.Office.Interop.Excel.Worksheet)m_app.ActiveSheet;
                // Заполняем шапку
                int k = 1;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        m_workSheet.Cells[1, j + k] = dgv.Columns[j].HeaderText;
                        ((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[1, j + k]).Font.Bold = true;
                        ((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[1, j + k]).Borders.Color = Color.Black;
                    }
                    else k = 0;
                }
                k = 1;
                // Пишем строку
                for (int l = 0; l < dgv.Rows.Count; l++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible)
                        {
                            m_workSheet.Cells[l + 2, j + k] = dgv[j, l].Value;
                            ((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[1, j + k]).Borders.Color = Color.Black;
                        }
                        else k = 0;
                    }
                }
                // Сохранение файла Excel.
                m_workSheet.Columns.AutoFit();
                m_workBook.SaveCopyAs(saveFileDialog1.FileName);
            }
            finally
            {
                m_app.Visible = true;
                m_app.Interactive = true;
                m_app.ScreenUpdating = true;
                m_app.UserControl = true;
                GC.Collect();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {
            preLoadPeople();
        }

        private void tree_department_AfterSelect(object sender, TreeViewEventArgs e)
        {
            preLoadPeople();
        }

        private void loadPeople(TreeNode idDep, bool first)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                bool noFlag = true;
                if (showNoAllPeople)
                {
                    int idD = 0;
                    IQueryable<Database.PeopleDepartment> peopleDep = null;
                    if (idDep.Name == "W")
                    {
                        idD = Convert.ToInt32(idDep.Parent.Name);
                        
                        Database.Department department = db.Departments.FirstOrDefault(p => p.id == idD);

                        if (rb_all_prof.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Муж" && p.Person.type == "W");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Жен" && p.Person.type == "W");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.type == "W");
                        }
                        else if (rb_inProf.Checked)
                        {
                            if(rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Муж" && p.Person.type == "W");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Жен" && p.Person.type == "W");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.type == "W");
                        }
                        else if (rb_exitProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Муж" && p.Person.type == "W");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Жен" && p.Person.type == "W");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.type == "W");
                        }

                    }
                    else if (idDep.Name == "S")
                    {
                        idD = Convert.ToInt32(idDep.Parent.Name);
                        if (rb_all_prof.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Муж" && p.Person.type == "S");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Жен" && p.Person.type == "S");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.type == "S");
                        }
                        else if (rb_inProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Муж" && p.Person.type == "S");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Жен" && p.Person.type == "S");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.type == "S");
                        }
                        else if (rb_exitProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Муж" && p.Person.type == "S");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Жен" && p.Person.type == "S");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.type == "S");
                        }
                    }
                    else
                    {
                        idD = Convert.ToInt32(idDep.Name);

                        if (rb_all_prof.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD);
                        }
                        else if (rb_inProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T");
                        }
                        else if (rb_exitProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F");
                        }
                    }
                    if (peopleDep.Count() > 0)
                    {
                        int[] arrayFiltr = new int[peopleDep.Count()];
                        if (clb_socialStatus.CheckedItems.Count > 0)
                        {
                            noFlag = false;
                            int arrayIndex = 0;
                            foreach (Database.PeopleDepartment dp in peopleDep)
                            {
                                arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                for (int k = 0; k < clb_socialStatus.CheckedItems.Count; k++)
                                {
                                    string nTss = clb_socialStatus.CheckedItems[k].ToString();
                                    Database.TypeSocialStatu tss = db.TypeSocialStatus.FirstOrDefault(p => p.name == nTss);
                                    Database.PeopleSocialStatu pss = db.PeopleSocialStatus.FirstOrDefault(p => p.idPeople == dp.idPeople && p.idTypeSocialStatus == tss.id);
                                    if (pss == null)
                                    {
                                        arrayFiltr[arrayIndex] = -1;
                                        break;
                                    }
                                }
                                arrayIndex++;
                            }

                        }
                        if (clb_livingConditions.CheckedItems.Count > 0)
                        {
                            noFlag = false;
                            int arrayIndex = 0;
                            foreach (Database.PeopleDepartment dp in peopleDep)
                            {
                                arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                for (int k = 0; k < clb_livingConditions.CheckedItems.Count; k++)
                                {
                                    string nTlc = clb_livingConditions.CheckedItems[k].ToString();
                                    Database.TypeLivingCondition tss = db.TypeLivingConditions.FirstOrDefault(p => p.name == nTlc);
                                    Database.PeopleLivingCondition pss = db.PeopleLivingConditions.FirstOrDefault(p => p.idPeople == dp.idPeople && p.idTypeLivingConditions == tss.id);
                                    if (pss == null)
                                    {
                                        arrayFiltr[arrayIndex] = -1;
                                        break;
                                    }
                                }
                                arrayIndex++;
                            }
                        }
                        if (clb_other.CheckedItems.Count > 0)
                        {
                            noFlag = false;
                            int arrayIndex = 0;
                            foreach (Database.PeopleDepartment dp in peopleDep)
                            {
                                arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                for (int k = 0; k < clb_other.CheckedItems.Count; k++)
                                {
                                    string nOther = clb_other.CheckedItems[k].ToString();
                                    if (nOther.Contains("Младший специалист (до 3х лет)"))
                                    {
                                        if (!loadWorks((int)dp.idPeople))
                                        {
                                            arrayFiltr[arrayIndex] = -1;
                                            break;
                                        }
                                    }
                                    if (nOther.Contains("До 35 лет"))
                                    {
                                        if (getAge((DateTime)dp.Person.birthday, DateTime.Now) > 34)
                                        {
                                            arrayFiltr[arrayIndex] = -1;
                                            break;
                                        }
                                    }
                                    else if (nOther.Contains("Пенсионер"))
                                    {
                                        if (dp.Person.isPensioner == "F")
                                        {
                                            arrayFiltr[arrayIndex] = -1;
                                            break;
                                        }
                                    }
                                }
                                arrayIndex++;
                            }
                        }
                        if (cb_period.Checked)
                        {
                            noFlag = false;
                            int arrayIndex = 0;
                            foreach (Database.PeopleDepartment dp in peopleDep)
                            {
                                arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                if ((dp.Person.dateEnter.Value.Date < dtp_periodStart.Value.Date || dp.Person.dateEnter.Value.Date > dtp_periodEnd.Value.Date) ||
                                    (dp.Person.dateExit.Value.Date >= dtp_periodStart.Value.Date && dp.Person.dateExit.Value.Date <= dtp_periodEnd.Value.Date))
                                    arrayFiltr[arrayIndex] = -1;
                                arrayIndex++;
                            }

                        }
                        if (noFlag)
                        {
                            foreach (Database.PeopleDepartment dp in peopleDep)
                            {
                                Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.isActual == "T" && p.idPeople == dp.idPeople && p.isWorked == "T");

                                dgv.Rows.Add();
                                dgv[0, ii].Value = dp.Person.id;
                                dgv[1, ii].Value = decryptoStr(dp.Person.famil) + " " + decryptoStr(dp.Person.name) + " " + decryptoStr(dp.Person.otch);
                                dgv[2, ii].Value = dp.Person.birthday;
                                if (dp.Person.gender == "Муж")
                                {
                                    dgv[3, ii].Value = "Мужской";
                                    countMale++;
                                }
                                else
                                {
                                    dgv[3, ii].Value = "Женский";
                                    countFemale++;
                                }
                                
                                dgv[4, ii].Value = pw != null ? pw.workPlace : "";
                                dgv[5, ii].Value = pw != null ? pw.doljn : "";
                                dgv[6, ii].Value = dp.Person.type == "W" ? "Сотрудник" : dp.Person.type == "S" ? "Студент" : "";
                                string soc = "";
                                var socialStatus = db.PeopleSocialStatus.Where(p => p.idPeople == dp.idPeople).ToList();
                                if (socialStatus.Count() > 0)
                                {
                                    foreach (Database.PeopleSocialStatu pss in socialStatus)
                                        soc += pss.TypeSocialStatu.name + "; ";
                                }
                                dgv[7, ii].Value = soc.Trim();
                                string child = "";
                                var children = db.PeopleChildrens.Where(p => p.idPeople == dp.idPeople).ToList();
                                if (children.Count() > 0)
                                {
                                    foreach (Database.PeopleChildren ch in children)
                                    {
                                        child += ch.fioChildren + " ( " + getAge(ch.birthday.Value, DateTime.Now).ToString() + " г.); ";
                                        countChild++;
                                    }
                                }
                                dgv[8, ii].Value = child.Trim();
                                string other = "";
                                other += dp.Person.isPensioner == "T" ? "Пенсионер; " : "";
                                other += getAge(dp.Person.birthday.Value, DateTime.Now) < 36 ? "До 35 лет; " : "";
                                other += loadWorks(dp.Person.id) ? "Молодой специалист (до 35 лет); " : "";
                                dgv[9, ii].Value = other;

                                countAll++;

                                ii++;
                            }
                        }
                        else
                        {
                            for (int k = 0; k < arrayFiltr.Length; k++)
                            {
                                if (arrayFiltr[k] != -1)
                                {
                                    int idP = arrayFiltr[k];
                                    Database.Person pers = db.People.FirstOrDefault(p => p.id == idP);
                                    Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.isActual == "T" && p.idPeople == pers.id && p.isWorked == "T");
                                    dgv.Rows.Add();
                                    dgv[0, ii].Value = pers.id;
                                    dgv[1, ii].Value = decryptoStr(pers.famil) + " " + decryptoStr(pers.name) + " " + decryptoStr(pers.otch);
                                    dgv[2, ii].Value = pers.birthday;
                                    if (pers.gender == "Муж")
                                    {
                                        dgv[3, ii].Value = "Мужской";
                                        countMale++;
                                    }
                                    else
                                    {
                                        dgv[3, ii].Value = "Женский";
                                        countFemale++;
                                    }
                                    dgv[4, ii].Value = pw != null ? pw.workPlace : "";
                                    dgv[5, ii].Value = pw != null ? pw.doljn : "";
                                    dgv[6, ii].Value = pers.type == "W" ? "Сотрудник" : pers.type == "S" ? "Студент" : "";
                                    string soc = "";
                                    var socialStatus = db.PeopleSocialStatus.Where(p => p.idPeople == pers.id).ToList();
                                    if (socialStatus.Count() > 0)
                                    {
                                        foreach (Database.PeopleSocialStatu pss in socialStatus)
                                            soc += pss.TypeSocialStatu.name + "; ";
                                    }
                                    dgv[7, ii].Value = soc.Trim();
                                    string child = "";
                                    var children = db.PeopleChildrens.Where(p => p.idPeople == pers.id).ToList();
                                    if (children.Count() > 0)
                                    {
                                        foreach (Database.PeopleChildren ch in children)
                                        {
                                            child += ch.fioChildren + " ( " + getAge(ch.birthday.Value, DateTime.Now).ToString() + " г.); ";
                                            countChild++;
                                        }
                                    }
                                    dgv[8, ii].Value = child.Trim();
                                    string other = "";
                                    other += pers.isPensioner == "T" ? "Пенсионер; " : "";
                                    other += getAge(pers.birthday.Value, DateTime.Now) < 36 ? "До 35 лет; " : "";
                                    other += loadWorks(pers.id) ? "Молодой специалист (до 35 лет); " : "";
                                    dgv[9, ii].Value = other;
                                    countAll++;
                                    ii++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    int idD = 0;
                    IQueryable<Prof.Database.PeopleDepartment> peopleDep = null;
                    if ((idDep.Name == "W" || idDep.Name == "S") && first)
                    {
                        idD = Convert.ToInt32(idDep.Parent.Name);
                        if (rb_all_prof.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Муж" && p.Person.type == idDep.Name);
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Жен" && p.Person.type == idDep.Name);
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.type == idDep.Name);
                        }
                        else if (rb_inProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Муж" && p.Person.type == idDep.Name);
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Жен" && p.Person.type == idDep.Name);
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.type == idDep.Name);
                        }
                        else if (rb_exitProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Муж" && p.Person.type == idDep.Name);
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Жен" && p.Person.type == idDep.Name);
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.type == idDep.Name);
                        }
                    }
                    else if (idDep.Name != "W" && idDep.Name != "S")
                    {
                        idD = Convert.ToInt32(idDep.Name);

                        if (rb_all_prof.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD);
                        }
                        else if (rb_inProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T" && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "T");
                        }
                        else if (rb_exitProf.Checked)
                        {
                            if (rb_male.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Муж");
                            else if (rb_femaly.Checked)
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F" && p.Person.gender == "Жен");
                            else
                                peopleDep = db.PeopleDepartments.Where(p => p.idDepartment == idD && p.Person.isProf == "F");
                        }
                    }
                    if (first)
                    {
                        dgv.Rows.Clear();
                        first = false;
                        idDepart = idD;
                    }
                    if (peopleDep != null)
                    {
                        if (peopleDep.Count() > 0)
                        {
                            int[] arrayFiltr = new int[peopleDep.Count()];
                            if (clb_socialStatus.CheckedItems.Count > 0)
                            {
                                noFlag = false;
                                int arrayIndex = 0;
                                foreach (Database.PeopleDepartment dp in peopleDep)
                                {
                                    arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                    for (int k = 0; k < clb_socialStatus.CheckedItems.Count; k++)
                                    {
                                        string nTss = clb_socialStatus.CheckedItems[k].ToString();
                                        Database.TypeSocialStatu tss = db.TypeSocialStatus.FirstOrDefault(p => p.name == nTss);
                                        Database.PeopleSocialStatu pss = db.PeopleSocialStatus.FirstOrDefault(p => p.idPeople == dp.idPeople && p.idTypeSocialStatus == tss.id);
                                        if (pss == null)
                                        {
                                            arrayFiltr[arrayIndex] = -1;
                                            break;
                                        }
                                    }
                                    arrayIndex++;
                                }

                            }
                            if (clb_livingConditions.CheckedItems.Count > 0)
                            {
                                noFlag = false;
                                int arrayIndex = 0;
                                foreach (Database.PeopleDepartment dp in peopleDep)
                                {
                                    arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                    for (int k = 0; k < clb_livingConditions.CheckedItems.Count; k++)
                                    {
                                        string nTlc = clb_livingConditions.CheckedItems[k].ToString();
                                        Database.TypeLivingCondition tss = db.TypeLivingConditions.FirstOrDefault(p => p.name == nTlc);
                                        Database.PeopleLivingCondition pss = db.PeopleLivingConditions.FirstOrDefault(p => p.idPeople == dp.idPeople && p.idTypeLivingConditions == tss.id);
                                        if (pss == null)
                                        {
                                            arrayFiltr[arrayIndex] = -1;
                                            break;
                                        }
                                    }
                                    arrayIndex++;
                                }
                            }
                            if (clb_other.CheckedItems.Count > 0)
                            {
                                noFlag = false;
                                int arrayIndex = 0;
                                foreach (Database.PeopleDepartment dp in peopleDep)
                                {
                                    arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                    for (int k = 0; k < clb_other.CheckedItems.Count; k++)
                                    {
                                        string nOther = clb_other.CheckedItems[k].ToString();
                                        if (nOther.Contains("Младший специалист (до 3х лет)"))
                                        {
                                            if (!loadWorks((int)dp.idPeople))
                                            {
                                                arrayFiltr[arrayIndex] = -1;
                                                break;
                                            }
                                        }
                                        if (nOther.Contains("До 35 лет"))
                                        {
                                            if (getAge((DateTime)dp.Person.birthday, DateTime.Now) > 34)
                                            {
                                                arrayFiltr[arrayIndex] = -1;
                                                break;
                                            }
                                        }
                                        else if (nOther.Contains("Пенсионер"))
                                        {
                                            if (dp.Person.isPensioner == "F")
                                            {
                                                arrayFiltr[arrayIndex] = -1;
                                                break;
                                            }
                                        }
                                    }
                                    arrayIndex++;
                                }
                            }
                            if (cb_period.Checked)
                            {
                                noFlag = false;
                                int arrayIndex = 0;
                                foreach (Database.PeopleDepartment dp in peopleDep)
                                {
                                    arrayFiltr[arrayIndex] = arrayFiltr[arrayIndex] != -1 ? (int)dp.idPeople : -1;
                                    if ((dp.Person.dateEnter.Value.Date < dtp_periodStart.Value.Date || dp.Person.dateEnter.Value.Date > dtp_periodEnd.Value.Date) ||
                                        (dp.Person.dateExit.Value.Date >= dtp_periodStart.Value.Date && dp.Person.dateExit.Value.Date <= dtp_periodEnd.Value.Date))
                                        arrayFiltr[arrayIndex] = -1; 
                                    arrayIndex++;
                                }
                                
                            }
                            if (noFlag)
                            {
                                foreach (Database.PeopleDepartment dp in peopleDep)
                                {
                                    Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.isActual == "T" && p.idPeople == dp.idPeople && p.isWorked == "T");

                                    dgv.Rows.Add();
                                    dgv[0, ii].Value = dp.Person.id;
                                    dgv[1, ii].Value = decryptoStr(dp.Person.famil) + " " + decryptoStr(dp.Person.name) + " " + decryptoStr(dp.Person.otch);
                                    dgv[2, ii].Value = dp.Person.birthday;
                                    if (dp.Person.gender == "Муж")
                                    {
                                        dgv[3, ii].Value = "Мужской";
                                        countMale++;
                                    }
                                    else
                                    {
                                        dgv[3, ii].Value = "Женский";
                                        countFemale++;
                                    }
                                    dgv[4, ii].Value = pw != null ? pw.workPlace : "";
                                    dgv[5, ii].Value = pw != null ? pw.doljn : "";
                                    dgv[6, ii].Value = dp.Person.type == "W" ? "Сотрудник" : dp.Person.type == "S" ? "Студент" : "";
                                    string soc = "";
                                    var socialStatus = db.PeopleSocialStatus.Where(p => p.idPeople == dp.idPeople).ToList();
                                    if (socialStatus.Count() > 0)
                                    {
                                        foreach (Database.PeopleSocialStatu pss in socialStatus)
                                            soc += pss.TypeSocialStatu.name + "; ";
                                    }
                                    dgv[7, ii].Value = soc.Trim();
                                    string child = "";
                                    var children = db.PeopleChildrens.Where(p => p.idPeople == dp.Person.id).ToList();
                                    if (children.Count() > 0)
                                    {
                                        foreach (Database.PeopleChildren ch in children)
                                        {
                                            child += ch.fioChildren + " ( " + getAge(ch.birthday.Value, DateTime.Now).ToString() + " г.); ";
                                            countChild++;
                                        }
                                    }
                                    dgv[8, ii].Value = child.Trim();
                                    string other = "";
                                    other += dp.Person.isPensioner == "T" ? "Пенсионер; " : "";
                                    other += getAge(dp.Person.birthday.Value, DateTime.Now) < 36 ? "До 35 лет; " : "";
                                    other += loadWorks(dp.Person.id) ? "Молодой специалист (до 35 лет); " : "";
                                    dgv[9, ii].Value = other;
                                    countAll++;
                                    ii++;
                                }
                            }
                            else
                            {
                                for (int k = 0; k < arrayFiltr.Length; k++)
                                {
                                    if (arrayFiltr[k] != -1)
                                    {
                                        int idP = arrayFiltr[k];
                                        Database.Person pers = db.People.FirstOrDefault(p => p.id == idP);
                                        Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.isActual == "T" && p.idPeople == pers.id && p.isWorked == "T");
                                        dgv.Rows.Add();
                                        dgv[0, ii].Value = pers.id;
                                        dgv[1, ii].Value = decryptoStr(pers.famil) + " " + decryptoStr(pers.name) + " " + decryptoStr(pers.otch);
                                        dgv[2, ii].Value = pers.birthday;
                                        if (pers.gender == "Муж")
                                        {
                                            dgv[3, ii].Value = "Мужской";
                                            countMale++;
                                        }
                                        else
                                        {
                                            dgv[3, ii].Value = "Женский";
                                            countFemale++;
                                        }
                                        dgv[4, ii].Value = pw != null ? pw.workPlace : "";
                                        dgv[5, ii].Value = pw != null ? pw.doljn : "";
                                        dgv[6, ii].Value = pers.type == "W" ? "Сотрудник" : pers.type == "S" ? "Студент" : "";
                                        string soc = "";
                                        var socialStatus = db.PeopleSocialStatus.Where(p => p.idPeople == pers.id).ToList();
                                        if (socialStatus.Count() > 0)
                                        {
                                            foreach (Database.PeopleSocialStatu pss in socialStatus)
                                                soc += pss.TypeSocialStatu.name + "; ";
                                        }
                                        dgv[7, ii].Value = soc.Trim();
                                        string child = "";
                                        var children = db.PeopleChildrens.Where(p => p.idPeople == pers.id).ToList();
                                        if (children.Count() > 0)
                                        {
                                            foreach (Database.PeopleChildren ch in children)
                                            {
                                                child += ch.fioChildren + " ( " + getAge(ch.birthday.Value, DateTime.Now).ToString() + " г.); ";
                                                countChild++;
                                            }
                                        }
                                        dgv[8, ii].Value = child.Trim();
                                        string other = "";
                                        other += pers.isPensioner == "T" ? "Пенсионер; " : "";
                                        other += getAge(pers.birthday.Value, DateTime.Now) < 36 ? "До 35 лет; " : "";
                                        other += loadWorks(pers.id) ? "Молодой специалист (до 35 лет); " : "";
                                        dgv[9, ii].Value = other;
                                        countAll++;
                                        ii++;
                                    }
                                }
                            }
                        }
                    }
                    for (int i = 0; i < idDep.Nodes.Count; i++)
                    {
                        loadPeople(idDep.Nodes[i], first);
                    }
                }
            }
        }

        private void tsmi_showNotAll_Click(object sender, EventArgs e)
        {
            showNoAllPeople = !showNoAllPeople;
            tsmi_showNotAll.Checked = showNoAllPeople;
            Properties.Settings.Default.showNoAllPeople = showNoAllPeople;
            Properties.Settings.Default.Save();
            string selectNode = tree_department.SelectedNode.Name;
            loadTree();
            tree_department.SelectedNode = findNode(null, selectNode);
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
                        if (n != null) break;
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
                            if (n != null) break;
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
            else return "";
        }

        private void reportChild(bool first, int idDepartment)
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                if (first)
                {
                    var pd = db.PeopleDepartments.Where(p => p.idDepartment == idDepartment && p.Person.isProf == "T").ToList();

                    if (pd.Count() != 0)
                    {
                        foreach (Database.PeopleDepartment ppd in pd)
                        {
                            var child = db.PeopleChildrens.Where(p => p.idPeople == ppd.idPeople).ToList();
                            if (child.Count() != 0)
                                foreach (Database.PeopleChildren pc in child)
                                    countChild++;
                        }
                    }
                    reportChild(false, idDepartment);
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment);
                    foreach (Database.Department nd in dd)
                    {
                        var pd = db.PeopleDepartments.Where(p => p.idDepartment == nd.id && p.Person.isProf == "T");
                        if (pd.Count() != 0)
                        {
                            foreach (Database.PeopleDepartment ppd in pd)
                            {
                                Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.isActual == "T" && p.idPeople == ppd.idPeople && p.isWorked == "T");
                                var child = db.PeopleChildrens.Where(p => p.idPeople == ppd.idPeople);
                                if (child.Count() != 0)
                                    foreach (Database.PeopleChildren pc in child)
                                        countChild++;
                            }
                        }
                        reportChild(false, nd.id);
                    }
                }
            }
        }
        private void preLoadPeople()
        {
            ii = 0;
            countAll = 0;
            countMale = 0;
            countFemale = 0;
            countChild = 0;
            loadPeople(tree_department.SelectedNode, true);
            tssl_All.Text = $"Всего: {countAll}";
            tssl_male.Text = $"Мужчин: {countMale}";
            tssl_female.Text = $"Женщин: {countFemale}";
            tssl_Child.Text = $"Детей: {countChild}";
        }
    }
}
