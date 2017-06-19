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
                //Az adatbázis kapcsolatot ugyanúgy inicializálod mint a "UserPer" osztályban. Miért nem csinálsz egy ősosztályt?
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

            //Kikommentezett függvényeket ne hagyj a kódban!

            //public MessageClass getMessage(long ID)
            //{
            //    MessageClass m = new MessageClass();
            //    MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

            //    String sqlString = "SELECT * FROM messages WHERE ID = "+ ID.ToString();
            //    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
            //    mySqlReader = command.ExecuteReader();
            //    if (mySqlReader.Read())
            //    {
     
            //        m.ID = mySqlReader.GetInt32(0);
            //        m.Message = mySqlReader.GetString(1);
            //        m.Sender = mySqlReader.GetString(2);
            //        m.Receiver = mySqlReader.GetString(3);
            //        m.Seen = mySqlReader.GetBoolean(4);
            //        return m;

            //    } else return null;
               
            //}



        //A userSID-ből már tudod, hogy ki kéri le az üzeneteket, így a "user" paraméter fölösleges. Nem is biztonságos, mivel így bárki üzeneteit lekérheti!
        public ArrayList getMessages(string userSID, string user, string user2)
           {
            ArrayList messageList = new ArrayList();
            if (SIDauth(userSID))
            {
                //Az elején ha beírod hogy "using MySql.Data.MySqlClient;", akkor nem kell mindig újra beírni.
                MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;

                String sqlString = "SELECT * FROM messages WHERE (sender = "+user+" AND receiver = "+user2+ ") OR (sender = " + user2 + " AND receiver = " + user + ")";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
                mySqlReader = command.ExecuteReader();
                while (mySqlReader.Read())
                {
                    MessageClass m = new MessageClass();
                    m.ID = mySqlReader.GetInt32(0);
                    m.Message = mySqlReader.GetString(1);
                    m.Sender = mySqlReader.GetString(2);
                    m.Receiver = mySqlReader.GetString(3);
                    m.Seen = mySqlReader.GetBoolean(4);
                    messageList.Add(m);
                }
            }
            return messageList;
        }

        //Mire való a "mess" paraméter? Ahogy látom a "mess.Seen" mindig true.
        public bool SawMessage(long ID, string userSID, MessageClass mess)
        {
            if (SIDauth(userSID))
            {
                {
                    MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
                    //Ez a SELECT fölösleges.
                    String sqlString = "SELECT * FROM messages WHERE ID = " + ID.ToString();
                    MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
                    mySqlReader = command.ExecuteReader();
                    if (mySqlReader.Read())
                    {
                        mySqlReader.Close();
                        sqlString = "UPDATE messages SET seen= " + mess.Seen + " WHERE ID = " + ID.ToString();
                        command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);

                        command.ExecuteNonQuery();
                        return true;
                    }
                    else return false;
                }

            }
            else return false;
        }

           //Ha a küldőt a SID-ből állaípítanád meg akkor kiküszöbölhetnéd, hogy más nevében lehessen üzenetet küldeni.
           public long saveMessage(String SID,MessageClass messageForSending)
                {
            long ID = 0;
            if (SIDauth(SID))
            {
                String sqlString = "INSERT INTO messages(message, sender, receiver, seen) VALUES ('" + messageForSending.Message + "','" + messageForSending.Sender + "','" + messageForSending.Receiver + "'," + messageForSending.Seen + ")";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
                command.ExecuteNonQuery();
                ID = command.LastInsertedId;
                
            }
            return ID;
                }

        //Ez ugyanaz mint a UserPer.SIDAuth. Miért nem csinálsz egy ősosztályt?
        public bool SIDauth(string SID)
        {
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            String sqlString = "SELECT * FROM userstable WHERE SID = " + SID;
            MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sqlString, connection2);
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
