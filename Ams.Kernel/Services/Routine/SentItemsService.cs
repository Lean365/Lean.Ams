using Ams.Kernel.Model.Dto.Routine;
using Ams.Repository;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 已发邮件
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(ISentItemsService), ServiceLifetime = LifeTime.Transient)]
    public class SentItemsService : BaseService<SentItems>, ISentItemsService
    {
        /// <summary>
        /// 查询已发邮件列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SentItemsDto> GetList(SentItemsQueryDto parm)
        {
            var predicate = Expressionable.Create<SentItems>();

            predicate = predicate.AndIF(parm.IsSend != null, it => it.IsSend == parm.IsSend);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FromEmail), it => it.FromEmail == parm.FromEmail);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Subject), it => it.Subject.Contains(parm.Subject));
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.AddDays(-7).ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SentItems, SentItemsDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SentItems GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加已发邮件
        /// </summary>
        /// <param name="sendEmailVo"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public SentItems AddSentItems(SendEmailDto sendEmailVo, string result)
        {
            var log = new SentItems()
            {
                EmailContent = sendEmailVo.HtmlContent,
                Subject = sendEmailVo.Subject,
                ToEmails = sendEmailVo.ToUser,
                Create_time = DateTime.Now,
                FromEmail = sendEmailVo.FromEmail,
                IsSend = sendEmailVo.IsSend ? 1 : 0,
                SendResult = result,
                FromName = sendEmailVo.FromName,
            };
            log.Id = Insertable(log).ExecuteReturnSnowflakeId();
            return log;
        }

        /// <summary>
        /// 修改已发邮件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSentItems(SentItems model)
        {
            return Update(model, true);
        }
    }
}