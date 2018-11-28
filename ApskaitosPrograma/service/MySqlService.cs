using MySql.Data.MySqlClient;
using System;

public class MySqlService 
{
    public static MySqlConnection getConnection()
    {
        string server = "localhost";
        string database = "test";
        string user = "root";
        string password = "";

        string connectionString = String.Format("server={0};user id={1}; password={2}; database={3}", server, user, password, database);

        return new MySqlConnection(connectionString);
    }
}