namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 缓存
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public class CacheService
    {
        private static readonly string CK_verifyScan = "verifyScan_";
        private static readonly string CK_phoneSmsCode = "phone_sms_code_";

        #region 用户权限 缓存

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<string> GetUserPerms(string key)
        {
            return (List<string>)CacheHelper.GetCache(key);
            //return RedisServer.Cache.Get<List<string>>(key).ToList();
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public static void SetUserPerms(string key, object data)
        {
            CacheHelper.SetCache(key, data);
            //RedisServer.Cache.Set(key, data);
        }

        /// <summary>
        /// 移除用户权限
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveUserPerms(string key)
        {
            CacheHelper.Remove(key);
            //RedisServer.Cache.Del(key);
        }

        #endregion 用户权限 缓存

        /// <summary>
        /// 设置扫码登录
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object SetScanLogin(string key, Dictionary<string, object> val)
        {
            var ck = CK_verifyScan + key;

            return CacheHelper.SetCache(ck, val, 1);
        }

        /// <summary>
        /// 获取扫码登录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetScanLogin(string key)
        {
            var ck = CK_verifyScan + key;
            return CacheHelper.Get(ck);
        }

        /// <summary>
        /// 移除扫码登录
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveScanLogin(string key)
        {
            var ck = CK_verifyScan + key;
            CacheHelper.Remove(ck);
        }

        /// <summary>
        /// 设置锁定用户
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="time"></param>
        public static void SetLockUser(string key, long val, int time)
        {
            var CK = "lock_user_" + key;

            CacheHelper.SetCache(CK, val, time);
        }

        /// <summary>
        /// 获取锁定用户
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long GetLockUser(string key)
        {
            var CK = "lock_user_" + key;

            if (CacheHelper.Get(CK) is long t)
            {
                return t;
            }
            return 0;
        }

        /// <summary>
        /// 缴存手机验证码
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object SetPhoneCode(string key, string val)
        {
            var ck = CK_phoneSmsCode + key;

            return CacheHelper.SetCache(ck, val, 10);
        }

        /// <summary>
        /// 检查手机验证码是否正确
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool CheckPhoneCode(string key, string val)
        {
            var ck = CK_phoneSmsCode + key;
            var save_code = CacheHelper.Get(ck);

            if (save_code != null && save_code.Equals(val))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 缓存手机验证码
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <summary>
        public static void RemovePhoneCode(string key)
        {
            var ck = CK_phoneSmsCode + key;

            CacheHelper.Remove(ck);
        }
    }
}