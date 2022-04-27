#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.SqlClient;

#endregion


namespace Helpers
{
    public class DbConnect
    {
        private SqlConnection _connection;
        private string _database;
        private string _password;
        private string _port;
        private string _server;
        private string _uid;

        //Constructor
        public DbConnect(string server, string port, string database, string uid, string password)
        {
            Initialize(server, port, database, uid, password);
        }

        //Initialize values
        private void Initialize(string server, string port, string database, string uid, string password)
        {
            //server = "127.0.0.1";
            _server = server;
            _port = port; //3306
            // database = "avafinScraper";
            _database = database;
            //uid = "root";
            _uid = uid;

            //password = "";
            _password = password;
            string connectionString = "SERVER=" + _server + ";" + "Port=" + _port + ";" + "DATABASE=" + _database + ";" +
                                      "UID=" + _uid + ";" + "PASSWORD=" + _password + ";";

            _connection = new SqlConnection(connectionString);
        }


        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if (_connection != null && _connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                    return true;
                }
                return false;
                    
            }
            catch (SqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Log.WriteLog(ex);
                switch (ex.Number)
                {
                    case 0:
                        Log.WriteLog("Cannot connect to server.  Contact administrator");
                        Log.WriteLog(ex);
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Log.WriteLog("Invalid username/password, please try again");
                        Log.WriteLog(ex);
                        // MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                Log.WriteLog(ex);
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public bool Insert(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            if (OpenConnection())
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    SqlCommand cmd = new SqlCommand(query, _connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    CloseConnection();
                    return true;
                }
                catch (SqlException ex)
                {
                    Log.WriteLog(ex);
                    //MessageBox.Show(ex.Message);
                    return false;
                }

            }
            return false;
        }

        //Update statement
        public void Update()
        {
            const string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (OpenConnection())
            {
                //create  command
                SqlCommand cmd = new SqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = _connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            if (OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }


        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (OpenConnection())
            {
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }


        /// <summary>
        /// 	Gets the value.
        /// </summary>
        /// <param name="query"> The query. </param>
        /// <param name="displayMember"> The display member. </param>
        /// <param name="connectionstring"> The connectionstring. </param>
        /// <param name="values"> The values. </param>
        /// <returns> </returns>
        public static bool GetValue(string query, string displayMember, string connectionstring, out List<string> values)
        {
            if (String.IsNullOrEmpty(connectionstring))
            {
                values = null;
                return false;
            }
            values = new List<string>();
            using (var cn = new SqlConnection(connectionstring))
            {
                try
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(query, cn);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    values.Add(string.Empty);
                    while (dataReader.Read())
                    {
                        values.Add((string) dataReader[displayMember]);
                    }
                    cn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex);
                    return false;
                }
            }
            return false;
        }



        public static bool GetValue(string query, string displayMember1, string displayMember2, string connectionstring,
                                    out List<string> values)
        {
            values = new List<string>();
            using (var cn = new SqlConnection(connectionstring))
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    values.Add(string.Empty);
                    while (dataReader.Read())
                    {
                        values.Add((string) dataReader[displayMember1] + " => " + (double) dataReader[displayMember2]);
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex);
                    return true;
                }
            }
            return false;
        }


        public static bool GetSingleValue(string query, string displayMember, string message, string connectionstring,
                                          out List<string> values)
        {
            values = new List<string>();
            using (var cn = new SqlConnection(connectionstring))
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    values.Add(string.Empty);
                    while (dataReader.Read())
                    {
                        values.Add((message + " => " + (double) dataReader[displayMember]));
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex);
                    return true;
                }
            }
            return false;
        }


        public static bool GetValue(string query, string displayMember1, string displayMember2, string displayMember3,
                                    string displayMember4, string connectionstring, out List<string> values)
        {
            values = new List<string>();
            using (var cn = new SqlConnection(connectionstring))
            {
                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand(query, cn);
                    //Create a data reader and Execute the command
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    values.Add(string.Empty);
                    while (dataReader.Read())
                    {
                        string value1 = (string) dataReader[displayMember1];
                        double value2 = (float) dataReader[displayMember2];
                        string value3 = (string) dataReader[displayMember3];
                        string value4 = (string) dataReader[displayMember4];

                        values.Add(value1 + " // " + value2 + " // " + value3 + " // " + value4);
                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Log.WriteLog(ex);
                    return true;
                }
            }
            return false;
        }


        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (OpenConnection())
            {
                //Create Command
                SqlCommand cmd = new SqlCommand(query, _connection);
                //Create a data reader and Execute the command
                SqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (OpenConnection())
            {
                //Create  Command
                SqlCommand cmd = new SqlCommand(query, _connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime time = DateTime.Now;
                int year = time.Year;
                int month = time.Month;
                int day = time.Day;
                int hour = time.Hour;
                int minute = time.Minute;
                int second = time.Second;
                int millisecond = time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" +
                              millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "sqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", _uid, _password, _server, _database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                Log.WriteLog(ex);
                //MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\SqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "sql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", _uid, _password, _server, _database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                Log.WriteLog(ex);
                //MessageBox.Show("Error , unable to Restore!");
                Log.WriteLog("Error , unable to Restore!");
            }
        }
    }
}