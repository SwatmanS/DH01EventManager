using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace DH01EventManager
{
    internal class DBConnection
    {
        private SQLiteConnection? m_sqliteConnection;
        public Boolean dbConnect(string filename)
        {

            try
            {
                //if (!File.Exists(filename)) { throw new Exception($"No Such File : {filename}"); };
                m_sqliteConnection = new SQLiteConnection($"Data Source={filename};foreign_keys=true;");
                m_sqliteConnection.Open();
                Debug.WriteLine("Connected");
                return true;
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine($"SQLite Could not connect to {filename}.");
                Debug.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception in DBConnction::Connect().");
                Debug.WriteLine(ex.Message);
                return false;
            }
        }// dbConnect 
        public void dbDisconnect()
        {
            if (m_sqliteConnection != null)
            {
                m_sqliteConnection.Close();
                m_sqliteConnection = null;
            }
        }// dbDisconnect
        public bool dbConnected()
        {
            if (m_sqliteConnection != null)
            {
                return m_sqliteConnection is SQLiteConnection;
            }
            return false;
        } // dbConnected
        public bool runSQL(string sql)
        {
            if (m_sqliteConnection != null)
            {
                try
                {
                    SQLiteCommand SQLcommand = m_sqliteConnection.CreateCommand();
                    SQLcommand.CommandText = sql;
                    SQLcommand.ExecuteNonQuery();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    Debug.WriteLine($"SQLite Could not run query: {sql}.");
                    Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                Debug.WriteLine($"Can't run '{sql}'. You need to connect to a database first.");
                return false;
            }
        }// runSQL
        public SQLiteDataReader? querySQL(string sql)
        {
            SQLiteDataReader? dataReader = null;

            if (m_sqliteConnection != null)
            {


                try
                {
                    SQLiteCommand SQLcommand = m_sqliteConnection.CreateCommand();
                    SQLcommand.CommandText = sql;
                    dataReader = SQLcommand.ExecuteReader();
                }
                catch (SQLiteException ex)
                {
                    Debug.WriteLine($"SQLite Could not run query: {sql}.");
                    Debug.WriteLine(ex.Message);
                }
            }
            else
            {
                Debug.WriteLine($"Can't run '{sql}'. You need to connect to a database first.");
            }

            return dataReader;
        }// querySQL


    }//DBConnection

}
