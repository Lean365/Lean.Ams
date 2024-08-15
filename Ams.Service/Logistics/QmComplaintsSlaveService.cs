using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 从客诉管理
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    [AppService(ServiceType = typeof(IQmComplaintsSlaveService), ServiceLifetime = LifeTime.Transient)]
    public class QmComplaintsSlaveService : BaseService<QmComplaintsSlave>, IQmComplaintsSlaveService
    {
        /// <summary>
        /// 查询从客诉管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsSlaveDto> GetList(QmComplaintsSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmComplaintsSlave, QmComplaintsSlaveDto>(parm);

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
            int count = Count(it => it. QmcsSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmcsSfId"></param>
        /// <returns></returns>
        public QmComplaintsSlave GetInfo(long QmcsSfId)
        {
            var response = Queryable()
                .Where(x => x.QmcsSfId == QmcsSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加从客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmComplaintsSlave AddQmComplaintsSlave(QmComplaintsSlave model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改从客诉管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmComplaintsSlave(QmComplaintsSlave model)
        {
            return Update(model, true, "修改从客诉管理");
        }

        /// <summary>
        /// 导入从客诉管理
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmComplaintsSlave(List<QmComplaintsSlave> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QmcsSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QmcsIssuesNo.IsEmpty(), "外部客诉No.不能为空")
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
        /// 导出从客诉管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmComplaintsSlaveDto> ExportList(QmComplaintsSlaveQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmComplaintsSlaveDto()
                {
                    QmcsLineLabel = it.QmcsLine.GetConfigValue<SysDictData>("sql_line_list"),
                    QmcsOperatorLabel = it.QmcsOperator.GetConfigValue<SysDictData>("sql_ec_group"),
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
        private static Expressionable<QmComplaintsSlave> QueryExp(QmComplaintsSlaveQueryDto parm)
        {
            var predicate = Expressionable.Create<QmComplaintsSlave>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcsIssuesNo), it => it.QmcsIssuesNo == parm.QmcsIssuesNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcsLine), it => it.QmcsLine == parm.QmcsLine);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmcsProcessingDate == null, it => it.QmcsProcessingDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmcsProcessingDate == null, it => it.QmcsProcessingDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmcsProcessingDate != null, it => it.QmcsProcessingDate >= parm.BeginQmcsProcessingDate);
            predicate = predicate.AndIF(parm.EndQmcsProcessingDate != null, it => it.QmcsProcessingDate <= parm.EndQmcsProcessingDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmcsOperator), it => it.QmcsOperator == parm.QmcsOperator);
            return predicate;
        }
    }
}