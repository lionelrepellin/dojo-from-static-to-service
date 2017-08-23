using System.Collections.Generic;
using Entities;

namespace DAL
{
	public interface IUserRepository
	{
		int Add(User user);
		User FindById(int id);
		IEnumerable<User> GetAll();
	}
}