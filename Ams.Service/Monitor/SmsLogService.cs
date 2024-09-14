using Ams.Repository;
using Ams.Service.Admin;

namespace Ams.Service.Monitor
{
    /// <summary>
    /// 短信验证Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISmsLogService), ServiceLifetime = LifeTime.Transient)]
    public class SmsLogService : BaseService<SmsLog>, ISmsLogService
    {
        /// <summary>
        /// 查询短信验证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SmsLogDto> GetList(SmsLogQueryDto parm)
        {
            var predicate = Expressionable.Create<SmsLog>();

            predicate = predicate.AndIF(parm.Userid != null, it => it.Userid == parm.Userid);
            predicate = predicate.AndIF(parm.PhoneNum != null, it => it.PhoneNum == parm.PhoneNum);
            predicate = predicate.AndIF(parm.BeginAddTime == null, it => it.SendTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginAddTime != null, it => it.SendTime >= parm.BeginAddTime);
            predicate = predicate.AndIF(parm.EndAddTime != null, it => it.SendTime <= parm.EndAddTime);
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
        /// 添加短信验证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SmsLog AddSmsLog(SmsLog model)
        {
            model.SendTime = Context.GetDate();

            var smsCode = RandomHelper.GenerateNum(6);
            var smsContent = $"验证码{smsCode},有效期10分钟。";

            var oneMinus = Queryable().Any(f => f.PhoneNum == model.PhoneNum && SqlFunc.DateDiff(DateType.Minute, f.SendTime, model.SendTime) <= 1);
            if (oneMinus)
            {
                throw new CustomException("请稍后再试");
            }
            var oneMinusIP = Queryable().Any(f => f.UserIP == model.UserIP && SqlFunc.DateDiff(DateType.Minute, f.SendTime, model.SendTime) <= 1);
            if (oneMinusIP)
            {
                throw new CustomException("请稍后再试");
            }
            model.SmsCode = smsCode;
            model.SmsContent = smsContent;
            model.Id = Context.Insertable(model).ExecuteReturnSnowflakeId();
            //TODO 发送验证码

            CacheService.SetPhoneCode(model.PhoneNum.ToString(), smsCode);

            return model;
        }
    }
}