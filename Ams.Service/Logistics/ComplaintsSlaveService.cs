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
    /// 从客诉管理
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 17:05:54)
    /// </summary>
    [AppService(ServiceType = typeof(IComplaintsSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class ComplaintsSlaveService : BaseService<ComplaintsSlave>, IComplaintsSlaveService
    {
        /// <summary>
        /// 查询从客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ComplaintsSlaveDto> GetList(ComplaintsSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<ComplaintsSlave, ComplaintsSlaveDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. QmcsSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmcsSFID"></param>
        /// <returns></returns>
        public ComplaintsSlave GetInfo(long QmcsSFID)
        {
            var response = Queryable()
                .Where(x => x.QmcsSFID == QmcsSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加从客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ComplaintsSlave AddComplaintsSlave(ComplaintsSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改从客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateComplaintsSlave(ComplaintsSlave model)
        {
            return Update(model, true, "修改从客诉管理");
        }


        /// <summary>
        /// 导出从客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ComplaintsSlaveDto> ExportList(ComplaintsSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ComplaintsSlaveDto()
                {
                    QmcsLineLabel = it.QmcsLine.GetConfigValue<Kernel.Model.System.SysDictData>("sql_line_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<ComplaintsSlave> QueryExp(ComplaintsSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<ComplaintsSlave>();

            return predicate;
        }
    }
}