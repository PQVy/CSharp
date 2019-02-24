using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLConnectionDemo
{
    class DBConn
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private string connectionString;
        private string query;

        public SqlConnection DBConnection()
        {
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Study\MicrosoftVisualStudio\SQLConnectionDemo\SQLConnectionDemo\Database1.mdf;Integrated Security=True";
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return this.conn;
        }

        public void ViewData()
        {
            try
            {
                conn = DBConnection();
                query = "SELECT * FROM details";
                cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("ID  " + " | " + "Name  " + "     | " + "Age  ");
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetValue(0).ToString() + "    | " + dr.GetValue(1).ToString() + " | " + dr.GetValue(2).ToString());
                }
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void InsertData(string name, int age)
        {
            try
            {
                conn = DBConnection();
                query = "INSERT INTO details (user_name, user_age) VALUES (@name, @age)";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data stored in Database");
                conn.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public void DeleteData(string name)
        {
            try
            {
                conn = DBConnection();
                query = "DELETE FROM details WHERE user_name = @name";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Delete Success!!!");
                }
                else
                {
                    Console.WriteLine("Database is not have this name.");
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SearchData(string name)
        {
           
            try
            {
                conn = DBConnection();
                query = "SELECT * FROM details where user_name like @name";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", "%"+name+"%");
                //cmd.Parameters.AddWithValue("@name", "'" + name + "'");

                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("ID  " + " | " + "Name  " + "     | " + "Age  ");
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetValue(0).ToString() + "    | " + dr.GetValue(1).ToString() + " | " + dr.GetValue(2).ToString());
                }
                conn.Close();
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
