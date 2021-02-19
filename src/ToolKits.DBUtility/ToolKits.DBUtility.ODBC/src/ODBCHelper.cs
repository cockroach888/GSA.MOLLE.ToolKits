//=========================================================================
//**   魂哥常用工具集（GSA.MOLLE.ToolKits）
//=========================================================================
//**   脉脉含情的充满精神的高尚的小强精神
//**   风幽思静繁花落；夜半楼台听江雨。（cockroach888@outlook.com）
//=========================================================================
//**   Copyright © 蟑螂·魂 2014 -- Support 文雀
//=========================================================================
// 文件名称：ODBCHelper.cs
// 项目名称：数据库操作实用工具集
// 创建时间：2014年2月26日14时40分
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
using System.Data.Odbc;
using System.Collections;

namespace GSA.ToolKits.DBUtility
{
    /// <summary>
    /// ODBC数据操作辅助类
    /// </summary>
    public sealed class ODBCHelper
    {

        #region private utility methods & constructors

        private ODBCHelper() { }

        /// <summary>
        /// This method is used to attach array of OdbcParameters to a OdbcCommand.
        /// 
        /// This method will assign a value of DbNull to any parameter with a direction of
        /// InputOutput and a value of null.  
        /// 
        /// This behavior will prevent default values from being used, but
        /// this will be the less common case than an intended pure output parameter (derived as InputOutput)
        /// where the user provided no input value.
        /// </summary>
        /// <param name="command">The command to which the parameters will be added</param>
        /// <param name="commandParameters">An array of OdbcParameters to be added to command</param>
        private static void AttachParameters(OdbcCommand command, OdbcParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (OdbcParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // Check for derived output value with no value assigned
                        if ((p.Direction == ParameterDirection.InputOutput ||
                            p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        /// <summary>
        /// This method assigns dataRow column values to an array of OdbcParameters
        /// </summary>
        /// <param name="commandParameters">Array of OdbcParameters to be assigned values</param>
        /// <param name="dataRow">The dataRow used to hold the stored procedure's parameter values</param>
        private static void AssignParameterValues(OdbcParameter[] commandParameters, DataRow dataRow)
        {
            if ((commandParameters == null) || (dataRow == null))
            {
                // Do nothing if we get no data
                return;
            }
            int i = 0;
            // Set the parameters values
            foreach (OdbcParameter commandParameter in commandParameters)
            {
                // Check the parameter name
                if (commandParameter.ParameterName == null ||
                    commandParameter.ParameterName.Length <= 1)
                {
                    throw new Exception(
                           string.Format(
                               "Please provide a valid parameter name on the parameter #{0}, the ParameterName property has the following value: '{1}'.",
                               i, commandParameter.ParameterName));
                }
                if (dataRow.Table.Columns.IndexOf(commandParameter.ParameterName.Substring(1)) != -1)
                {
                    commandParameter.Value = dataRow[commandParameter.ParameterName.Substring(1)];
                }
                i++;
            }
        }
        /// <summary>
        /// This method assigns an array of values to an array of OdbcParameters
        /// </summary>
        /// <param name="commandParameters">Array of OdbcParameters to be assigned values</param>
        /// <param name="parameterValues">Array of objects holding the values to be assigned</param>
        private static void AssignParameterValues(OdbcParameter[] commandParameters, object[] parameterValues)
        {
            if ((commandParameters == null) || (parameterValues == null))
            {
                // Do nothing if we get no data
                return;
            }
            // We must have the same number of values as we pave parameters to put them in
            if (commandParameters.Length != parameterValues.Length)
            {
                throw new ArgumentException("Parameter count does not match Parameter Value count.");
            }
            // Iterate through the OdbcParameters, assigning the values from the corresponding position in the 
            // value array
            for (int i = 0, j = commandParameters.Length; i < j; i++)
            {
                // If the current array value derives from IDbDataParameter, then assign its Value property
                if (parameterValues[i] is IDbDataParameter)
                {
                    IDbDataParameter paramInstance = (IDbDataParameter)parameterValues[i];
                    if (paramInstance.Value == null)
                    {
                        commandParameters[i].Value = DBNull.Value;
                    }
                    else
                    {
                        commandParameters[i].Value = paramInstance.Value;
                    }
                }
                else if (parameterValues[i] == null)
                {
                    commandParameters[i].Value = DBNull.Value;
                }
                else
                {
                    commandParameters[i].Value = parameterValues[i];
                }
            }
        }
        /// <summary>
        /// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
        /// to the provided command
        /// </summary>
        /// <param name="command">The OdbcCommand to be prepared</param>
        /// <param name="connection">A valid OdbcConnection, on which to execute this command</param>
        /// <param name="transaction">A valid OdbcTransaction, or 'null'</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of OdbcParameters to be associated with the command or 'null' if no parameters are required</param>
        /// <param name="mustCloseConnection"><c>true</c> if the connection was opened by the method, otherwose is false.</param>
        private static void PrepareCommand(OdbcCommand command, OdbcConnection connection, OdbcTransaction transaction, CommandType commandType, string commandText, OdbcParameter[] commandParameters, out bool mustCloseConnection)
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
            // If we were provided a transaction, assign it
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

        #region ExecuteDataset

        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText)
        {
            return ExecuteDataset(connectionString, CommandType.Text, commandText);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of OdbcParameters
            return ExecuteDataset(connectionString, commandType, commandText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, string commandText, params OdbcParameter[] commandParameters)
        {
            return ExecuteDataset(connectionString, CommandType.Text, commandText, commandParameters);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // Create & open a OdbcConnection, and dispose of it after we are done
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                return ExecuteDataset(connection, commandType, commandText, commandParameters);
            }
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the database specified in 
        /// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OdbcParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, spName);
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(commandParameters, parameterValues);
                // Call the overload that takes an array of OdbcParameters
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the provided OdbcConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcConnection connection, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of OdbcParameters
            return ExecuteDataset(connection, commandType, commandText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the specified OdbcConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcConnection connection, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            // Create a command and prepare it for execution
            OdbcCommand cmd = new OdbcCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, connection, (OdbcTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);
            // Create the DataAdapter & DataSet
            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);
                // Detach the OdbcParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
                if (mustCloseConnection) connection.Close();
                // Return the dataset
                return ds;
            }
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the specified OdbcConnection 
        /// using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcConnection connection, string spName, params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OdbcParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(commandParameters, parameterValues);
                // Call the overload that takes an array of OdbcParameters
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the provided OdbcTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcTransaction transaction, CommandType commandType, string commandText)
        {
            // Pass through the call providing null for the set of OdbcParameters
            return ExecuteDataset(transaction, commandType, commandText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the specified OdbcTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcTransaction transaction, CommandType commandType, string commandText, params OdbcParameter[] commandParameters)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            // Create a command and prepare it for execution
            OdbcCommand cmd = new OdbcCommand();
            bool mustCloseConnection = false;
            PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            // Create the DataAdapter & DataSet
            using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);
                // Detach the OdbcParameters from the command object, so they can be used again
                cmd.Parameters.Clear();
                // Return the dataset
                return ds;
            }
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the specified 
        /// OdbcTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        /// <returns>A dataset containing the resultset generated by the command</returns>
        public static DataSet ExecuteDataset(OdbcTransaction transaction, string spName, params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OdbcParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(commandParameters, parameterValues);
                // Call the overload that takes an array of OdbcParameters
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
            }
        }
        /// <summary>
        ///  Updated By Rickie. Mar, 10, 2004
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="mappingName"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, string mappingName)
        {
            DataSet myDataSet = ExecuteDataset(connectionString, commandType, commandText);
            myDataSet.Tables[0].TableName = mappingName;
            return myDataSet;
        }

