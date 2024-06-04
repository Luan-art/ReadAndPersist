using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SqlConnection
    {
        private static readonly Lazy<Microsoft.Data.SqlClient.SqlConnection> _instance = new Lazy<Microsoft.Data.SqlClient.SqlConnection>(() =>
        {
            string connectionString = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes;";
            return new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        });

        public static Microsoft.Data.SqlClient.SqlConnection Instance => _instance.Value;

        private SqlConnection() { }
    }
}
