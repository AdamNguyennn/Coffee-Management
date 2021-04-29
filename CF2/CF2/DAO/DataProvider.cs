using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF2.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        
        public static DataProvider Instace
        { 
            get { if (instance == null) instance = new DataProvider();  return DataProvider.instance;} 
          
            private set { DataProvider.instance = value; } 
        }      
        
        private DataProvider() { }
        
        private string connectionSTB = @"Data Source=DESKTOP-9SLTGIG\SQLEXPRESS;Initial Catalog=CoffeeShop12;Integrated Security=True";
       
        public DataTable ExcuteQuery(string query, object[] paramater = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTB))
            {

                connection.Open();

                var command = new SqlCommand(query, connection);

                if(paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (var item in listPara)
                    {
                        if(item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }
            return data;

        }

        public int ExcuteNonQuery(string query, object[] paramater = null)
        {
            
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTB))
            {

                connection.Open();

                var command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }
            return data;

        }

        public object ExcuteScalarQuery(string query, object[] paramater = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTB))
            {

                connection.Open();

                var command = new SqlCommand(query, connection);

                if (paramater != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (var item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, paramater[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                data = command.ExecuteScalar();

                connection.Close();
            }
            return data;

        }
    }
}
