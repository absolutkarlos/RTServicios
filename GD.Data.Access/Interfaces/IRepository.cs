using System.Collections.Generic;
using GD.Models.Commons;

namespace GD.Data.Access.Interfaces
{
	/// <summary>
	/// Intarface related with the Design Pattern of Repository
	/// </summary>
	/// <typeparam name="TModel"></typeparam>
	public interface IRepository<TModel>
	{
		/// <summary>
		/// Insert objects
		/// </summary>
		/// <param name="model">Object to be inserted</param>
		/// <returns></returns>
		long Insert(TModel model);

		/// <summary>
		/// Delete objects
		/// </summary>
		/// <param name="id">Id of object to be deleted</param>
		void Delete<TId>(TId id);

		/// <summary>
		/// Update object
		/// </summary>
		/// <param name="model">Object to be updated</param>
		void Update(TModel model);

		/// <summary>
		/// Get all objects
		/// </summary>
		/// <returns></returns>
		IEnumerable<TModel> GetAll();

		/// <summary>
		/// Get object by id
		/// </summary>
		/// <param name="id">Id of the object to be obtained</param>
		/// <returns></returns>
		TModel GetById<TId>(TId id);

		/// <summary>
		/// Validate whether a specific object
		/// </summary>
		/// <param name="id">Id of the object to be validated</param>
		/// <returns></returns>
		bool Exists<TId>(TId id);

		void Dispose();
	}
}
