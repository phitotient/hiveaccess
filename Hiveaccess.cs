using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        public static void GetDataFromHive()
        {
            string connection = "DSN=crmnextbigdata;UID=cloudera;PWD=cloudera";
            using (OdbcConnection DbConnection = new OdbcConnection(connection))
            {
                if (DbConnection.State == ConnectionState.Closed)
                {
                    DbConnection.Open();
                    OdbcCommand cmd = DbConnection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM leadfact LIMIT 100;";
                    DbDataReader dr = cmd.ExecuteReader();
                    var dataTable = new DataTable();
                    dataTable.Load(dr);
                    DbConnection.Close();
                }
            }
        }


        static void Main(string[] args)
        {
            GetDataFromHive();
        }
    }
}
