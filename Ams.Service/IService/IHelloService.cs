using Ams.Model.Content;

namespace Ams.Service.IService
{
    /// <summary>
    /// Hello
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IHelloService : IBaseService<ArticleCategory>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string SayHello(string name);
    }
}