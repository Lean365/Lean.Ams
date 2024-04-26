using CSRedis;

namespace Ams.Infrastructure.Cache
{
    /// <summary>
    /// Redis服务器
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public class RedisServer
    {
        public static CSRedisClient Cache;
        public static CSRedisClient Session;

        /// <summary>
        /// 初始化Redis服务器
        /// </summary>
        public static void Initalize()
        {
            Cache = new CSRedisClient(AppSettings.GetConfig("RedisServer:Cache"));
            Session = new CSRedisClient(AppSettings.GetConfig("RedisServer:Session"));
        }
    }
}