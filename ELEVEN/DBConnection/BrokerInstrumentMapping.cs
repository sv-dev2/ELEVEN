using ELEVEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.DBConnection
{
    public class BrokerInstrumentMapping
    {
        #region "Broker Table CRUD"
        public void AddBroker(clsBroker model)
        {
            // We use these three SQLite objects:

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // create a new database connection:

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = $"INSERT INTO tblBroker (BrokerCode,BrokerDescription) VALUES ('{model.BrokerCode}','{model.BrokerDescription}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public bool CheckDuplicateBroker(clsBroker model)
        {
            // We use these three SQLite objects:
            List<LocationModel> modelList = new List<LocationModel>();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = $"SELECT Id FROM tblBroker where BrokerCode='{model.BrokerCode}' COLLATE NOCASE";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                return false;
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return true;
        }
        #endregion
        #region "Instrument table CRUD"
        public void AddInstrument(clsInstrument model)
        {
            // We use these three SQLite objects:

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // create a new database connection:

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = $"INSERT INTO tblInstrument (InstrumentCode,InstrumentDescription) VALUES ('{model.InstrumentCode}','{model.InstrumentDescription}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public bool CheckDuplicateInstrument(clsInstrument model)
        {
            // We use these three SQLite objects:
            List<LocationModel> modelList = new List<LocationModel>();
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            // create a new database connection:

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = $"SELECT Id FROM tblInstrument where InstrumentCode='{model.InstrumentCode}' COLLATE NOCASE";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                return false;
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return true;
        }
        #endregion
        #region "Broker Instrument Mapping Table CRUD"

        #endregion
    }
}
