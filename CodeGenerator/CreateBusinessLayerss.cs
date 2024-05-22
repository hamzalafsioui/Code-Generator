using System.Data;

namespace CodeGenerator
{
    public class clsCreateBusinessLayer
    {
        DataTable _dt { get; set; }
        string _TableName { get; set; }
        string _BaseTableName { get; set; }

        DataTable _dtColumnChecked { get; set; }

        public clsCreateBusinessLayer(DataTable dt, string TableName, string BaseTableName, DataTable dtCoulmnCheaked)
        {
            _dt = dt;
            _TableName = TableName;
            _BaseTableName = BaseTableName;
            _dtColumnChecked = dtCoulmnCheaked;
        }


        // Edit Data Type

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
                case "money":
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
        private string returnValueForDataType(string DataType, int Number)
        {
            string S1 = DataType;

            char quotation = '"';


            switch (DataType)
            {
                case "datetime":
                    S1 = "DateTime.MinValue;";
                    break;

                case "date":
                    S1 = "DateTime.MinValue;";
                    break;

                case "nvarchar":
                    S1 = $"{quotation}{quotation}";
                    break;

                case "varchar":
                    S1 = $"{quotation}{quotation}";
                    break;

                case "smalldatetime":
                    S1 = "DateTime.MinValue;";
                    break;

                case "smallmoney":
                    S1 = "-1;";
                    break;
                case "money":
                    S1 = "-1;";
                    break;
                case "bit":
                    S1 = "false";
                    break;
                default:
                    S1 = Number.ToString();
                    break;
            }
            return S1;
        }

        // Create Name Class 
        private string CreateNameClass()
        {
            string S1 = "";

            S1 += $"   public class cls{_TableName}\r\n    " + "{";

            return S1;
        }

        // Get & Set


        private string CreateGetAndSet()
        {
            string S1 = "";

            foreach (DataRow item in _dt.Rows)
            {

                S1 += $"\n      public {EditDataType(item[1].ToString())} {(item[0].ToString())} " +
                    $" {{ get; set; }}";

            }
            S1 += "\n       enum enMode { AddNew = 0, UpDate = 1 };\n      enMode Mode = enMode.AddNew;\r\n";

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
            //   short Counter = Count;
            foreach (DataRow RecordRow in _dt.Rows)
            {
                switch (Count)
                {
                    case 1:

                        S1 += EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";
                        break;

                    case 2:
                        S1 += EditDataType(RecordRow[1].ToString()) + " " + RecordRow[0] + ", ";
                        break;

                    case 3:
                        if (CountRef > 0)
                        {
                            S1 += WriteReference(CountRef) + RecordRow[0] + ", ";
                        }
                        CountRef++;
                        break;

                    case 4:
                        if (CountRef > 0)
                        {
                            S1 += RecordRow[0] + ", ";
                        }
                        CountRef++;
                        break;
                }
            }

            S1 = S1.Substring(0, S1.Length - 2);

            S1 += ")\n";

            return S1;
        }

        //  Create Constructer 


        private string CreateConstructerEmpty()
        {
            string S1 = "\r\n";
            S1 += $"\r\n        public cls{_TableName}()\n        {{\n";

            foreach (DataRow item in _dt.Rows)
            {

                S1 += $"            this.{(item[0].ToString())} = {returnValueForDataType(item[1].ToString(), 0)};";
                S1 += "\n";
            }
            S1 += "            Mode = enMode.AddNew;";
            S1 += "\n        }";
            return S1;
        }

        private string CreateConstructerFull()
        {
            string S1 = "\r\n";
            S1 += $"\r\n        private cls{_TableName}(";

            S1 += CreateParameters(2);


            S1 += $"        {{\n";

            foreach (DataRow item in _dt.Rows)
            {
                S1 += $"            this.{(item[0].ToString())} = {(item[0].ToString())};";
                S1 += "\n";
            }

            S1 += "            Mode = enMode.UpDate;";

            S1 += "\n        }";

            return S1;
        }

        /// /////////////////////////////////////

        // Name Function

        private string NameFunctionForHeader(string Name, string EndTextName = "", string Prametars = "")
        {
            return $"\r\n            {Name}{_TableName}{EndTextName}({Prametars}";
        }

        // Add  New

        private string AddNew()
        {
            string S1 = "";

            S1 += NameFunctionForHeader("private bool _AddNew");

            S1 += ")\n        {";
            string ID = "";
            short Counter = 0;
            foreach (DataRow item in _dt.Rows)
            {
                if (Counter == 0)
                {
                    S1 += $"            this.{item[0].ToString()} = cls{_TableName}DataLayer.AddNew{_TableName}(";
                    ID = item[0].ToString(); Counter++;
                }

                else
                {
                    S1 += $"this.{item[0].ToString()}, ";
                }

            }
            S1 = S1.Substring(0, S1.Length - 2);

            S1 += $");\n            return (this.{ID} != -1);\n        }}";

            return S1;
        }

        //

        // UpDate
        private string UpDate()
        {
            string S1 = "";

            S1 += NameFunctionForHeader("private bool _UpDate");

            S1 += ")\n        {\n            return cls";

            S1 += $"{_TableName}DataLayer.UpDate{_TableName}(";


            foreach (DataRow item in _dt.Rows)
            {
                S1 += $"this.{item[0].ToString()}, ";
            }


            S1 = S1.Substring(0, S1.Length - 2);

            S1 += ");\n        }";


            return S1;
        }

