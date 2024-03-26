using Ams.Repository;

namespace Ams.Kernel
{
    /// <summary>
    /// 基础服务
    /// 定义对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : BaseRepository<T> where T : class, new()
    {
    }
}