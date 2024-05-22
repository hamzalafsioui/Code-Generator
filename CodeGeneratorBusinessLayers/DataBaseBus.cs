using CodeGeneratorDataAccessLayer;
using System.Data;

namespace CodeGeneratorBusinessLayers
{
    public class clsDatabase
    {



        static public DataTable GetAllDataBase()
        {
            return clsDatabaseData.GetAllDataBase();
        }

        public static DataTable GetAllTables(string DataBaseName)
        {
            return clsDatabaseData.GetAllTable(DataBaseName);
        }

        public static DataTable GetTableInfo(string DataBaseName, string Table)
        {
            return clsDatabaseData.GetTableInfo(DataBaseName, Table);
        }
        public static DataTable GetColumnName(string DataBaseName, string Table)
        {
            return clsDatabaseData.GetColumnName(DataBaseName, Table);
        }
    }
}
