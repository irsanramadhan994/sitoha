using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace basket_toha.Database
{
    public static class DBConecction
    {
        private static SqlConnection _SqlConnection;
        private static SqlDataReader _SqlDataReader;
        private static SqlDataAdapter _SqlDataAdapter;
        private static SqlTransaction _SqlTransaction = null;
        private static string SQL;

        public static bool OpenConnection() {
            try{
                string Config = "Data Source=127.0.0.1;" +
                                "Initial Catalog=test_oop;" +
                                "User id=sa;" +
                                "Password=Biofarma2020#;";
                _SqlConnection = new SqlConnection(Config);
                _SqlConnection.Open();
                return true;
            }
            catch (SqlException Ex)
            {
                SimpanLog("ERROR SQL : "+ Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
                return false;
            }
            catch (Exception Ex)
            {
                SimpanLog("ERROR LOGIC : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
                return false;
            }
        }

        public static void BeginTransaction() {
            try
            {
                _SqlTransaction = _SqlConnection.BeginTransaction();
            }
            catch (SqlException Ex)
            {
                SimpanLog("ERROR SQL : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
            }
            catch (Exception Ex)
            {
                SimpanLog("ERROR LOGIC : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
            }
            
        }

        public static void CommitTransaction()
        {
            try
            {
                _SqlTransaction.Commit();
            }
            catch (SqlException Ex)
            {
                SimpanLog("ERROR SQL : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
            }
            catch (Exception Ex)
            {
                SimpanLog("ERROR LOGIC : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
            }
        }

        public static void RollBackTransaction()
        {
            _SqlTransaction.Rollback();
        }
        private static void CreateFieldValueParam(Dictionary<string, object> field, ref SqlCommand sqlCommand, out string FieldName, out string FieldValue) {
            FieldName = "";
            FieldValue = "";

            foreach (var item in field)
            {
                FieldName += item.Key + ",";
                FieldValue += "@" + item.Key + ",";
                sqlCommand.Parameters.AddWithValue("@" + item.Key, item.Value);
            }

            FieldName = FieldName.Remove(FieldName.Length - 1);
            FieldValue = FieldValue.Remove(FieldValue.Length - 1);
        }

        public static bool Insert(Dictionary<string, object> field, string table) {
            bool result = false;

            try
            {
                string FieldName;
                string FieldValue;
                SqlCommand sqlCommand;

                sqlCommand = new SqlCommand("", _SqlConnection, _SqlTransaction);

                CreateFieldValueParam(field, ref sqlCommand, out FieldName, out FieldValue);

                SQL = "INSERT INTO " + table + "(" + FieldName + ") VALUES (" + FieldValue + ")";

                sqlCommand.CommandText = SQL;

                ExecuteSQL(sqlCommand);

                result = true;
                sqlCommand.Dispose();
            }
            catch (SqlException)
            {
                throw;
                result = false;
            }
            catch (Exception)
            {
                throw;
                result = false;
            }
            return result;
        }

        private static bool ExecuteSQL(SqlCommand sqlCommand) {
            try
            {
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (SqlException Ex)
            {
                SimpanLog("ERROR SQL : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
                return false;
            }
            catch (Exception Ex)
            {
                SimpanLog("ERROR LOGIC : " + Environment.NewLine + Ex.ToString() + Environment.NewLine);
                throw;
                return false;
            }
        }

        private static void SimpanLog(String line)
        {
            DateTime now = DateTime.Now;
            string tahun = now.ToString("yyyy");
            string bulan = now.ToString("MM");
            string hari = now.ToString("dd");
            string dates = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            line = dates + "\t" + line;
            // cek file 
            bool cekfile = false;
            while (!cekfile)
            {
                if (Directory.Exists("eventlog"))
                {
                    if (Directory.Exists("eventlog" + @"\" + tahun))
                    {
                        if (Directory.Exists("eventlog" + @"\" + tahun + @"\" + bulan))
                        {
                            using (StreamWriter outputFile = new StreamWriter("eventlog" + @"\" + tahun + @"\" + bulan + @"\" + hari + ".txt", true))
                            {
                                outputFile.WriteLine(line);
                            }
                            cekfile = true;
                        }
                        else
                        {
                            Directory.CreateDirectory("eventlog" + @"\" + tahun + @"\" + bulan);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory("eventlog" + @"\" + tahun);
                    }
                }
                else
                {
                    Directory.CreateDirectory("eventlog");
                }
            }
        }
    }
}
