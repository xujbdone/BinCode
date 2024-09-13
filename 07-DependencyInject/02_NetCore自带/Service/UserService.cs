using _07_DependencyInject._02_NetCore.Entity;
using _07_DependencyInject._02_NetCore.IRepository;
using _07_DependencyInject._02_NetCore.IService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _user = null;

        public UserService(IUserRepository userRepository)
        {
            _user = userRepository;
        }


        public IEnumerable<UserEntity> UserList()
        {
            return _user.UserList();
        }

        public bool AddUser(UserEntity user)
        {
            return _user.AddUser(user);
        }

        public UserEntity GetUser(int id)
        {
            return _user.GetUser(id);
        }
    }
}
