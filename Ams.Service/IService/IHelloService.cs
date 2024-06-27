using Ams.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;



namespace Ams.Service.IService
{
    /// <summary>
    /// Hello接口
    /// </summary>
    public interface IHelloService : IBaseService<ArticleCatalog>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string SayHello(string name);
        ApiResult SayHello2([FromBody] SysUserDto userDto);
        ApiResult SayHello3();
        ApiResult SayHelloJson([FromBody] SysUserDto userDto);
    }
}
