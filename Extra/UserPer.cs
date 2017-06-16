using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using API.Models;
using System.Collections;

namespace API
{
    public class UserPer
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;

        public UserPer()
        {
            string connectionStr;
            connectionStr = "server=127.0.0.1;uid=test2;pwd=password;database=tasktable";
            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection();
                connection.ConnectionString = connectionStr;
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
            }

        }

        public UserClass getUser(long ID)
        {

            UserClass u = new UserClass();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM userstable WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);

            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
            {
                u.ID = mySqlReader.GetInt64(0);
                u.UserName = mySqlReader.GetString(1);
                u.Password = mySqlReader.GetString(2);
                return u;
            }
            else { return null; }
        }

        public ArrayList getUsers()
        {
            ArrayList usersAlist = new ArrayList();


            MySql.Data.MySqlClient.MySqlDataReader mySqlreader = null;
            string sqlString = "SELECT * FROM userstable";
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);

            mySqlreader = command.ExecuteReader();
            while (mySqlreader.Read())
            {
                UserClass user = new UserClass();
                user.ID = mySqlreader.GetInt32(0);
                user.UserName = mySqlreader.GetString(1);
                user.Password = mySqlreader.GetString(2);
                usersAlist.Add(user);
            }
            return usersAlist;

        }

    }
}