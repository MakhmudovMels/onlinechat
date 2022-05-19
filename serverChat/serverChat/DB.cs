using MySql.Data.MySqlClient;
using System;

namespace serverChat
{
    // класс для подключения к базе данных
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=3119750;database=onlinechat");
        // метод открытия соединения
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        // метод закрытия соединения
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        // метод получения переменной соединения
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
