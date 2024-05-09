using Ams.Kernel.Model.Dto;
using Ams.Kernel.Model.Dto.Login;
using Ams.Model;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 登录日志
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ISysLoginService : IBaseService<LogLogin>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="logininfor"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, LogLogin logininfor);

        /// <summary>
        /// 手机号登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="logininfor"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        SysUser PhoneLogin(PhoneLoginDto loginBody, LogLogin logininfor, SysUser user);

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
        public int DeleteLogininforByIds(long[] ids);

        void CheckLockUser(string userName);

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        List<LogStatiDto> GetStatiLoginlog();
    }
}