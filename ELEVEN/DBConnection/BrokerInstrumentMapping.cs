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
                DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
                return false;
            }

            // We are ready, now lets cleanup and close our connection:

            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);

            return true;
        }
        private void DisposeConnection(SQLiteConnection sqlite_conn, SQLiteCommand sqlite_cmd, SQLiteDataReader sqlite_datareader)
        {
            sqlite_datareader.Close();
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public List<clsBroker> GetBrokers()
        {
            var listBroker = new List<clsBroker>();
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblBroker";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                var broker = new clsBroker();
                broker.BrokerCode = Convert.ToString(sqlite_datareader["BrokerCode"]);
                broker.BrokerDescription = Convert.ToString(sqlite_datareader["BrokerDescription"]);
                broker.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                listBroker.Add(broker);
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);

            return listBroker;
        }
        public clsBroker GetBroker(int id)
        {
            var broker = new clsBroker();
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblBroker where Id={id}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {

                broker.BrokerCode = Convert.ToString(sqlite_datareader["BrokerCode"]);
                broker.BrokerDescription = Convert.ToString(sqlite_datareader["BrokerDescription"]);
                broker.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
                return broker;
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);

            return broker;
        }
        public clsBroker DeleteBroker(int id)
        {
            var broker = new clsBroker();
            // We use these three SQLite objects:           
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = $"Delete from tblBroker where Id={id}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            var result = sqlite_cmd.ExecuteScalar();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();

            return broker;
        }
        public void UpdateBroker(clsBroker model)
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
            sqlite_cmd.CommandText = $"Update tblBroker set BrokerCode='{model.BrokerCode}',BrokerDescription='{model.BrokerDescription}' where Id={model.Id};";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
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
                DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
                return false;
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
            return true;
        }
        public List<clsInstrument> GetInstruments()
        {
            var listInstrument = new List<clsInstrument>();
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblInstrument";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                var instrument = new clsInstrument();
                instrument.InstrumentCode = Convert.ToString(sqlite_datareader["InstrumentCode"]);
                instrument.InstrumentDescription = Convert.ToString(sqlite_datareader["InstrumentDescription"]);
                instrument.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                listInstrument.Add(instrument);
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
            return listInstrument;
        }

        public clsInstrument GetInstrument(int id)
        {
            var instrument = new clsInstrument();
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblInstrument where id={id}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {

                instrument.InstrumentCode = Convert.ToString(sqlite_datareader["InstrumentCode"]);
                instrument.InstrumentDescription = Convert.ToString(sqlite_datareader["InstrumentDescription"]);
                instrument.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
                return instrument;
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
            return instrument;
        }

        public void DeleteInstrument(int id)
        {
            // We use these three SQLite objects:           
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = $"Delete from tblInstrument where Id={id}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            var result = sqlite_cmd.ExecuteScalar();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();

        }
        public void UpdateInstrument(clsInstrument model)
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
            sqlite_cmd.CommandText = $"Update tblInstrument set InstrumentCode='{model.InstrumentCode}',InstrumentDescription='{model.InstrumentDescription}' where Id={model.Id};";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        #endregion
        #region "Broker Instrument Mapping Table CRUD"

        public void AddBrokerInstrumentMapping(clsBrokerInstrumentMapping model)
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
            sqlite_cmd.CommandText = $"INSERT INTO tblBrokerInstrumentMapping (BrokerId,InstrumentId,BrokerInstrumentCode,FeedPrices,FeedTrades) VALUES ({model.BrokerId},{model.InstrumentId},'{model.BrokerInstrumentCode}','{model.FeedPrices}','{model.FeedTrades}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public bool CheckDuplicateMapping(clsBrokerInstrumentMapping model)
        {
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT Id FROM tblBrokerInstrumentMapping where BrokerId={model.BrokerId} and InstrumentId={model.InstrumentId}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns false if there is still a result line to read
            {
                DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
                return false;
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
            return true;
        }

        public List<clsBrokerInstrumentDetail> SearchBrokerInstrumentCode()
        {
            List<clsBrokerInstrumentDetail> listDetail = new List<clsBrokerInstrumentDetail>();
            // We use these three SQLite objects:           
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblBrokerInstrumentMapping where FeedPrices='True' and FeedTrades='True'";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                clsBrokerInstrumentDetail model = new clsBrokerInstrumentDetail();
                model.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                model.InstrumentId = Convert.ToInt32(sqlite_datareader["InstrumentId"]);
                model.BrokerId = Convert.ToInt32(sqlite_datareader["BrokerId"]);
                model.BrokerInstrumentCode = Convert.ToString(sqlite_datareader["BrokerInstrumentCode"]);

                var broker = GetBroker(model.BrokerId);
                model.BrokerCode = broker.BrokerCode;
                model.BrokerDescription = broker.BrokerDescription;

                var instrument = GetInstrument(model.InstrumentId);
                model.InstrumentCode = instrument.InstrumentCode;
                model.InstrumentDescription = instrument.InstrumentDescription;

                listDetail.Add(model);
            }

            // We are ready, now lets cleanup and close our connection:
            DisposeConnection(sqlite_conn, sqlite_cmd, sqlite_datareader);
            return listDetail;
        }

        public clsBroker DeleteMapping(int id)
        {
            var broker = new clsBroker();
            // We use these three SQLite objects:           
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = $"Delete from tblBrokerInstrumentMapping where Id={id}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            var result = sqlite_cmd.ExecuteScalar();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();

            return broker;
        }
        public void UpdateMapping(clsBrokerInstrumentMapping model)
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
            sqlite_cmd.CommandText = $"Update tblBrokerInstrumentMapping set BrokerId={model.BrokerId},InstrumentId={model.InstrumentId},BrokerInstrumentCode='{model.BrokerInstrumentCode}',FeedPrices='{model.FeedPrices}',FeedTrades='{model.FeedTrades}' where Id={model.Id};";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        #endregion
    }
}
