using Ams.Infrastructure;
using CSRedis;

namespace Ams.Common.Cache
{
    /// <summary>
    /// Redis内存存储的数据结构服务器
    /// 连接
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public class RedisServer
    {
        public static CSRedisClient Cache;
        public static CSRedisClient Session;

        public static void Initalize()
        {
            Cache = new CSRedisClient(AppSettings.GetConfig("RedisServer:Cache"));
            Session = new CSRedisClient(AppSettings.GetConfig("RedisServer:Session"));
        }
    }
}