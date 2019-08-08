using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Demo
{
    class SQL
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <returns>SQL string</returns>
        public static String Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ");
            sql.Append("Users ");
            sql.Append("VALUES( ");
            sql.Append("@id, ");
            sql.Append("@name, ");
            sql.Append("@email ");
            sql.Append(") ");
            return sql.ToString();
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <returns>SQL string</returns>
        public static String Select()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("* ");
            sql.Append("FROM ");
            sql.Append("Users ");
            return sql.ToString();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <returns>SQL string</returns>
        public static String Delete()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE ");
            sql.Append("FROM ");
            sql.Append("Users ");
            sql.Append("WHERE ");
            sql.Append("id = @id ");
            return sql.ToString();

        }

        /// <summary>
        /// Update
        /// </summary>
        /// <returns>SQL string</returns>
        public static String Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ");
            sql.Append("Users ");
            sql.Append("SET ");
            sql.Append("name = @name, ");
            sql.Append("email = @email ");
            sql.Append("WHERE ");
            sql.Append("id = @id");
            return sql.ToString();
        }
    }
}
