using System.Collections.Generic;

namespace GD.Core.Business.Interfaces
{
	public interface IBusinessLayer<TModel>
	{
		/// <summary>
		/// Insert objects
		/// </summary>
		/// <param name="model">Object to be inserted</param>
		/// <returns></returns>
		long InsertValue(TModel model);

		/// <summary>
		/// Delete Object
		/// </summary>
		/// <param name="id">Id of the object to be validated</param>
		void DeleteValue<TId>(TId id);

		/// <summary>
		/// Update Object
		/// </summary>
		/// <param name="model">Object to be updated</param>
		void UpdateValue(TModel model);

		/// <summary>
		/// Get all objects
		/// </summary>
		/// <returns></returns>
		IEnumerable<TModel> GetAllValues();

		/// <summary>
		/// Get object by id
		/// </summary>
		/// <param name="id">Id of the object to be obtained</param>
		/// <returns></returns>
		TModel GetValueById<TId>(TId id);

		/// <summary>
		/// Validate whether a specific object
		/// </summary>
		/// <param name="id">Id of the object to be validated</param>
		/// <returns></returns>
		bool ExistsValue<TId>(TId id);

		void Dispose();
	}
}