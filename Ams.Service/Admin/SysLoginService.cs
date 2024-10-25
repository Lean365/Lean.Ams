﻿using Ams.Common;
using Ams.Repository;
using Ams.Service.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using UAParser;

namespace Ams.Service.Admin
{
    /// <summary>
    /// 登录
    /// </summary>
    [AppService(ServiceType = typeof(ISysLoginService), ServiceLifetime = LifeTime.Transient)]
    public class SysLoginService : BaseService<LoginLog>, ISysLoginService
    {
        private readonly ISysUserService SysUserService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SysLoginService(
            ISysUserService sysUserService,
            IHttpContextAccessor httpContextAccessor,
            IStringLocalizer<SharedResource> localizer)
        {
            SysUserService = sysUserService;
            this.httpContextAccessor = httpContextAccessor;
            _localizer = localizer;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="logininfor"></param>
        /// <param name="loginBody"></param>
        /// <returns></returns>
        public SysUser Login(LoginBodyDto loginBody, LoginLog logininfor)
        {
            if (loginBody.Password.Length != 32)
            {
                loginBody.Password = NETCore.Encrypt.EncryptProvider.Md5(loginBody.Password);
            }
            SysUser user = SysUserService.Login(loginBody);
            logininfor.UserName = loginBody.Username;
            logininfor.IsStatus = 1;
            logininfor.LoginTime = DateTime.Now;
            logininfor.Ipaddr = loginBody.LoginIP;
            logininfor.ClientId = loginBody.ClientId;
            logininfor.Create_by = loginBody.Username;
            ClientInfo clientInfo = httpContextAccessor.HttpContext.GetClientInfo();
            logininfor.Browser = clientInfo.ToString();
            logininfor.Os = clientInfo.OS.ToString();

            if (user == null || user.UserId <= 0)
            {
                logininfor.Msg = _localizer["login_pwd_error"].Value;
                AddLoginInfo(logininfor);
                throw new CustomException(ResultCode.LOGIN_ERROR, logininfor.Msg, false);
            }
            logininfor.UserId = user.UserId;
            if (user.IsStatus == 1)
            {
                logininfor.Msg = _localizer["login_user_disabled"].Value;//該用戶已禁用
                AddLoginInfo(logininfor);
                throw new CustomException(ResultCode.LOGIN_ERROR, logininfor.Msg, false);
            }

            logininfor.IsStatus = 0;
            logininfor.Msg = "登录成功";
            AddLoginInfo(logininfor);
            SysUserService.UpdateLoginInfo(loginBody.LoginIP, user.UserId);
            return user;
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="logininfor"></param>
        /// <param name="loginBody"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public SysUser PhoneLogin(PhoneLoginDto loginBody, LoginLog logininfor, SysUser user)
        {
            logininfor.UserName = user.UserName;
            logininfor.IsStatus = 1;
            logininfor.LoginTime = DateTime.Now;
            logininfor.Ipaddr = loginBody.LoginIP;

            ClientInfo clientInfo = httpContextAccessor.HttpContext.GetClientInfo();
            logininfor.Browser = clientInfo.ToString();
            logininfor.Os = clientInfo.OS.ToString();

            if (user.IsStatus == 1)
            {
                logininfor.Msg = _localizer["login_user_disabled"].Value;
                AddLoginInfo(logininfor);
                throw new CustomException(ResultCode.LOGIN_ERROR, logininfor.Msg, false);
            }

            logininfor.IsStatus = 0;
            logininfor.Msg = "登录成功";
            AddLoginInfo(logininfor);
            SysUserService.UpdateLoginInfo(loginBody.LoginIP, user.UserId);
            return user;
        }

        /// <summary>
        /// 查询登录日志
        /// </summary>
        /// <param name="logininfoDto"></param>
        /// <returns></returns>
        public PagedInfo<LoginLog> GetLoginLog(LoginLogQueryDto logininfoDto)
        {
            var exp = Expressionable.Create<LoginLog>();

            exp.AndIF(logininfoDto.BeginTime == null, it => it.LoginTime >= new DateTime(DateTime.Now.Year, 1, 1)); //DateTime.Now.ToShortDateString().ParseToDateTime());
            exp.AndIF(logininfoDto.BeginTime != null, it => it.LoginTime >= logininfoDto.BeginTime && it.LoginTime <= logininfoDto.EndTime);
            exp.AndIF(logininfoDto.UserId != null, it => it.UserId == logininfoDto.UserId);
            exp.AndIF(logininfoDto.IsStatus != -1, f => f.IsStatus == logininfoDto.IsStatus);
            exp.AndIF(logininfoDto.Ipaddr.IfNotEmpty(), f => f.Ipaddr == logininfoDto.Ipaddr);
            exp.AndIF(logininfoDto.UserName.IfNotEmpty(), f => f.UserName.Contains(logininfoDto.UserName));

            var query = Queryable().Where(exp.ToExpression())
            .OrderBy(it => it.InfoId, OrderByType.Desc);

            return query.ToPage(logininfoDto);
        }

        /// <summary>
        /// 记录登录日志
        /// </summary>
        /// <param name="LoginLog"></param>
        /// <returns></returns>
        public void AddLoginInfo(LoginLog LoginLog)
        {
            Insert(LoginLog);
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
        public int DeleteLogininforByIds(long[] ids)
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
                throw new CustomException(ResultCode.LOGIN_ERROR, $"你的账号已被锁,剩余{Math.Round(ts.TotalMinutes, 0)}分钟");
            }
        }

        public List<StatiLogDto> GetStatiLoginlog()
        {
            var time = DateTime.Now;

            //如果是查询当月那么 time就是 DateTime.Now
            var days = (time.AddMonths(1) - time).Days;//获取当月天数
            var dayArray = Enumerable.Range(1, days).Select(it => Convert.ToDateTime(time.ToString("yyyy-MM-" + it))).ToList();//转成时间数组

            var queryableLeft = Context.Reportable(dayArray)
                .ToQueryable<DateTime>();

            var queryableRight = Context.Queryable<LoginLog>();
            var list = Context.Queryable(queryableLeft, queryableRight, JoinType.Left, (x1, x2)
                 => x2.LoginTime.ToString("yyyy-MM-dd") == x1.ColumnName.ToString("yyyy-MM-dd"))
                .GroupBy((x1, x2) => x1.ColumnName)
                .Where((x1, x2) => x1.ColumnName >= DateTime.Now.AddDays(-7) && x1.ColumnName <= DateTime.Now)
                .Select((x1, x2) => new StatiLogDto()
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