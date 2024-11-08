using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTaplonVPP
{///
    internal class ketnoi
    {
        SqlConnection conn;

        public void OpenConnection()
        {
            string sql = @"Data Source=HANIE-K2\TUBAC;Initial Catalog=VPP;Integrated Security=True;";
            conn = new SqlConnection(sql);
            conn.Open();
        }
        public void CloseConnection()
        {
            conn.Close();
        }

        public DataTable ReadData(string sql, SqlParameter[] sqlparameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sqlparameters != null) cmd.Parameters.AddRange(sqlparameters);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        public void CreateUpdateDelete(string sql, SqlParameter[] sqlparameters = null)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (sqlparameters != null) cmd.Parameters.AddRange(sqlparameters);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
 
