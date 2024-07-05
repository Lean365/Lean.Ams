namespace Ams.Common.Model
{
    /// <summary>
    /// 微信Token结果
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class WxTokenResult
    {
        /// <summary>
        /// 0、正常
        /// </summary>
        public int errcode { get; set; }

        public string errmsg { get; set; }
        public string access_token { get; set; }
        public string ticket { get; set; }
    }
}