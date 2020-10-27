using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using SharpUpdate;
using System.Reflection;
using System.ComponentModel;

namespace Prof
{
	public partial class FMain : MetroFramework.Forms.MetroForm
	{
		public FMain(int idUser, string userLogin, string userRole)
		{
			InitializeComponent();
			this.idUser = idUser;
			this.userLogin = userLogin;
			this.userRole = userRole;

		}

		string projectVersion = "1.0.0";
		public int idUser = 0;
		public string userRole = "";
		public string userLogin = "";
		bool showNoAllPeople = true;
		int idDepart = 0;

		int countAll = 0;
		int countInProf = 0;
		int countOutProf = 0;
		int countChild = 0;
		int count35 = 0;
		int countMS = 0;
		int countPens = 0;
		int countWoman = 0;
		int countMan = 0;

		DataTable dt = new DataTable();
		DataTable dt_persons = new DataTable();


		private Microsoft.Office.Interop.Excel.Workbook m_workBook = null;
		private Microsoft.Office.Interop.Excel._Application m_app = null;

		private int[] arrayUserDeparments;
		private int[] arrayUserDeparmentsForLoadPeople;
		private int[] arrayUserDeparmentsAll;
		private string arrayUserDeparmentsForLoadPeople_String = "";
		private string arrayUserDeparmentsAll_String = "";

		private void CheckRole()
		{
			switch (userRole)
			{
				case "GrandAdmin":
					tsm_userMeneger.Visible = true;
					tsm_sprav.Visible = true;
					импортИзToolStripMenuItem.Visible = idUser == 1047 ? true : false;
					break;
				case "Admin":
					tsm_userMeneger.Visible = true;
					tsm_sprav.Visible = true;
					break;
				case "Operator":
					tsm_userMeneger.Visible = false;
					tsm_sprav.Visible = false;
					break;
				default:
					MessageBox.Show("Ошибка в определении прав, обратитесь к администратору!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Close();
					break;
			}
		}

		private void FillArrayUserDeparmentsAll()
		{
			DataTable dt = get_treeTableAdapter.GetData(idUser, null);
			arrayUserDeparmentsAll = new int[dt.Rows.Count];
			int i = 0;

			foreach (DataRow dt_row in dt.Rows)
			{
				for (int k = 1; k <= 10; k++)
				{
					if (!dt_row.IsNull("lvl" + k.ToString() + "_id"))
					{
						if (Array.IndexOf(arrayUserDeparmentsAll, (int)dt_row["lvl" + k.ToString() + "_id"]) == -1)
						{
							if (arrayUserDeparmentsAll.Length == i)
							{
								int[] tmp = new int[arrayUserDeparmentsAll.Length + 1];
								for (int l = 0; l < arrayUserDeparmentsAll.Length; l++)
									tmp[l] = arrayUserDeparmentsAll[l];

								arrayUserDeparmentsAll = new int[tmp.Length];
								for (int l = 0; l < tmp.Length; l++)
									arrayUserDeparmentsAll[l] = tmp[l];
							}
							arrayUserDeparmentsAll[i] = (int)dt_row["lvl" + k.ToString() + "_id"];
							i++;
						}
					}
					if (!dt_row.IsNull("lvl" + k.ToString() + "_idParent") && k != 1)
					{
						if (Array.IndexOf(arrayUserDeparmentsAll, (int)dt_row["lvl" + k.ToString() + "_idParent"]) == -1)
						{
							if (arrayUserDeparmentsAll.Length == i)
							{
								int[] tmp = new int[arrayUserDeparmentsAll.Length + 1];
								for (int l = 0; l < arrayUserDeparmentsAll.Length; l++)
									tmp[l] = arrayUserDeparmentsAll[l];

								arrayUserDeparmentsAll = new int[tmp.Length];
								for (int l = 0; l < tmp.Length; l++)
									arrayUserDeparmentsAll[l] = tmp[l];
							}
							arrayUserDeparmentsAll[i] = (int)dt_row["lvl" + k.ToString() + "_idParent"];
							i++;
						}
					}
				}
			}
			if (userRole.Equals("GrandAdmin")) arrayUserDeparmentsAll_String = "0,";
			else arrayUserDeparmentsAll_String = "";
			for (i = 0; i < arrayUserDeparmentsAll.Length; i++)
			{
				if (i == arrayUserDeparmentsAll.Length - 1)
					arrayUserDeparmentsAll_String += arrayUserDeparmentsAll[i].ToString();
				else
					arrayUserDeparmentsAll_String += arrayUserDeparmentsAll[i].ToString() + ",";
			}
		}
		
		private void FillArrayUserDeparmentsForLoadPeople(int id_dep)
		{
			DataTable dt = get_treeTableAdapter.GetData(null, id_dep);
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
									tmp[l] = arrayUserDeparmentsForLoadPeople[l];
								
								arrayUserDeparmentsForLoadPeople = new int[tmp.Length];
								for (int l = 0; l < tmp.Length; l++)
									arrayUserDeparmentsForLoadPeople[l] = tmp[l];
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
									tmp[l] = arrayUserDeparmentsForLoadPeople[l];

								arrayUserDeparmentsForLoadPeople = new int[tmp.Length];
								for (int l = 0; l < tmp.Length; l++)
									arrayUserDeparmentsForLoadPeople[l] = tmp[l];
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
					arrayUserDeparmentsForLoadPeople_String += arrayUserDeparmentsForLoadPeople[i].ToString();
				else
					arrayUserDeparmentsForLoadPeople_String += arrayUserDeparmentsForLoadPeople[i].ToString() + ",";
			}
		}
		