        #endregion

        #region FillDataset

        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the database specified in 
        /// the connection string. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)</param>
        public static void FillDataset(string connectionString, CommandType commandType, string commandText, DataSet dataSet, string[] tableNames)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // Create & open a OdbcConnection, and dispose of it after we are done
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                FillDataset(connection, commandType, commandText, dataSet, tableNames);
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        public static void FillDataset(string connectionString, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OdbcParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // Create & open a OdbcConnection, and dispose of it after we are done
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                FillDataset(connection, commandType, commandText, dataSet, tableNames, commandParameters);
            }
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the database specified in 
        /// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  FillDataset(connString, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, 24);
        /// </remarks>
        /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>    
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        public static void FillDataset(string connectionString, string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // Create & open a OdbcConnection, and dispose of it after we are done
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                FillDataset(connection, spName, dataSet, tableNames, parameterValues);
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the provided OdbcConnection. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>    
        public static void FillDataset(OdbcConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames)
        {
            FillDataset(connection, commandType, commandText, dataSet, tableNames, null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the specified OdbcConnection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        public static void FillDataset(OdbcConnection connection, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OdbcParameter[] commandParameters)
        {
            FillDataset(connection, null, commandType, commandText, dataSet, tableNames, commandParameters);
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the specified OdbcConnection 
        /// using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  FillDataset(conn, "GetOrders", ds, new string[] {"orders"}, 24, 36);
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        public static void FillDataset(OdbcConnection connection, string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OdbcParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(connection, spName);
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(commandParameters, parameterValues);
                // Call the overload that takes an array of OdbcParameters
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                FillDataset(connection, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset and takes no parameters) against the provided OdbcTransaction. 
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"});
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        public static void FillDataset(OdbcTransaction transaction, CommandType commandType,
            string commandText,
            DataSet dataSet, string[] tableNames)
        {
            FillDataset(transaction, commandType, commandText, dataSet, tableNames, null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns a resultset) against the specified OdbcTransaction
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        public static void FillDataset(OdbcTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OdbcParameter[] commandParameters)
        {
            FillDataset(transaction.Connection, transaction, commandType, commandText, dataSet, tableNames, commandParameters);
        }
        /// <summary>
        /// Execute a stored procedure via a OdbcCommand (that returns a resultset) against the specified 
        /// OdbcTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
        /// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
        /// </summary>
        /// <remarks>
        /// This method provides no access to output parameters or the stored procedure's return value parameter.
        /// 
        /// e.g.:  
        ///  FillDataset(trans, "GetOrders", ds, new string[]{"orders"}, 24, 36);
        /// </remarks>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="spName">The name of the stored procedure</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="parameterValues">An array of objects to be assigned as the input values of the stored procedure</param>
        public static void FillDataset(OdbcTransaction transaction, string spName,
            DataSet dataSet, string[] tableNames,
            params object[] parameterValues)
        {
            if (transaction == null) throw new ArgumentNullException("transaction");
            if (transaction != null && transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
            // If we receive parameter values, we need to figure out where they go
            if ((parameterValues != null) && (parameterValues.Length > 0))
            {
                // Pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
                OdbcParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(transaction.Connection, spName);
                // Assign the provided values to these parameters based on parameter order
                AssignParameterValues(commandParameters, parameterValues);
                // Call the overload that takes an array of OdbcParameters
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames, commandParameters);
            }
            else
            {
                // Otherwise we can just call the SP without params
                FillDataset(transaction, CommandType.StoredProcedure, spName, dataSet, tableNames);
            }
        }
        /// <summary>
        /// Private helper method that execute a OdbcCommand (that returns a resultset) against the specified OdbcTransaction and OdbcConnection
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  FillDataset(conn, trans, CommandType.StoredProcedure, "GetOrders", ds, new string[] {"orders"}, new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">A valid OdbcConnection</param>
        /// <param name="transaction">A valid OdbcTransaction</param>
        /// <param name="commandType">The CommandType (stored procedure, text, etc.)</param>
        /// <param name="commandText">The stored procedure name or T-SQL command</param>
        /// <param name="dataSet">A dataset wich will contain the resultset generated by the command</param>
        /// <param name="tableNames">This array will be used to create table mappings allowing the DataTables to be referenced
        /// by a user defined name (probably the actual table name)
        /// </param>
        /// <param name="commandParameters">An array of SqlParamters used to execute the command</param>
        private static void FillDataset(OdbcConnection connection, OdbcTransaction transaction, CommandType commandType,
            string commandText, DataSet dataSet, string[] tableNames,
            params OdbcParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            if (dataSet == null) throw new ArgumentNullException("dataSet");
            // Create a command and prepare it for execution
            OdbcCommand command = new OdbcCommand();
            bool mustCloseConnection = false;
            PrepareCommand(command, connection, transaction, commandType, commandText, commandParameters, out mustCloseConnection);
            // Create the DataAdapter & DataSet
            using (OdbcDataAdapter dataAdapter = new OdbcDataAdapter(command))
            {
                // Add the table mappings specified by the user
                if (tableNames != null && tableNames.Length > 0)
                {
                    string tableName = "Table";
                    for (int index = 0; index < tableNames.Length; index++)
                    {
                        if (tableNames[index] == null || tableNames[index].Length == 0) throw new ArgumentException("The tableNames parameter must contain a list of tables, a value was provided as null or empty string.", "tableNames");
                        dataAdapter.TableMappings.Add(tableName, tableNames[index]);
                        tableName += (index + 1).ToString();
                    }
                }
                // Fill the DataSet using default values for DataTable names, etc
                dataAdapter.Fill(dataSet);
                // Detach the OdbcParameters from the command object, so they can be used again
                command.Parameters.Clear();
            }
            if (mustCloseConnection) connection.Close();
        }

        #endregion

        #region UpdateDataset

        /// <summary>
        /// Executes the respective command for each inserted, updated, or deleted row in the DataSet.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  UpdateDataset(conn, insertCommand, deleteCommand, updateCommand, dataSet, "Order");
        /// </remarks>
        /// <param name="insertCommand">A valid transact-SQL statement or stored procedure to insert new records into the data source</param>
        /// <param name="deleteCommand">A valid transact-SQL statement or stored procedure to delete records from the data source</param>
        /// <param name="updateCommand">A valid transact-SQL statement or stored procedure used to update records in the data source</param>
        /// <param name="dataSet">The DataSet used to update the data source</param>
        /// <param name="tableName">The DataTable used to update the data source.</param>
        public static void UpdateDataset(OdbcCommand insertCommand, OdbcCommand deleteCommand, OdbcCommand updateCommand, DataSet dataSet, string tableName)
        {
            if (insertCommand == null) throw new ArgumentNullException("insertCommand");
            if (deleteCommand == null) throw new ArgumentNullException("deleteCommand");
            if (updateCommand == null) throw new ArgumentNullException("updateCommand");
            if (tableName == null || tableName.Length == 0) throw new ArgumentNullException("tableName");
            // Create a OdbcDataAdapter, and dispose of it after we are done
            using (OdbcDataAdapter dataAdapter = new OdbcDataAdapter())
            {
                // Set the data adapter commands
                dataAdapter.UpdateCommand = updateCommand;
                dataAdapter.InsertCommand = insertCommand;
                dataAdapter.DeleteCommand = deleteCommand;
                // Update the dataset changes in the data source
                dataAdapter.Update(dataSet, tableName);
                // Commit all the changes made to the DataSet
                dataSet.AcceptChanges();
            }
        }

        #endregion

        #region SqlHelperParameterCache

        /// <summary>
        /// SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
        /// ability to discover parameters for stored procedures at run-time.
        /// </summary>
        public sealed class SqlHelperParameterCache
        {

            #region private methods, variables, and constructors

            //Since this class provides only static methods, make the default constructor private to prevent 
            //instances from being created with "new SqlHelperParameterCache()"
            private SqlHelperParameterCache() { }

            /// <summary>
            /// Hashtable to store cached parameters
            /// </summary>
            private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

            /// <summary>
            /// Resolve at run time the appropriate set of OdbcParameters for a stored procedure
            /// </summary>
            /// <param name="connection">A valid OdbcConnection object</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <param name="includeReturnValueParameter">Whether or not to include their return value parameter</param>
            /// <returns>The parameter array discovered.</returns>
            private static OdbcParameter[] DiscoverSpParameterSet(OdbcConnection connection, string spName, bool includeReturnValueParameter)
            {
                if (connection == null) throw new ArgumentNullException("connection");
                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
                OdbcCommand cmd = new OdbcCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                OdbcCommandBuilder.DeriveParameters(cmd);
                connection.Close();
                if (!includeReturnValueParameter)
                {
                    cmd.Parameters.RemoveAt(0);
                }
                OdbcParameter[] discoveredParameters = new OdbcParameter[cmd.Parameters.Count];
                cmd.Parameters.CopyTo(discoveredParameters, 0);
                // Init the parameters with a DBNull value
                foreach (OdbcParameter discoveredParameter in discoveredParameters)
                {
                    discoveredParameter.Value = DBNull.Value;
                }
                return discoveredParameters;
            }
            /// <summary>
            /// Deep copy of cached OdbcParameter array
            /// </summary>
            /// <param name="originalParameters"></param>
            /// <returns></returns>
            private static OdbcParameter[] CloneParameters(OdbcParameter[] originalParameters)
            {
                OdbcParameter[] clonedParameters = new OdbcParameter[originalParameters.Length];
                for (int i = 0, j = originalParameters.Length; i < j; i++)
                {
                    clonedParameters[i] = (OdbcParameter)((ICloneable)originalParameters[i]).Clone();
                }
                return clonedParameters;
            }

            #endregion private methods, variables, and constructors

            #region caching functions

            /// <summary>
            /// Add parameter array to the cache
            /// </summary>
            /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
            /// <param name="commandText">The stored procedure name or T-SQL command</param>
            /// <param name="commandParameters">An array of SqlParamters to be cached</param>
            public static void CacheParameterSet(string connectionString, string commandText, params OdbcParameter[] commandParameters)
            {
                if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
                if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

                string hashKey = connectionString + ":" + commandText;

                paramCache[hashKey] = commandParameters;
            }
            /// <summary>
            /// Retrieve a parameter array from the cache
            /// </summary>
            /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
            /// <param name="commandText">The stored procedure name or T-SQL command</param>
            /// <returns>An array of SqlParamters</returns>
            public static OdbcParameter[] GetCachedParameterSet(string connectionString, string commandText)
            {
                if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
                if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");
                string hashKey = connectionString + ":" + commandText;
                OdbcParameter[] cachedParameters = paramCache[hashKey] as OdbcParameter[];
                if (cachedParameters == null)
                {
                    return null;
                }
                else
                {
                    return CloneParameters(cachedParameters);
                }
            }

            #endregion

            #region Parameter Discovery Functions

            /// <summary>
            /// Retrieves the set of OdbcParameters appropriate for the stored procedure
            /// </summary>
            /// <remarks>
            /// This method will query the database for this information, and then store it in a cache for future requests.
            /// </remarks>
            /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <returns>An array of OdbcParameters</returns>
            public static OdbcParameter[] GetSpParameterSet(string connectionString, string spName)
            {
                return GetSpParameterSet(connectionString, spName, false);
            }
            /// <summary>
            /// Retrieves the set of OdbcParameters appropriate for the stored procedure
            /// </summary>
            /// <remarks>
            /// This method will query the database for this information, and then store it in a cache for future requests.
            /// </remarks>
            /// <param name="connectionString">A valid connection string for a OdbcConnection</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
            /// <returns>An array of OdbcParameters</returns>
            public static OdbcParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
            {
                if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");

                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
                }
            }
            /// <summary>
            /// Retrieves the set of OdbcParameters appropriate for the stored procedure
            /// </summary>
            /// <remarks>
            /// This method will query the database for this information, and then store it in a cache for future requests.
            /// </remarks>
            /// <param name="connection">A valid OdbcConnection object</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <returns>An array of OdbcParameters</returns>
            internal static OdbcParameter[] GetSpParameterSet(OdbcConnection connection, string spName)
            {
                return GetSpParameterSet(connection, spName, false);
            }
            /// <summary>
            /// Retrieves the set of OdbcParameters appropriate for the stored procedure
            /// </summary>
            /// <remarks>
            /// This method will query the database for this information, and then store it in a cache for future requests.
            /// </remarks>
            /// <param name="connection">A valid OdbcConnection object</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
            /// <returns>An array of OdbcParameters</returns>
            internal static OdbcParameter[] GetSpParameterSet(OdbcConnection connection, string spName, bool includeReturnValueParameter)
            {
                if (connection == null) throw new ArgumentNullException("connection");
                using (OdbcConnection clonedConnection = (OdbcConnection)((ICloneable)connection).Clone())
                {
                    return GetSpParameterSetInternal(clonedConnection, spName, includeReturnValueParameter);
                }
            }
            /// <summary>
            /// Retrieves the set of OdbcParameters appropriate for the stored procedure
            /// </summary>
            /// <param name="connection">A valid OdbcConnection object</param>
            /// <param name="spName">The name of the stored procedure</param>
            /// <param name="includeReturnValueParameter">A bool value indicating whether the return value parameter should be included in the results</param>
            /// <returns>An array of OdbcParameters</returns>
            private static OdbcParameter[] GetSpParameterSetInternal(OdbcConnection connection, string spName, bool includeReturnValueParameter)
            {
                if (connection == null) throw new ArgumentNullException("connection");
                if (spName == null || spName.Length == 0) throw new ArgumentNullException("spName");
                string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");
                OdbcParameter[] cachedParameters;
                cachedParameters = paramCache[hashKey] as OdbcParameter[];
                if (cachedParameters == null)
                {
                    OdbcParameter[] spParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                    paramCache[hashKey] = spParameters;
                    cachedParameters = spParameters;
                }
                return CloneParameters(cachedParameters);
            }

            #endregion

        }

        #endregion

        // Hashtable to store cached parameters
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        #region ExecuteNonQuery

        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteNonQuery(connectionString, cmdType, cmdText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, string cmdText, params OdbcParameter[] commandParameters)
        {
            return ExecuteNonQuery(connectionString, CommandType.Text, cmdText, commandParameters);
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            using (OdbcConnection conn = new OdbcConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">an existing database connection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OdbcConnection connection, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        /// <summary>
        /// Execute a OdbcCommand (that returns no resultset) using an existing SQL Transaction 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="trans">an existing sql transaction</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>an int representing the number of rows affected by the command</returns>
        public static int ExecuteNonQuery(OdbcTransaction trans, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region ExecuteReader

        /// <summary>
        /// Execute a OdbcCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static OdbcDataReader ExecuteReader(string connectionString, string cmdText)
        {
            return ExecuteReader(connectionString, CommandType.Text, cmdText);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static OdbcDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteReader(connectionString, cmdType, cmdText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static OdbcDataReader ExecuteReader(string connectionString, string cmdText, params OdbcParameter[] commandParameters)
        {
            return ExecuteReader(connectionString, CommandType.Text, cmdText, commandParameters);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns a resultset against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  SqlDataReader r = ExecuteReader(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>A SqlDataReader containing the results</returns>
        public static OdbcDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            OdbcConnection conn = new OdbcConnection(connectionString);
            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                OdbcDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute a OdbcCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, string cmdText)
        {
            return ExecuteScalar(connectionString, CommandType.Text, cmdText);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText)
        {
            return ExecuteScalar(connectionString, cmdType, cmdText, (OdbcParameter[])null);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, string cmdText, params OdbcParameter[] commandParameters)
        {
            return ExecuteScalar(connectionString, CommandType.Text, cmdText, commandParameters);
        }
        /// <summary>
        /// Execute a OdbcCommand that returns the first column of the first record against the database specified in the connection string 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a OdbcConnection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// Execute a OdbcCommand that returns the first column of the first record against an existing database connection 
        /// using the provided parameters.
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new OdbcParameter("@prodid", 24));
        /// </remarks>
        /// <param name="connection">an existing database connection</param>
        /// <param name="cmdType">the CommandType (stored procedure, text, etc.)</param>
        /// <param name="cmdText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters used to execute the command</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(OdbcConnection connection, CommandType cmdType, string cmdText, params OdbcParameter[] commandParameters)
        {
            OdbcCommand cmd = new OdbcCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        #endregion

        #region CacheParameters

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="cacheKey">Key to the parameter cache</param>
        /// <param name="commandParameters">an array of SqlParamters to be cached</param>
        public static void CacheParameters(string cacheKey, params OdbcParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }
        /// <summary>
        /// Retrieve cached parameters
        /// </summary>
        /// <param name="cacheKey">key used to lookup parameters</param>
        /// <returns>Cached SqlParamters array</returns>
        public static OdbcParameter[] GetCachedParameters(string cacheKey)
        {
            OdbcParameter[] cachedParms = (OdbcParameter[])parmCache[cacheKey];
            if (cachedParms == null) return null;
            OdbcParameter[] clonedParms = new OdbcParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
            {
                clonedParms[i] = (OdbcParameter)((ICloneable)cachedParms[i]).Clone();
            }
            return clonedParms;
        }
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">OdbcCommand object</param>
        /// <param name="conn">OdbcConnection object</param>
        /// <param name="trans">OdbcTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">OdbcParameters to use in the command</param>
        private static void PrepareCommand(OdbcCommand cmd, OdbcConnection conn, OdbcTransaction trans, CommandType cmdType, string cmdText, OdbcParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (OdbcParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        #endregion

    }
}
