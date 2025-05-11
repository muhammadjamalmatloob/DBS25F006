using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class TransactionRecordDL
    {
        public static List<TransactionRecordBL> transactionRecords = new List<TransactionRecordBL>();

        public static void getRecords(int client_id)
        {
            transactionRecords.Clear();
            string query = $"SELECT t1.transaction_id AS transaction_id,l.value AS transaction_type,t2.amount AS amount,t1.charges AS charges,t1.date_recorded AS date_recorded FROM transactions t1 JOIN transfers t2 ON t1.transaction_id = t2.transaction_id JOIN lookup l ON t1.transaction_type = l.lookup_id WHERE t1.client_id = {client_id}";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    transactionRecords.Add(new TransactionRecordBL(
                        Convert.ToInt32(reader["transaction_id"]),
                        reader["transaction_type"].ToString(),
                        Convert.ToDecimal(reader["amount"]),
                        Convert.ToDecimal(reader["charges"]),
                        Convert.ToDateTime(reader["date_recorded"])
                    ));
                }
            }
        }

        public static void LoadDataGrid(List<TransactionRecordBL> transactionRecords, KryptonDataGridView dgv)
        {

            dgv.Rows.Clear();
            foreach (var record in transactionRecords)
            {
                dgv.Rows.Add(
                    record.getTransactionId(),
                    record.getTransactionType(),
                    record.getAmount(),
                    record.getCharges(),
                    record.getDate()
                );
            }
        }
    }
}
