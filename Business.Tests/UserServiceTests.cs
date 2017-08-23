using DAL;
using Entities;
using Moq;
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
		private Mock<IUserRepository> _userRepository;

		[SetUp]
		public void Initialize()
		{
			_userRepository = CreateUserRepositoryMock();
			_userService = new UserService(_userRepository.Object);
		}

		[Test]
		public void FindDatavivAccessAllowed()
		{
			var users = _userService.FindDatavivAccessAllowed();

			Check.That(users)
				.IsNotNull()
				.And
				.HasElementThatMatches(u => u.DatavivAccessAllowed);

			Check.That(users.Extracting("Name"))
				.ContainsExactly("Paul", "Pierre");

			_userRepository.Verify(r => r.GetAll(), Times.Once);
		}

		private Mock<IUserRepository> CreateUserRepositoryMock()
		{
			var users = new List<User>
			{
				new User { Id = 1, Name = "Pierre", DatavivAccessAllowed = true },
				new User { Id = 2, Name = "Paul", DatavivAccessAllowed = true },
				new User { Id = 3, Name = "Jacques", DatavivAccessAllowed = false }
			};

			var repository = new Mock<IUserRepository>();

			repository
				.Setup(r => r.GetAll())
				.Returns(users);

			return repository;
		}
	}
}