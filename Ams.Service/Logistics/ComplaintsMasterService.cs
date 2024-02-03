using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:38:17)
    /// </summary>
    [AppService(ServiceType = typeof(IComplaintsMasterService), ServiceLifetime = LifeTime.Transient)]
    public class ComplaintsMasterService : BaseService<ComplaintsMaster>, IComplaintsMasterService
    {
        /// <summary>
        /// 查询主客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ComplaintsMasterDto> GetList(ComplaintsMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<ComplaintsMaster, ComplaintsMasterDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. QmcmSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmcmSFID"></param>
        /// <returns></returns>
        public ComplaintsMaster GetInfo(long QmcmSFID)
        {
            var response = Queryable()
                .Where(x => x.QmcmSFID == QmcmSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加主客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ComplaintsMaster AddComplaintsMaster(ComplaintsMaster model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改主客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateComplaintsMaster(ComplaintsMaster model)
        {
            return Update(model, true, "修改主客诉管理");
        }


        /// <summary>
        /// 导出主客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ComplaintsMasterDto> ExportList(ComplaintsMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ComplaintsMasterDto()
                {
                    QmcmCustomerLabel = it.QmcmCustomer.GetConfigValue<Kernel.Model.System.SysDictData>("sql_cus_list"),
                    QmcmItemLabel = it.QmcmItem.GetConfigValue<Kernel.Model.System.SysDictData>("sql_moc_item"),
                    QmcmAdmitDeptLabel = it.QmcmAdmitDept.GetConfigValue<Kernel.Model.System.SysDictData>("sql_dept_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<ComplaintsMaster> QueryExp(ComplaintsMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<ComplaintsMaster>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmCustomer), it => it.QmcmCustomer.Contains(parm.QmcmCustomer));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmModel), it => it.QmcmModel.Contains(parm.QmcmModel));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmItem), it => it.QmcmItem.Contains(parm.QmcmItem));
            predicate = predicate.AndIF(parm.BeginQmcmReceivingDate == null, it => it.QmcmReceivingDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginQmcmReceivingDate != null, it => it.QmcmReceivingDate >= parm.BeginQmcmReceivingDate);
            predicate = predicate.AndIF(parm.EndQmcmReceivingDate != null, it => it.QmcmReceivingDate <= parm.EndQmcmReceivingDate);
            return predicate;
        }
    }
}