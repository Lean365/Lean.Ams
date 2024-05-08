namespace Ams.Common.Model
{
    /// <summary>
    /// 微信Token结果
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
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