using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UserRepository : IUserRepository
	{
		public int Add(User user)
		{
			using (var context = new Context())
			{
				context.Users.Add(user);
				return context.SaveChanges();
			}
		}

		public IEnumerable<User> GetAll()
		{
			using (var context = new Context())
			{
				return context.Users.ToList();
			}
		}

		public User FindById(int id)
		{
			using (var context = new Context())
			{
				return context.Users.Find(id);
			}
		}
	}
}
