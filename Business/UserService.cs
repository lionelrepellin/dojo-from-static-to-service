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
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
        }

        public User FindById(int id)
        {
            return _unitOfWork.UserRepository.FindById(id);
        }

        public IEnumerable<User> FindDatavivAccessAllowed()
        {
            var users = _unitOfWork.UserRepository.Get();

            return users
                    .Where(u => u.DatavivAccessAllowed)
                    .OrderBy(u => u.Name);
        }
    }
}
