using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Data;

namespace serverChat
{
    // класс для работы с конкретным клиентом
    public class Client
    {
        private string _userLogin = null;
        private Socket _handler;
        private Thread _userThread;
        public Client(Socket socket)
        {
            _handler = socket;
            // отдельным потоком запускаем прослушивание запросов от клиента
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();
        }
        public string UserLogin
        {
            get { return _userLogin; }
        }
        // метод прослушивания запросов от клиента
        private void listner()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = _handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    handleCommand(data);
                }
                catch { Server.EndClient(this); return; }
            }
        }
        // метод отключения клиента
        public void End()
        {
            try
            {
                _handler.Close();
                try
                {
                    _userThread.Abort();
                }
                catch { } // г
            }
            catch (Exception exp) { Console.WriteLine("Error with end: {0}.", exp.Message); }
        }
        // метод обработки данных, пришедших от клиента
        private void handleCommand(string data)
        {
            // пришёл запрос на авторизацию
            if (data.Contains("#login"))
            {
                string userLogin = data.Split('&')[1].Split('~')[0];
                string userPassHash = data.Split('&')[1].Split('~')[1];
                
                DB db = new DB();

                db.openConnection();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @uL AND pass_hash = @uP", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassHash;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                db.closeConnection();
                
                if (table.Rows.Count > 0)
                {
                    // пользователь успешно авторизован
                    Send("#login&yes");
                    _userLogin = userLogin;
                    Thread.Sleep(1000);
                    UpdateChat();
                    //UpdateUsers();
                    Server.UpdateAllUsers();
                }
                // авторизация провалена, введён неверный логин или пароль
                else Send("#login&no");
                return;
            }
            // пришёл запрос на регистрацию
            else if (data.Contains("#reg"))
            {
                string userLogin = data.Split('&')[1].Split('~')[0];
                string userPassHash = data.Split('&')[1].Split('~')[1];
                DB db = new DB();

                db.openConnection();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE login = @uL", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                // ошибка регистрации пользователь с таким логином уже существвует
                if (table.Rows.Count > 0)
                    Send("#reg&error");
                else
                {                   
                    MySqlCommand command1 = new MySqlCommand("INSERT INTO users (login, pass_hash) VALUES (@uL,@uP)", db.getConnection());
                    command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;
                    command1.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassHash;
                    // регистрация прошла успешно
                    if (command1.ExecuteNonQuery() == 1)
                        Send("#reg&yes");
                    // ошибка регистрации, запрос в бд не выполнился
                    else Send("#reg&no");                    
                }
                db.closeConnection();
                return;
            }
            // пришло новое сообщение
            else if (data.Contains("#newmsg"))
            {
                string message = data.Split('&')[1];
                ChatController.AddMessage(_userLogin, message);
                return;
            }
        }
        // метод обновления чата
        public void UpdateChat()
        {
            Send(ChatController.GetChat());
        }
        // метод обновления списка пользователей
        public void UpdateUsers()
        {
            Send(Server.GetUsers());
        }
        // метод отправки клиенту данных
        public void Send(string command)
        {
            try
            {
                int bytesSent = _handler.Send(Encoding.UTF8.GetBytes(command));
                if (bytesSent > 0) Console.WriteLine("Success");
            }
            catch (Exception exp) { Console.WriteLine("Error with send command: {0}.", exp.Message); Server.EndClient(this); }
        }
    }
}
