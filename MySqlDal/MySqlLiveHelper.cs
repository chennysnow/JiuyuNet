using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace MySqlDal
{
    public sealed class MySqlLiveHelper
    {
        public MySqlLiveHelper()
        {
        }

        #region ExecuteNonQuery

        public static int ExecuteNonQuery(MySqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteNonQuery(connection, commandType, commandText, (MySqlParameter[])null);
        }
        public static int ExecuteNonQuery(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            if (commandParameters != null)
                cmd.Parameters.AddRange(commandParameters);
            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Dispose();
            connection.Close();
            return result;
        }

        #endregion

        #region ExecuteDataSet

        public static DataSet ExecuteDataset(MySqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteDataset(connection, commandType, commandText, (MySqlParameter[])null);
        }

        public static DataSet ExecuteDataset(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (commandParameters != null)
                cmd.Parameters.AddRange(commandParameters);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Dispose();
            connection.Close();
            return ds;
        }

        #endregion

        #region ExecuteDataReader

        public static MySqlDataReader ExecuteReader(MySqlConnection connection, CommandType commandType, string commandText)
        {
            return ExecuteReader(connection, commandType, commandText, (MySqlParameter[])null);
        }
        public static MySqlDataReader ExecuteReader(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (connection.State != ConnectionState.Open)
                connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;

            if (commandParameters != null)
                cmd.Parameters.AddRange(commandParameters);
            MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Dispose();
            return dr;
        }


        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for the update</param>
        /// <param name="commandText">Command text to use for the update</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string connectionString, string commandText)
        {
            //pass through the call providing null for the set of MySqlParameters
            return ExecuteScalar(connectionString, commandText, (MySqlParameter[])null);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connectionString">Settings to use for the command</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(string connectionString, string commandText, params MySqlParameter[] commandParameters)
        {
            //create & open a SqlConnection, and dispose of it after we are done.
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                cn.Open();

                //call the overload that takes a connection in place of the connection string
                return ExecuteScalar(cn, commandText, commandParameters);
            }
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(MySqlConnection connection, string commandText)
        {
            //pass through the call providing null for the set of MySqlParameters
            return ExecuteScalar(connection, commandText, (MySqlParameter[])null);
        }

        /// <summary>
        /// Execute a single command against a MySQL database.
        /// </summary>
        /// <param name="connection"><see cref="MySqlConnection"/> object to use</param>
        /// <param name="commandText">Command text to use for the command</param>
        /// <param name="commandParameters">Parameters to use for the command</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public static object ExecuteScalar(MySqlConnection connection, string commandText, params MySqlParameter[] commandParameters)
        {
            //create a command and prepare it for execution
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.Text;

            if (commandParameters != null)
                foreach (MySqlParameter p in commandParameters)
                    cmd.Parameters.Add(p);

            //execute the command & return the results
            object retval = cmd.ExecuteScalar();

            // detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;

        }

        #endregion


    }
}