using System;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
	public class DataAccessException : Exception
	{
		public DataAccessException(string message)
			: base(message)
		{
		}

		public DataAccessException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}

	public class ConnectionStringMissingException : DataAccessException
	{
		public ConnectionStringMissingException(string connectionString, string tableName)
			: base(BuildMessage(connectionString, tableName))
		{
		}

		private static string BuildMessage(string connectionString, string tableName)
		{
			return string.Format("Cannot find connection string in {0} class. See connection string named '{1}'",
				tableName, connectionString);
		}
	}

	public class DatabaseDoesNotExistException : DataAccessException
	{
		public DatabaseDoesNotExistException(string databaseName, System.Data.SqlClient.SqlException ex)
			: base(BuildMessage(databaseName), ex)
		{
		}

		private static string BuildMessage(string databaseName)
		{
			return string.Format("Database '{0}' does not exist. Check Sql Server and database name.", databaseName);
		}
	}

	public class TableDoesNotExistException : DataAccessException
	{
		public TableDoesNotExistException(string databaseName, string tableName, System.Data.SqlClient.SqlException ex)
			: base(BuildMessage(databaseName, tableName), ex)
		{
		}

		private static string BuildMessage(string databaseName, string tableName)
		{
			return string.Format(
				"Table '{0}' does not exist in database '{1}'. Check the database to make sure the table names are correct or add the table '{0}'.",
				tableName, databaseName);
		}
	}

	public class ColumnDoesNotExistException : DataAccessException
	{
		public ColumnDoesNotExistException(string databaseName, string tableName, System.Data.SqlClient.SqlException ex)
			: base(BuildMessage(databaseName, tableName, ex), ex)
		{
		}

		private static string BuildMessage(string databaseName, string tableName, System.Data.SqlClient.SqlException ex)
		{
			return string.Format("{0} in table '{1}' in database '{2}'.",
				ex.Message.Replace("\n",""), tableName, databaseName);
		}
	}

	public class RowReferencedElsewhereException : DataAccessException
	{
		public RowReferencedElsewhereException(string databaseName, string tableName,
			string otherTableName, System.Data.SqlClient.SqlException ex)
			: base(BuildMessage(databaseName, tableName, otherTableName))
		{
		}

		private static string BuildMessage(string databaseName, string tableName, string otherTableName)
		{
			return string.Format("The row you are trying to delete from '{0}' cannot be deleted because it is being referenced in the '{1}' table in database '{1}'.",
				tableName, otherTableName, databaseName);
		}
	}

	public class ForeignKeyViolationException : DataAccessException
	{
		public ForeignKeyViolationException(string pkTableName, string fkTableName, object entity)
			: base(BuildMessage(pkTableName, fkTableName, entity))
		{ }

		private static string BuildMessage(string pkTableName, string fkTableName, object entity)
		{
			return string.Format(
				"{0} {1} is also a {2} and cannot be deleted without first deleting the associated {1} record.",
				pkTableName, entity.ToString(), fkTableName);
		}
	}

	public class PrimaryKeyMissingException : DataAccessException
	{
		public PrimaryKeyMissingException(string tableName, object entity, string action)
			: base(BuildMessage(tableName, entity, action))
		{ }

		private static string BuildMessage(string tableName, object entity, string action)
		{
			return string.Format(
				"Cannot {0} {1} {2} because the key is missing.",
				action, tableName, entity.ToString());
		}
	}
}
	