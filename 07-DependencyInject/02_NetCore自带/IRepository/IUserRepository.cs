using _07_DependencyInject._02_NetCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore.IRepository
{
    public interface IUserRepository
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserEntity> UserList();

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddUser(UserEntity user);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserEntity GetUser(int id);
    }
}
