using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class ClientDL
    {
        public static List<ClientBL> clients = new List<ClientBL>();

        public static void AddClient(ClientBL client)
        {
            string query = $"INSERT INTO clients VALUES ('{client.getClientId()}','{client.getUserId()}', '{client.getApplicationId()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void EditClient(ClientBL client)
        {
            string query = $"UPDATE clients SET application_id = '{client.getApplicationId()}' WHERE user_id = '{client.getUserId()}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteClient(ClientBL client)
        {
            string query = $"DELETE FROM clients WHERE user_id = '{client.getUserId()}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static string TotalClients()
        {
            string query = "SELECT COUNT(*) FROM clients";
            int total = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader[0]);
                }
            }
            return total.ToString();
        }
        public static int getUserIdByClientId(int client_id)
        {
            string query = $"SELECT user_id FROM clients WHERE client_id = {client_id}";
            int userId = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    userId = Convert.ToInt32(reader[0]);
                }
            }
            return userId;
        }
        }
}
