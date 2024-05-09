using Ams.Repository;

namespace Ams.Kernel
{
    /// <summary>
    /// 基础服务
    /// 定义
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : BaseRepository<T> where T : class, new()
    {
    }
}