using System;
using System.Collections.Generic;
using GD.Models.Commons;
using GD.Core.Business.Interfaces;
using GD.Data.Access.Interfaces;
using Action = GD.Models.Commons.Action;

namespace GD.Core.Business
{
	public class UserBl : IUserBl
	{
		public IRepository<User> UserRepository { get; set; }
		public IRepository<Audit> AuditRepository { get; set; }

		public UserBl(IRepository<User> userRepository, IRepository<Audit> auditRepository)
		{
			UserRepository = userRepository;
			AuditRepository = auditRepository;
		}

		public long InsertValue(User model)
		{
			return UserRepository.Insert(model);
		}

		public void DeleteValue<TId>(TId id)
		{
			UserRepository.Delete(id);
		}

		public void UpdateValue(User model)
		{
			UserRepository.Update(model);
		}

		public IEnumerable<User> GetAllValues()
		{
			return UserRepository.GetAll();
		}

		public User GetValueById<TId>(TId id)
		{
			return UserRepository.GetById(id);
		}

		public bool ExistsValue<TId>(TId id)
		{
			return UserRepository.Exists(id);
		}

		public void UpdateLastConnect(long userId)
		{
			AuditRepository.Insert(new Audit
			{
				IdObject = userId,
				Object = @"TUser",
				ActionType = Action.ActionType.Disconnect.ToString(),
				CreateAt = DateTime.Now,
				CreateBy = short.Parse(userId.ToString()),
				UpdateBy = short.Parse(userId.ToString()),
				UpdateAt = DateTime.Now
			});
		}

		public void GetLastConnect(long userId)
		{
			AuditRepository.Insert(new Audit
			{
				IdObject = userId,
				Object = @"TUser",
				ActionType = Action.ActionType.Disconnect.ToString(),
				CreateAt = DateTime.Now,
				CreateBy = short.Parse(userId.ToString()),
				UpdateBy = short.Parse(userId.ToString()),
				UpdateAt = DateTime.Now
			});
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}
	}
}
