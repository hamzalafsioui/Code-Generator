using CodeGeneratorDataAccess;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CodeGeneratorDataAccessLayer
{
    public class clsDatabaseData
    {
        public static DataTable GetAllDataBase()
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString()))
            {
                string Query = "SELECT name FROM sys.databases";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;

                    }
                }
            }
            return dt;

        }



        public static DataTable GetAllTable(string DataBaseName)
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString(DataBaseName)))
            {
                string Query = "SELECT TABLE_NAME  FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        return null;

                    }
                }
            }

            return dt;
        }

        public static DataTable GetTableInfo(string DataBaseName, string Table)
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString(DataBaseName)))
            {
                string Query =
   "SELECT COLUMN_NAME, DATA_TYPE ,IS_NULLABLE  FROM INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = @Table";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@Table", Table);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        return null;

                    }
                }

            }

            return dt;

        }



        public static DataTable GetColumnName(string DataBaseName, string Table)
        {

            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString(DataBaseName)))
            {
                string Query = "SELECT COLUMN_NAME, DATA_TYPE    FROM INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = @Table";

                using (SqlCommand Command = new SqlCommand(Query, Connection))
                {
                    Command.Parameters.AddWithValue("@Table", Table);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return null;

                    }
                }
                 
            }

            return dt;
        }
    }
}
