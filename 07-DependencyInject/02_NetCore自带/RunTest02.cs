using _07_DependencyInject._02_NetCore.IRepository;
using _07_DependencyInject._02_NetCore.IService;
using _07_DependencyInject._02_NetCore.Repository;
using _07_DependencyInject._02_NetCore.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _07_DependencyInject._02_NetCore
{
    public class RunTest02
    {
        public static void Run()
        {
            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<IUserService, UserService>();
            IHost host = builder.Build();
            host.Start();

            var userService = host.Services.GetService<IUserService>();

            userService.AddUser(new Entity.UserEntity() { name = "熊大", age = 99 });
            userService.AddUser(new Entity.UserEntity() { name = "王二", age = 19 });
            userService.AddUser(new Entity.UserEntity() { name = "张三", age = 3 });
            userService.AddUser(new Entity.UserEntity() { name = "李四", age = 45 });

            var user1 = userService.GetUser(1);
           
            var userList = userService.UserList();
        }
    }
}
