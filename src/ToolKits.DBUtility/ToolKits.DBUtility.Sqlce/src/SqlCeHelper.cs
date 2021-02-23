//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：SqlCeHelper.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014年2月26日11时40分
// 创建人员：宋杰军
// 负责人员：宋杰军
// 参与人员：宋杰军
// ========================================================================
// 修改日期：
// 修改人员：
// 修改内容：
// ========================================================================
using System;
using System.Data;
using System.Data.SqlServerCe;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// The SqlCeHelper class is intended to encapsulate high performance, scalable best practices for 
    /// common uses of SqlCe.
    /// </summary>
    public sealed class SqlCeHelper
    {

        #region private utility methods & constructors

        /// <summary>
        /// Since this class provides only static methods, make the default constructor private to prevent 
        /// instances from being created with "new SqlCeHelper()".
        /// </summary>
        private SqlCeHelper() { }
        /// <summary>
        /// This method is used to attach array of SqlCeParameter to a SqlCeCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of SqlCeParameter to be added to command</param>
        private static void AttachParameters(SqlCeCommand command, SqlCeParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlCeParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) && (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command.
        /// </summary>
        /// <param name="command">The SqlCeCommand to be prepared</param>
        /// <param name="connection">A valid SqlCeConnection, on which to execute this command</param>
        /// <param name="transaction">A valid SqlCeTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand(SqlCeCommand command, SqlCeConnection connection, SqlCeTransaction transaction, CommandType commandType, string commandText, SqlCeParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }
            // Associate the connection with the command
            command.Connection = connection;
            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;
            // If we were provided a transaction, assign it.
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }
            // Set the command type
            command.CommandType = commandType;
            // Attach the command parameters if they are provided
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.Text, "PublishOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, string commandText)
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(connectionString, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.Text, "PublishOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(connectionString, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.Text, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, string commandText, params SqlCeParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, commandText, commandParameters);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.Text, "PublishOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // Create & open a SqlCeConnection, and dispose of it after we are done.
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset) against the specified SqlCeConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(conn, CommandType.Text, "PublishOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlCeConnection connection, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (SqlCeTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
            // Finally, execute the command.
            int retval = cmd.ExecuteNonQuery();
            // Detach the SqlParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            if (mustCloseConnection)
            {
                connection.Close();
            }
            return retval;
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.Text, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlCeTransaction transaction, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteNonQuery(transaction, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.Text, "PublishOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlCeTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteNonQuery(transaction, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns no resultset) against the specified SqlCeTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(trans, CommandType.Text, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(SqlCeTransaction transaction, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection as SqlCeConnection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            // Finally, execute the command.
            int retval = cmd.ExecuteNonQuery();
            // Detach the SqlCeParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion

        #region ExecuteDataSet

        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteDataset(connectionString, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteDataset(connectionString, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, params SqlCeParameter[] commandParameters)
        {
            return ExecuteDataset(connectionString, CommandType.Text, commandText, commandParameters);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // Create & open a SqlCeConnection, and dispose of it after we are done.
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                return ExecuteDataset(connection, commandType, commandText, commandParameters);
            }
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the specified SqlCeConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParameter used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(SqlCeConnection connection, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (SqlCeTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
            // Create the DataAdapter & DataSet
            using (SqlCeDataAdapter da = new SqlCeDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                // Fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds);
                // Detach the SqlCeParameters from the command object, so they can be used again.			
                cmd.Parameters.Clear();
                if (mustCloseConnection)
                {
                    connection.Close();
                }
                // Return the dataset
                return ds;
            }
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.Text, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(SqlCeTransaction transaction, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteDataset(transaction, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.Text, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(SqlCeTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteDataset(transaction, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the specified SqlCeTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.Text, "GetOrders", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(SqlCeTransaction transaction, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection as SqlCeConnection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            // Create the DataAdapter & DataSet
            using (SqlCeDataAdapter da = new SqlCeDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                // Fill the DataSet using default values for DataTable names, etc.
                da.Fill(ds);
                // Detach the SqlCeParameters from the command object, so they can be used again.
                cmd.Parameters.Clear();
                // Return the dataset
                return ds;
            }
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// This enum is used to indicate whether the connection was provided by the caller, or created by SqlCeHelper, so that
        /// we can set the appropriate CommandBehavior when calling ExecuteReader()
        /// </summary>
        private enum SqlCeConnectionOwnership
        {
            /// <summary>Connection is owned and managed by SqlCeHelper</summary>
            Internal,
            /// <summary>Connection is owned and managed by the caller</summary>
            External
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCeDataReader dr = ExecuteReader(connString, CommandType.Text, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(string connectionString, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteReader(connectionString, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCeDataReader dr = ExecuteReader(connString, CommandType.Text, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteReader(connectionString, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCeDataReader dr = ExecuteReader(connString, CommandType.Test, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(string connectionString, string commandText, params SqlCeParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, CommandType.Text, commandText, commandParameters);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCeDataReader dr = ExecuteReader(connString, CommandType.Test, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            SqlCeConnection connection = null;
            try
            {
                // Create & open a SqlConnection
                connection = new SqlCeConnection(connectionString);
                connection.Open();
                // Call the private overload that takes an internally owned connection in place of the connection string
                return ExecuteReader(connection, null, commandType, commandText, commandParameters, SqlCeConnectionOwnership.Internal);
            }
            catch
            {
                // If we fail to return the SqlCeDatReader, we need to close the connection ourselves
                if (connection != null)
                {
                    connection.Close();
                }
                throw;
            }
        }
        /// <summary>
        /// Create and prepare a SqlCeCommand, and call ExecuteReader with the appropriate CommandBehavior.
        /// </summary>
        /// <remarks>
        /// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
        /// 
        /// If the caller provided the connection, we want to leave it to them to manage.
        /// </remarks>
        /// <param name="connection">A valid SqlCeConnection, on which to execute this command</param>
        /// <param name="transaction">A valid SqlCeTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="connectionOwnership">Indicates whether the connection parameter was provided by the caller, or created by SqlCeHelper</param>
        /// <returns>SqlCeDataReader containing the results of the command</returns>
        private static SqlCeDataReader ExecuteReader(SqlCeConnection connection, SqlCeTransaction transaction, CommandType commandType, string commandText, SqlCeParameter[] commandParameters, SqlCeConnectionOwnership connectionOwnership)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            bool mustCloseConnection = false;
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
                // Create a reader
                SqlCeDataReader dataReader;
                // Call ExecuteReader with the appropriate CommandBehavior
                if (connectionOwnership == SqlCeConnectionOwnership.External)
                {
                    dataReader = cmd.ExecuteReader();
                }
                else
                {
                    dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                // Detach the SqlCeParameters from the command object, so they can be used again.
                // HACK: There is a problem here, the output parameter values are fletched 
                // when the reader is closed, so if the parameters are detached from the command
                // then the SqlCeReader cant set its values. 
                // When this happen, the parameters cant be used again in other command.
                bool canClear = true;
                foreach (SqlCeParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                        canClear = false;
                }
                if (canClear)
                {
                    cmd.Parameters.Clear();
                }
                return dataReader;
            }
            catch
            {
                if (mustCloseConnection)
                {
                    connection.Close();
                }
                throw;
            }
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlCeDataReader dr = ExecuteReader(trans, CommandType.Text, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(SqlCeTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteReader(transaction, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a resultset) against the specified SqlCeTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///   SqlCeDataReader dr = ExecuteReader(trans, CommandType.Text, "GetOrders", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>A SqlCeDataReader containing the resultset generated by the command</returns>
        public static SqlCeDataReader ExecuteReader(SqlCeTransaction transaction, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            // Pass through to private overload, indicating that the connection is owned by the caller
            return ExecuteReader(transaction.Connection as SqlCeConnection, transaction, commandType, commandText, commandParameters, SqlCeConnectionOwnership.External);
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.Text, "GetOrderCount");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(string connectionString, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteScalar(connectionString, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.Text, "GetOrderCount");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteScalar(connectionString, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.Text, "GetOrderCount", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(string connectionString, string commandText, params SqlCeParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, CommandType.Text, commandText, commandParameters);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(connString, CommandType.Text, "GetOrderCount", new SqlParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // Create & open a SqlCeConnection, and dispose of it after we are done.
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset) against the specified SqlCeConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(conn, CommandType.Text, "GetOrderCount", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid SqlCeConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlCeConnection connection, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (SqlCeTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();
            // Detach the SqlCeParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            if (mustCloseConnection)
            {
                connection.Close();
            }
            return retval;
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.Text, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlCeTransaction transaction, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteScalar(transaction, CommandType.Text, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset and takes no parameters) against the provided SqlCeTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.Text, "GetOrderCount");
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlCeTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlCeParameters
            return ExecuteScalar(transaction, commandType, commandText, (SqlCeParameter[])null);
        }
        /// <summary>
        /// Execute a SqlCeCommand (that returns a 1x1 resultset) against the specified SqlCeTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int orderCount = (int)ExecuteScalar(trans, CommandType.Text, "GetOrderCount", new SqlCeParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid SqlCeTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlCeParamters used to execute the command</param>
        /// <returns>An object containing the value in the 1x1 resultset generated by the command</returns>
        public static object ExecuteScalar(SqlCeTransaction transaction, CommandType commandType, string commandText, params SqlCeParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            // Create a command and prepare it for execution
            SqlCeCommand cmd = new SqlCeCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection as SqlCeConnection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            // Execute the command & return the results
            object retval = cmd.ExecuteScalar();
            // Detach the SqlCeParameters from the command object, so they can be used again.
            cmd.Parameters.Clear();
            return retval;
        }

        #endregion

        #region 判断数据表是否存在

        /// <summary>
        /// 判断数据表是否存在
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tableName">表名称</param>
        /// <returns>true / false</returns>
        public bool ExistsOfTable(string connectionString, string tableName)
        {
            string cmdSql = string.Format("select count(-1) from information_schema.tables where table_name='{0}'", tableName);
            string strVal = ExecuteScalar(connectionString, tableName).ToString();
            int tmpVal = 0; ;
            int.TryParse(strVal, out tmpVal);
            return tmpVal > 0 ? true : false;
        }

        #endregion

        #region 判断数据字段是否存在

        /// <summary>
        /// 判断数据字段是否存在
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="tableName">表名称</param>
        /// <param name="columnName">列名称</param>
        /// <returns>true / false</returns>
        public static bool ExistsOfColumn(string connectionString, string tableName, string columnName)
        {
            string cmdSql = string.Format("select count(-1) from information_schema.columns where table_name='{0}' and column_name='{1}'", tableName, columnName);
            string strVal = ExecuteScalar(connectionString, cmdSql).ToString();
            int tmpVal = 0;
            int.TryParse(strVal, out tmpVal);
            return tmpVal > 0 ? true : false;
        }

        #endregion

    }
}
