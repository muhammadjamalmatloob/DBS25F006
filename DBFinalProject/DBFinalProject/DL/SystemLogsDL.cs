using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class SystemLogsDL
    {

        public static void LoadDataGrid(KryptonDataGridView dgvSystem)
        {
            string query = $@"
                SELECT 
                    s.log_id as l_id,
                    u.username as u_name,
                    l.value as type,
                    s.time as time,
                    l1.value as level,
                    s.user_id as u_id,
                    s.action as act,
                    s.details as det 
                FROM 
                    system_logs s
                INNER JOIN 
                    users u ON u.user_id = s.user_id
                INNER JOIN 
                    lookup l ON l.lookup_id = u.role_id
                INNER JOIN 
                    lookup l1 ON l1.lookup_id = s.log_level";

            dgvSystem.Rows.Clear();

            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    int log_id = Convert.ToInt32(reader["l_id"]);
                    int user_id = Convert.ToInt32(reader["u_id"]);
                    string username = reader["u_name"].ToString();
                    string usertype = reader["type"].ToString();
                    string log_level = reader["level"].ToString();
                    string time = reader["time"].ToString();
                    string action = reader["act"].ToString();
                    string details = reader["det"].ToString();
                    

                    dgvSystem.Rows.Add(
                        log_id,
                        user_id,
                        username,
                        usertype,
                        log_level,          
                        action,
                        details,
                        time
                    );
                }
            }
        }

        public static bool AddLog(int level, string action, string details)
        {
            string query = $"Insert into system_logs (time, log_level, user_id, action, details) " +
                $"values (Now(),{level}, " +
                $"(Select user_id From users Where username = '{MainInterface.username}'), " +
                $"'{action}', '{details}')";
            DatabaseHelper.Instance.Update(query);
            return true;
        }
    }
}
