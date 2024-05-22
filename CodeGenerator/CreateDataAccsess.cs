using System.Data;

namespace CodeGenerator
{
    internal class clsCreateDataAccess
    {
        DataTable _dt { get; set; }
        string _TableName { get; set; }
        string _BaseTableName { get; set; }

        DataTable _dtColumnChecked { get; set; }

        // Name Class

        private string CreateNameClass()
        {
            string S1 = "";

            S1 += $"   public class cls{_TableName}Data\r\n    " + "{";

            return S1;
        }

        public void BasicParameters(DataTable dt, string TableName, string BaseTableName, DataTable dtColumnChecked)
        {
            _dt = dt;
            _TableName = TableName;
            _BaseTableName = BaseTableName;
            _dtColumnChecked = dtColumnChecked;
        }

        //   Name Function

        private string NameFunctionForHeader(string Name, string EndText = "")
        {
            return $"\r\n            public static {Name}{_TableName}{EndText}(";
        }

        //   Command

        private string CreateBaseCommandWithQuery()
        {
            string S1 = "";

            S1 += "\r            using( SqlCommand Command = new SqlCommand(query, Connection))\n{";

            return S1;
        }

        //   Data Type
        private string EditDataType(string DataType)
        {
            string S1 = DataType;


            switch (DataType)
            {
                case "datetime":
                    S1 = "DateTime";
                    break;

                case "date":
                    S1 = "DateTime";
                    break;

                case "nvarchar":
                    S1 = "string";
                    break;

                case "varchar":
                    S1 = "string";
                    break;

                case "tinyint":
                    S1 = "byte";
                    break;
                case "smallmoney":
                    S1 = "decimal";
                    break;
                case "smalldatetime":
                    S1 = "DateTime";
                    break;

                case "bit":
                    S1 = "Boolean";
                    break;
            }
            return S1;
        }

        private string ZeroOrEmpty(string DataType)
        {
            string S1 = DataType;

            char Quotation = '"';
            switch (DataType)
            {
                case "datetime":
                    S1 = "null";
                    // S1 = " DateTime.MinValue";
                    break;

                case "date":
                    S1 = "null";
                    //  S1 = " DateTime.MinValue";
                    break;

                case "nvarchar":
                    S1 = "null";
                    // S1 = $"{Quotation}{Quotation}";
                    break;

                case "varchar":
                    S1 = "null";
                    // S1 = $"{Quotation}{Quotation}";
                    break;

                case "smallmoney":
                    S1 = "null";
                    //  S1 = "-1";
                    break;
                case "smalldatetime":
                    // S1 = " DateTime.MinValue";
                    S1 = "null";
                    break;
                case "bit":
                    S1 = "null";
                    //   S1 = "false";
                    break;
                default:
                    S1 = "null";
                    // S1 = "0";
                    break;
            }
            return S1;


        }

