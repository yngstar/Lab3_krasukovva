using MySql.Data.MySqlClient;
using System;
using System.Data;

public class UserDatabase : IUserDatabase
{
    private string connectionString = "Server=your_server;Database=your_database;Uid=your_username;Pwd=your_password;";

    public UserDatabase(string connection)
    {
        // Инициализация объекта UserDatabase с переданным значением подключения
        connectionString = connection;
    }

    public bool UserExists(string username)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }

    public void AddUser(string username, string password)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }
        }
    }
}
