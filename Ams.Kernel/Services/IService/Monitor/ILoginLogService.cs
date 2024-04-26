using Ams.Kernel.Model.Dto;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Model.System.Dto;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 登录信息
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ILoginLogService : IBaseService<LoginLog>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="loginlog"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, LoginLog loginlog);

        /// <summary>
        /// 手机号登录
        /// </summary>
        /// <param name="loginBody"></param>
        /// <param name="loginlog"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        SysUser PhoneLogin(PhoneLoginDto loginBody, LoginLog loginlog, SysUser user);

        /// <summary>
        /// 查询操作日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<LoginLog> GetLoginLog(LoginLog logininfoDto, PagerInfo pager);

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="LoginLog"></param>
        /// <returns></returns>
        public void AddLoginInfo(LoginLog LoginLog);

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogininfo();

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteloginlogByIds(long[] ids);

        void CheckLockUser(string userName);

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        List<StatiLogDto> GetStatiLoginlog();
    }
}