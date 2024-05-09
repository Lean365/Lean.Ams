using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Model;
using Ams.Kernel.Services.IService.Routine;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 发送记录
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(IEmailSentItemsService), ServiceLifetime = LifeTime.Transient)]
    public class EmailSentItemsService : BaseService<EmailSentItems>, IEmailSentItemsService
    {
        /// <summary>
        /// 查询邮件发送记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EmailSentItemsDto> GetList(EmailSentItemsQueryDto parm)
        {
            var predicate = Expressionable.Create<EmailSentItems>();

            predicate = predicate.AndIF(parm.IsSend != null, it => it.IsSend == parm.IsSend);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FromEmail), it => it.FromEmail == parm.FromEmail);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Subject), it => it.Subject.Contains(parm.Subject));
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.AddDays(-7).ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<EmailSentItems, EmailSentItemsDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmailSentItems GetInfo(long Id)
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
        public EmailSentItems AddEmailSentItems(SendEmail sendEmailVo, string result)
        {
            var log = new EmailSentItems()
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
        public int UpdateEmailSentItems(EmailSentItems model)
        {
            return Update(model, true);
        }
    }
}