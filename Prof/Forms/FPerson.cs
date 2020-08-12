using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        private int[] arrayUserDeparments;
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
            cmd2.CommandText = " select dp.id as did, case when CONCAT(d.fullname,'')= '' then dp.fullName else concat('(', d.shortName, ') ', dp.fullName) end as fname from prof.Departments d  " +
                         " right join prof.Departments dp on dp.idparent = d.id  " +
                         $" where dp.idParent in ({arrayUserDeparmentsAll_String}) order by d.shortName, dp.fullName ";
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
                dgv_Child.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                dgv_Child.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                
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
                    DataRowView drv = (DataRowView)clb_socialStatus.Items[i];
                    if ((int)drv.Row["id"] == (int)dr["idTypeSocialStatus"])
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
                    DataRowView drv = (DataRowView)clb_livingConditions.Items[i];
                    if ((int)drv.Row["id"] == (int)dr["idTypeLivingConditions"])
                    {
                        clb_livingConditions.SetItemChecked(i, true);
                    }
                }
            }

        }

        private void loadPers()
        {
            ProfDataSet.PeopleDataTable dtPers = new ProfDataSet.PeopleDataTable();
            peopleTableAdapter1.FillByPers(dtPers, idPerson);

            tb_famil.Text = !dtPers.Rows[0].IsNull("famil") ? decryptoStr(dtPers.Rows[0]["famil"].ToString()) : "";
            tb_name.Text = !dtPers.Rows[0].IsNull("name") ? decryptoStr(dtPers.Rows[0]["name"].ToString()) : "";
            tb_otch.Text = !dtPers.Rows[0].IsNull("otch") ? decryptoStr(dtPers.Rows[0]["otch"].ToString()) : "";
            tb_phone.Text = !dtPers.Rows[0].IsNull("phone") ? decryptoStr(dtPers.Rows[0]["phone"].ToString()) : "";
            dtp_birthday.Value = !dtPers.Rows[0].IsNull("birthday") ? Convert.ToDateTime(dtPers.Rows[0]["birthday"]) : dtp_docDate.MinDate;
            if (dtPers.Rows[0]["gender"].ToString().Equals("Муж")) rb_male.Checked = true;
            else if (dtPers.Rows[0]["gender"].ToString().Equals("Муж")) rb_female.Checked = true;

            if (dtPers.Rows[0]["type"].ToString().Equals("W")) rb_w.Checked = true;
            else if (dtPers.Rows[0]["type"].ToString().Equals("S")) rb_s.Checked = true;
            cb_isPens.Checked = dtPers.Rows[0]["isPensioner"].ToString().Equals("T") ? true : false;
            cb_isProf.Checked = dtPers.Rows[0]["isProf"].ToString().Equals("T") ? true : false;
            dtp_enterProf.Value = !dtPers.Rows[0].IsNull("dateEnter") ? Convert.ToDateTime(dtPers.Rows[0]["dateEnter"]) : dtp_docDate.MinDate;
            if (!cb_isPens.Checked) dtp_exitProf.Value = !dtPers.Rows[0].IsNull("dateExit") ? Convert.ToDateTime(dtPers.Rows[0]["dateExit"]) : dtp_docDate.MinDate;
            else label11.Visible = dtp_exitProf.Visible = false;
            tb_numProfBil.Text = !dtPers.Rows[0].IsNull("numProfTicket") ? dtPers.Rows[0]["numProfTicket"].ToString() : "";
            tb_startJob.Text = !dtPers.Rows[0].IsNull("startTrudYearStr") ? dtPers.Rows[0]["startTrudYearStr"].ToString() : "";

            ProfDataSet.PeopleDepartmentDataTable dtPeopleDep = new ProfDataSet.PeopleDepartmentDataTable();
            peopleDepartmentTableAdapter1.FillByPers(dtPeopleDep, idPerson);
            cb_dep.SelectedValue = (int)dtPeopleDep.Rows[0]["idDepartment"];

            tb_nagr.Text = !dtPers.Rows[0].IsNull("activity") ? dtPers.Rows[0]["activity"].ToString() : ""; ;
            tb_obshDeyat.Text = !dtPers.Rows[0].IsNull("socialWork") ? dtPers.Rows[0]["socialWork"].ToString() : "";
            tb_hobbies.Text = !dtPers.Rows[0].IsNull("hobbies") ? dtPers.Rows[0]["hobbies"].ToString() : "";

            loadDoc();
            loadChild();
            loadEduc();
            loadMatHelp();
            loadOtherHelp();
            loadWorks();
        }

        private void loadEduc()
        {
            ProfDataSet.EducationDataTable tbEduc = new ProfDataSet.EducationDataTable();
            
            try
            {
                dgv_educ.AutoGenerateColumns = false;
                dgv_educ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                dgv_educ.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                educationTableAdapter1.FillByPers(tbEduc, idPerson);
                dgv_educ.DataSource = tbEduc;
                dgv_educ.Columns[0].DataPropertyName = "id";
                dgv_educ.Columns[1].DataPropertyName = "stLevel"; 
                dgv_educ.Columns[2].DataPropertyName = "nameUniver"; 
                dgv_educ.Columns[3].DataPropertyName = "nameSpec";
                dgv_educ.Columns[4].DataPropertyName = "nameKval"; 
                dgv_educ.Columns[5].DataPropertyName = "numDipl";
                dgv_educ.Columns[6].DataPropertyName = "dateEduc";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadMatHelp()
        {
            ProfDataSet.PeopleEncouragementDataTable tbEnc = new ProfDataSet.PeopleEncouragementDataTable();
            try
            {
                dgv_mat.AutoGenerateColumns = false;
                dgv_mat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                dgv_mat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                peopleEncouragementTableAdapter1.FillByPersMat(tbEnc, idPerson);
                dgv_mat.DataSource = tbEnc;
                dgv_mat.Columns[0].DataPropertyName = "id";
                dgv_mat.Columns[1].DataPropertyName = "name";
                dgv_mat.Columns[2].DataPropertyName = "dateEncouragement"; 
                dgv_mat.Columns[3].DataPropertyName = "source";
                dgv_mat.Columns[4].DataPropertyName = "countMat";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadOtherHelp()
        {
            ProfDataSet.PeopleEncouragementDataTable tbEnc = new ProfDataSet.PeopleEncouragementDataTable();
            try
            {
                dgv_OtherEnc.AutoGenerateColumns = false;
                dgv_OtherEnc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                dgv_OtherEnc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                peopleEncouragementTableAdapter1.FillByPersOther(tbEnc, idPerson);
                dgv_OtherEnc.DataSource = tbEnc;
                dgv_OtherEnc.Columns[0].DataPropertyName = "id";
                dgv_OtherEnc.Columns[1].DataPropertyName = "name";
                dgv_OtherEnc.Columns[2].DataPropertyName = "dateEncouragement";
                dgv_OtherEnc.Columns[3].DataPropertyName = "source";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadWorks()
        {
            ProfDataSet.PeopleWorkDataTable dtPersWork = new ProfDataSet.PeopleWorkDataTable();
            try
            {
                dgv_trudKnig.AutoGenerateColumns = false;
                dgv_trudKnig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                dgv_trudKnig.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
                peopleWorkTableAdapter1.FillByPeopleId(dtPersWork, idPerson);
                dgv_trudKnig.DataSource = dtPersWork;
                dgv_trudKnig.Columns[0].DataPropertyName = "id";
                dgv_trudKnig.Columns[1].DataPropertyName = "workPlace";
                dgv_trudKnig.Columns[2].DataPropertyName = "doljn";
                dgv_trudKnig.Columns[3].DataPropertyName = "dateStart";
                dgv_trudKnig.Columns[4].DataPropertyName = "dateEnd";
                dgv_trudKnig.Columns[5].DataPropertyName = "stajObsh";
                dgv_trudKnig.Columns[6].DataPropertyName = "stajPed";
                dgv_trudKnig.Columns[7].DataPropertyName = "stajNPed";
                dgv_trudKnig.Columns[8].DataPropertyName = "isActual";
                dgv_trudKnig.Columns[9].DataPropertyName = "isSovm";
                dgv_trudKnig.Columns[10].DataPropertyName = "isWorked";
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            if (dtPersWork.Rows.Count > 0)
            {
                l_ObshStaj.Text = $"{dtPersWork.Rows[0]["year_s_obsh"]}г. {dtPersWork.Rows[0]["month_s_obsh"]}м. {dtPersWork.Rows[0]["day_s_obsh"]}д.";
                l_PStaj.Text = $"{dtPersWork.Rows[0]["year_s_ped"]}г. {dtPersWork.Rows[0]["month_s_ped"]}м. {dtPersWork.Rows[0]["day_s_ped"]}д.";
                l_NPStaj.Text = $"{dtPersWork.Rows[0]["year_s_nped"]}г. {dtPersWork.Rows[0]["month_s_nped"]}м. {dtPersWork.Rows[0]["day_s_nped"]}д.";

                if ((int)dtPersWork.Rows[0]["year_s_obsh"] < 3) l_molodSpec.Visible = true;
                else l_molodSpec.Visible = false;
            }
            else
            {
                l_ObshStaj.Text = $"0г. 0м. 0д.";
                l_PStaj.Text = $"0г. 0м. 0д.";
                l_NPStaj.Text = $"0г. 0м. 0д.";

                l_molodSpec.Visible = false;
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
                        peopleChildrenTableAdapter1.DeleteChield(idChild);
                        idChild = 0;
                        loadChild();
                    }
                }
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
                        educationTableAdapter1.DeleteEduc(idEduc);
                        idEduc = 0;
                        loadEduc();
                    }
                }
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
                if (idMatPom == 0)
                {
                    MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        peopleEncouragementTableAdapter1.DeleteMat(idMatPom);
                        idMatPom = 0;
                        loadMatHelp();
                    }
                }
            }
            p_allInfoMat.Height = 1;
        }

        private void b_deleteOtherEnc_Click(object sender, EventArgs e)
        {
            if (newPers)
            {
                MessageBox.Show("Создайте персону!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (idOtheEnc == 0)
                {
                    MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        peopleEncouragementTableAdapter1.DeleteOther(idOtheEnc);
                        idOtheEnc = 0;
                        loadOtherHelp();
                    }
                }
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
                if (idTrudKnij == 0)
                {
                    MessageBox.Show("Не выбрана запись!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (MessageBox.Show("Вы уверены в удалении выбранной записи?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        peopleWorkTableAdapter1.DeleteWork(idTrudKnij);
                        idTrudKnij = 0;
                        loadWorks();
                    }
                }
                p_allInfoTrudKnig.Height = 1;
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
                    
                    idDep = (int)cb_dep.SelectedValue;

                    SqlConnection conn = DB.GetDBConnection();
                    string gender = rb_male.Checked ? "Муж" : rb_female.Checked ? "Жен" : "";
                    string pens = cb_isPens.Checked ? "T" : "F";
                    string prof = cb_isProf.Checked ? "T" : "F";
                    string type = rb_w.Checked ? "W" : rb_s.Checked ? "S" : "";
                    string startJob = tb_startJob.Text.Trim() != "" ? tb_startJob.Text.Trim() : "";
                    DateTime dateExit = cb_isProf.Checked ? dtp_exitProf.Value : dtp_exitProf.MinDate;
                    string sql = $" INSERT INTO prof.People (famil, name, otch, birthday, phone, gender, isPensioner, isProf, " +
                        $"numProfTicket, dateEnter, dateExit, type, startTrudYearStr) " +
                                       $" VALUES(@famil, @name, @otch, @birthday, @phone, @gender, @pens, @prof, @numbil, " +
                                       $" @enterProf, @exitProf, @type, @startJob); " +
                                       $" SELECT SCOPE_IDENTITY() as id";

                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.Parameters.Add("@famil", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@otch", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@birthday", SqlDbType.DateTime);
                    cmd.Parameters.Add("@phone", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@gender", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@pens", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@prof", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@numbil", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@enterProf", SqlDbType.DateTime);
                    cmd.Parameters.Add("@exitProf", SqlDbType.DateTime);
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@startJob", SqlDbType.NVarChar);
                    cmd.Parameters["@famil"].Value = cryptoStr(tb_famil.Text.Trim());
                    cmd.Parameters["@name"].Value = cryptoStr(tb_name.Text.Trim());
                    cmd.Parameters["@otch"].Value = cryptoStr(tb_otch.Text.Trim());
                    cmd.Parameters["@birthday"].Value = dtp_birthday.Value;
                    cmd.Parameters["@phone"].Value = cryptoStr(tb_phone.Text.Trim());
                    cmd.Parameters["@gender"].Value = gender;
                    cmd.Parameters["@pens"].Value = pens;
                    cmd.Parameters["@prof"].Value = prof;
                    cmd.Parameters["@numbil"].Value = tb_numProfBil.Text.Trim();
                    cmd.Parameters["@enterProf"].Value = dtp_enterProf.Value;
                    cmd.Parameters["@exitProf"].Value = dateExit;
                    cmd.Parameters["@type"].Value = type;
                    cmd.Parameters["@startJob"].Value = startJob;
                    cmd.Connection = conn;

                    conn.Open();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                idPerson = (int)reader.GetDecimal(0);
                            }
                        }
                    }

                    peopleDepartmentTableAdapter1.Insert(idPerson, idDep, DateTime.Now);

                    MessageBox.Show("Новая запись успешно добавлена!");
                }
                else { MessageBox.Show("Заполните все поля со звездочкой \"*\"!"); }
            }
            else
            {
                if (tb_famil.Text.Trim() != "" && tb_name.Text.Trim() != "" && cb_dep.SelectedItem.ToString().Trim() != "")
                {
                    ProfDataSet.PeopleDataTable dtPers = new ProfDataSet.PeopleDataTable();
                    peopleTableAdapter1.FillByPers(dtPers, idPerson);
                    DataRow dr = dtPers.Rows[0];
                    dr["famil"] = cryptoStr(tb_famil.Text.Trim());
                    dr["name"] = cryptoStr(tb_name.Text.Trim());
                    dr["otch"] = cryptoStr(tb_otch.Text.Trim());
                    dr["phone"] = cryptoStr(tb_phone.Text.Trim());
                    dr["birthday"] = dtp_birthday.Value;
                    dr["gender"] = rb_male.Checked ? "Муж" : rb_female.Checked ? "Жен" : "";
                    dr["type"] = rb_w.Checked ? "W" : rb_s.Checked ? "S" : "";
                    dr["isPensioner"] = cb_isPens.Checked ? "T" : "F";
                    dr["isProf"] = cb_isProf.Checked ? "T" : "F";
                    dr["dateEnter"] = dtp_enterProf.Value;
                    dr["numProfTicket"] = tb_numProfBil.Text.Trim();
                    dr["dateExit"] = cb_isProf.Checked ? dtp_exitProf.Value : dtp_exitProf.MinDate;
                    dr["startTrudYearStr"] = tb_startJob.Text.Trim();
                    peopleTableAdapter1.Update(dr);
                    ProfDataSet.PeopleDepartmentDataTable dtPersDep = new ProfDataSet.PeopleDepartmentDataTable();
                    peopleDepartmentTableAdapter1.FillByPers(dtPersDep, idPerson);
                    dr = dtPersDep.Rows[0];
                    dr["idDepartment"] = (int)cb_dep.SelectedValue;
                    peopleDepartmentTableAdapter1.Update(dr);
                     MessageBox.Show("Запись успешно обновлена!");
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
                ProfDataSet.PeopleDataTable dtPers = new ProfDataSet.PeopleDataTable();
                peopleTableAdapter1.FillByPers(dtPers, idPerson);
                DataRow dr = dtPers.Rows[0];
                dr["typeDoc"] = cryptoStr(cb_doc.SelectedItem.ToString().Trim());
                dr["pasp_ser"] = cryptoStr(tb_docSer.Text.Trim());
                dr["pasp_num"] = cryptoStr(tb_docNum.Text.Trim());
                dr["pasp_issue"] = cryptoStr(tb_docIssue.Text.Trim());
                dr["pasp_date"] = dtp_docDate.Value;
                dr["propiska"] = cryptoStr(tb_propiska.Text.Trim());
                peopleTableAdapter1.Update(dr);
                
                peopleSocialStatusTableAdapter1.DeleteByPers(idPerson);
                peopleLivingConditionsTableAdapter1.DeleteByPers(idPerson);
                    
                for (int i = 0; i < clb_socialStatus.CheckedItems.Count; i++)
                {
                    DataRowView drv = (DataRowView)clb_socialStatus.CheckedItems[i];
                    peopleSocialStatusTableAdapter1.Insert(idPerson, (int)drv.Row["id"], DateTime.Now);
                }
                for (int i = 0; i < clb_livingConditions.CheckedItems.Count; i++)
                {
                    DataRowView drv = (DataRowView)clb_livingConditions.CheckedItems[i];
                    peopleLivingConditionsTableAdapter1.Insert(idPerson, (int)drv.Row["id"]);
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
                    if (idChild == 0)
                    {
                        peopleChildrenTableAdapter1.Insert(idPerson, tb_fioChild.Text.Trim(), dtp_birthdayChild.Value, DateTime.Now);
                    }
                    else
                    {
                        ProfDataSet.PeopleChildrenDataTable dtPeopleChild = new ProfDataSet.PeopleChildrenDataTable();
                        peopleChildrenTableAdapter1.FillByChild(dtPeopleChild, idChild);
                        DataRow dr = dtPeopleChild.Rows[0];
                        dr["fioChildren"] = tb_fioChild.Text.Trim();
                        dr["birthday"] = dtp_birthdayChild.Value;
                        peopleChildrenTableAdapter1.Update(dr);
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
                if (idEduc == 0)
                {
                    educationTableAdapter1.Insert(
                        idPerson,
                        tb_Educ.Text.Trim(),
                        tb_spec.Text.Trim(),
                        tb_kval.Text.Trim(),
                        cb_typeEduc.SelectedItem.ToString(),
                        dtp_educ.Value,
                        DateTime.Now,
                        tb_numEduc.Text.Trim()
                    );
                }
                else
                {
                    ProfDataSet.EducationDataTable dtEduc = new ProfDataSet.EducationDataTable();
                    educationTableAdapter1.FillByEduc(dtEduc, idEduc);
                    DataRow dr = dtEduc.Rows[0];
                    dr["stLevel"]       = cb_typeEduc.SelectedItem.ToString();
                    dr["nameUniver"]    = tb_Educ.Text.Trim();
                    dr["nameSpec"]      = tb_spec.Text.Trim();
                    dr["nameKval"]      = tb_kval.Text.Trim();
                    dr["numDipl"]       = tb_numEduc.Text.Trim();
                    dr["dateEduc"]      = dtp_educ.Value;
                    educationTableAdapter1.Update(dr);
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
                ProfDataSet.PeopleDataTable dtPers = new ProfDataSet.PeopleDataTable();
                peopleTableAdapter1.FillByPers(dtPers, idPerson);
                DataRow dr = dtPers.Rows[0];
                dr["activity"] = tb_nagr.Text.Trim();
                dr["socialWork"] = tb_obshDeyat.Text.Trim();
                dr["hobbies"] = tb_hobbies.Text.Trim();
                peopleTableAdapter1.Update(dr);
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
                if (idMatPom == 0)
                {
                    peopleEncouragementTableAdapter1.Insert(
                        idPerson,
                        1, 
                        cb_matSource.SelectedItem.ToString(),
                        dtp_mat.Value,
                        DateTime.Now,
                        Convert.ToDouble(tb_matCount.Text.Trim())
                    );
                }
                else
                {
                    ProfDataSet.PeopleEncouragementDataTable dtPersEnc = new ProfDataSet.PeopleEncouragementDataTable();
                    peopleEncouragementTableAdapter1.FillByEnc(dtPersEnc, idMatPom);
                    DataRow dr = dtPersEnc.Rows[0];
                    dr["source"] = cb_matSource.SelectedItem.ToString();
                    dr["countMat"] = Convert.ToDouble(tb_matCount.Text.Trim());
                    dr["dateEncouragement"] = dtp_mat.Value;
                    peopleEncouragementTableAdapter1.Update(dr);
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
                if (idOtheEnc == 0)
                {
                    peopleEncouragementTableAdapter1.Insert(
                      idPerson,
                      (int)cb_typeOtherEnc.SelectedValue,
                      cb_sourceOtherEnc.SelectedItem.ToString(),
                      dtp_dateOtherEnc.Value,
                      DateTime.Now,
                      null
                    );
                }
                else
                {
                    ProfDataSet.PeopleEncouragementDataTable dtPersEnc = new ProfDataSet.PeopleEncouragementDataTable();
                    peopleEncouragementTableAdapter1.FillByEnc(dtPersEnc, idOtheEnc);
                    DataRow dr = dtPersEnc.Rows[0];
                    dr["source"] = cb_sourceOtherEnc.SelectedItem.ToString();
                    dr["idTypeEncouragement"] = (int)cb_typeOtherEnc.SelectedValue;
                    dr["dateEncouragement"] = dtp_dateOtherEnc.Value;
                    peopleEncouragementTableAdapter1.Update(dr);
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
                string isActual = cb_osnJobTrudKnig.Checked ? "T" : "F";
                string isWorked = cb_worked.Checked ? "T" : "F";
                string stajObsh = cb_stajObsh.Checked ? "T" : "F";
                string stajPed = cb_stajPed.Checked ? "T" : "F";
                string stajNPed = cb_stajNPed.Checked ? "T" : "F";
                string isSovm = cb_sovm.Checked ? "T" : "F";
                if (idTrudKnij == 0)
                {
                        
                    if (!cb_worked.Checked) {
                        peopleWorkTableAdapter1.Insert(
                            idPerson,
                            tb_whereWork.Text.Trim(),
                            tb_positionWork.Text.Trim(),
                            dtp_startWork.Value,
                            dtp_finishWork.Value,
                            isActual,
                            DateTime.Now,
                            isWorked,
                            stajObsh,
                            stajPed,
                            stajNPed,
                            isSovm
                        );
                    } else {
                        peopleWorkTableAdapter1.Insert(
                            idPerson,
                            tb_whereWork.Text.Trim(),
                            tb_positionWork.Text.Trim(),
                            dtp_startWork.Value,
                            null,
                            isActual,
                            DateTime.Now,
                            isWorked,
                            stajObsh,
                            stajPed,
                            stajNPed,
                            isSovm
                        );
                    }
                }
                else
                {
                    ProfDataSet.PeopleWorkDataTable dtPeopleWork = new ProfDataSet.PeopleWorkDataTable();
                    peopleWorkTableAdapter1.FillByWorkId(dtPeopleWork, idTrudKnij);
                    DataRow dr = dtPeopleWork.Rows[0];

                    dr["dateStart"] = dtp_startWork.Value;
                    dr["workPlace"] = tb_whereWork.Text.Trim();
                    dr["doljn"] = tb_positionWork.Text.Trim();
                    dr["isWorked"] = cb_worked.Checked ? "T" : "F";
                    if (!cb_worked.Checked) dr["dateEnd"] = dtp_finishWork.Value;
                    else dr["dateEnd"] = DBNull.Value;
                    dr["isActual"] = isActual;
                    dr["stajObsh"] = stajObsh;
                    dr["stajPed"] = stajPed;
                    dr["stajNPed"] = stajNPed;
                    dr["isSovm"] = isSovm;
                    peopleWorkTableAdapter1.Update(dr);
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

                b_saveEduc.Enabled = true;
                b_cancelEduc.Enabled = true;
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
                cb_worked.Checked = dgv_trudKnig[10, e.RowIndex].Value.ToString().Equals("T");
                if (!cb_worked.Checked) dtp_finishWork.Value = Convert.ToDateTime(dgv_trudKnig[4, e.RowIndex].Value);
                cb_stajObsh.Checked = dgv_trudKnig[5, e.RowIndex].Value.ToString().Equals("T");
                cb_stajPed.Checked = dgv_trudKnig[6, e.RowIndex].Value.ToString().Equals("T");
                cb_stajNPed.Checked = dgv_trudKnig[7, e.RowIndex].Value.ToString().Equals("T");
                cb_osnJobTrudKnig.Checked = dgv_trudKnig[8, e.RowIndex].Value.ToString().Equals("T");
                cb_sovm.Checked = dgv_trudKnig[9, e.RowIndex].Value.ToString().Equals("T");
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
                if (tb_famil.Text.Trim() != "" && tb_name.Text.Trim() != "")
                    if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        b_saveMain.PerformClick();
            }
            else
            {
                ProfDataSet.PeopleDataTable dtPeople = new ProfDataSet.PeopleDataTable();
                peopleTableAdapter1.FillByPers(dtPeople, idPerson);
                DataRow dr = dtPeople.Rows[0];
                ProfDataSet.PeopleDepartmentDataTable dtPeopleDep = new ProfDataSet.PeopleDepartmentDataTable();
                peopleDepartmentTableAdapter1.FillByPers(dtPeopleDep, idPerson);
                DataRow drDep = dtPeopleDep.Rows[0];
                if (tb_famil.Text.Trim() != decryptoStr(dr["famil"].ToString()) || 
                    tb_name.Text.Trim() != decryptoStr(dr["name"].ToString()) || 
                    tb_otch.Text.Trim() != decryptoStr(dr["otch"].ToString()) ||
                    (int)cb_dep.SelectedValue != (int)drDep["idDepartment"] ||
                    tb_numProfBil.Text.Trim() != dr["numProfTicket"].ToString() || 
                    tb_startJob.Text.Trim() != dr["startTrudYearStr"].ToString() ||
                    (rb_male.Checked && dr["gender"].ToString().Equals("Жен")) || 
                    (rb_female.Checked && dr["gender"].ToString().Equals("Муж")) || 
                    (cb_isPens.Checked && dr["isPensioner"].ToString().Equals("F")) ||
                    dtp_birthday.Value != Convert.ToDateTime(dr["birthday"]) || 
                    dtp_enterProf.Value != Convert.ToDateTime(dr["dateEnter"]) || 
                    dtp_exitProf.Value != Convert.ToDateTime(dr["dateExit"]) ||
                    (cb_isProf.Checked && dr["isProf"].ToString().Equals("F")))
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
                peopleTableAdapter1.DeletePers(idPerson);
                idPerson = 0;
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

    }
}