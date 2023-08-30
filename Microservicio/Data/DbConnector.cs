using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microservicio.Models;

namespace Microservicio.Data
{
    public class DbConnector
    {
        private readonly string _dbConnector;

        public DbConnector(string connectionString)
        {
            _dbConnector = connectionString;
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(_dbConnector))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM clients", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Client client = new Client
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["nameClient"].ToString(),
                        email = reader["email"].ToString(),
                        phone = reader["phone"].ToString(),
                        age = Convert.ToInt32(reader["edad"])
                    };

                    clients.Add(client);
                }

                reader.Close();
            }

            return clients;
        }



        public Client GetClientById(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnector))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("showclientxid", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", clientId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Client client = new Client
                    {
                        id = Convert.ToInt32(reader["id"]),
                        name = reader["nameClient"].ToString(),
                        email = reader["email"].ToString(),
                        phone = reader["phone"].ToString(),
                        age = Convert.ToInt32(reader["edad"])
                    };

                    reader.Close();
                    return client;
                }

                reader.Close();
                return null; 
            }
        }
        public void InsertClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnector))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("CreateNewClient", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", client.id);
                command.Parameters.AddWithValue("@nameClient", client.name);
                command.Parameters.AddWithValue("@email", client.email);
                command.Parameters.AddWithValue("@phone", client.phone);
                command.Parameters.AddWithValue("@edad", client.age);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnector))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateClient", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", client.id);
                command.Parameters.AddWithValue("@nameClient", client.name);
                command.Parameters.AddWithValue("@email", client.email);
                command.Parameters.AddWithValue("@phone", client.phone);
                command.Parameters.AddWithValue("@edad", client.age);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(_dbConnector))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteClient", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", clientId);

                command.ExecuteNonQuery();
            }
        }
    }
}
