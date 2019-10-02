using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer.Model;
using System.Data.SqlClient;
using System.Data;

namespace Customer.Repository
{
    public class CustomerRepository
    {
        string connectionString = @"Server=HABIB; Database=CoffeeShop;Integrated Security = true";
        public bool Add(Customers customers)
        {
            bool isAdd = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "INSERT INTO Customers(Name,Address,Contact)" +
                "VALUES('" + customers.Name + "','" + customers.Address + "','" + customers.Contact + "')";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isAdd = true;
            }
            sqlConnection.Close();
            return isAdd;
        }

        public DataTable Display()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public bool Delete(int id)
        {
            bool isDekete = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "DELETE Customers WHERE Id = "+id+"";
            SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);

            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();
            if (isExecute > 0)
            {
                isDekete = true;
            }
            return isDekete;
        }

        public bool Update(Customers customers,int id)
        {
            bool isUpdate = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "UPDATE Customers SET Name = '"+customers.Name+"'" +
                ",Address = '"+customers.Address+"',Contact='"+customers.Contact+"'" +
                "WHERE Id = "+id+"";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            int isExecute = sqlCommand.ExecuteNonQuery();

            if (isExecute > 0)
            {
                isUpdate = true;
            }
            sqlConnection.Close();
            return isUpdate;
        }

        public DataTable Search(Customers customers)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string commandString = @"SELECT * FROM Customers WHERE Name = '" + customers.Name + "' " +
                "OR Address = '" + customers.Address + "' OR Contact = '"+customers.Contact+"'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
