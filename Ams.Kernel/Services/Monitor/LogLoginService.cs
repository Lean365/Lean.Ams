using Ams.Common;
using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.Helper;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.System;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Kernel.Services.IService.System;
using Ams.Model;
using Ams.Repository;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 登录日志
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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
                AddLogLogin(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }
            if (user.IsState == 1)
            {
                loglogin.Msg = "该用户已禁用";
                AddLogLogin(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }

            loglogin.IsState = 0;
            loglogin.Msg = "登录成功";
            AddLogLogin(loglogin);
            SysUserService.UpdateLogLogin(loginBody.LoginIP, user.UserId);
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
                AddLogLogin(loglogin);
                throw new CustomizeException(ResultCode.LOGIN_ERROR, loglogin.Msg, false);
            }

            loglogin.IsState = 0;
            loglogin.Msg = "登录成功";
            AddLogLogin(loglogin);
            SysUserService.UpdateLogLogin(loginBody.LoginIP, user.UserId);
            return user;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="LogLoginDto"></param>
        /// <param name="pager">分页</param>
        /// <returns></returns>
        public PagedInfo<LogLogin> GetLoginLog(LogLogin LogLoginDto, PagerInfo pager)
        {
            //LogLoginDto.BeginTime = DateTimeHelper.GetBeginTime(LogLoginDto.BeginTime, -1);
            //LogLoginDto.EndTime = DateTimeHelper.GetBeginTime(LogLoginDto.EndTime, 1);

            var exp = Expressionable.Create<LogLogin>();

            //exp.AndIF(LogLoginDto.BeginTime == null, it => it.LoginTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            exp.AndIF(LogLoginDto.BeginTime != null, it => it.LoginTime >= LogLoginDto.BeginTime && it.LoginTime <= LogLoginDto.EndTime);
            exp.AndIF(LogLoginDto.Ipaddr.IfNotEmpty(), f => f.Ipaddr == LogLoginDto.Ipaddr);
            exp.AndIF(LogLoginDto.UserName.IfNotEmpty(), f => f.UserName.Contains(LogLoginDto.UserName));
            exp.AndIF(LogLoginDto.IsState.ToString().IfNotEmpty(), f => f.IsState == LogLoginDto.IsState);
            var query = Queryable().Where(exp.ToExpression())
            .OrderBy(it => it.InfoId, OrderByType.Desc);

            return query.ToPage(pager);
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="LogLogin"></param>
        /// <returns></returns>
        public void AddLogLogin(LogLogin LogLogin)
        {
            Insert(LogLogin);
        }

        /// <summary>
        /// 清空登录日志
        /// </summary>
        public void TruncateLogLogin()
        {
            Truncate();
        }

        /// <summary>
        /// 删除登录日志
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DeleteLogLoginByIds(long[] ids)
        {
            return Delete(ids);
        }

        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="userName"></param>
        /// <exception cref="CustomizeException"></exception>
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

        /// <summary>
        /// 查询登录日志统计
        /// </summary>
        /// <returns></returns>
        public List<StatiLogLoginDto> GetStatiLogLogin()
        {
            var time = DateTime.Now;

            //如果是查询当月那么 time就是 DateTime.Now
            var days = (time.AddMonths(1) - time).Days;//获取当月天数
            var dayArray = Enumerable.Range(1, days).Select(it => Convert.ToDateTime(time.ToString("yyyy-MM-" + it))).ToList();//转成时间数组

            var queryableLeft = Context.Reportable(dayArray)
                .ToQueryable<DateTime>();

            var queryableRight = Context.Queryable<LogLogin>();
            var list = Context.Queryable(queryableLeft, queryableRight, JoinType.Left, (x1, x2)
                 => x2.LoginTime.ToString("yyyy-MM-dd") == x1.ColumnName.ToString("yyyy-MM-dd"))
                .GroupBy((x1, x2) => x1.ColumnName)
                .Where((x1, x2) => x1.ColumnName >= DateTime.Now.AddDays(-7) && x1.ColumnName <= DateTime.Now)
                .Select((x1, x2) => new StatiLogLoginDto()
                {
                    DeRepeatNum = SqlFunc.AggregateDistinctCount(x2.Ipaddr),
                    Num = SqlFunc.AggregateCount(x2.InfoId),
                    Date = x1.ColumnName,
                })
                .Mapper(it =>
                {
                    it.WeekName = Tools.GetWeekByDate(it.Date);//相当于ToList循环赋值
                }).ToList();
            return list;
        }
    }
}