		private void CreateTree()
		{
			tree_department.Nodes.Clear();
			DataTable dt = get_treeTableAdapter.GetData(idUser, null);
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
								if (treeNode == null) tree_department.Nodes.Add(dt_row["lvl" + k.ToString() + "_id"].ToString(), dt_row["lvl" + k.ToString() + "_shortName"].ToString());
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

		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = $"Профсоюз (образование) | пользователь: {userLogin} | роль: {userRole} | версия {Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
			CheckRole();
			CreateTree();
			FillArrayUserDeparmentsAll();
			showNoAllPeople = Properties.Settings.Default.showNoAllPeople;
			tsmi_showNotAll.Checked = showNoAllPeople;
			timer_update.Enabled = true;
			check_update();
		}

		private void tsm_userMeneger_Click(object sender, EventArgs e)
		{
			new FUserMeneger(idUser, arrayUserDeparmentsAll_String).ShowDialog();
		}

		private void sumPeople(bool first)
		{
			int idD = Convert.ToInt32(tree_department.SelectedNode.Name);
			FillArrayUserDeparmentsForLoadPeople(idD);
			string paramArr = arrayUserDeparmentsForLoadPeople_String;

			SqlConnection conn = DB.GetDBConnection();
			string sql = $"select count(pd.id) from prof.PeopleDepartment pd left join prof.people p on p.id = pd.idPeople where pd.idDepartment in ({paramArr})";

			SqlCommand cmd = new SqlCommand();
			// Сочетать Command с Connection.
			cmd.Connection = conn;
			cmd.CommandText = sql;
			conn.Open();
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				if (reader.HasRows)
				{ 
					reader.Read(); countAll += !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
				}
				else countAll += 0;
			}
			conn.Close();
			sql = $"select count(pd.id) from prof.PeopleDepartment pd left join prof.people p on p.id = pd.idPeople where pd.idDepartment in ({paramArr}) and p.isProf = 'T' ";
			cmd.CommandText = sql;
			conn.Open();
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				if (reader.HasRows)
				{
					reader.Read(); countInProf += !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
				}
				else countInProf += 0;
			}
			conn.Close();
			sql = $"select count(pd.id) from prof.PeopleDepartment pd left join prof.people p on p.id = pd.idPeople where pd.idDepartment in ({paramArr}) and p.isProf = 'F'";
			cmd.CommandText = sql;
			conn.Open();
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				if (reader.HasRows)
				{
					reader.Read(); countOutProf += !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
				}
				else countOutProf += 0;
			}
			conn.Close();

			sql = "select count(pc.id) from prof.PeopleDepartment pd " +
					"left join prof.People p on p.id = pd.idPeople " +
					"left join prof.PeopleChildren pc on pc.idPeople = pd.idPeople ";

			if (rb_all.Checked)
				sql += $" where pd.idDepartment in ({paramArr})";
			else if (rb_inProf.Checked)
				sql += $" where pd.idDepartment in ({paramArr}) and p.isProf = 'T'";
			else if (rb_exitProf.Checked)
				sql += $" where pd.idDepartment in ({paramArr}) and p.isProf = 'F'";

			cmd.CommandText = sql;
			conn.Open();
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				if (reader.HasRows)
				{
					reader.Read();
					countChild += reader.GetInt32(0);
				}
			}
			conn.Close();
			conn.Dispose();
			
		}

		private void loadPeople()
		{
			int idD = Convert.ToInt32(tree_department.SelectedNode.Name);
			FillArrayUserDeparmentsForLoadPeople(idD);

			SqlConnection conn = DB.GetDBConnection();
			string sql = "select distinct p.id, p.famil, p.name, p.otch, p.activity, p.socialWork, p.type, p.phone from prof.PeopleDepartment pd " +
						 "left join prof.people p on p.id = pd.idPeople ";

			

			if (rb_all.Checked)
				sql += $" where pd.idDepartment in ({arrayUserDeparmentsForLoadPeople_String})";
			else if (rb_inProf.Checked)
				sql += $" where pd.idDepartment in ({arrayUserDeparmentsForLoadPeople_String}) and p.isProf = 'T'";
			else if (rb_exitProf.Checked)
				sql += $" where pd.idDepartment in ({arrayUserDeparmentsForLoadPeople_String}) and p.isProf = 'F'";

			l_fullDepart.Text = departmentsTableAdapter1.GetDataById(idD).Rows[0]["fullName"].ToString();
			idDepart = idD;
			
			sumPeople(false);

			SqlCommand sqlCommand = new SqlCommand(sql);
			sqlCommand.Connection = conn;
			conn.Open();
			using (DbDataReader reader = sqlCommand.ExecuteReader())
			{
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						DataRow dr = dt_persons.NewRow();
						dr[0] = reader.GetInt32(0);
						dr[1] = decryptoStr(reader.GetString(1));
						dr[2] = decryptoStr(reader.GetString(2));
						dr[3] = decryptoStr(reader.GetString(3));
						dr[4] = !reader.IsDBNull(4) ? reader.GetString(4) : "";
						dr[5] = !reader.IsDBNull(5) ? reader.GetString(5) : "";
						dr[6] = reader.GetString(6) == "W" ? "Сотрудник" : reader.GetString(6) == "S" ? "Студент" : "";
						dr[7] = decryptoStr(!reader.IsDBNull(7) ? reader.GetString(7) : "");
						dt_persons.Rows.Add(dr);
					}
				}
			}
			conn.Close();
			conn.Dispose();
		}
		
		private void loadNoAllPeople()
		{
			int idD = Convert.ToInt32(tree_department.SelectedNode.Name);
			FillArrayUserDeparmentsForLoadPeople(idD);

			SqlConnection conn = DB.GetDBConnection();
			string sql = "select distinct p.id, p.famil, p.name, p.otch, p.activity, p.socialWork, p.type, p.phone from prof.PeopleDepartment pd " +
						 "left join prof.people p on p.id = pd.idPeople ";

			l_fullDepart.Text = departmentsTableAdapter1.GetDataById(idD).Rows[0]["fullName"].ToString();

			if (rb_all.Checked)
				sql += $" where pd.idDepartment = {idD}";
			else if (rb_inProf.Checked)
				sql += $" where pd.idDepartment = {idD} and p.isProf = 'T'";
			else if (rb_exitProf.Checked)
				sql += $" where pd.idDepartment = {idD} and p.isProf = 'F'";
			

			sumPeople(false);
			// Создать объект Command.
			SqlCommand cmd = new SqlCommand();
			// Сочетать Command с Connection.
			cmd.Connection = conn;
			cmd.CommandText = sql;
			conn.Open();
			using (DbDataReader reader = cmd.ExecuteReader())
			{
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						DataRow dr = dt_persons.NewRow();
						dr[0] = reader.GetInt32(0);
						dr[1] = decryptoStr(reader.GetString(1));
						dr[2] = decryptoStr(reader.GetString(2));
						dr[3] = decryptoStr(reader.GetString(3));
						dr[4] = !reader.IsDBNull(4) ? reader.GetString(4) : "";
						dr[5] = !reader.IsDBNull(5) ? reader.GetString(5) : "";
						dr[6] = reader.GetString(6) == "W" ? "Сотрудник" : reader.GetString(6) == "S" ? "Студент" : "";
						dr[7] = decryptoStr(!reader.IsDBNull(7) ? reader.GetString(7) : "");
						dt_persons.Rows.Add(dr);
					}
				}
			}
			conn.Close();
			conn.Dispose();
		}

		private void tree_department_AfterSelect(object sender, TreeViewEventArgs e)
		{
			fillDgv();
		}

		private void fillDgv()
		{
			countAll = 0;
			countInProf = 0;
			countOutProf = 0;
			countChild = 0;

			dgv.Enabled = false;
			
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dt_persons = new DataTable("persons");
			dt_persons.Columns.Add(new DataColumn("id", typeof(int)));
			dt_persons.Columns.Add(new DataColumn("Фамилия", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Имя", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Отчество", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Нагрузка", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Общественная деятельность", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Сотрудник / студент", typeof(string)));
			dt_persons.Columns.Add(new DataColumn("Телефон", typeof(string)));
			if (showNoAllPeople) loadNoAllPeople();
			else loadPeople();
			
			dgv.DataSource = dt_persons;
			dgv.Columns[0].Visible = false;
			dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
			dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
			dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);
			tssl_All.Text = String.Format("Всего: {0}", countAll);
			tssl_inProf.Text = String.Format("В профсоюзе: {0}", countInProf);
			tssl_OutProf.Text = String.Format("Вышло из профсоюза: {0}", countOutProf);
			tssl_Child.Text = String.Format("Всего детей: {0}", countChild);
			label_info.Visible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.Enabled = true;
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

		private void tsm_add_Click(object sender, EventArgs e)
		{
			new FPerson(idUser, true, 0, idDepart, arrayUserDeparments, arrayUserDeparmentsAll_String).ShowDialog();
			fillDgv();
		}

		private void tsm_edit_Click(object sender, EventArgs e)
		{
			if (dgv[0, dgv.CurrentRow.Index].Value.ToString() != "")
			{
				new FPerson(idUser, false, (int)dgv[0, dgv.CurrentRow.Index].Value, idDepart, arrayUserDeparments, arrayUserDeparmentsAll_String).ShowDialog();
				fillDgv();
			}
		}

		private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			tsm_edit.PerformClick();
		}

		private void tsmi_showNotAll_Click(object sender, EventArgs e)
		{
			showNoAllPeople = !showNoAllPeople;
			tsmi_showNotAll.Checked = showNoAllPeople;
			Properties.Settings.Default.showNoAllPeople = showNoAllPeople;
			Properties.Settings.Default.Save();
			string selectNode = "";
			if (tree_department.SelectedNode != null)
				selectNode = tree_department.SelectedNode.Name;
			CreateTree();
			tree_department.SelectedNode = findNode(null, selectNode);
		}

		private void tsm_sprav_Click(object sender, EventArgs e)
		{
			new FDepartaments(arrayUserDeparmentsAll_String).ShowDialog();
			CreateTree();
		}

		private void tsm_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void мастерОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FReports(arrayUserDeparments, idUser).ShowDialog();
		}

		private void tsm_search_Click(object sender, EventArgs e)
		{
			FSearch search = new FSearch();
			search.ShowDialog();
			if (search.idPers != 0)
			{
				int idPers = search.idPers;
				int keyTree = 0;
				string isProf = "";
				SqlConnection conn = DB.GetDBConnection();
				string sql = $"select pd.idDepartment, p.isProf from prof.PeopleDepartment pd " +
					$"left join prof.People p on p.id = pd.idPeople " +
					$"where idPeople = {idPers}";
				// Создать объект Command.
				SqlCommand cmd = new SqlCommand();
				// Сочетать Command с Connection.
				cmd.Connection = conn;
				cmd.CommandText = sql;
				conn.Open();
				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						reader.Read();
						keyTree = reader.GetInt32(0);
						isProf = reader.GetString(1);
						
					}
				}
				conn.Close();
				conn.Dispose();

				switch (isProf)
				{
					case "T":
						rb_inProf.Checked = true;
						break;
					case "F":
						rb_exitProf.Checked = true;
						break;
					default:
						rb_all.Checked = true;
						break;
				}
				tree_department.SelectedNode = findNode(null, keyTree.ToString());
				for (int i = 0; i < dgv.Rows.Count; i++)
				{
					dgv.Rows[i].Selected = false;
					if (dgv[0, i].Value.ToString().Equals(idPers.ToString()))
					{
						dgv.Rows[i].Selected = true;
						dgv.FirstDisplayedScrollingRowIndex = i;
						dgv.CurrentCell = dgv[1, i];
						break;
					}
				}
			}
		}

		private void rb_all_CheckedChanged(object sender, EventArgs e)
		{
			fillDgv();
		}

		private void tsm_delete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы уверены в удалении?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				int delPeople = (int)dgv[0, dgv.CurrentRow.Index].Value;
				SqlConnection conn = DB.GetDBConnection();
				string sql = $"delete from prof.People where id = {delPeople}";
				// Создать объект Command.
				SqlCommand cmd = new SqlCommand();
				// Сочетать Command с Connection.
				cmd.Connection = conn;
				cmd.CommandText = sql;
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
				conn.Dispose();

				MessageBox.Show("Персона успешно удалена!");
				sumPeople(true);
				if (showNoAllPeople) loadNoAllPeople();
				else loadPeople();
				tssl_All.Text = String.Format("Всего: {0}", countAll);
				tssl_inProf.Text = String.Format("В профсоюзе: {0}", countInProf);
				tssl_OutProf.Text = String.Format("Вышло из профсоюза: {0}", countOutProf);
				tssl_Child.Text = String.Format("Всего детей: {0}", countChild);
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

		private void детиToolStripMenuItem_Click(object sender, EventArgs e)
		{
			reportChild();
			ExportToExcel(dt);
		}

		private void ExportToExcel(DataTable dt)
		{
			if (m_app != null)
			{
				m_app.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_app);
			}
			// Книга Excel.
			m_workBook = null;
			// Страница Excel.
			Microsoft.Office.Interop.Excel.Worksheet m_workSheet = null;
			m_app = null;
			string name = "";
			if (dt.TableName == "statistic") name = "Статистика на ";
			else if (dt.TableName == "child") name = "Список детей на ";
			saveFileDialog1.FileName = name + DateTime.Now.Day + "." +
				DateTime.Now.Month + "." +
				DateTime.Now.Year + ".xlsx";// по умолчанию сохраняет в корень диска С:
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
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


					for (int j = 0; j < dt.Columns.Count; j++)
					{
						m_workSheet.Cells[1, j + k] = dt.Columns[j].ColumnName;
						((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[1, j + k]).Font.Bold = true;
						((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[1, j + k]).Borders.Color = Color.Black;

					}
					k = 1;
					// Пишем строку
					for (int l = 0; l < dt.Rows.Count; l++)
					{
						for (int j = 0; j < dt.Columns.Count; j++)
						{
							DataRow dr = dt.Rows[l];
							((Microsoft.Office.Interop.Excel.Range)m_workSheet.Cells[l + 2, j + k]).Borders.Color = Color.Black;
							m_workSheet.Cells[l + 2, j + k] = dr[j];
						}
					}
					// Сохранение файла Excel.
					m_workSheet.Columns.AutoFit();
					m_workBook.SaveAs(saveFileDialog1.FileName);
				}
				finally
				{
					m_app.Visible = true;
					m_app.Interactive = true;
					m_app.ScreenUpdating = true;
					m_app.UserControl = true; 
					GC.Collect();
					dt.Clear();
				}
			}
		}

		private void статистическийОтчетToolStripMenuItem_Click(object sender, EventArgs e)
		{

			try
			{
				DataTable dt = new DataTable("statistic");

				dt.Columns.Add(new DataColumn("Всего", typeof(int)));
				dt.Columns.Add(new DataColumn("Состоит в профсоюзе", typeof(int)));
				dt.Columns.Add(new DataColumn("Выбыл из профсоюза", typeof(int)));
				dt.Columns.Add(new DataColumn("Всего детей", typeof(int)));
				dt.Columns.Add(new DataColumn("Количество молодых специалистов", typeof(int)));
				dt.Columns.Add(new DataColumn("Количество до 35 лет", typeof(int)));
				dt.Columns.Add(new DataColumn("Количество пенсионеров", typeof(int)));
				dt.Columns.Add(new DataColumn("Количество женщин", typeof(int)));
				dt.Columns.Add(new DataColumn("Количество мужчин", typeof(int)));

				count35 = 0;
				countMS = 0;
				countPens = 0;
				countWoman = 0;
				countMan = 0;
				FillReportOther();

				DataRow dr = dt.NewRow();
				dr[0] = countAll;
				dr[1] = countInProf;
				dr[2] = countOutProf;
				dr[3] = countChild;
				dr[4] = countMS;
				dr[5] = count35;
				dr[6] = countPens;
				dr[7] = countWoman;
				dr[8] = countMan;
				dt.Rows.Add(dr);
				ExportToExcel(dt);
			}
			catch (Exception)
			{
				MessageBox.Show("Требуется выбрать подразделение!");
			}
		}

		private void FillReportOther()
		{
			string paramArr = arrayUserDeparmentsForLoadPeople_String;

			SqlConnection conn = DB.GetDBConnection();
			string sql = "(select count(pd.id) from prof.PeopleDepartment pd " +
						 "left join prof.people p on p.id = pd.idPeople ";


			string cm = sql + $" where pd.idDepartment in ({paramArr}) and p.gender = 'Муж' and p.isProf = 'T') as male, ";
			string cw = sql + $" where pd.idDepartment in ({paramArr}) and p.gender = 'Жен' and p.isProf = 'T') as female, ";
			string cp = sql + $" where pd.idDepartment in ({paramArr}) and p.isPensioner = 'T' and p.isProf = 'T') as pens, ";
			string ag = sql + $" where pd.idDepartment in ({paramArr}) and dbo.fullAge(birthday, CURRENT_TIMESTAMP) < 36) as do36, ";
			string ms = sql + $" left join prof.PeopleWork pw on pw.idPeople = p.id where pd.idDepartment in ({paramArr}) " +
							  $" and pw.stajObsh = 'T' and pw.isActual = 'T' and dbo.fullAge(pw.dateStart, pw.dateEnd) < 3) as ms ";


			sql = $"select {cm} {cw} {cp} {ag} {ms} ";


			SqlCommand sqlCommand = new SqlCommand(sql);
			sqlCommand.Connection = conn;
			conn.Open();
			using (DbDataReader reader = sqlCommand.ExecuteReader())
			{
				if (reader.HasRows)
				{
					reader.Read();
					countMan = reader.GetInt32(0);
					countWoman = reader.GetInt32(1);
					countPens = reader.GetInt32(2);
					count35 = reader.GetInt32(3);
					countMS = reader.GetInt32(4);
				}
			}
			conn.Close();
			conn.Dispose();
		}

		private void reportChild()
		{
			try
			{
				int i = 1;
				string paramArr = arrayUserDeparmentsForLoadPeople_String;
				dt = new DataTable("child");
				dt.Columns.Add(new DataColumn("№ п/п", typeof(int)));
				dt.Columns.Add(new DataColumn("Ф.И.О ребенка", typeof(string)));
				dt.Columns.Add(new DataColumn("Дата рождения", typeof(DateTime)));
				dt.Columns.Add(new DataColumn("Ф.И.О родителя", typeof(string)));
				dt.Columns.Add(new DataColumn("Место работы родителя", typeof(string)));
				dt.Columns.Add(new DataColumn("Должность родителя", typeof(string)));
				string sql = $" select pc.fioChildren, pc.birthday, p.famil, p.name, p.otch, pw.workPlace, pw.doljn from prof.PeopleDepartment pd " +
							 $" left join prof.people p on p.id = pd.idPeople " +
							 $" left join prof.PeopleWork pw on pw.idPeople = p.id " +
							 $" inner join prof.PeopleChildren pc on pc.idPeople = pd.idPeople ";
				if (rb_all.Checked)
					sql += $" where pd.idDepartment in ({paramArr}) ";
				else if (rb_inProf.Checked)
					sql += $" where pd.idDepartment in ({paramArr}) and p.isProf = 'T' ";
				else if (rb_exitProf.Checked)
					sql += $" where pd.idDepartment in ({paramArr}) and p.isProf = 'F' ";
				sql += $" and pw.isActual = 'T' and pw.isWorked = 'T' ";

				SqlConnection conn = DB.GetDBConnection();
				SqlCommand child = new SqlCommand(sql);
				child.Connection = conn;
				conn.Open();
				using (DbDataReader reader = child.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							DataRow dr = dt.NewRow();
							dr[0] = i;
							dr[1] = reader.GetString(0);
							dr[2] = reader.GetDateTime(1);
							dr[3] = decryptoStr(reader.GetString(2)) + " " + decryptoStr(reader.GetString(3)) + " " + decryptoStr(reader.GetString(4));
							dr[4] = !reader.IsDBNull(5) ? reader.GetString(5) : "";
							dr[5] = !reader.IsDBNull(6) ? reader.GetString(6) : "";
							dt.Rows.Add(dr);
							i++;
						}
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Требуется выбрать подразделение!");
			}
			
		}

		private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FAbout().ShowDialog();
		}

		private void ИмпортИзToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new FImport(idUser, idDepart, arrayUserDeparmentsAll_String).ShowDialog();
		}

		private void refreshTree_Click(object sender, EventArgs e)
		{
			string selectNode = "";
			if (tree_department.SelectedNode != null)
				selectNode = tree_department.SelectedNode.Name;
			CreateTree();
			tree_department.SelectedNode = findNode(null, selectNode);
		}

		private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			tsm_edit.Enabled = true;
		}

		private void but_newVersion_Click(object sender, EventArgs e)
		{
			SharpUpdater updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://raw.githubusercontent.com/AlexDives/ProfUpdater/master/version.xml"));
			updater.DoUpdate();
		}

		private void timer_update_Tick(object sender, EventArgs e)
		{
			check_update();
		}

		private void check_update()
		{
			SharpUpdateXml[] sux = SharpUpdateXml.Parse(new Uri("https://raw.githubusercontent.com/AlexDives/ProfUpdater/master/version.xml"));

			for (int i = 0; i < sux.Length; i++)
			{
				if (sux[i].FilePath.Equals("./Prof.exe"))
					if (sux[i].IsNewerThan(new Version(Application.ProductVersion.ToString())))
						but_newVersion.Visible = true;
					else but_newVersion.Visible = false;
			}
		}

		private void FMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (m_app != null)
			{
				m_app.Quit();
				System.Runtime.InteropServices.Marshal.ReleaseComObject(m_app);
			}
			Application.Exit();
		}
	}

}
