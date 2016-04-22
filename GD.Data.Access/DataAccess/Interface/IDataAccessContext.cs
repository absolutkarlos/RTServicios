using System.Collections.Generic;
using System.Data;

namespace GD.Data.Access.DataAccess.Interface
{
	public interface IDataAccessContext
	{
		/// <summary>
		/// Returns a DataTable with the results of the query
		/// </summary>
		/// <param name="nameSp">string with the stored procedure name</param>
		/// <param name="parameters">List with the for the query</param>
		/// <returns>Returns a datatable base on the query executed</returns>
		T ExecuteStoredProcedure<T>(string nameSp, List<Parameter> parameters = null) where T : new();


		/// <summary>
		/// Execute store procedure
		/// </summary>
		/// <param name="nameSp">string with the stored procedure Name</param>
		/// <param name="parameters">List with the for the query</param>
		void ExecuteStoredProcedure(string nameSp, List<Parameter> parameters);

		/// <summary>
		/// Returns a DataTable with the results of the query
		/// </summary>
		/// <param name="nameSp">string with the stored procedure name</param>
		/// <param name="parameters">Dictionary with the for the query</param>
		/// <returns>Returns a datatable base on the query executed</returns>
		DataTable GetDataTable(string nameSp, Dictionary<string, object> parameters);
	}
}
