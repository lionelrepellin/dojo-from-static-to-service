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
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public void Add(User user)
		{
			_userRepository.Add(user);
		}

		public User FindById(int id)
		{
			return _userRepository.FindById(id);
		}

		public IEnumerable<User> FindDatavivAccessAllowed()
		{
			var users = _userRepository.GetAll();

			return users
					.Where(u => u.DatavivAccessAllowed)
					.OrderBy(u => u.Name);
		}
	}
}
