using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public class UserService
	{
		public void Add(User user)
		{
			UserRepository.Add(user);
		}

		public User FindById(int id)
		{
			return UserRepository.FindById(id);
		}

		public IEnumerable<User> FindDatavivAccessAllowed()
		{
			var users = UserRepository.GetAll();

			return users
					.Where(u => u.DatavivAccessAllowed)
					.OrderBy(u => u.Name);
		}
	}
}
