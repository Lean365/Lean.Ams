using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 短信验证码
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(ILogSmsService), ServiceLifetime = LifeTime.Transient)]
    public class LogSmsService : BaseService<LogSms>, ILogSmsService
    {
        /// <summary>
        /// 查询验证码记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LogSmsDto> GetList(LogSmsQueryDto parm)
        {
            var predicate = Expressionable.Create<LogSms>();

            predicate = predicate.AndIF(parm.Userid != null, it => it.Userid == parm.Userid);
            predicate = predicate.AndIF(parm.PhoneNum != null, it => it.PhoneNum == parm.PhoneNum);
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
            predicate = predicate.AndIF(parm.SendType != null, it => it.SendType == parm.SendType);
            var response = Queryable()
                //.OrderBy("Id desc")
                .Where(predicate.ToExpression())
                .ToPage<LogSms, LogSmsDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public LogSms GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加验证码记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LogSms AddLogSms(LogSms model)
        {
            var httpContext = App.HttpContext;
            model.Create_by = HttpContextExtension.GetName(httpContext); //获取当前登录用户
            model.Id = Context.Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
    }
}