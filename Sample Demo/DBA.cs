using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sample_Demo
{
    class DBA
    {
        /// <summary>
        /// Connect
        /// </summary>
        /// <returns>SqlConnection</returns>
        public static SqlConnection Connect()
        {
            // create connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=ODCN032;Initial Catalog=MSSQLSERVER;Integrated Security=True";
            return connection;
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="connect">connect</param>
        /// <param name="row">DataRow</param>
        public static void ExecuteNonQuery(String sql, SqlConnection connect, DataRow row)
        {
            SqlCommand command = new SqlCommand(sql, connect);
            command.Parameters.AddWithValue("@id", row[0]);
            command.Parameters.AddWithValue("@name", row[1]);
            command.Parameters.AddWithValue("@email", row[2]);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Fill
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="connect">connect</param>
        /// <returns>DataTable</returns>
        public static DataTable Fill(String sql, SqlConnection connect)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(sql, connect);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
