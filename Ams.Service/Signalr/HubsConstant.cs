namespace Ams.Service.Signalr
{
    /// <summary>
    /// HubsConstant
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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