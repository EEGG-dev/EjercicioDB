using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP_6.Models
{
    internal class CervezaBD
    {
        private string connectionString = "Data Source= LAPTOP-CVFN424T\\SQLEXPRESS;" +
            "Initial Catalog= FundamentosCSHARP_6;Integrated Security=true";

        public List<Cerveza> Get()
        {
            List<Cerveza> cervezas = new List<Cerveza>();
            string query = "select id, nombre, marca, alcohol, cantidad from cerveza";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand (query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int Cantidad = reader.GetInt32(4);
                    string Nombre = reader.GetString(1);
                    Cerveza cerveza = new Cerveza(Cantidad, Nombre);
                    cerveza.Alcohol = reader.GetInt32(3);
                    cerveza.Marca = reader.GetString(2);
                    cerveza.Id = reader.GetInt32(0);
                    cervezas.Add(cerveza);
                }
                reader.Close();
                connection.Close();
            }

            return cervezas;
        }

        public void Add(Cerveza cerveza)
        {
            string query = "insert into cerveza(nombre, marca, alcohol, cantidad) " +
                "values(@nombre, @marca, @alcohol, @cantidad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand (query, connection);
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);

                connection.Open();
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Edit(Cerveza cerveza, int Id)
        {
            string query = "update cerveza set nombre=@nombre, marca=@marca, alcohol=@alcohol, " +
                "cantidad=@cantidad where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", cerveza.Nombre);
                command.Parameters.AddWithValue("@marca", cerveza.Marca);
                command.Parameters.AddWithValue("@alcohol", cerveza.Alcohol);
                command.Parameters.AddWithValue("@cantidad", cerveza.Cantidad);
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

        }

        public void Delete(int Id)
        {
            string query = "delete from cerveza where id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