        // IsExists

        private string IsExists()
        {
            string S1 = "";

            S1 += NameFunctionForHeader("public static bool Is", "Exists", "int ID)");
            S1 += "\n        {\n            " +
                $"return cls{_TableName}DataLayer.Is{_TableName}Exist(ID);\n        }}";


            return S1;

        }

        // Find

        private string Find()
        {
            string S1 = "";

            S1 += $"public static cls{_TableName} Find (int ID)";
            S1 += "\n        {\n            ";
            short Counter = 0;
            foreach (DataRow item in _dt.Rows)
            {
                if (Counter > 0)
                {
                    S1 += $"            {EditDataType(item[1].ToString())} {(item[0].ToString())} = {returnValueForDataType(item[1].ToString(), 0)};";
                    S1 += "\n";
                }
                Counter++;
            }

            S1 += $"               if (cls{_TableName}DataLayer.FindByID{_TableName}(ID, ";

            S1 += CreateParameters(3);

            S1 += ")\n                {";

            S1 += $"                    return new cls{_TableName}(ID,";

            S1 += CreateParameters(4);



            S1 += ";\n                 }\n                 else\n                 {\n                     return null;\n                 }\n         \n             }";


            return S1;

        }

        // Delete

        private string Delete()
        {
            string S1 = "";

            S1 += NameFunctionForHeader("public static bool Delete", "", "int ID)");
            S1 += "\n        {\n            " +
                $"return cls{_TableName}DataLayer.Delete{_TableName}(ID);\n        }}";

            return S1;

        }

        // GetAll

        private string GetAll()
        {
            string S1 = "";
            S1 += $"public static DataTable GetAll{_TableName}()";
            S1 += "\n        {\n            " +
                 $"return cls{_TableName}DataLayer.All{_TableName}();\n        }}";

            return S1;

        }


        // Get All By Search 

        private string CreateDateForAllSearch(DataRow dtRow)
        {
            string S1 = "";

            S1 += $"public static DataTable GetAll{_TableName}InDate(DateTime Date)\r\n        {{\r\n            string stDate = $\"{{Date.Year}} - {{Date.Month}} - {{Date.Day}}  00:00:00.000\";\r\n             return cls{_TableName}DataLayer.Get{_TableName}InDate(stDate);\r\n        }}";

            return S1;
        }

        private string SearchBy(DataRow dtRow)
        {

            string S1 = "";

            S1 += $"public static DataTable GetAll{_TableName}By{dtRow[0]}(string StartWith)";
            S1 += "\n        {\n            " +
                 $"return cls{_TableName}DataLayer.All{_TableName}By{dtRow[0]}(StartWith);\n        }}";

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
                    S1 += CreateDateForAllSearch(item);

                else
                    S1 += SearchBy(item);
                S1 += "\r\n\n";
            }

            return S1;
        }


        // Is Exists For Column

        private string CreateDateForIsExists(DataRow dtRow)
        {
            string S1 = "";

            S1 += $"public static DataTable ISExists{_TableName}By{dtRow[0]}({EditDataType(dtRow[1].ToString())} Date)\r\n        {{\r\n            string stDate = $\"{{Date.Year}} - {{Date.Month}} - {{Date.Day}}  00:00:00.000\";\r\n             return cls{_TableName}DataLayer.Get{_TableName}InDate(stDate);\r\n        }}";

            return S1;
        }
        private string ExistsForColumn(DataRow dtRow)
        {
            string S1 = "";
            S1 += $"public static bool ISExists{_TableName}By{dtRow[0]}({EditDataType(dtRow[1].ToString())} {dtRow[0]})";
            S1 += "\n        {\n            " +
                 $"return cls{_TableName}DataLayer.ISExists{_TableName}By{dtRow[0]}({dtRow[0]});\n        }}";
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
                    S1 += CreateDateForIsExists(item);

                else
                    S1 += ExistsForColumn(item);
                S1 += "\r\n\n";
            }

            return S1;
        }


        // Save 

        private string Save()
        {
            string S1 = "";

            S1 += $"    public bool Save()\n        {{\n\n            switch (Mode)\n            {{\n                case enMode.AddNew:\n                    if (_AddNew{_TableName}())\n                    {{\n                        Mode = enMode.UpDate;\n                        return true;\n                    }}\n                    else\n                    {{\n                        return false;\n                    }}\n                    \n                case enMode.UpDate:\n                    return _UpDate{_TableName}();\n            }}\n\n\n          return false;\n        }}";


            return S1;
        }

        public string AllFunctionForBusinessLayers()
        {
            string Empty = "\r\n";
            return CreateNameClass() + Empty + CreateGetAndSet() + Empty + CreateConstructerEmpty() + Empty
                + CreateConstructerFull() + Empty + AddNew() + Empty + UpDate() + Empty + IsExists() + Empty
                + Find() + Empty + Delete() + GetAll() + Empty + AllSearch() + Empty + AllExistsForColumn() + Empty + Save()
                + "\n\n    }";
        }

    }
}