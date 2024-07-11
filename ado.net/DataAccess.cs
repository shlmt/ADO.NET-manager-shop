using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ado.net
{
    internal class DataAccess
    {
        internal int insertData(string connectionString)
        {
            Console.WriteLine("insert User Name");
            string userName = Console.ReadLine();
            Console.WriteLine("insert password");
            string password = Console.ReadLine();

            string query = "INSERT INTO users(userName,password)" + "VALUES(@UserName,@Password)";

            using(SqlConnection conn = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 20).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 20).Value = password;

                conn.Open();
                int rowsAffwcted = cmd.ExecuteNonQuery();
                conn.Close();

                return rowsAffwcted;
            }
        }

        internal void readData(string connectionString)
        {
            string queryString = "SELECT * FROM users";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine("{0}\t{1}\t{2}", reader[0], reader[1], reader[2]);
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine();
        }
    }
}
