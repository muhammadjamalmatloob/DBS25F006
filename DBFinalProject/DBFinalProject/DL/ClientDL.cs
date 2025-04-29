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
    }
}
