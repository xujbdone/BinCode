using _07_DependencyInject._02_NetCore.Entity;
using _07_DependencyInject._02_NetCore.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore.IService
{
    public interface IUserService
    {
        IEnumerable<UserEntity> UserList();

        bool AddUser(UserEntity user);

        UserEntity GetUser(int id);
    }
}
