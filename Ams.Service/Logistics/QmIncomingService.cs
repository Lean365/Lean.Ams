using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 进料检验
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    [AppService(ServiceType = typeof(IQmIncomingService), ServiceLifetime = LifeTime.Transient)]
    public class QmIncomingService : BaseService<QmIncoming>, IQmIncomingService
    {
        /// <summary>
        /// 查询进料检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIncomingDto> GetList(QmIncomingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmIncoming, QmIncomingDto>(parm);

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
            int count = Count(it => it. QminSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QminSfId"></param>
        /// <returns></returns>
        public QmIncoming GetInfo(long QminSfId)
        {
            var response = Queryable()
                .Where(x => x.QminSfId == QminSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加进料检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmIncoming AddQmIncoming(QmIncoming model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改进料检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmIncoming(QmIncoming model)
        {
            return Update(model, true, "修改进料检验");
        }

        /// <summary>
        /// 导入进料检验
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmIncoming(List<QmIncoming> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QminSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QminPurOrder.IsEmpty(), "采购订单不能为空")
                .SplitError(x => x.Item.QminMaterial.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.QminPurOrderQty.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.QminPurDate.IsEmpty(), "进货日期不能为空")
                .SplitError(x => x.Item.QminInspector.IsEmpty(), "检验员不能为空")
                .SplitError(x => x.Item.QminCheckDate.IsEmpty(), "检验日期不能为空")
                .SplitError(x => x.Item.QminInspectingItem.IsEmpty(), "检验项目不能为空")
                .SplitError(x => x.Item.QminSamplingLevel.IsEmpty(), "检验水准不能为空")
                .SplitError(x => x.Item.QminCheckMethod.IsEmpty(), "检验方式不能为空")
                .SplitError(x => x.Item.QminSamplingQty.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.QminJudgment.IsEmpty(), "判定不能为空")
                .SplitError(x => x.Item.QminJudgmentLevel.IsEmpty(), "不良级别不能为空")
                .SplitError(x => x.Item.QminRejectQty.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.QminAcceptQty.IsEmpty(), "验收数量不能为空")
                .SplitError(x => x.Item.QminCheckoutSequence.IsEmpty(), "检验次数不能为空")
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
        /// 导出进料检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmIncomingDto> ExportList(QmIncomingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmIncomingDto()
                {
                    QminInspectorLabel = it.QminInspector.GetConfigValue<SysDictData>("sql_ec_group"),
                    QminInspectingItemLabel = it.QminInspectingItem.GetConfigValue<SysDictData>("sql_insp_list"),
                    QminSamplingLevelLabel = it.QminSamplingLevel.GetConfigValue<SysDictData>("sys_insp_level"),
                    QminCheckMethodLabel = it.QminCheckMethod.GetConfigValue<SysDictData>("sys_insp_method"),
                    QminJudgmentLabel = it.QminJudgment.GetConfigValue<SysDictData>("sys_insp_judge"),
                    QminJudgmentLevelLabel = it.QminJudgmentLevel.GetConfigValue<SysDictData>("sys_insp_bad"),
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
        private static Expressionable<QmIncoming> QueryExp(QmIncomingQueryDto parm)
        {
            var predicate = Expressionable.Create<QmIncoming>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminPurOrder), it => it.QminPurOrder == parm.QminPurOrder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminMaterial), it => it.QminMaterial.Contains(parm.QminMaterial));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQminPurDate == null, it => it.QminPurDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQminPurDate == null, it => it.QminPurDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQminPurDate != null, it => it.QminPurDate >= parm.BeginQminPurDate);
            predicate = predicate.AndIF(parm.EndQminPurDate != null, it => it.QminPurDate <= parm.EndQminPurDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminInspector), it => it.QminInspector == parm.QminInspector);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQminCheckDate == null, it => it.QminCheckDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQminCheckDate == null, it => it.QminCheckDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQminCheckDate != null, it => it.QminCheckDate >= parm.BeginQminCheckDate);
            predicate = predicate.AndIF(parm.EndQminCheckDate != null, it => it.QminCheckDate <= parm.EndQminCheckDate);
            predicate = predicate.AndIF(parm.QminInspectingItem != null, it => parm.QminInspectingItem.Contains(it.QminInspectingItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminSamplingLevel), it => it.QminSamplingLevel == parm.QminSamplingLevel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminCheckMethod), it => it.QminCheckMethod == parm.QminCheckMethod);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminJudgment), it => it.QminJudgment == parm.QminJudgment);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QminJudgmentLevel), it => it.QminJudgmentLevel == parm.QminJudgmentLevel);
            return predicate;
        }
    }
}