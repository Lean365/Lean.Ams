using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 主客诉管理
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:33:20
    /// </summary>
    [AppService(ServiceType = typeof(IQmComplaintsMasterService), ServiceLifetime = LifeTime.Transient)]
    public class QmComplaintsMasterService : BaseService<QmComplaintsMaster>, IQmComplaintsMasterService
    {
        /// <summary>
        /// 查询主客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsMasterDto> GetList(QmComplaintsMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmComplaintsMaster, QmComplaintsMasterDto>(parm);

            return response;
        }
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString)
        {
            int count = Count(it => it. QmcmSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmcmSfId"></param>
        /// <returns></returns>
        public QmComplaintsMaster GetInfo(long QmcmSfId)
        {
            var response = Queryable()
                .Where(x => x.QmcmSfId == QmcmSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加主客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmComplaintsMaster AddQmComplaintsMaster(QmComplaintsMaster model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改主客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmComplaintsMaster(QmComplaintsMaster model)
        {
            return Update(model, true, "修改主客诉管理");
        }

        /// <summary>
        /// 导入主客诉管理
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmComplaintsMaster(List<QmComplaintsMaster> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QmcmSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QmcmDocNo.IsEmpty(), "客诉No.不能为空")
                .SplitError(x => x.Item.QmcmIssuesNo.IsEmpty(), "外部客诉No.不能为空")
                .SplitError(x => x.Item.QmcmCustomer.IsEmpty(), "客户不能为空")
                .SplitError(x => x.Item.QmcmModel.IsEmpty(), "机种不能为空")
                .SplitError(x => x.Item.QmcmItem.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.QmcmRegion.IsEmpty(), "仕向不能为空")
                .SplitError(x => x.Item.QmcmReceivingDate.IsEmpty(), "接收日期不能为空")
                .SplitError(x => x.Item.QmcmFaultQty.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.QmcmSerialno.IsEmpty(), "序列号不能为空")
                .SplitError(x => x.Item.QmcmFaultDescription.IsEmpty(), "症状不能为空")
                .SplitError(x => x.Item.QmcmRootcauseanalysis.IsEmpty(), "分析不能为空")
                .SplitError(x => x.Item.QmcmAdmitDept.IsEmpty(), "承认部门不能为空")
                .SplitError(x => x.Item.QmcmAdmitDate.IsEmpty(), "承认日期不能为空")
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
                .SplitError(x => x.Item.IsDeleted.IsEmpty(), "软删除不能为空")
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出主客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsMasterDto> ExportList(QmComplaintsMasterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmComplaintsMasterDto()
                {
                    QmcmCustomerLabel = it.QmcmCustomer.GetConfigValue<SysDictData>("sql_cus_list"),
                    QmcmRegionLabel = it.QmcmRegion.GetConfigValue<SysDictData>("sql_sap_region"),
                    QmcmAdmitDeptLabel = it.QmcmAdmitDept.GetConfigValue<SysDictData>("sql_dept_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmComplaintsMaster> QueryExp(QmComplaintsMasterQueryDto parm)
        {
            var predicate = Expressionable.Create<QmComplaintsMaster>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmDocNo), it => it.QmcmDocNo.Contains(parm.QmcmDocNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmIssuesNo), it => it.QmcmIssuesNo.Contains(parm.QmcmIssuesNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmCustomer), it => it.QmcmCustomer.Contains(parm.QmcmCustomer));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmModel), it => it.QmcmModel == parm.QmcmModel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmItem), it => it.QmcmItem == parm.QmcmItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmRegion), it => it.QmcmRegion == parm.QmcmRegion);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmcmReceivingDate == null, it => it.QmcmReceivingDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmcmReceivingDate == null, it => it.QmcmReceivingDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmcmReceivingDate != null, it => it.QmcmReceivingDate >= parm.BeginQmcmReceivingDate);
            predicate = predicate.AndIF(parm.EndQmcmReceivingDate != null, it => it.QmcmReceivingDate <= parm.EndQmcmReceivingDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmRootcauseanalysis), it => it.QmcmRootcauseanalysis == parm.QmcmRootcauseanalysis);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcmAdmitDept), it => it.QmcmAdmitDept == parm.QmcmAdmitDept);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmcmAdmitDate == null, it => it.QmcmAdmitDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmcmAdmitDate == null, it => it.QmcmAdmitDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmcmAdmitDate != null, it => it.QmcmAdmitDate >= parm.BeginQmcmAdmitDate);
            predicate = predicate.AndIF(parm.EndQmcmAdmitDate != null, it => it.QmcmAdmitDate <= parm.EndQmcmAdmitDate);
            return predicate;
        }
    }
}