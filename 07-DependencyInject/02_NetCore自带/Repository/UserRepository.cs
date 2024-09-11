using _07_DependencyInject._02_NetCore.Entity;
using _07_DependencyInject._02_NetCore.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<UserEntity> _users = new List<UserEntity>();

        public bool AddUser(UserEntity user)
        {
            var _user = _users.OrderByDescending(f => f.id).FirstOrDefault();
            user.id = _user?.id + 1 ?? 1;
            _users.Add(user);
            return true;
        }

        public UserEntity GetUser(int id)
        {
            return _users.FirstOrDefault(f => f.id == id);
        }

        public IEnumerable<UserEntity> UserList()
        {
            return _users;
        }
    }
}
