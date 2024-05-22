using System;

namespace CodeGeneratorDataAccess
{
    static class clsDataAccessSettings 
    {
     
        public static string ConnectionString(string DataBase ="master")
        {
            return   $"Server=.;Database= {DataBase};User Id=sa;Password=sa123456;";
        }
    }

}