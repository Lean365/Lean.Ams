using Ams.Infrastructure.Model;
using Ams.Model.Kernel.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Service
{
    /// <summary>
    /// Hello接口
    /// </summary>
    public interface IHelloService : IBaseService<ArticleCategory>
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