        private string To_String(string s1)
        {
            if (s1 == "date" || s1 == "datetime" || s1 == "smalldatetime")
            {
                return ".ToString()";
            }
            else
                return "";
        }
        private string CreateCommandParameters(short Count)
        {
            string S1 = "";
            char Quotation = '"';
            char CurlyR = '{';
            char CurlyL = '}';

            S1 += CreateBaseCommandWithQuery();

            short Counter = Count;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Counter > 0)
                {
                    if (RecordRow[2].ToString() == "NO")
                    {

                        S1 += $"\n\r\n            Command.Parameters.AddWithValue({Quotation}@{RecordRow[0]}{Quotation}, {RecordRow[0]});";
                        if (Count == 10)
                        {
                            break;
                        }
                    }
                    else
                    {
                        S1 += $"\n\n\r\n            if  ({RecordRow[0]}{To_String(RecordRow[0].ToString())} != {ZeroOrEmpty(RecordRow[1].ToString())})\n            {CurlyR}\n             Command.Parameters.AddWithValue({Quotation}@{RecordRow[0]}{Quotation}, {RecordRow[0]});\n";
                        S1 += $"            {CurlyL}\n            else\n            {CurlyR}\n            Command.Parameters.AddWithValue({Quotation}@{RecordRow[0]}{Quotation}, System.DBNull.Value);\n            {CurlyL}";

                    }
                }
                Counter++;
            }
            return S1;
        }

        private string CommandForNonQueryQuery()
        {
            string S1 = "            ";
            char Quotation = '"';
            S1 += $"string query = @{Quotation}Update   {_BaseTableName} \r\n                            Set ";

            S1 += WriteColumnName2(0);
            S1 += "\r\n                                " + WriteWhere(0);

            S1 += $"{Quotation};\n\n";

            return S1;
        }

        private string CommandForExecuteScalar()
        {
            return " object result = Command.ExecuteScalar();\r\n\r\n\r\n                if (result != null && int.TryParse(result.ToString(), out int insertedID))\r\n                {\r\n                    ID = insertedID;\r\n                }";
        }

        private string CommandForReader()
        {
            return "\r\n                using(SqlDataReader reader = Command.ExecuteReader())\n{\r\n";
        }

        private string CreateCodeForCommandReader()
        {
            string S1 = "";
            S1 += "\r\n\r\n                if (reader.Read())\r\n                {\r\n                        isFound = true;\r\n                       ";

            short Counter = 0;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Counter > 0)
                {
                    if (RecordRow[2].ToString() == "NO")
                    {
                        S1 += $"\n                        {RecordRow[0]} = " + $"({EditDataType(RecordRow[1].ToString())})" + $"reader[\"{RecordRow[0]}\"];";

                    }
                    else
                    {
                        S1 += $"\n                        if (reader[\"{RecordRow[0]}\"] != DBNull.Value)";

                        S1 += "\r\n                        { \r\n                            ";
                        S1 += $"{RecordRow[0]} = ({EditDataType(RecordRow[1].ToString())})reader[\"{RecordRow[0]}\"];\r\n";
                        S1 += "                        }";

                        S1 += " else\r\n                        {\r\n                            ";
                        S1 += $"{RecordRow[0]} = {ZeroOrEmpty(RecordRow[1].ToString())};";
                        S1 += "\r\n                        }";
                    }
                }
                Counter++;
            }

            S1 += "\r\n                }";


            S1 += " else\r\n                {\r\n                    isFound = false;\r\n                }\r\n\r\n                }\r\n\r\n";
            S1 += "\r\n\r\n";
            return S1;
        }

        private string CreateCodeForCommandReaderIsFound()
        {
            string S1 = "";

            S1 += "\n                isFound = reader.HasRows;\r\n\r\n                }";
            return S1;
        }

        private string CreateCodeForCommandReaderHasRows()
        {
            string S1 = "";
            S1 += "\r                if (reader.HasRows)\r\n                {\r\n                    dt.Load(reader);\r\n                }\r\n                }";
            return S1;
        }


        //   Parameters

        private string WriteReference(short Count)
        {
            if (Count != 0)
                return "ref ";
            else
                return "";
        }

        private string CreateParameters(short Count)
        {
            string S1 = "";
            short CountRef = 0;
            short Counter = 0;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Count == 100)
                {
                    S1 += EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";
                    break;
                }

                if (Count == 10 && Counter != 0)
                {
                    S1 += EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";
                }

                if (Count == 20)
                {
                    S1 += WriteReference(CountRef) + EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";
                    CountRef++;
                }
                if (Count == 30)
                {
                    S1 += EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";

                }
                Counter++;
            }


            S1 = S1.Substring(0, S1.Length - 2);

            S1 += ")\n            {";

            return S1;
        }

        // Connection
        private string ConnectionNameAndDatatype(string DataType)
        {
            return $"\n            {DataType};\n\n            using( SqlConnection Connection = new SqlConnection" +
             "(clsDataAccessSettings.ConnectionString))\n{\n\n";

        }

        // Column
        private string WriteColumnName1(short Count, string MarkCoomorequ, string Mark = "")
        {
            string S1 = "";


            short Counter = Count;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Counter > 0)
                {

                    S1 += Mark + RecordRow[0] + MarkCoomorequ;
                }
                Counter++;
            }
            S1 = S1.Substring(0, S1.Length - 2);

            S1 += " )";
            return S1;
        }

        private string WriteColumnName2(short Count)
        {
            string S1 = "";


            short Counter = Count;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Counter > 0)
                {

                    S1 += "\r\n                                " + RecordRow[0] + " = " + "@" + RecordRow[0] + ", ";
                }
                Counter++;
            }
            S1 = S1.Substring(0, S1.Length - 2);


            return S1;
        }

        // Where

        private string WriteWhere(short Count)
        {
            string S1 = "where ";

            short Counter = 0;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                if (Counter == Count)
                {
                    S1 += RecordRow[0].ToString() + " = @" + RecordRow[0].ToString();
                }
                Counter++;
            }
            return S1;


        }


        private string WriteWhereForSearch(string ColumnName)
        {
            string S1 = "";

            S1 += $"  Where {ColumnName} like '' + @StartsWith + '%' ";

            return S1;
        }

        // Try Catch 
        private string CreateTryCatch(string DifferentCommand, string ResultInCatch,
            string ReturnDataType, string CodeReader = "")
        {
            string S1 = "";

            S1 = "\n\n            try\r\n            {\r\n                Connection.Open();";
            S1 += $"\r\n                {DifferentCommand}";
            S1 += CodeReader;
            S1 += "\r\n\r\n            }";

            S1 += "\n            catch (Exception ex)\r\n            {\r\n";
            S1 += $"                {ResultInCatch}";
            S1 += "\r\n            }\r\n            finally\r\n            {\r\n                \r\n            }\r\n}\n}  ";
            S1 += $"          return {ReturnDataType};\n";
            S1 += "        }";


            return S1;
        }


        //   Add New 
        private string CreateHeaderAddNew()
        {

            string S1 = "";

            S1 = NameFunctionForHeader("int AddNew");

            S1 += CreateParameters(10);

            return S1;
        }
        private string CreateQueryForAddNew()
        {
            string S1 = "            ";
            char Quotation = '"';
            S1 += $"string query = @{Quotation}INSERT INTO {_BaseTableName} (";

            S1 += WriteColumnName1(0, ", ");
            S1 += "\n              VALUES (" + WriteColumnName1(0, ", ", "@") + ";" + "\n              SELECT SCOPE_IDENTITY();";

            S1 += $"{Quotation};\n\n";


            return S1;
        }
        public string AddNew()
        {

            string S1 = "";

            S1 += CreateHeaderAddNew();

            S1 += ConnectionNameAndDatatype("int ID = -1");

            S1 += CreateQueryForAddNew();

            S1 += CreateCommandParameters(0);

            S1 += CreateTryCatch(CommandForExecuteScalar(), "", "ID");


            return S1;
        }

        // UpDate 
        private string CreateHeaderUpDate()
        {
            string S1 = "";

            S1 = NameFunctionForHeader("bool UpDate");

            S1 += CreateParameters(30);

            return S1;
        }
        private string CommandUpDateAndDelete()
        {
            return "\r\n                rowsAffected = Command.ExecuteNonQuery();\r\n";
        }
        private string Update()
        {
            string S1 = "";

            S1 += CreateHeaderUpDate();

            S1 += ConnectionNameAndDatatype("int rowsAffected = 0");

            S1 += CommandForNonQueryQuery();

            S1 += CreateCommandParameters(1);

            S1 += CreateTryCatch(CommandUpDateAndDelete(), "return false;", "(rowsAffected > 0);");

            return S1;
        }

        // Delete

        private string CreateHeaderDelete()
        {
            string S1 = "";

            S1 = NameFunctionForHeader("bool Delete");

            S1 += CreateParameters(100);

            return S1;
        }
        private string CreateQueryForDelete()
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = @{Quotation}DELETE   {_BaseTableName} ";


            S1 += WriteWhere(0);

            S1 += $"{Quotation};\n\n";

            return S1;
        }
        private string Delete()
        {
            string S1 = "";

            S1 += CreateHeaderDelete();

            S1 += ConnectionNameAndDatatype("int rowsAffected = 0");

            S1 += CreateQueryForDelete();

            S1 += CreateCommandParameters(10);

            S1 += CreateTryCatch(CommandUpDateAndDelete(), "", "(rowsAffected > 0);");

            return S1;
        }


        // Find

        private string CreateHeaderForFind()
        {
            string S1 = "";

            S1 = NameFunctionForHeader("bool FindByID");

            S1 += CreateParameters(20);

            return S1;
        }
        private string CreateQueryForFind()
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = {Quotation}SELECT * FROM  {_BaseTableName} ";

            S1 += WriteWhere(0);

            S1 += $"{Quotation};\n\n";

            return S1;
        }
        private string Find()
        {
            string S1 = "";

            S1 += CreateHeaderForFind();

            S1 += ConnectionNameAndDatatype("bool isFound = false");

            S1 += CreateQueryForFind();

            S1 += CreateCommandParameters(10);

            S1 += CreateTryCatch(CommandForReader(), "isFound = false;", "isFound;", CreateCodeForCommandReader());

            return S1;
        }

        // Is Exists
        private string CreateHeaderForIsExist()
        {
            string S1 = "";

            S1 = NameFunctionForHeader($"bool Is", "Exist");

            S1 += CreateParameters(100);

            return S1;
        }
        private string CreateQueryForIsExist()
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = {Quotation}SELECT Top 1 Found = 1 FROM  {_BaseTableName} ";

            S1 += WriteWhere(0);

            S1 += $"{Quotation};\n\n";

            return S1;
        }
        private string IsExist()
        {
            string S1 = "";

            S1 += CreateHeaderForIsExist();

            S1 += ConnectionNameAndDatatype("bool isFound = false");

            S1 += CreateQueryForIsExist();

            S1 += CreateCommandParameters(10);

            S1 += CreateTryCatch(CommandForReader(), "isFound = false;", "isFound;", CreateCodeForCommandReaderIsFound());

            return S1;
        }

        //Select All

        private string CreateHeaderForSelectAll()
        {
            string S1 = "";

            S1 = NameFunctionForHeader("DataTable All");

            S1 += ")\n            {\n";

            return S1;
        }

        private string CreateQueryForSelectAll()
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = {Quotation}SELECT * FROM  {_BaseTableName}";


            S1 += $"{Quotation};\n\n";

            return S1;
        }

        private string SelectAll()
        {
            string S1 = "";

            S1 += CreateHeaderForSelectAll();

            S1 += ConnectionNameAndDatatype("DataTable dt = new DataTable()");

            S1 += CreateQueryForSelectAll();

            S1 += CreateBaseCommandWithQuery();

            S1 += CreateTryCatch(CommandForReader(), "return null;", "dt", CreateCodeForCommandReaderHasRows());

            return S1;
        }


        // Get All By Search 

        private string CreateHeaderForSearchBy(string EndName)
        {
            string S1 = "";

            S1 = NameFunctionForHeader("DataTable All", $"By{EndName}");
            S1 += "string StartsWith";

            S1 += ")\n            {\n";

            return S1;
        }

        private string CreateQueryForSearchBy(DataRow dtRow)
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = {Quotation}SELECT * FROM  {_BaseTableName} ";

            S1 += WriteWhereForSearch(dtRow[0].ToString());


            S1 += $"{Quotation};\n\n";

            return S1;
        }

        /// date

        private string CreateBetweenDate(DataRow dtRow)
        {
            string S1 = "";

            S1 += $"      public static DataTable Get{_TableName}InDate(string Date)\r\n        {{\r\n\r\n            DataTable dt = new DataTable();\r\n\r\n            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);\r\n\r\n\r\n          \r\n            string Quere = \"SELECT * From {_BaseTableName} Where {dtRow[0]} = @Date \";\r\n         \r\n            SqlCommand Command = new SqlCommand(Quere, Connection);\r\n            Command.Parameters.AddWithValue(\"@Date\", Date);\r\n            try\r\n            {{\r\n                Connection.Open();\r\n                SqlDataReader reader = Command.ExecuteReader();\r\n\r\n                if (reader.HasRows)\r\n                {{\r\n                    dt.Load(reader);\r\n                }}\r\n                reader.Close();\r\n            }}\r\n            catch (Exception ex)\r\n            {{\r\n                return null;\r\n\r\n            }}\r\n            finally\r\n            {{\r\n                Connection.Close();\r\n            }}\r\n\r\n            return dt;\r\n\r\n        }}";

            return S1;
        }

        private string SearchBy(DataRow dtRow)
        {

            string S1 = "";

            S1 += CreateHeaderForSearchBy(dtRow[0].ToString());

            S1 += ConnectionNameAndDatatype("DataTable dt = new DataTable()");

            S1 += CreateQueryForSearchBy(dtRow);

            S1 += CreateBaseCommandWithQuery();

            S1 += " Command.Parameters.AddWithValue(\"@StartsWith\", StartsWith);";

            S1 += CreateTryCatch(CommandForReader(), "return null;", "dt", CreateCodeForCommandReaderHasRows());

            return S1;


        }

        private string AllSearch()
        {
            string S1 = "";

            if (_dtColumnChecked == null)
                return "";


            foreach (DataRow item in _dtColumnChecked.Rows)
            {
                if (EditDataType(item[1].ToString()) == "DateTime")
                    S1 += CreateBetweenDate(item);

                else
                    S1 += SearchBy(item);
                S1 += "\r\n";
            }

            return S1;
        }

        // Is Exists For Colum

        private string CreateHeaderForIsExistForColunm(DataRow dtRow)
        {
            string S1 = "";

            S1 = NameFunctionForHeader("bool ISExists", $"By{dtRow[0].ToString()}");

            S1 += $"{EditDataType(dtRow[1].ToString())} {dtRow[0].ToString()}";

            S1 += ")\n            {";
            return S1;
        }

        private string CreateQueryForSearchByIsExistsColumn(DataRow dtRow)
        {
            string S1 = "            ";
            char Quotation = '"';


            S1 += $"string query = {Quotation}select Top 1 Found = 1 from  {_BaseTableName} ";

            S1 += $"where {dtRow[0]} = @{dtRow[0]}";

            S1 += $"{Quotation};\n\n";

            return S1;
        }

        private string CreateCommandIsExistsColumn(DataRow dtRow)
        {
            string S1 = "";
            char Quotation = '"';

            S1 += CreateBaseCommandWithQuery();

            S1 += $"\n\r\n            Command.Parameters.AddWithValue(@{Quotation}{dtRow[0]}{Quotation}, {dtRow[0]});";

            return S1;
        }
        private string ExistsForColumn(DataRow dtRow)
        {

            string S1 = "";

            S1 += CreateHeaderForIsExistForColunm(dtRow);

            S1 += ConnectionNameAndDatatype("bool isFound = false");

            S1 += CreateQueryForSearchByIsExistsColumn(dtRow);

            S1 += CreateCommandIsExistsColumn(dtRow);

            S1 += CreateTryCatch(CommandForReader(), "isFound = false;", "isFound;", CreateCodeForCommandReaderIsFound());


            return S1;

        }
        private string AllExistsForColumn()
        {
            string S1 = "";

            if (_dtColumnChecked == null)
                return "";


            foreach (DataRow item in _dtColumnChecked.Rows)
            {
                if (EditDataType(item[1].ToString()) == "DateTime")
                { item[1] = "nvarchar"; }

                S1 += ExistsForColumn(item);
                S1 += "\r\n";
            }

            return S1;
        }

        // All Funcation

        public string AllFunctionForDataAccess()
        {
            string Empty = "\r\n";
            return CreateNameClass() + AddNew() + Empty + Update() + Empty + Delete() + Empty +
                     Find() + Empty + IsExist() + Empty + SelectAll() + Empty + AllSearch()
                     + Empty + AllExistsForColumn()
                     + "\n\n    }";
        }

    }
}