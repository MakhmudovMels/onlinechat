using System;
using System.Collections.Generic;
using System.Net.Sockets;
namespace serverChat
{
    // класс для работы со всеми подключёнными клиентами
    public static class Server
    {
        // список подключённых клиентов
        public static List<Client> Clients = new List<Client>();
        // метод подключения нового клиента
        public static void NewClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                Console.WriteLine("New client connected: {0}", handle.RemoteEndPoint);
            }
            catch (Exception exp) { Console.WriteLine("Error with addNewClient: {0}.", exp.Message); }
        }
        // метод отключения клиента
        public static void EndClient(Client client)
        {
            try
            {
                client.End();
                Clients.Remove(client);
                Console.WriteLine("User {0} has been disconnected.", client.UserLogin);
                UpdateAllUsers();
            }
            catch (Exception exp) { Console.WriteLine("Error with endClient: {0}.", exp.Message); }
        }
        // метод обновления чатов у всех клиентов
        public static void UpdateAllChats()
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    if (Clients[i].UserLogin != null)
                        Clients[i].UpdateChat();
                }
            }
            catch (Exception exp) { Console.WriteLine("Error with updateAlLChats: {0}.", exp.Message); }
        }
        // метод обновления списков пользователей у всех клиентов
        public static void UpdateAllUsers()
        {
            try
            {
                int countUsers = Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    if (Clients[i].UserLogin != null)                     
                        Clients[i].UpdateUsers();
                }
            }
            catch (Exception exp) { Console.WriteLine("Error with UpdateUsers: {0}.", exp.Message); }
        }
        // метод получения списка пользователей
        public static string GetUsers()
        {
            try
            {
                string data = "#updateusers&";
                int countUsers = Clients.Count;
                if (countUsers <= 0) return string.Empty;
                for (int i = 0; i < countUsers; i++)
                {
                    if (Clients[i].UserLogin != null)
                        data += String.Format("{0}|", Clients[i].UserLogin);
                }
                return data;
            }
            catch (Exception exp) { Console.WriteLine("Error with GetUsers: {0}", exp.Message); return string.Empty; }
        }

    }
}
