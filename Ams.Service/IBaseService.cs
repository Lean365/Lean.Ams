namespace Ams.Service
{
    /// <summary>
    /// 基础服务定义
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> : IBaseRepository<T> where T : class, new()
    {
    }
}