using Ams.Kernel.Model.Dto.Monitor;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 验证码
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(ISmsLogService), ServiceLifetime = LifeTime.Transient)]
    public class SmsLogService : BaseService<SmsLog>, ISmsLogService
    {
        /// <summary>
        /// 查询验证码记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm)
        {
            var predicate = Expressionable.Create<SmsLog>();

            predicate = predicate.AndIF(parm.Userid != null, it => it.Userid == parm.Userid);
            predicate = predicate.AndIF(parm.PhoneNum != null, it => it.PhoneNum == parm.PhoneNum);
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.AddTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.AddTime >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.AddTime <= parm.EndTime);
            predicate = predicate.AndIF(parm.SendType != null, it => it.SendType == parm.SendType);
            var response = Queryable()
                //.OrderBy("Id desc")
                .Where(predicate.ToExpression())
                .ToPage<SmsLog, SmsLogDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SmsLog GetInfo(long Id)
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
        public SmsLog AddSmsLog(SmsLog model)
        {
            model.Id = Context.Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
    }
}