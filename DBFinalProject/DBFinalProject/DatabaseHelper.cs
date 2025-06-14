﻿using System;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    public class DatabaseHelper
    {
        private String serverName = "127.0.0.1";
        private String port = "3306";
        private String databaseName = "midprojectdb";
        private String databaseUser = "root";
        private String databasePassword = "1234567890-=1234567890-=";
        private DatabaseHelper() { }
        private static DatabaseHelper _instance;
        public static DatabaseHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseHelper();
                return _instance;
            }
        }
        public MySqlConnection getConnection()
        {
            string connectionString =
           $"server={serverName};port={port};user={databaseUser};database ={databaseName}; password ={databasePassword}; SslMode = Required; ";
            var connection = new MySqlConnection(connectionString);
            connection.Open();

            return connection;
        }
        public MySqlDataReader getData(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, getConnection()))
                {
                    return command.ExecuteReader();
                }
            }
        }
        public int Update(string query)
        {
            using (var connection = getConnection())
            {
                using (var command = new MySqlCommand(query, getConnection()))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}

