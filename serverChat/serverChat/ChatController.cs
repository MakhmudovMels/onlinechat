using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace serverChat
{
    // класс для работы с чатом и сообщениями
    public static class ChatController
    {
        private const int _maxMessage = 100; // клиентам будут отображаться не все сообщения, а только последние 100. При желании ограничение можно убрать
        public static Queue<message> Chat = GetChatFromDB(); // очередь сообщений
        // структура сообщения
        public struct message
        {
            public string userName;
            public string data;
            public message(string name, string msg)
            {
                userName = name;
                data = msg;
            }
        }
        // метод получения сообщений из бд
        private static Queue<message> GetChatFromDB()
        {
            Queue<message> chat = new Queue<message>();

            DB db = new DB();
            db.openConnection();

            string sql = "SELECT user_login, message FROM (SELECT * FROM messages ORDER BY id DESC LIMIT 100) t ORDER BY id";
            MySqlCommand command = new MySqlCommand(sql, db.getConnection());

            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                message msg;
                msg.userName = reader[0].ToString();
                msg.data = reader[1].ToString();
                chat.Enqueue(msg);
            }
            reader.Close();
            db.closeConnection();

            return (chat);
        }
        // метод добавления сообщения в чат
        public static void AddMessage(string userName, string msg)
        {
            try
            {
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(msg)) return;

                DB db = new DB();
                db.openConnection();
                string sql = "INSERT INTO messages (user_login, message) VALUES (@uL,@uM)";
                MySqlCommand command = new MySqlCommand(sql, db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userName;
                command.Parameters.Add("@uM", MySqlDbType.VarChar).Value = msg;
                command.ExecuteNonQuery();
                db.closeConnection();

                int countMessages = Chat.Count;
                if (countMessages >= _maxMessage) Chat.Dequeue();
                message newMessage = new message(userName, msg);
                Chat.Enqueue(newMessage);
                Console.WriteLine("New message from {0}.", userName);
                Server.UpdateAllChats();
            }
            catch (Exception exp) { Console.WriteLine("Error with addMessage: {0}.", exp.Message); }
        }
        // метод очищения чата
        public static void ClearChat()
        {
            Chat.Clear();
        }
        // метод возвращает чат в виде строки
        public static string GetChat()
        {
            try
            {
                string data = "#updatechat&";
                int countMessages = Chat.Count;
                if (countMessages <= 0) return string.Empty;
                foreach( message msg in Chat)
                {
                    data += String.Format("{0}~{1}|", msg.userName, msg.data);
                }
                return data;
            }
            catch (Exception exp) { Console.WriteLine("Error with getChat: {0}", exp.Message); return string.Empty; }
        }
    }
}
