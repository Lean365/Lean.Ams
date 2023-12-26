using Ams.Infrastructure;
using Ams.Infrastructure.Attribute;
using Microsoft.AspNetCore.Http;
using UAParser;
using Ams.Model;
using Ams.Kernel.Model.System;
using Ams.Repository;
using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.Helper;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Services.IService.System;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Services.IService.Monitor;
namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 登录
    /// </summary>
    [AppService(ServiceType = typeof(ILogLoginService), ServiceLifetime = LifeTime.Transient)]
    public class LogLoginService : BaseService<LogLogin>, ILogLoginService
    {
        private readonly ISysUserService SysUserService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LogLoginService(ISysUserService sysUserService, IHttpContextAccessor httpContextAccessor)
        {
            SysUserService = sysUserService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="loglogin"></param>
        /// <param name="loginBody"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, LogLogin loglogin)
        {
            if (loginBody.Password.Length != 32)
            {
                loginBody.Password = NETCore.Encrypt.EncryptProvider.Md5(loginBody.Password);
            }
            SysUser user = SysUserService.Login(loginBody);
            loglogin.UserName = loginBody.Username;
            loglogin.IsState = 1;
            loglogin.LoginTime = DateTime.Now;
            loglogin.Ipaddr = loginBody.LoginIP;

            ClientInfo clientInfo = httpContextAccessor.HttpContext.GetClientInfo();
            loglogin.Browser = clientInfo.ToString();
            loglogin.Os = clientInfo.OS.ToString();

            if (user == null || user.UserId <= 0)
            {
                loglogin.Msg = "用户名或密码错误";
                AddLoginInfo(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }
            if (user.IsState == 1)
            {
                loglogin.Msg = "该用户已禁用";
                AddLoginInfo(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }

            loglogin.IsState = 0;
            loglogin.Msg = "登录成功";
            AddLoginInfo(loglogin);
            SysUserService.UpdateLoginInfo(loginBody.LoginIP, user.UserId);
            return user;
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="loglogin"></param>
        /// <param name="loginBody"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public SysUser PhoneLogin(PhoneLoginDto loginBody, LogLogin loglogin, SysUser user)
        {
            loglogin.UserName = user.UserName;
            loglogin.IsState = 1;
            loglogin.LoginTime = DateTime.Now;
            loglogin.Ipaddr = loginBody.LoginIP;

            ClientInfo clientInfo = httpContextAccessor.HttpContext.GetClientInfo();
            loglogin.Browser = clientInfo.ToString();
            loglogin.Os = clientInfo.OS.ToString();

            if (user.IsState == 1)
            {
                loglogin.Msg = "该用户已禁用";
                AddLoginInfo(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }

            loglogin.IsState = 0;
            loglogin.Msg = "登录成功";
            AddLoginInfo(loglogin);
            SysUserService.UpdateLoginInfo(loginBody.LoginIP, user.UserId);
            return user;
        }
        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<LogLogin> GetLoginLog(LogLogin logininfoDto, PagerInfo pager)
        {
            //logininfoDto.BeginTime = DateTimeHelper.GetBeginTime(logininfoDto.BeginTime, -1);
            //logininfoDto.EndTime = DateTimeHelper.GetBeginTime(logininfoDto.EndTime, 1);

            var exp = Expressionable.Create<LogLogin>();

            exp.AndIF(logininfoDto.BeginTime == null, it => it.LoginTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            exp.AndIF(logininfoDto.BeginTime != null, it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);
            exp.AndIF(logininfoDto.Ipaddr.IfNotEmpty(), f => f.Ipaddr == logininfoDto.Ipaddr);
            exp.AndIF(logininfoDto.UserName.IfNotEmpty(), f => f.UserName.Contains(logininfoDto.UserName));
            exp.AndIF(logininfoDto.IsState.ToString().IfNotEmpty(), f => f.IsState == logininfoDto.IsState);
            var query = Queryable().Where(exp.ToExpression())
            .OrderBy(it => it.InfoId, OrderByType.Desc);

            return query.ToPage(pager);
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="LogLogin"></param>
        /// <returns></returns>
        public void AddLoginInfo(LogLogin LogLogin)
        {
            Insert(LogLogin);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogininfo()
        {
            Truncate();
        }

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeletelogloginByIds(long[] ids)
        {
            return Delete(ids);
        }

        public void CheckLockUser(string userName)
        {
            var lockTimeStamp = CacheService.GetLockUser(userName);
            var lockTime = DateTimeHelper.ToLocalTimeDateBySeconds(lockTimeStamp);
            var ts = lockTime - DateTime.Now;

            if (lockTimeStamp > 0 && ts.TotalSeconds > 0)
            {
                throw new CustomizeException(ResultCode.LOGIN_ERROR, $"你的账号已被锁,剩余{Math.Round(ts.TotalMinutes, 0)}分钟");
            }
        }

    }
}
