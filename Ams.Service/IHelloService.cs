using Ams.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Ams.Service
{
    /// <summary>
    /// Hello接口
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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