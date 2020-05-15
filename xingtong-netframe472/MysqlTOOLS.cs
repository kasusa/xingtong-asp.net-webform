using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472
{
    public class MysqlTOOLS
    {
        MySqlConnection conn;

        public MysqlTOOLS()
        {
            newconnection();
        }

        public void newconnection()
        {
            string connStr = "server=123.56.18.36;user=root;database=andorid-2020-spring;port=3306;password=Jinghaoyang1;Charset=utf8";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }
        public void closeconnection()
        {
            conn.Close();
        }
        public MySqlDataReader sqlToReader(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public void sqlToExec(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
        public bool sqlToBoolhave(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}