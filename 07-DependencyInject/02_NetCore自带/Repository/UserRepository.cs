using _07_DependencyInject._02_NetCore.Entity;
using _07_DependencyInject._02_NetCore.IRepository;
using _07_DependencyInject._02_NetCore.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore.Repository
{
    public class UserRepository : IUserRepository
    {
        private ILogger<UserService> _logger = null;

        public UserRepository(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        private List<UserEntity> _users = new List<UserEntity>();

        public bool AddUser(UserEntity user)
        {
            var _user = _users.OrderByDescending(f => f.id).FirstOrDefault();
            user.id = _user?.id + 1 ?? 1;
            _logger.LogDebug($"仓储添加用户,data={Newtonsoft.Json.JsonConvert.SerializeObject(_user)}");
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
