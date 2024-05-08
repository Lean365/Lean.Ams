using Ams.Model.Content;

namespace Ams.Service.IService
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
    }
}
