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

        public string getUser(string UserSID)
        {
            
            string username = "";
            if (SIDauth(UserSID))
            {


                MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

                String sqlString = "SELECT * FROM userstable WHERE SID = " + UserSID;
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);

                mySqlReader = command.ExecuteReader();
                if (mySqlReader.Read())
                {
                    username = mySqlReader.GetString(1);               
                }
               
            }
            return username;
        }

        public List<string> getUsers(string UserSID)
        {
            List<string> usersAlist = new List<string>();
            if (SIDauth(UserSID))
            {
                MySql.Data.MySqlClient.MySqlDataReader mySqlreader = null;
                string sqlString = "SELECT * FROM userstable WHERE SID = "+"''";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);

                mySqlreader = command.ExecuteReader();
                while (mySqlreader.Read())
                {
                    usersAlist.Add(mySqlreader.GetString(1));
                }
                
            }
            return usersAlist;
            
        }

        public String postSID(string userName, string password)
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlreader = null;
            string mySqlString = "SELECT * FROM userstable WHERE UserName = " + userName + " AND Password = " + password;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(mySqlString, connection);

            UserClass userSID = new UserClass();

            mySqlreader = command.ExecuteReader();
            if (mySqlreader.Read())
            {
                string sessionId = Guid.NewGuid().ToString();
                userSID.ID = mySqlreader.GetInt32(0);
                userSID.UserName = mySqlreader.GetString(1);
                userSID.Password = mySqlreader.GetString(2);
                userSID.SessionID = sessionId;
            }
            mySqlreader.Close();
            if (userSID.SessionID != "")
            {
                SaveSID(userSID);
                return userSID.SessionID;
            }
            else return "";
        }

        public void SaveSID(UserClass userSID)
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString2 = "SELECT * FROM userstable WHERE ID = " + userSID.ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString2, connection);
            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
                {
                 mySqlReader.Close();
                sqlString2 = "UPDATE userstable SET SID = '" + userSID.SessionID + "' WHERE ID = " + userSID.ID.ToString();
                 command = new MySql.Data.MySqlClient.MySqlCommand(sqlString2, connection);

                 command.ExecuteNonQuery();
                }


        }

        public void DeleteSID(string SID)
        {
            if (SIDauth(SID))
            {
                MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
                String sqlString3 = "SELECT * FROM userstable WHERE SID = " + SID;
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString3, connection);
                mySqlReader = command.ExecuteReader();
                if (mySqlReader.Read())
                {
                    mySqlReader.Close();
                    string emptyString = "";
                    sqlString3 = "UPDATE userstable SET SID = '" + emptyString + "'";
                    command = new MySql.Data.MySqlClient.MySqlCommand(sqlString3, connection);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool SIDauth(string SID)
        {
            
                MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
                String sqlString = "SELECT * FROM userstable WHERE SID = " + SID;
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection);
                mySqlReader = command.ExecuteReader();
                if (mySqlReader.Read())
                {
                    mySqlReader.Close();
                    return true;
                
            }
            else return false;
        }

    }
}