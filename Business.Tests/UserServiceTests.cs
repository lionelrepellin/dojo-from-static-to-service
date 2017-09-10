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
        private Mock<IGenericRepository<User>> _userRepository;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void Initialize()
        {
            _userRepository = CreateUserRepositoryMock();
            _unitOfWork = CreateUnitOfWorkMock(_userRepository);
            _userService = new UserService(_unitOfWork.Object);
        }

        [Test]
        public void FindDatavivAccessAllowed()
        {
            var users = _userService.FindDatavivAccessAllowed();

            Check.That(users.All(u => u.DatavivAccessAllowed));

            Check.That(users.Extracting("Name"))
                .ContainsExactly("Paul", "Pierre");

            _userRepository.Verify(r => r.Get(null, null, string.Empty), Times.Once);
            _unitOfWork.Verify(u => u.UserRepository, Times.Once);
        }

        private Mock<IGenericRepository<User>> CreateUserRepositoryMock()
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Pierre", DatavivAccessAllowed = true },
                new User { Id = 2, Name = "Paul", DatavivAccessAllowed = true },
                new User { Id = 3, Name = "Jacques", DatavivAccessAllowed = false }
            };

            var repository = new Mock<IGenericRepository<User>>();
            repository
                .Setup(r => r.Get(null, null, string.Empty))
                .Returns(users);

            return repository;
        }

        private Mock<IUnitOfWork> CreateUnitOfWorkMock(IMock<IGenericRepository<User>> userRepositoryMock)
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork
                .SetupGet(u => u.UserRepository)
                .Returns(userRepositoryMock.Object);

            return unitOfWork;
        }
    }
}