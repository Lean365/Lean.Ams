using Ams.Repository;

namespace Ams.Kernel
{
    /// <summary>
    /// 基础服务类接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> : IBaseRepository<T> where T : class, new()
    {
    }
}