using DAL;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestFixture]
	public class UserServiceTests
    {
		private UserService _userService;

		[SetUp]
		public void Initialize()
		{
			var repository = new UserRepository();
			_userService = new UserService(repository);
		}

		[Test]
		public void FindDatavivAccessAllowed()
		{
			var users = _userService.FindDatavivAccessAllowed();

			Check.That(users)
				.IsNotNull()
				.And
				.HasElementThatMatches(u => u.DatavivAccessAllowed);
		}
	}
}