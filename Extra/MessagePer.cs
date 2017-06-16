using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using API.Models;
using MySql.Data;

namespace API
{
    public class MessagePer 
    {
            private MySql.Data.MySqlClient.MySqlConnection connection2;

            public MessagePer()
            {
                string connectionStr;
                connectionStr = "server=127.0.0.1;uid=test2;pwd=password;database=tasktable";
                try
                {
                    connection2 = new MySql.Data.MySqlClient.MySqlConnection();
                    connection2.ConnectionString = connectionStr;
                    connection2.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                }

            }
            
           public ArrayList getMessages()
           {
            ArrayList messageList = new ArrayList();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            String sqlString = "SELECT * FROM messages";
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
            mySqlReader = command.ExecuteReader();
            while(mySqlReader.Read())
            {
                MessageClass m = new MessageClass();
                m.ID = mySqlReader.GetInt32(0);
                m.Message = mySqlReader.GetString(1);
                m.Sender = mySqlReader.GetString(2);
                m.Receiver = mySqlReader.GetString(3);
                m.Seen = mySqlReader.GetBoolean(4);
                messageList.Add(m);
               
            }
            return messageList;
            }

           public bool SawMessage(long ID, MessageClass mess)
            {
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM messages WHERE ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
            mySqlReader = command.ExecuteReader();
            if (mySqlReader.Read())
            {
                mySqlReader.Close();
                sqlString = "UPDATE messages SET message='" + mess.Message + "',sender='" + mess.Sender + "',receiver='" + mess.Receiver + "',seen=" + mess.Seen + " WHERE ID = " + ID.ToString();
                command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);

                command.ExecuteNonQuery();
                return true;
            }
            else return false;

             
            }

           public long saveMessage(MessageClass messageForSending)
                {
                    String sqlString = "INSERT INTO messages(message, sender, receiver, seen) VALUES ('" + messageForSending.Message + "','" + messageForSending.Sender + "','" + messageForSending.Receiver + "'," + messageForSending.Seen + ")";
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
                    command.ExecuteNonQuery();
                    long ID = command.LastInsertedId;
                    return ID;
                }
           
    }
}
