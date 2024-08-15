using Ams.Infrastructure.Model;
using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 邮件发送记录Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IEmailItemsService), ServiceLifetime = LifeTime.Transient)]
    public class EmailItemsService : BaseService<EmailItems>, IEmailItemsService
    {
        /// <summary>
        /// 查询邮件发送记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EmailItemsDto> GetList(EmailItemsQueryDto parm)
        {
            var predicate = Expressionable.Create<EmailItems>();

            predicate = predicate.AndIF(parm.IsSend != null, it => it.IsSend == parm.IsSend);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FromEmail), it => it.FromEmail == parm.FromEmail);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Subject), it => it.Subject.Contains(parm.Subject));
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.AddDays(-7).ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<EmailItems, EmailItemsDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmailItems GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加邮件发送记录
        /// </summary>
        /// <param name="sendEmailVo"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public EmailItems AddEmailLog(SendEmailDto sendEmailVo, string result)
        {
            var log = new EmailItems()
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
        /// 修改邮件发送记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateEmailLog(EmailItems model)
        {
            return Update(model, true);
        }
    }
}