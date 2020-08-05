using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prof
{
    public partial class FPerson : MetroFramework.Forms.MetroForm
    {
        #region variobles
        int idUser = 0;
        bool newPers = true;
        int idPerson = 0;
        int idDep = 0;
        int idChild = 0;
        int idEduc = 0;
        int idMatPom = 0;
        int idOtheEnc = 0;
        int idTrudKnij = 0;
        int rowNum = 0;
        private int[] arrayUserDeparments;
        private int[] lArrayUserDeparments;
        private string arrayUserDeparmentsAll_String;
        #endregion
        #region constructor
        public FPerson(int idUser, bool newPers, int idPerson, int idDep, int[] arrayUserDeparments, string arrayUserDeparmentsAll_String)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.newPers = newPers;
            this.idPerson = idPerson;
            this.idDep = idDep;
            this.arrayUserDeparments = arrayUserDeparments;
            this.arrayUserDeparmentsAll_String = arrayUserDeparmentsAll_String;
        }
        #endregion
        #region load functions
        private void FPerson_Load(object sender, EventArgs e)
        {
            settingLoad();
            loadSocialStatus();
            loadLivingConditions();
            loadTypeEnc();
            if (!newPers) loadPers();
        }

        private void LoadDepartments()
        {
            cb_dep.Items.Clear();
            SqlConnection conn = DB.GetDBConnection();
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = " select dp.id as did, concat('(', d.shortName, ') ', dp.fullName) as fname from prof.Departments d  " +
                         " inner join prof.Departments dp on dp.idparent = d.id  " +
                         $" where d.id in ({arrayUserDeparmentsAll_String}) order by d.shortName, dp.fullName ";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            conn.Open();
            try
            {
                adapter.Fill(dt);
                cb_dep.DataSource = dt;
                cb_dep.DisplayMember = "fname";
                cb_dep.ValueMember = "did";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                if (newPers) cb_dep.SelectedValue = idDep;
            }
        }

        private void loadSocialStatus()
        {
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
        }

        private void loadTypeEnc()
        {
            ProfDataSet.TypeEncouragementDataTable dt = new ProfDataSet.TypeEncouragementDataTable();
            try
            {
                dt = typeEncouragementTableAdapter1.GetDataOther();
                cb_typeOtherEnc.DataSource = dt;
                cb_typeOtherEnc.DisplayMember = "name";
                cb_typeOtherEnc.ValueMember = "id";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadLivingConditions()
        {
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
        }

        private void settingLoad()
        {
            p_allInfoChild.Height = 1;
            p_allInfoEduc.Height = 1;
            p_allInfoTrudKnig.Height = 1;
            p_allInfoMat.Height = 1;
            p_allInfoOtherEnc.Height = 1;
            LoadDepartments();
            
        }

        private void loadChild()
        {
            ProfDataSet.PeopleChildrenDataTable dt = new ProfDataSet.PeopleChildrenDataTable();
            try
            {
                dgv_Child.AutoGenerateColumns = false;
                peopleChildrenTableAdapter1.FillByPers(dt, idPerson);
                dgv_Child.DataSource = dt;
                dgv_Child.Columns[0].DataPropertyName = "id";
                dgv_Child.Columns[1].DataPropertyName = "fioChildren";
                dgv_Child.Columns[2].DataPropertyName = "birthday";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadDoc()
        {
            ProfDataSet.PeopleDataTable dtPers = new ProfDataSet.PeopleDataTable();
            peopleTableAdapter1.FillByPers(dtPers, idPerson);

            cb_doc.SelectedItem = !dtPers.Rows[0].IsNull("typeDoc") ? decryptoStr(dtPers.Rows[0]["typeDoc"].ToString()) : "";
            tb_docSer.Text = !dtPers.Rows[0].IsNull("pasp_ser") ? decryptoStr(dtPers.Rows[0]["pasp_ser"].ToString()) : "";
            tb_docNum.Text = !dtPers.Rows[0].IsNull("pasp_num") ? decryptoStr(dtPers.Rows[0]["pasp_num"].ToString()) : "";
            tb_docIssue.Text = !dtPers.Rows[0].IsNull("pasp_issue") ? decryptoStr(dtPers.Rows[0]["pasp_issue"].ToString()) : "";
            dtp_docDate.Value = !dtPers.Rows[0].IsNull("pasp_date") ? Convert.ToDateTime(dtPers.Rows[0]["pasp_date"]) : dtp_docDate.MinDate;
            tb_propiska.Text = !dtPers.Rows[0].IsNull("propiska") ? decryptoStr(dtPers.Rows[0]["propiska"].ToString()) : "";

            ProfDataSet.PeopleSocialStatusDataTable dtPersSocial = new ProfDataSet.PeopleSocialStatusDataTable();
            peopleSocialStatusTableAdapter1.FillByPers(dtPersSocial, idPerson);
            foreach (DataRow dr in dtPersSocial.Rows)
            {
                for (int i = 0; i < clb_socialStatus.Items.Count; i++)
                {
                    if (clb_socialStatus.Items[i].ToString() == dr["TypeSocialStatus_name"].ToString())
                    {
                        clb_socialStatus.SetItemChecked(i, true);
                    }
                }
            }
            ProfDataSet.PeopleLivingConditionsDataTable dtPersLivin = new ProfDataSet.PeopleLivingConditionsDataTable();
            peopleLivingConditionsTableAdapter1.FillByPers(dtPersLivin, idPerson);
            foreach (DataRow dr in dtPersLivin.Rows)
            {
                for (int i = 0; i < clb_livingConditions.Items.Count; i++)
                {
                    if (clb_livingConditions.SelectedValue.ToString() == dr["TypeLivingConditions_name"].ToString())
                    {
                        clb_livingConditions.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void loadPers()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                Database.Person pers = db.People.FirstOrDefault(p => p.id == idPerson);
                tb_famil.Text = decryptoStr(pers.famil);
                tb_name.Text = decryptoStr(pers.name);
                tb_otch.Text = decryptoStr(pers.otch);
                tb_phone.Text = decryptoStr(pers.phone);
                dtp_birthday.Value = pers.birthday != null ? pers.birthday.Value : dtp_birthday.MinDate;
                if (pers.gender == "Муж") rb_male.Checked = true;
                else if (pers.gender == "Жен") rb_female.Checked = true;

                if (pers.type == "T") rb_w.Checked = true;
                else if (pers.type == "S") rb_s.Checked = true;
                cb_isPens.Checked = pers.isPensioner == "T" ? true : false;
                cb_isProf.Checked = pers.isProf == "T" ? true : false;
                dtp_enterProf.Value = pers.dateEnter != null ? pers.dateEnter.Value : dtp_enterProf.MinDate;
                if (!cb_isPens.Checked) dtp_exitProf.Value = pers.dateExit != null ? pers.dateExit.Value : dtp_exitProf.MinDate;
                else label11.Visible = dtp_exitProf.Visible = false;
                tb_numProfBil.Text = pers.numProfTicket;
                tb_startJob.Text = pers.startTrudYearStr.ToString();
                Database.PeopleDepartment pd = db.PeopleDepartments.FirstOrDefault(p => p.idPeople == idPerson);
                cb_dep.SelectedItem = pd.Department.fullName;

                tb_nagr.Text = pers.activity;
                tb_obshDeyat.Text = pers.socialWork;
                tb_hobbies.Text = pers.hobbies;

                loadDoc();
                loadChild();
                loadEduc();
                loadMatHelp();
                loadOtherHelp();
                loadWorks();
            }
        }

        private void loadEduc()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                var persEducs = db.Educations.Where(p => p.idPeople == idPerson).ToList();
                dgv_educ.Rows.Clear();
                if (persEducs.Count() != 0)
                {
                    dgv_educ.Rows.Add(persEducs.Count());
                    int i = 0;
                    foreach (Database.Education educ in persEducs)
                    {
                        dgv_educ[0, i].Value = educ.id;
                        dgv_educ[1, i].Value = educ.stLevel;
                        dgv_educ[2, i].Value = educ.nameUniver;
                        dgv_educ[3, i].Value = educ.nameSpec;
                        dgv_educ[4, i].Value = educ.nameKval;
                        dgv_educ[5, i].Value = educ.numDipl;
                        dgv_educ[6, i].Value = educ.dateEduc;
                        i++;
                    }
                }
            }
        }

        private void loadMatHelp()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                var matHelp = db.PeopleEncouragements.Where(p => p.idPeople == idPerson && p.idTypeEncouragement == 1).ToList();
                dgv_mat.Rows.Clear();
                if (matHelp.Count() != 0)
                {
                    dgv_mat.Rows.Add(matHelp.Count());
                    int i = 0;
                    foreach (Database.PeopleEncouragement pe in matHelp)
                    {
                        dgv_mat[0, i].Value = pe.id;
                        dgv_mat[1, i].Value = pe.TypeEncouragement.name;
                        dgv_mat[2, i].Value = pe.dateEncouragement.Value;
                        dgv_mat[3, i].Value = pe.source;
                        dgv_mat[4, i].Value = pe.countMat;
                    }
                }
            }
        }

        private void loadOtherHelp()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                var matHelp = db.PeopleEncouragements.Where(p => p.idPeople == idPerson && p.idTypeEncouragement != 1).ToList();
                dgv_OtherEnc.Rows.Clear();
                if (matHelp.Count() != 0)
                {
                    dgv_OtherEnc.Rows.Add(matHelp.Count());
                    int i = 0;
                    foreach (Database.PeopleEncouragement pe in matHelp)
                    {
                        dgv_OtherEnc[0, i].Value = pe.id;
                        dgv_OtherEnc[1, i].Value = pe.TypeEncouragement.name;
                        dgv_OtherEnc[2, i].Value = pe.dateEncouragement.Value;
                        dgv_OtherEnc[3, i].Value = pe.source;
                        i++;
                    }
                }
            }
        }

        private void loadWorks()
        {
            using (Database.DataBase db = new Database.DataBase())
            {
                var works = db.PeopleWorks.Where(p => p.idPeople == idPerson).OrderBy(p => p.dateStart).ToList();
                dgv_trudKnig.Rows.Clear();
                if (works.Count() != 0)
                {
                    dgv_trudKnig.Rows.Add(works.Count());
                    int i = 0;
                    int[] stajObsh = new int[3];
                    int[] pStaj = new int[3];
                    int[] npStaj = new int[3];
                    int[] tmp;
                    foreach (Database.PeopleWork pk in works)
                    {
                        dgv_trudKnig[0, i].Value = pk.id;
                        dgv_trudKnig[1, i].Value = pk.dateStart;
                        dgv_trudKnig[2, i].Value = pk.workPlace;
                        dgv_trudKnig[3, i].Value = pk.doljn;
                        dgv_trudKnig[4, i].Value = pk.dateEnd;
                        dgv_trudKnig[5, i].Value = pk.stajObsh == "T" ? true : false;
                        dgv_trudKnig[6, i].Value = pk.stajPed == "T" ? true : false;
                        dgv_trudKnig[7, i].Value = pk.stajNPed == "T" ? true : false;
                        dgv_trudKnig[8, i].Value = pk.isActual == "T" ? true : false;
                        dgv_trudKnig[9, i].Value = pk.isSovm == "T" ? true : false;
                        dgv_trudKnig[10, i].Value = pk.isWorked == "T" ? true : false;

                        if (pk.stajObsh == "T" && pk.isActual == "T")
                        {
                            tmp = getStaj(pk.dateStart.Value, pk.dateEnd != null ? pk.dateEnd.Value : DateTime.Now);
                            stajObsh[0] += tmp[0];
                            stajObsh[1] += tmp[1];
                            stajObsh[2] += tmp[2];
                        }
                        if (pk.stajPed == "T")
                        {
                            tmp = getStaj(pk.dateStart.Value, pk.dateEnd != null ? pk.dateEnd.Value : DateTime.Now);
                            pStaj[0] += tmp[0];
                            pStaj[1] += tmp[1];
                            pStaj[2] += tmp[2];
                        }
                        if (pk.stajNPed == "T")
                        {
                            tmp = getStaj(pk.dateStart.Value, pk.dateEnd != null ? pk.dateEnd.Value : DateTime.Now);
                            npStaj[0] += tmp[0];
                            npStaj[1] += tmp[1];
                            npStaj[2] += tmp[2];
                        }
                        i++;
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

                    l_ObshStaj.Text = $"{stajObsh[2]}г. {stajObsh[1]}м. {stajObsh[0]}д.";
                    l_PStaj.Text = $"{pStaj[2]}г. {pStaj[1]}м. {pStaj[0]}д.";
                    l_NPStaj.Text = $"{npStaj[2]}г. {npStaj[1]}м. {npStaj[0]}д.";

                    if (stajObsh[2] < 3) l_molodSpec.Visible = true;
                    else l_molodSpec.Visible = false;
                }
            }
        }
        #endregion
        #region other functions
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

        private int currentAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (birthday > now.AddYears(-age)) age--;
            return age;
        }

        private string currentAgeFull(DateTime birthday)
        {
            string fullAge = "";
            DateTime dt2 = DateTime.Today;
            DateTime tmp = birthday;
            int years = 0;
            int months = 0;
            int day = 0;
            if (tmp.Date != dt2.Date)
            {
                while (tmp < dt2)
                {
                    years++;
                    tmp = tmp.AddYears(1);
                }
                years--;
                tmp = birthday.AddYears(years);
                while (tmp < dt2)
                {
                    months++;
                    tmp = tmp.AddMonths(1);
                }
                if (birthday.Day < dt2.Day) months--;

                day = dt2.Day - birthday.Day;
                if (day < 0)
                {
                    months--;
                    day = 30 + day;
                }
                DateTime.IsLeapYear(birthday.Year);
            }
            string nameYears = years == 1 ? "год" : years < 4 && years > 1 ? "года" : "лет";
            string nameMonths = months == 1 ? "месяц" : months > 1 && months < 5 ? "месяца" : "месяцев";
            string nameDays = day == 1 || day == 21 || day == 31 ? "день" : (day > 1 && day < 5) || (day > 21 && day < 25) ? "дня" : "дней";

            fullAge = String.Format("{0} {1} {2} {3} {4} {5}", years, nameYears, months, nameMonths, day, nameDays);
            return fullAge;
        }

        #endregion
        #region add functions
        private void b_addChild_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoChild.Height = 28;
                tb_fioChild.Clear();
                idChild = 0;
            }
        }

        private void b_addEduc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoEduc.Height = 91;
                cb_typeEduc.SelectedIndex = 0;
                tb_Educ.Clear();
                tb_spec.Clear();
                tb_kval.Clear();
                tb_numEduc.Clear();
                dtp_educ.Value = DateTime.Now;
                idEduc = 0;
                b_saveEduc.Enabled = true;
                b_cancelEduc.Enabled = true;
            }
        }

        private void b_addTrudKnig_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoTrudKnig.Height = 98;
                idTrudKnij = 0;
                dtp_startWork.Value = DateTime.Now;
                dtp_finishWork.Value = DateTime.Now;
                cb_worked.Checked = false;
                tb_positionWork.Clear();
                tb_whereWork.Clear();
                cb_stajPed.Checked = false;
                cb_stajNPed.Checked = false;
                cb_osnJobTrudKnig.Checked = false;
            }
        }

        private void b_addMat_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoMat.Height = 33;
                idMatPom = 0;
                dtp_mat.Value = DateTime.Now;
                cb_matSource.SelectedIndex = 0;
                tb_matCount.Clear();
            }
        }

        private void b_addOtherEnc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoOtherEnc.Height = 33;
                idOtheEnc = 0;
                dtp_dateOtherEnc.Value = DateTime.Now;
                cb_sourceOtherEnc.SelectedIndex = 0;
                cb_typeOtherEnc.SelectedIndex = 0;
            }
        }


        #endregion
        #region cancel functions
        private void b_cancelMain_Click(object sender, EventArgs e)
        {
            loadPers();
        }

        private void b_cancelDoc_Click(object sender, EventArgs e)
        {
            loadDoc();
        }

        private void b_cancelChild_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loadChild();
                p_allInfoChild.Height = 1;
            }
        }

        private void b_cancelEduc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loadEduc();
                p_allInfoEduc.Height = 1;
            }
        }

        private void b_cancelDopSved_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loadPers();
            }
        }

        private void b_cancelMat_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loadMatHelp();
                p_allInfoMat.Height = 1;
            }
        }

        private void b_cancelOtherEnc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                loadOtherHelp();
                p_allInfoOtherEnc.Height = 1;
            }
        }

        private void b_cancelTrudKnig_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoTrudKnig.Height = 1;
                loadWorks();
            }
        }


        #endregion
        #region delete functions
        private void b_deleteChild_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idChild == 0)
                {
                    MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (Database.DataBase db = new Database.DataBase())
                        {
                            db.PeopleChildrens.Remove(db.PeopleChildrens.FirstOrDefault(p => p.id == idChild));
                            db.SaveChanges();
                        }
                    }
                }
                loadChild();
                p_allInfoChild.Height = 1;
            }
        }

        private void b_deleteEduc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idEduc == 0)
                {
                    MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (Database.DataBase db = new Database.DataBase())
                        {
                            db.Educations.Remove(db.Educations.FirstOrDefault(p => p.id == idEduc));
                            db.SaveChanges();
                            idEduc = 0;
                        }
                    }
                }

                loadEduc();
                p_allInfoEduc.Height = 1;
            }
        }

        private void b_deleteDopSved_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tb_nagr.Clear();
                tb_obshDeyat.Clear();
                tb_hobbies.Clear();
                b_saveDopSved.PerformClick();
            }
        }

        private void b_deleteMat_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idMatPom == 0)
                    {
                        MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.PeopleEncouragements.Remove(db.PeopleEncouragements.FirstOrDefault(p => p.id == idMatPom));
                            db.SaveChanges();
                        }
                    }
                }
                loadMatHelp();
                p_allInfoMat.Height = 1;
            }
        }

        private void b_deleteOtherEnc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idOtheEnc == 0)
                    {
                        MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.PeopleEncouragements.Remove(db.PeopleEncouragements.FirstOrDefault(p => p.id == idOtheEnc));
                            db.SaveChanges();
                        }
                    }
                }
                loadOtherHelp();
                p_allInfoOtherEnc.Height = 1;
            }
        }

        private void b_deleteTrudKnig_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idTrudKnij == 0)
                    {
                        MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.PeopleWorks.Remove(db.PeopleWorks.FirstOrDefault(p => p.id == idTrudKnij));
                            db.SaveChanges();
                        }
                    }
                }
                p_allInfoTrudKnig.Height = 1;
                loadWorks();
            }
        }


        #endregion
        #region save functions
        private void b_saveMain_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                if (tb_famil.Text.Trim() != "" && tb_name.Text.Trim() != "" && cb_dep.SelectedItem.ToString().Trim() != "")
                {
                    using (Database.DataBase db = new Database.DataBase())
                    {
                        Database.Person p = new Database.Person();
                        p.famil = cryptoStr(tb_famil.Text.Trim());
                        p.name = cryptoStr(tb_name.Text.Trim());
                        p.otch = cryptoStr(tb_otch.Text.Trim());
                        p.phone = cryptoStr(tb_phone.Text.Trim());
                        p.birthday = dtp_birthday.Value;
                        p.gender = rb_male.Checked ? "Муж" : rb_female.Checked ? "Жен" : "";
                        p.type = rb_w.Checked ? "W" : rb_s.Checked ? "S" : "";
                        p.isPensioner = cb_isPens.Checked ? "T" : "F";
                        p.isProf = cb_isProf.Checked ? "T" : "F";
                        p.dateEnter = dtp_enterProf.Value;
                        p.numProfTicket = tb_numProfBil.Text.Trim();
                        p.dateExit = cb_isProf.Checked ? dtp_exitProf.Value : dtp_exitProf.MinDate;
                        p.startTrudYearStr = tb_startJob.Text.Trim() != "" ? tb_startJob.Text.Trim() : "";
                        p.dateCrt = DateTime.Now;
                        db.People.Add(p);
                        idPerson = p.id;
                        //idDep = db.Departments.FirstOrDefault(pp => pp.fullName == cb_dep.SelectedItem.ToString()).id;
                        idDep = lArrayUserDeparments[cb_dep.SelectedIndex];
                        db.PeopleDepartments.Add(new Database.PeopleDepartment { idPeople = idPerson, idDepartment = idDep, dateCrt = DateTime.Now });
                        db.SaveChanges();
                        idPerson = p.id;
                        newPers = false;
                        MessageBox.Show("Новая запись успешно добавлена!");
                    }
                }
                else { MessageBox.Show("Заполните все поля со звездочкой \"*\"!"); }
            }
            else
            {
                if (tb_famil.Text.Trim() != "" && tb_name.Text.Trim() != "" && cb_dep.SelectedItem.ToString().Trim() != "")
                {
                    using (Database.DataBase db = new Database.DataBase())
                    {
                        Database.Person pers = db.People.FirstOrDefault(p => p.id == idPerson);
                        pers.famil = cryptoStr(tb_famil.Text.Trim());
                        pers.name = cryptoStr(tb_name.Text.Trim());
                        pers.otch = cryptoStr(tb_otch.Text.Trim());
                        pers.phone = cryptoStr(tb_phone.Text.Trim());
                        pers.birthday = dtp_birthday.Value;
                        pers.gender = rb_male.Checked ? "Муж" : rb_female.Checked ? "Жен" : "";
                        pers.type = rb_w.Checked ? "W" : rb_s.Checked ? "S" : "";
                        pers.isPensioner = cb_isPens.Checked ? "T" : "F";
                        pers.isProf = cb_isProf.Checked ? "T" : "F";
                        pers.dateEnter = dtp_enterProf.Value;
                        pers.numProfTicket = tb_numProfBil.Text.Trim();
                        pers.dateExit = cb_isProf.Checked ? dtp_exitProf.Value : dtp_exitProf.MinDate;
                        pers.startTrudYearStr = tb_startJob.Text.Trim();
                        Database.PeopleDepartment pd = db.PeopleDepartments.FirstOrDefault(p => p.idPeople == idPerson);
                        //pd.idDepartment = db.Departments.FirstOrDefault(pp => pp.fullName == cb_dep.SelectedItem.ToString()).id;
                        pd.idDepartment = lArrayUserDeparments[cb_dep.SelectedIndex];
                        db.SaveChanges();
                        MessageBox.Show("Запись успешно обновлена!");
                    }
                }
                else { MessageBox.Show("Заполните все поля со звездочкой \"*\"!"); }
            }
        }

        private void b_saveDoc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    Database.Person pers = db.People.FirstOrDefault(p => p.id == idPerson);
                    pers.typeDoc = cryptoStr(cb_doc.SelectedItem.ToString().Trim());
                    pers.pasp_ser = cryptoStr(tb_docSer.Text.Trim());
                    pers.pasp_num = cryptoStr(tb_docNum.Text.Trim());
                    pers.pasp_issue = cryptoStr(tb_docIssue.Text.Trim());
                    pers.pasp_date = dtp_docDate.Value;
                    pers.propiska = cryptoStr(tb_propiska.Text.Trim());

                    var socStatus = db.PeopleSocialStatus.Where(p => p.idPeople == pers.id).ToList();
                    if (socStatus != null)
                    {
                        foreach (Database.PeopleSocialStatu ss in socStatus)
                        {
                            db.PeopleSocialStatus.Remove(ss);
                        }
                    }
                    var livCon = db.PeopleLivingConditions.Where(p => p.idPeople == pers.id).ToList();
                    if (livCon != null)
                    {
                        foreach (Database.PeopleLivingCondition ss in livCon)
                        {
                            db.PeopleLivingConditions.Remove(ss);
                        }
                    }

                    for (int i = 0; i < clb_socialStatus.CheckedItems.Count; i++)
                    {
                        string nTss = clb_socialStatus.CheckedItems[i].ToString();
                        Database.TypeSocialStatu tss = db.TypeSocialStatus.FirstOrDefault(p => p.name == nTss);
                        db.PeopleSocialStatus.Add(new Database.PeopleSocialStatu
                        {
                            idPeople = idPerson,
                            idTypeSocialStatus = tss.id,
                            dateCrt = DateTime.Now
                        });
                    }
                    for (int i = 0; i < clb_livingConditions.CheckedItems.Count; i++)
                    {
                        string nTlc = clb_livingConditions.CheckedItems[i].ToString();
                        Database.TypeLivingCondition tss = db.TypeLivingConditions.FirstOrDefault(p => p.name == nTlc);
                        db.PeopleLivingConditions.Add(new Database.PeopleLivingCondition
                        {
                            idPeople = idPerson,
                            idTypeLivingConditions = tss.id
                        });
                    }
                    db.SaveChanges();
                }
                MessageBox.Show("Информация сохранена!");
            }
        }

        private void b_saveChild_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tb_fioChild.Text.Trim() != "")
                {
                    using (Database.DataBase db = new Database.DataBase())
                    {
                        if (idChild == 0)
                        {
                            Database.PeopleChildren pc = new Database.PeopleChildren();
                            pc.idPeople = idPerson;
                            pc.fioChildren = tb_fioChild.Text.Trim();
                            pc.birthday = dtp_birthdayChild.Value;
                            pc.dateCrt = DateTime.Now;
                            db.PeopleChildrens.Add(pc);
                        }
                        else
                        {
                            Database.PeopleChildren pc = db.PeopleChildrens.FirstOrDefault(p => p.id == idChild);
                            pc.fioChildren = tb_fioChild.Text.Trim();
                            pc.birthday = dtp_birthdayChild.Value;
                        }
                        db.SaveChanges();
                    }
                    loadChild();
                    p_allInfoChild.Height = 1;
                }
                MessageBox.Show("Информация сохранена!");
            }
        }

        private void b_saveEduc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idEduc == 0)
                    {
                        Database.Education educ = new Database.Education();
                        educ.idPeople = idPerson;
                        educ.stLevel = cb_typeEduc.SelectedItem.ToString();
                        educ.nameUniver = tb_Educ.Text.Trim();
                        educ.nameSpec = tb_spec.Text.Trim();
                        educ.nameKval = tb_kval.Text.Trim();
                        educ.numDipl = tb_numEduc.Text.Trim();
                        educ.dateEduc = dtp_educ.Value;
                        educ.dateCrt = DateTime.Now;
                        db.Educations.Add(educ);
                    }
                    else
                    {
                        Database.Education educ = db.Educations.FirstOrDefault(p => p.id == idEduc);
                        educ.stLevel = cb_typeEduc.SelectedItem.ToString();
                        educ.nameUniver = tb_Educ.Text.Trim();
                        educ.nameSpec = tb_spec.Text.Trim();
                        educ.nameKval = tb_kval.Text.Trim();
                        educ.numDipl = tb_numEduc.Text.Trim();
                        educ.dateEduc = dtp_educ.Value;
                    }
                    db.SaveChanges();
                }
                loadEduc();
                p_allInfoEduc.Height = 1;
                MessageBox.Show("Информация сохранена!");
                b_saveEduc.Enabled = false;
                b_cancelEduc.Enabled = false;
            }
        }

        private void b_saveDopSved_Click_1(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    Database.Person pers = db.People.FirstOrDefault(p => p.id == idPerson);
                    pers.activity = tb_nagr.Text.Trim();
                    pers.socialWork = tb_obshDeyat.Text.Trim();
                    pers.hobbies = tb_hobbies.Text.Trim();
                    db.SaveChanges();
                }
                MessageBox.Show("Информация сохранена!");
            }
        }

        private void b_saveMat_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idMatPom == 0)
                    {
                        Database.PeopleEncouragement pe = new Database.PeopleEncouragement();
                        pe.idPeople = idPerson;
                        pe.idTypeEncouragement = 1;
                        pe.source = cb_matSource.SelectedItem.ToString();
                        pe.countMat = Convert.ToDouble(tb_matCount.Text.Trim());
                        pe.dateEncouragement = dtp_mat.Value;
                        pe.dateCrt = DateTime.Now;
                        db.PeopleEncouragements.Add(pe);
                        db.SaveChanges();
                    }
                    else
                    {
                        Database.PeopleEncouragement pe = db.PeopleEncouragements.FirstOrDefault(p => p.id == idMatPom);
                        pe.source = cb_matSource.SelectedItem.ToString();
                        pe.countMat = Convert.ToDouble(tb_matCount.Text.Trim());
                        pe.dateEncouragement = dtp_mat.Value;
                        db.SaveChanges();
                    }
                }
                loadMatHelp();
                p_allInfoMat.Height = 1;
                MessageBox.Show("Информация сохранена!");
            }
        }

        private void b_saveOtherEnc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idOtheEnc == 0)
                    {
                        string tename = cb_typeOtherEnc.SelectedItem.ToString();
                        Database.PeopleEncouragement pe = new Database.PeopleEncouragement();
                        pe.idPeople = idPerson;
                        pe.idTypeEncouragement = db.TypeEncouragements.FirstOrDefault(p => p.name == tename).id;
                        pe.source = cb_sourceOtherEnc.SelectedItem.ToString();
                        pe.dateEncouragement = dtp_dateOtherEnc.Value;
                        pe.dateCrt = DateTime.Now;
                        db.PeopleEncouragements.Add(pe);
                        db.SaveChanges();
                    }
                    else
                    {
                        string tename = cb_typeOtherEnc.SelectedItem.ToString();
                        Database.PeopleEncouragement pe = db.PeopleEncouragements.FirstOrDefault(p => p.id == idOtheEnc);
                        pe.idTypeEncouragement = db.TypeEncouragements.FirstOrDefault(p => p.name == tename).id;
                        pe.source = cb_sourceOtherEnc.SelectedItem.ToString();
                        pe.dateEncouragement = dtp_dateOtherEnc.Value;
                        db.SaveChanges();
                    }
                }
                loadOtherHelp();
                p_allInfoOtherEnc.Height = 1;
                MessageBox.Show("Информация сохранена!");
            }
        }

        private void b_saveTrudKnig_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    if (idTrudKnij == 0)
                    {
                        Database.PeopleWork pw = new Database.PeopleWork();
                        pw.idPeople = idPerson;
                        pw.dateStart = dtp_startWork.Value;
                        pw.workPlace = tb_whereWork.Text.Trim();
                        pw.doljn = tb_positionWork.Text.Trim();
                        pw.isWorked = cb_worked.Checked ? "T" : "F";
                        if (!cb_worked.Checked) pw.dateEnd = dtp_finishWork.Value;
                        pw.isActual = cb_osnJobTrudKnig.Checked ? "T" : "F";
                        pw.stajObsh = cb_stajObsh.Checked ? "T" : "F";
                        pw.stajPed = cb_stajPed.Checked ? "T" : "F";
                        pw.stajNPed = cb_stajNPed.Checked ? "T" : "F";
                        pw.isSovm = cb_sovm.Checked ? "T" : "F";
                        pw.dateCrt = DateTime.Now;
                        db.PeopleWorks.Add(pw);
                        db.SaveChanges();
                    }
                    else
                    {
                        Database.PeopleWork pw = db.PeopleWorks.FirstOrDefault(p => p.id == idTrudKnij);
                        pw.dateStart = dtp_startWork.Value;
                        pw.workPlace = tb_whereWork.Text.Trim();
                        pw.doljn = tb_positionWork.Text.Trim();
                        pw.isWorked = cb_worked.Checked ? "T" : "F";
                        if (!cb_worked.Checked) pw.dateEnd = dtp_finishWork.Value;
                        else pw.dateEnd = null;
                        pw.isActual = cb_osnJobTrudKnig.Checked ? "T" : "F";
                        pw.stajObsh = cb_stajObsh.Checked ? "T" : "F";
                        pw.stajPed = cb_stajPed.Checked ? "T" : "F";
                        pw.stajNPed = cb_stajNPed.Checked ? "T" : "F";
                        pw.isSovm = cb_sovm.Checked ? "T" : "F";
                        db.SaveChanges();
                    }
                }
                p_allInfoTrudKnig.Height = 1;
                loadWorks();
                MessageBox.Show("Информация сохранена!");
            }
        }

        #endregion
        #region other
        private void dgv_Child_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            p_allInfoChild.Height = 28;
            tb_fioChild.Text = dgv_Child[1, e.RowIndex].Value.ToString();
            dtp_birthdayChild.Value = Convert.ToDateTime(dgv_Child[2, e.RowIndex].Value);
            idChild = (int)dgv_Child[0, e.RowIndex].Value;
        }

        private void dtp_birthdayChild_ValueChanged(object sender, EventArgs e)
        {
            l_yearChild.Text = currentAgeFull(dtp_birthdayChild.Value);
        }

        private void dtp_birthday_ValueChanged(object sender, EventArgs e)
        {
            l_year.Text = currentAgeFull(dtp_birthday.Value);
        }

        private void dgv_educ_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                p_allInfoEduc.Height = 91;
                cb_typeEduc.SelectedItem = dgv_educ[1, e.RowIndex].Value.ToString();
                tb_Educ.Text = dgv_educ[2, e.RowIndex].Value.ToString();
                tb_spec.Text = dgv_educ[3, e.RowIndex].Value.ToString();
                tb_kval.Text = dgv_educ[4, e.RowIndex].Value.ToString();
                tb_numEduc.Text = dgv_educ[5, e.RowIndex].Value.ToString();
                dtp_educ.Value = Convert.ToDateTime(dgv_educ[6, e.RowIndex].Value);
                idEduc = (int)dgv_educ[0, e.RowIndex].Value;
            }
        }

        private void dgv_mat_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoMat.Height = 33;
                idMatPom = (int)dgv_mat[0, e.RowIndex].Value;
                dtp_mat.Value = Convert.ToDateTime(dgv_mat[2, e.RowIndex].Value);
                cb_matSource.SelectedItem = dgv_mat[3, e.RowIndex].Value.ToString();
                tb_matCount.Text = dgv_mat[4, e.RowIndex].Value.ToString();
            }
        }

        private void dgv_OtherEnc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoOtherEnc.Height = 33;
                idOtheEnc = (int)dgv_OtherEnc[0, e.RowIndex].Value;
                cb_typeOtherEnc.SelectedItem = dgv_OtherEnc[1, e.RowIndex].Value.ToString();
                dtp_dateOtherEnc.Value = Convert.ToDateTime(dgv_OtherEnc[2, e.RowIndex].Value);
                cb_sourceOtherEnc.SelectedItem = dgv_OtherEnc[3, e.RowIndex].Value.ToString();
            }
        }

        private void dgv_trudKnig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                p_allInfoTrudKnig.Height = 98;
                idTrudKnij = (int)dgv_trudKnig[0, e.RowIndex].Value;
                dtp_startWork.Value = Convert.ToDateTime(dgv_trudKnig[1, e.RowIndex].Value);
                tb_whereWork.Text = dgv_trudKnig[2, e.RowIndex].Value.ToString();
                tb_positionWork.Text = dgv_trudKnig[3, e.RowIndex].Value.ToString();
                cb_worked.Checked = (bool)dgv_trudKnig[10, e.RowIndex].Value;
                if (!cb_worked.Checked) dtp_finishWork.Value = Convert.ToDateTime(dgv_trudKnig[4, e.RowIndex].Value);
                cb_stajObsh.Checked = (bool)dgv_trudKnig[5, e.RowIndex].Value;
                cb_stajPed.Checked = (bool)dgv_trudKnig[6, e.RowIndex].Value;
                cb_stajNPed.Checked = (bool)dgv_trudKnig[7, e.RowIndex].Value;
                cb_osnJobTrudKnig.Checked = (bool)dgv_trudKnig[8, e.RowIndex].Value;
                cb_sovm.Checked = (bool)dgv_trudKnig[9, e.RowIndex].Value;
            }
        }

        private void cb_worked_CheckedChanged(object sender, EventArgs e)
        {
            dtp_finishWork.Enabled = !cb_worked.Checked;
        }

        private void cb_isProf_CheckedChanged(object sender, EventArgs e)
        {
            dtp_exitProf.Visible = !cb_isProf.Checked;
            label11.Visible = dtp_exitProf.Visible;
        }
        #endregion
        #region функция экспорта в Excel файл
        private void ExportToExcel(DataGridView dgv)
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
                            if (dgv[j, l].ValueType == typeof(bool))
                            {
                                m_workSheet.Cells[l + 2, j + k] = dgv[j, l].Value.ToString() == "True" ? "+" : "-";
                            }
                            else m_workSheet.Cells[l + 2, j + k] = dgv[j, l].Value;
                        }
                        else k = 0;
                    }
                }
                // Сохранение файла Excel.
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

        private void b_exportChild_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_Child);
        }

        private void b_exportTrud_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_trudKnig);
        }

        private void b_exportEduc_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_educ);
        }

        private void b_exportMat_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_mat);
        }

        private void b_exportOther_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgv_OtherEnc);
        }
        #endregion

        private void tc_pasp_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (newPers)
            {
                if (tb_famil.Text.Trim() != "" && tb_name.Text.Trim() != "" && cb_dep.SelectedItem.ToString().Trim() != "")
                    if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        b_saveMain.PerformClick();
            }
            else
            {
                Database.DataBase db = new Database.DataBase();
                Database.Person pers = db.People.FirstOrDefault(p => p.id == idPerson);
                if (tb_famil.Text.Trim() != decryptoStr(pers.famil) || tb_name.Text.Trim() != decryptoStr(pers.name) || tb_otch.Text.Trim() != decryptoStr(pers.otch) ||
                    cb_dep.SelectedItem.ToString().Trim() != db.PeopleDepartments.FirstOrDefault(p => p.idPeople == idPerson).Department.fullName ||
                    tb_numProfBil.Text.Trim() != pers.numProfTicket || tb_startJob.Text.Trim() != pers.startTrudYearStr.ToString() ||
                    (rb_male.Checked && pers.gender == "Жен") || (rb_female.Checked && pers.gender == "Муж") || (cb_isPens.Checked && pers.isPensioner == "F") ||
                    dtp_birthday.Value != pers.birthday.Value || dtp_enterProf.Value != pers.dateEnter.Value || dtp_exitProf.Value != pers.dateExit.Value ||
                    (cb_isProf.Checked && pers.isProf == "F"))
                    if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        b_saveMain.PerformClick();
                    else
                        b_cancelMain.PerformClick();

            }
        }

        private void b_deleteMain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены в удалении?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (Database.DataBase db = new Database.DataBase())
                {
                    db.People.Remove(db.People.FirstOrDefault(p => p.id == idPerson));
                    db.SaveChanges();
                }
                MessageBox.Show("Персона успешно удалена!");
                Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            newPers = true;
            idPerson = 0;
            tb_famil.Clear();
            tb_name.Clear();
            tb_otch.Clear();
            rb_male.Checked = false;
            rb_female.Checked = false;
            rb_w.Checked = false;
            rb_s.Checked = false;
            cb_isPens.Checked = false;
            cb_isProf.Checked = false;
            tb_numProfBil.Clear();
            tb_startJob.Clear();
            tb_phone.Clear();
            cb_dep.SelectedIndex = 0;

            tb_docSer.Clear();
            tb_docNum.Clear();
            tb_docIssue.Clear();
            dgv_Child.Rows.Clear();
            dgv_educ.Rows.Clear();
            dgv_mat.Rows.Clear();
            dgv_OtherEnc.Rows.Clear();
            dgv_trudKnig.Rows.Clear();

            tb_Educ.Clear();
            tb_fioChild.Clear();
            tb_hobbies.Clear();
            tb_kval.Clear();
            tb_matCount.Clear();
            tb_nagr.Clear();
            tb_numEduc.Clear();
            tb_obshDeyat.Clear();
            tb_positionWork.Clear();
            tb_propiska.Clear();
            tb_spec.Clear();
            tb_startJob.Clear();
            tb_whereWork.Clear();
            cb_stajNPed.Checked = false;
            cb_stajPed.Checked = false;
            cb_osnJobTrudKnig.Checked = false;
            cb_sovm.Checked = false;
            cb_worked.Checked = false;
            for (int i = 0; i < clb_socialStatus.Items.Count; i++)
                clb_socialStatus.SetItemChecked(i, false);
            for (int i = 0; i < clb_livingConditions.Items.Count; i++)
                clb_livingConditions.SetItemChecked(i, false);
        }

        private void dgv_educ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                idEduc = (int)dgv_educ[0, e.RowIndex].Value;
        }

        private void cb_dep_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cb_dep.SelectedValue.ToString());
        }
    }
}