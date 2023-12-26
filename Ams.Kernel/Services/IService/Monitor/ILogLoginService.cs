using Ams.Model;
using Ams.Kernel.Model.System;
using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Model.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    public interface ILogLoginService : IBaseService<LogLogin>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="loglogin"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, LogLogin loglogin);
        /// <summary>
        /// 手机号登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="loglogin"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        SysUser PhoneLogin(PhoneLoginDto loginBody, LogLogin loglogin, SysUser user);
        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<LogLogin> GetLoginLog(LogLogin logininfoDto, PagerInfo pager);

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="LogLogin"></param>
        /// <returns></returns>
        public void AddLoginInfo(LogLogin LogLogin);

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogininfo();

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeletelogloginByIds(long[] ids);

        void CheckLockUser(string userName);
    }
}
