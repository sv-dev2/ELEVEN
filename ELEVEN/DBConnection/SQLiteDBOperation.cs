using ELEVEN.Model;
using ELEVEN.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEVEN.DBConnection
{
    public class SQLiteDBOperation
    {
        public static void RemoveWorkspace(int workSpaceid)
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
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = $"DELETE FROM tblWorkspace where Id={workSpaceid}";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            TruncatePreviousLocation(workSpaceid);
        }
        public static void TruncatePreviousLocation(int workSpaceid)
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
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = $"DELETE FROM tblFormLocation where WorkspaceId={workSpaceid}";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public static void AddFormsLocation(LocationModel model)
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
            sqlite_cmd.CommandText = $"INSERT INTO tblFormLocation (formName,SizeX,SizeY,LocationX,LocationY,WindowState,formUniqueName,WorkspaceId,formTitle) VALUES ('{model.formName}',{model.SizeX},{model.SizeY},{model.LocationX},{model.LocationY},'{model.WindowState}','{model.formUniqueName}',{model.WorkspaceId},'{model.formTitle}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public static List<LocationModel> ReteriveFormLocation(int workSpaceId)
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblFormLocation where WorkspaceId={workSpaceId}";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine( sqlite_datareader["text"] );
                LocationModel model = new LocationModel();
                model.formName = Convert.ToString(sqlite_datareader["formName"]);
                model.SizeX = Convert.ToInt32(sqlite_datareader["SizeX"]);
                model.SizeY = Convert.ToInt32(sqlite_datareader["SizeY"]);
                model.LocationX = Convert.ToInt32(sqlite_datareader["LocationX"]);
                model.LocationY = Convert.ToInt32(sqlite_datareader["LocationY"]);
                model.WindowState = Convert.ToString(sqlite_datareader["WindowState"]);
                model.formUniqueName = Convert.ToString(sqlite_datareader["formUniqueName"]);
                model.formTitle = Convert.ToString(sqlite_datareader["formTitle"]);
                modelList.Add(model);
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return modelList;
        }

        public static int AddWorkspace(string name)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            // create a new database connection:

            sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // Lets insert something into our new table:
            sqlite_cmd.CommandText = $"INSERT INTO tblWorkspace (WorkspaceName) VALUES ('{name}');SELECT last_insert_rowid()";
            // And execute this again ;D
            int lastID = Convert.ToInt32(sqlite_cmd.ExecuteScalar());
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return lastID;
        }

        public static List<WorkspaceModel> ReteriveWorkspace()
        {
            // We use these three SQLite objects:
            List<WorkspaceModel> modelList = new List<WorkspaceModel>();
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
            sqlite_cmd.CommandText = "SELECT * FROM tblWorkspace";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine( sqlite_datareader["text"] );
                WorkspaceModel model = new WorkspaceModel();
                model.Id = Convert.ToInt32(sqlite_datareader["Id"]);
                model.WorkspaceName = Convert.ToString(sqlite_datareader["WorkspaceName"]);

                modelList.Add(model);
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return modelList;
        }
        public static bool DuplicateWorkspace(string name)
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
            sqlite_cmd.CommandText = $"SELECT Id FROM tblWorkspace where WorkspaceName='{name}' COLLATE NOCASE";
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
        public static void SaveZoomList(ChartZoomOut model, string formName)
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
            sqlite_cmd.CommandText = $"INSERT INTO tblChartZoomPoints (formUniqueName,[Index],PosXStart,PosXFinish,PosYStart,PosYFinish) VALUES ('{formName}',{model.Index},{model.PosXStart},{model.PosXFinish},{model.PosYStart},{model.PosYFinish});";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public static void SaveAnnotation(string annotation, string formName)
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
            sqlite_cmd.CommandText = $"INSERT INTO tblAnnotation (formUniqueName,AnnotationText) VALUES ('{formName}','{annotation}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public static List<ChartZoomOut> ReteriveChartZoomList(string formName)
        {
            // We use these three SQLite objects:
            List<ChartZoomOut> modelList = new List<ChartZoomOut>();
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblChartZoomPoints where formUniqueName='{formName}'";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                //System.Console.WriteLine( sqlite_datareader["text"] );
                ChartZoomOut model = new ChartZoomOut();
                model.Index = Convert.ToInt32(sqlite_datareader["Id"]);
                model.PosXFinish = Convert.ToDouble(sqlite_datareader["PosXFinish"]);
                model.PosXStart = Convert.ToDouble(sqlite_datareader["PosXStart"]);
                model.PosYFinish = Convert.ToDouble(sqlite_datareader["PosYFinish"]);
                model.PosYStart = Convert.ToDouble(sqlite_datareader["PosYStart"]);

                modelList.Add(model);
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return modelList;
        }

        public static List<string> ReteriveChartAnnotations(string formName)
        {
            // We use these three SQLite objects:
            List<string> modelList = new List<string>();
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblAnnotation where formUniqueName='{formName}'";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                modelList.Add(Convert.ToString(sqlite_datareader["AnnotationText"]));
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return modelList;
        }

        public static void DeleteZoomList(string formName)
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
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = $"DELETE FROM tblChartZoomPoints where formUniqueName='{formName}'";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }

        public static void DeleteAnnotation(string formName)
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
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = $"DELETE FROM tblAnnotation where formUniqueName='{formName}'";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
        public static FormState ReteriveFormToolState(string formName)
        {
            // We use these three SQLite objects:
            FormState model = null;
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
            sqlite_cmd.CommandText = $"SELECT * FROM tblFormState where formUniqueName='{formName}'";
            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                model = new FormState();
                model.FormUniqueName = Convert.ToString(sqlite_datareader["FormUniqueName"]);
                model.LockState = Convert.ToInt32(sqlite_datareader["LockState"]);
                model.VisibleState = Convert.ToInt32(sqlite_datareader["VisibleState"]);
                model.TimeFrame = Convert.ToString(sqlite_datareader["timeFrame"]);
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
            return model;
        }

        public static void SaveFormToolState(FormState model)
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
            sqlite_cmd.CommandText = $"INSERT INTO tblFormState (FormUniqueName,LockState,VisibleState,timeFrame) VALUES ('{model.FormUniqueName}',{model.LockState},{model.VisibleState},'{model.TimeFrame}');";
            // And execute this again ;D
            sqlite_cmd.ExecuteNonQuery();
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }

        public static void DeleteFormToolState(string formName)
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
            // Let the SQLiteCommand object know our SQL-Query:
            sqlite_cmd.CommandText = $"DELETE FROM tblFormState where formUniqueName='{formName}'";
            // Now lets execute the SQL ;D
            sqlite_cmd.ExecuteNonQuery();

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
            sqlite_conn.Dispose();
            sqlite_cmd.Dispose();
        }
    }
}
