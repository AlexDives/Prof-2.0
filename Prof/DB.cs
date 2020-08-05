using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Prof
{
    class DB
    {
        public static SqlConnection GetDBConnection()
        {
            string connString = Properties.Settings.Default.ProfConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
