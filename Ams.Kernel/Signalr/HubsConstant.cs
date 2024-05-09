namespace Ams.Kernel.Signalr
{
    /// <summary>
    /// 消息中心
    /// 常量定义
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class HubsConstant
    {
        private const string V = "receiveNotice";
        public static string ReceiveNotice = V;
        public static string OnlineNum = "onlineNum";
        public static string MoreNotice = "moreNotice";
        public static string OnlineUser = "onlineUser";
        public static string LockUser = "lockUser";
        public static string ForceUser = "forceUser";
        public static string ConnId = "connId";
    }
}