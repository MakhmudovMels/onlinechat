using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Security.Cryptography;

namespace chatClient
{
    // форма клиента
    public partial class chatForm : Form
    {
        private delegate void printer(string data, TextBox textBox);
        private delegate void cleaner(TextBox textBox);
        printer Printer;
        cleaner Cleaner;
        private Socket _serverSocket;
        private Thread _clientThread;
        private const string _serverHost = "localhost";
        private const int _serverPort = 9933;
        public chatForm()
        {
            InitializeComponent();
            Printer = new printer(print);
            Cleaner = new cleaner(clearTextBox);
            connect();
            _clientThread = new Thread(listner);
            _clientThread.IsBackground = true;
            _clientThread.Start();
        }
        // метод, слушающий сообщения сервера
        private void listner()
        {
            while (_serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRec = _serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);

                // сервер уведомляет об обновлении чата
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }
                // сервер уведомляет об обновлении списка пользователей
                else if (data.Contains("#updateusers"))
                {
                    UpdateListOfUsers(data);
                    continue;
                }
                // сервер прислал ответ на запрос авторизации
                else if (data.Contains("#login"))
                {
                    string response = data.Split('&')[1];
                    if (response == "yes")
                    {
                        // авторизация прошла успешно, открываем пользователю доступ к чату
                        chatPanel.Enabled = true;
                        logPanel.Enabled = false;
                        showReg.Enabled = false;
                        if (regPanel.Visible == true)
                            regPanel.Visible = false;
                    }
                    else if (response == "no")
                    {
                        // авторизация провалена, введён непрвильный логин или пароль
                        MessageBox.Show("Непрвильный логин или пароль!");
                    }
                    continue;
                }
                // сервер прислал ответ на запрос регистрации
                else if (data.Contains("#reg"))
                {
                    string response = data.Split('&')[1];
                    if (response == "yes")
                    {
                        // регистрация прошла успешно
                        regPanel.Visible = false;
                        MessageBox.Show("Регистрация прошла успешно! Теперь вы можете авторизоваться!");
                    }
                    else if (response == "no")
                    {
                        // регистрация провалена, ошибка на сервере
                        MessageBox.Show("Ошибка регистрации!");
                    }
                    else if (response == "error")
                    {
                        // регистрация провалена, пользователь с таким логином уже существует
                        MessageBox.Show("Пользователь с таким логином уже существует! Придумайте другой!");
                    }
                    continue;
                }
            }
        }
        // метод соединения клиента с сервером
        private void connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(_serverHost);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, _serverPort);
                _serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Connect(ipEndPoint);
            }
            catch { print("Сервер недоступен!", chatBox); }
        }
        // метод очистки textBox
        private void clearTextBox(TextBox textBox)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Cleaner, textBox);
                return;
            }
            textBox.Clear();
        }
        // метод обновления чата
        private void UpdateChat(string data)
        {
            //#updatechat&username1~data1|username2~data2
            clearTextBox(chatBox);
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    print(String.Format("[{0}]:{1}", messages[i].Split('~')[0], messages[i].Split('~')[1]), chatBox);
                }
                catch { continue; }
            }
        }
        // метод обновления списка пользователей
        private void UpdateListOfUsers(string data)
        {
            //#updateusers&username1|username2
            clearTextBox(usersBox);
            string[] users = data.Split('&')[1].Split('|');
            int countUsers = users.Length;
            if (countUsers <= 0) return;
            for (int i = 0; i < countUsers; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(users[i])) continue;
                    print(users[i], usersBox);
                }
                catch { continue; }
            }
        }
        // метод отправки серверу данных
        private void send(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = _serverSocket.Send(buffer);
            }
            catch { print("Связь с сервером прервалась...", chatBox);}
        }
        // метод, который выводит текст в textBox
        private void print(string msg, TextBox textBox)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg, textBox);
                return;
            }
            if (textBox.Text.Length == 0)
                textBox.AppendText(msg);
            else
                textBox.AppendText(Environment.NewLine + msg);
        }
        // обработка события нажатия на кнопку входа в чат
        private void enterChat_Click(object sender, EventArgs e)
        {
            string login = userLogin.Text;
            string passHash = getHash(userPass.Text);
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(passHash))
                MessageBox.Show("Вы ввели не все данные!");
            send("#login&" + login + "~" + passHash);
        }
        // обработка события нажатия на кнопку регистрации
        private void regButton_Click(object sender, EventArgs e)
        {
            string login = regLogin.Text;
            string passHash = getHash(regPass.Text);
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(passHash))
                MessageBox.Show("Вы ввели не все данные!");
            send("#reg&" + login + "~" + passHash);
        }
        // обработка события нажатия на кнопку отправки сообщения
        private void chat_send_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        // метод отправки сообщения в чат
        private void sendMessage()
        {
            try
            {
                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }
        // метод, получает на вход строку, а возвращает её хэш
        private string getHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void showReg_Click(object sender, EventArgs e)
        {
            if (regPanel.Visible == false)
                regPanel.Visible = true;
            else
                regPanel.Visible = false;
        }
    }
}
