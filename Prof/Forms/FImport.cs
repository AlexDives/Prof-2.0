using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Prof
{
    public partial class FImport : MetroFramework.Forms.MetroForm
    {
        int idUser = 0;
        int idDep = 0;
        private int[] arrayUserDeparments;
        public FImport(int idUser, int idDep, int[] arrayUserDeparments)
        {
            InitializeComponent();
            
            this.idUser = idUser;
            this.idDep = idDep;
            this.arrayUserDeparments = arrayUserDeparments;
        }

        private void B_browse_Click(object sender, EventArgs e)
        {
            string str;
            int rCnt;
            int cCnt;

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Файл Excel|*.XLSX;*.XLS";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                DataTable tb = new System.Data.DataTable();
                string filename = opf.FileName;

                Excel.Application ExcelApp = new Excel.Application();
                Excel._Workbook ExcelWorkBook;
                Excel.Worksheet ExcelWorkSheet;
                Excel.Range ExcelRange;

                ExcelWorkBook = ExcelApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false,
                    false, 0, true, 1, 0);
                ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);

                ExcelRange = ExcelWorkSheet.UsedRange;
                progressBar1.Maximum = ExcelRange.Rows.Count;
                progressBar1.Value = 1;
                dgv2.Visible = false;
                dgv2.Rows.Clear();
                for (rCnt = 2; rCnt <= ExcelRange.Rows.Count; rCnt++)
                {
                    dgv2.Rows.Add(1);
                    for (cCnt = 1; cCnt <= 21; cCnt++)
                    {
                        str = (string)(ExcelRange.Cells[rCnt, cCnt] as Excel.Range).Text;
                        dgv2.Rows[rCnt - 2].Cells[0].Value = rCnt - 1;
                        if (cCnt == 11)
                        {
                            if (str.Contains("+") || str.ToLower().Contains("да") || str.ToLower().Contains("t"))
                            {
                                dgv2.Rows[rCnt - 2].Cells[cCnt].Value = true;
                            }
                            else
                                dgv2.Rows[rCnt - 2].Cells[cCnt].Value = false;
                        }
                        else
                            dgv2.Rows[rCnt - 2].Cells[cCnt].Value = str;
                    }
                    progressBar1.Value++;
                }

                dgv2.Visible = true;
                MessageBox.Show($"Загружено {ExcelRange.Rows.Count - 1} записей!", "Внимание!");
                ExcelWorkBook.Close(true, null, null);
                ExcelApp.Quit();

                releaseObject(ExcelWorkSheet);
                releaseObject(ExcelWorkBook);
                releaseObject(ExcelApp);

                b_import.Enabled = true;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void B_import_Click(object sender, EventArgs e)
        {
            if (cb_dep.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Для импорта данных, требуется выбрать базовое подразделение, куда они будут загружены!");
            }
            else
            {
                Database.DataBase db = new Database.DataBase();

                int idPerson = 0;
                progressBar1.Value = 0;
                progressBar1.Maximum = dgv2.Rows.Count;
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    string ssp = "";
                    string ssv = "";
                    idDep = db.Departments.FirstOrDefault(pp => pp.fullName == cb_dep.SelectedItem.ToString().Trim()).id;


                    if (dgv2.Rows[i].Cells[1].Value.ToString().Trim() != "")
                    {
                        ssp = dgv2.Rows[i].Cells[1].Value.ToString().Trim();

                        Database.Department dp = db.Departments.FirstOrDefault(pp => pp.fullName == ssp);
                        if (dp == null)
                        {
                            dp = new Database.Department();
                            dp.idParent = idDep;
                            dp.fullName = ssp;
                            dp.shortName = ssp;
                            dp.dateCrt = DateTime.Now;
                            db.Departments.Add(dp);
                            db.SaveChanges();
                            db = new Database.DataBase();
                            idDep = dp.id;

                        }
                        else if (dp != null)
                        {
                            idDep = dp.id;
                        }
                    }
                    if (dgv2.Rows[i].Cells[2].Value.ToString().Trim() != "")
                    {
                        ssv = dgv2.Rows[i].Cells[2].Value.ToString().Trim();

                        Database.Department dp = db.Departments.FirstOrDefault(pp => pp.fullName == ssv);
                        if (dp == null)
                        {
                            dp = new Database.Department();
                            dp.idParent = idDep;
                            dp.fullName = ssv;
                            dp.shortName = ssv;
                            dp.dateCrt = DateTime.Now;
                            db.Departments.Add(dp);
                            db.SaveChanges();
                            db = new Database.DataBase();
                            idDep = dp.id;
                        }
                        else if (dp != null)
                        {
                            idDep = dp.id;
                        }
                    }

                    string fam = cryptoStr(dgv2.Rows[i].Cells[3].Value.ToString().Trim());
                    string nam = cryptoStr(dgv2.Rows[i].Cells[4].Value.ToString().Trim());
                    string otc = cryptoStr(dgv2.Rows[i].Cells[5].Value.ToString().Trim());
                    string pn = dgv2.Rows[i].Cells[9].Value.ToString().Trim();
                    DateTime dt = DateTime.Parse(dgv2.Rows[i].Cells[7].Value.ToString().Trim());

                    Database.Person p = db.People.FirstOrDefault(pp => pp.famil == fam &&
                                                                       pp.name == nam &&
                                                                       pp.otch == otc &&
                                                                       pp.birthday == dt &&
                                                                       pp.numProfTicket == pn);
                    if (p == null)
                    {
                        p = new Database.Person();
                        p.famil = cryptoStr(dgv2.Rows[i].Cells[3].Value.ToString().Trim());
                        p.name = cryptoStr(dgv2.Rows[i].Cells[4].Value.ToString().Trim());
                        p.otch = cryptoStr(dgv2.Rows[i].Cells[5].Value.ToString().Trim());
                        p.gender = dgv2.Rows[i].Cells[6].Value.ToString().Trim() != "" ? dgv2.Rows[i].Cells[6].Value.ToString().Trim() : "Муж";
                        p.birthday = dgv2.Rows[i].Cells[7].Value.ToString().Trim() != "" ? DateTime.Parse(dgv2.Rows[i].Cells[7].Value.ToString().Trim()) : DateTime.Parse("01.01.1970");
                        p.phone = cryptoStr(dgv2.Rows[i].Cells[8].Value.ToString().Trim());
                        p.numProfTicket = dgv2.Rows[i].Cells[9].Value.ToString().Trim();
                        p.dateEnter = dgv2.Rows[i].Cells[10].Value.ToString().Trim() != "" ? DateTime.Parse(dgv2.Rows[i].Cells[10].Value.ToString().Trim()) : DateTime.Parse("01.01.1970");
                        p.isPensioner = (bool)dgv2.Rows[i].Cells[11].Value ? "T" : "F";
                        p.startTrudYearStr = dgv2.Rows[i].Cells[12].Value.ToString().Trim() != "" ? dgv2.Rows[i].Cells[12].Value.ToString().Trim() : "";
                        p.typeDoc = cryptoStr(dgv2.Rows[i].Cells[13].Value.ToString().Trim());
                        p.pasp_ser = cryptoStr(dgv2.Rows[i].Cells[14].Value.ToString().Trim());
                        p.pasp_num = cryptoStr(dgv2.Rows[i].Cells[15].Value.ToString().Trim());
                        p.pasp_date = dgv2.Rows[i].Cells[16].Value.ToString().Trim() != "" ? DateTime.Parse(dgv2.Rows[i].Cells[16].Value.ToString().Trim()) : DateTime.Parse("01.01.1970");
                        p.pasp_issue = cryptoStr(dgv2.Rows[i].Cells[17].Value.ToString().Trim());
                        p.propiska = cryptoStr(dgv2.Rows[i].Cells[18].Value.ToString().Trim());
                        p.activity = dgv2.Rows[i].Cells[19].Value.ToString().Trim();
                        p.socialWork = dgv2.Rows[i].Cells[20].Value.ToString().Trim();
                        p.hobbies = dgv2.Rows[i].Cells[21].Value.ToString().Trim();

                        p.type = rb_w.Checked ? "W" : rb_s.Checked ? "S" : "";
                        p.isProf = "T";
                        p.dateExit = DateTime.Parse("01.01.1970");
                        p.dateCrt = DateTime.Now;
                        db.People.Add(p);
                        idPerson = p.id;

                        db.PeopleDepartments.Add(new Database.PeopleDepartment { idPeople = idPerson, idDepartment = idDep, dateCrt = DateTime.Now });

                    }
                    db.SaveChanges();
                    progressBar1.Value++;
                }

                MessageBox.Show("Все данные загружены в БД!");
            }
        }

        private void FImport_Load(object sender, EventArgs e)
        {
            b_import.Enabled = false;
            dgv2.Visible = false;

            for (int i = 0; i < arrayUserDeparments.Length; i++)
            {
                LoadDepartments(true, arrayUserDeparments[i]);
            }
            cb_dep.SelectedIndex = Array.IndexOf(arrayUserDeparments, idDep);//idDep
        }

        private bool LoadDepartments(bool first, int idDepartment)
        {
            bool result = true;
            using (Database.DataBase db = new Database.DataBase())
            {
                if (first)
                {
                    cb_dep.Items.Clear();
                    Database.Department d = db.Departments.FirstOrDefault(p => p.id == idDepartment);
                    cb_dep.Items.Add(d.fullName);
                    LoadDepartments(false, idDepartment);
                }
                else
                {
                    var dd = db.Departments.Where(p => p.idParent == idDepartment).ToList();
                    foreach (Database.Department nd in dd)
                    {
                        cb_dep.Items.Add(nd.fullName);
                        LoadDepartments(false, nd.id);
                    }

                }
            }
            return result;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
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

        private void P_browse_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
