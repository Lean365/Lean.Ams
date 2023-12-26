using Ams.Infrastructure;
using Ams.Infrastructure.Attribute;
using SqlSugar.IOC;
using Ams.Kernel.Model.System;
using Ams.Repository;
using Ams.Service.IService;
using Ams.Infrastructure.Apps;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.System;
namespace Ams.Service
{
    /// <summary>
    /// 注意：下面的AppService不要漏了
    /// </summary>
    [AppService(ServiceType = typeof(IHelloService), ServiceLifetime = LifeTime.Transient)]
    public class HelloService : BaseService<RoutineArticleCategory>, IHelloService
    {
        /// <summary>
        /// 引用User服务
        /// </summary>
        private readonly ISysUserService userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public HelloService(ISysUserService userService)
        {
            this.userService = userService;
        }
        /// <summary>
        /// 数据库使用案例
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string SayHello(string name)
        {
            //构造函数式使用
            var user = JsonConvert.SerializeObject(userService.GetFirst(f => f.UserId == 1));
            Console.WriteLine(user);

            var postService = App.GetRequiredService<ISysPostService>();
            Console.WriteLine(JsonConvert.SerializeObject(postService.GetId(1)));

            BaseRepository<SysDept> deptRepo = new();
            Console.WriteLine(JsonConvert.SerializeObject(deptRepo.GetId(1)));

            var result = DbScoped.SugarScope.Queryable<SysDictType>().Where(f => f.DictId == 1).First();
            Console.WriteLine(JsonConvert.SerializeObject(result));

            //切换库
            //DbScoped.SugarScope.GetConnectionScope(2);

            GetFirst(x => x.CategoryId == 1);
            Context.Queryable<SysUser>().First(f => f.UserId == 1);

            return "Hello:" + name;
        }
    }
}
