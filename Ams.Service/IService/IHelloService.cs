using Ams.Kernel.Model.Routine;

namespace Ams.Service.IService
{
    /// <summary>
    /// Hello接口
    /// </summary>
    public interface IHelloService : IBaseService<RoutineArticleCategory>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string SayHello(string name);
    }
}
