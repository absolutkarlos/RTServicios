using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;
using GD.Data.Access.DataAccess.Interface;
using GD.Models.Commons.Utilities;
using Npgsql;
using NpgsqlTypes;

namespace GD.Data.Access.DataAccess
{
	public class PsgSqlDataAccess : IDataAccessContext
	{
		private string ConnectionString { get; }

		public PsgSqlDataAccess()
		{
			ConnectionString = ConfigurationManager.ConnectionStrings[@"PsqlConnection"].ConnectionString;
		}

		/// <summary>
		/// Returns a DataTable with the results of the store procedure
		/// </summary>
		/// <param name="nameSp">string with the stored procedure Name</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		/// <returns>Returns a datatable base on the query executed</returns>
		public T ExecuteStoredProcedure<T>(string nameSp, Dictionary<string, object> parameters) where T : new()
		{
			using (var conn = new NpgsqlConnection(ConnectionString))
			{
				conn.Open();
				var result = ExecuteCommandSp(nameSp, parameters, conn);
				if (string.IsNullOrWhiteSpace(result))
				{
					return new T();
				}
				return JsonHelper.Deserialize<T>(result);
			}
		}

		/// <summary>
		/// Execute store procedure
		/// </summary>
		/// <param name="nameSp">string with the stored procedure Name</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		public void ExecuteStoredProcedure(string nameSp, Dictionary<string, object> parameters)
		{
			using (var conn = new NpgsqlConnection(ConnectionString))
			{
				conn.Open();
				ExecuteCommandSpNonQuery(nameSp, parameters, conn);
			}
		}

		/// <summary>
		/// Returns a DataTable with the results of the store procedure
		/// </summary>
		/// <param name="nameSp">string with the stored procedure Name</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		/// <returns>Returns a datatable base on the query executed</returns>
		public DataTable GetDataTable(string nameSp, Dictionary<string, object> parameters = null)
		{
			using (var conn = new NpgsqlConnection(ConnectionString))
			{
				conn.Open();
				DataTable results = new DataTable("results");
				//results.Load(ExecuteCommandSp(nameSp, parameters, conn));
				return results;
			}
		}

		/// <summary>
		/// Returns a DataTable with the results of the store procedure
		/// </summary>
		/// <param name="nameSp">string with the name stored procedure</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		/// <param name="connection"></param>
		private string ExecuteCommandSp(string nameSp, Dictionary<string, object> parameters, NpgsqlConnection connection)
		{
			using (var command = new NpgsqlCommand(nameSp, connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				if (parameters != null)
				{
					foreach (string key in parameters.Keys)
					{
						var dbType = (key == @"_jsonvalue") ? NpgsqlDbType.Json : ((key == @"_id") ? NpgsqlDbType.Integer : NpgsqlDbType.Text);
						command.Parameters.AddWithValue(key, dbType, parameters[key]);
					}
				}

				using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
				{
					var result = string.Empty;
					while (reader.Read())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							if(reader[i] != DBNull.Value)
								result = reader[i].ToString();
						}
					}
					return result;
				}
			}
		}

		/// <summary>
		/// Execute store procedure
		/// </summary>
		/// <param name="nameSp">string with the name stored procedure</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		/// <param name="connection"></param>
		private void ExecuteCommandSpNonQuery(string nameSp, Dictionary<string, object> parameters, NpgsqlConnection connection)
		{
			using (var command = new NpgsqlCommand(nameSp, connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				if (parameters != null)
				{
					foreach (string key in parameters.Keys)
					{
						var dbType = (key == @"_jsonvalue") ? NpgsqlDbType.Json : ((key == @"_id") ? NpgsqlDbType.Integer : NpgsqlDbType.Text);
						command.Parameters.AddWithValue(key, dbType, parameters[key]);
					}
				}

				var rowsaffected = command.ExecuteNonQuery();
			}
		}
	}
}
