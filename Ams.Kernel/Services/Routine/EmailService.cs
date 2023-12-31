using Ams.Infrastructure.Attribute;
using Ams.Model;
using Ams.Repository;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Services.IService.Routine;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 邮件发送记录Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IEmailService), ServiceLifetime = LifeTime.Transient)]
    public class EmailService : BaseService<Email>, IEmailService
    {
        /// <summary>
        /// 查询邮件发送记录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<EmailDto> GetList(EmailQueryDto parm)
        {
            var predicate = Expressionable.Create<Email>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FromEmail), it => it.FromEmail == parm.FromEmail);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Subject), it => it.Subject.Contains(parm.Subject));
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.AddTime >= DateTime.Now.AddDays(-7).ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.AddTime >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.AddTime <= parm.EndTime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Email, EmailDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Email GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加邮件发送记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Email AddEmail(Email model)
        {
            model.Id = Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改邮件发送记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateEmail(Email model)
        {
            return Update(model, true);
        }
    }
}