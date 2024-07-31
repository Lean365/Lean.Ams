using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 出货检验
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    [AppService(ServiceType = typeof(IQmOutgoingService), ServiceLifetime = LifeTime.Transient)]
    public class QmOutgoingService : BaseService<QmOutgoing>, IQmOutgoingService
    {
        /// <summary>
        /// 查询出货检验列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmOutgoingDto> GetList(QmOutgoingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmOutgoing, QmOutgoingDto>(parm);

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
            int count = Count(it => it. QmoutSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QmoutSfId"></param>
        /// <returns></returns>
        public QmOutgoing GetInfo(long QmoutSfId)
        {
            var response = Queryable()
                .Where(x => x.QmoutSfId == QmoutSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加出货检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmOutgoing AddQmOutgoing(QmOutgoing model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改出货检验
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmOutgoing(QmOutgoing model)
        {
            return Update(model, true, "修改出货检验");
        }

        /// <summary>
        /// 导入出货检验
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmOutgoing(List<QmOutgoing> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QmoutSfId.IsEmpty(), "QmoutSfId不能为空")
                .SplitError(x => x.Item.QmoutProOrder.IsEmpty(), "生产工单不能为空")
                .SplitError(x => x.Item.QmoutProLine.IsEmpty(), "班组不能为空")
                .SplitError(x => x.Item.QmoutProMaterial.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.QmoutProLot.IsEmpty(), "批次不能为空")
                .SplitError(x => x.Item.QmoutProSerial.IsEmpty(), "序号不能为空")
                .SplitError(x => x.Item.QmoutProQty.IsEmpty(), "送检数量不能为空")
                .SplitError(x => x.Item.QmoutProDate.IsEmpty(), "生产日期不能为空")
                .SplitError(x => x.Item.QmoutInspector.IsEmpty(), "检查员不能为空")
                .SplitError(x => x.Item.QmoutCheckDate.IsEmpty(), "查验日期不能为空")
                .SplitError(x => x.Item.QmoutInspectingItem.IsEmpty(), "检查项目不能为空")
                .SplitError(x => x.Item.QmoutSamplingLevel.IsEmpty(), "检验水准不能为空")
                .SplitError(x => x.Item.QmoutCheckMethod.IsEmpty(), "检验方式不能为空")
                .SplitError(x => x.Item.QmoutSamplingQty.IsEmpty(), "抽样数不能为空")
                .SplitError(x => x.Item.QmoutJudgment.IsEmpty(), "判定不能为空")
                .SplitError(x => x.Item.QmoutJudgmentLevel.IsEmpty(), "不良级别不能为空")
                .SplitError(x => x.Item.QmoutRejectQty.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.QmoutCheckNotes.IsEmpty(), "检查号码不能为空")
                .SplitError(x => x.Item.QmoutAcceptQty.IsEmpty(), "验收数量不能为空")
                .SplitError(x => x.Item.QmoutOrderQty.IsEmpty(), "订单数量不能为空")
                .SplitError(x => x.Item.QmoutCheckoutSequence.IsEmpty(), "检验次数不能为空")
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
        /// 导出出货检验
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmOutgoingDto> ExportList(QmOutgoingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmOutgoingDto()
                {
                    QmoutInspectorLabel = it.QmoutInspector.GetConfigValue<SysDictData>("sql_ec_group"),
                    QmoutInspectingItemLabel = it.QmoutInspectingItem.GetConfigValue<SysDictData>("sys_insp_type"),
                    QmoutSamplingLevelLabel = it.QmoutSamplingLevel.GetConfigValue<SysDictData>("sys_insp_level"),
                    QmoutCheckMethodLabel = it.QmoutCheckMethod.GetConfigValue<SysDictData>("sys_insp_method"),
                    QmoutJudgmentLabel = it.QmoutJudgment.GetConfigValue<SysDictData>("sys_insp_judge"),
                    QmoutJudgmentLevelLabel = it.QmoutJudgmentLevel.GetConfigValue<SysDictData>("sys_insp_bad"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmOutgoing> QueryExp(QmOutgoingQueryDto parm)
        {
            var predicate = Expressionable.Create<QmOutgoing>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProOrder), it => it.QmoutProOrder == parm.QmoutProOrder);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProLine), it => it.QmoutProLine.Contains(parm.QmoutProLine));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProModels), it => it.QmoutProModels.Contains(parm.QmoutProModels));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProMaterial), it => it.QmoutProMaterial.Contains(parm.QmoutProMaterial));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProLot), it => it.QmoutProLot.Contains(parm.QmoutProLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutProSerial), it => it.QmoutProSerial.Contains(parm.QmoutProSerial));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmoutProDate == null, it => it.QmoutProDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmoutProDate == null, it => it.QmoutProDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmoutProDate != null, it => it.QmoutProDate >= parm.BeginQmoutProDate);
            predicate = predicate.AndIF(parm.EndQmoutProDate != null, it => it.QmoutProDate <= parm.EndQmoutProDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutInspector), it => it.QmoutInspector == parm.QmoutInspector);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQmoutCheckDate == null, it => it.QmoutCheckDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQmoutCheckDate == null, it => it.QmoutCheckDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQmoutCheckDate != null, it => it.QmoutCheckDate >= parm.BeginQmoutCheckDate);
            predicate = predicate.AndIF(parm.EndQmoutCheckDate != null, it => it.QmoutCheckDate <= parm.EndQmoutCheckDate);
            predicate = predicate.AndIF(parm.QmoutInspectingItem != null, it => parm.QmoutInspectingItem.Contains(it.QmoutInspectingItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutSamplingLevel), it => it.QmoutSamplingLevel == parm.QmoutSamplingLevel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutCheckMethod), it => it.QmoutCheckMethod == parm.QmoutCheckMethod);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutJudgment), it => it.QmoutJudgment == parm.QmoutJudgment);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutJudgmentLevel), it => it.QmoutJudgmentLevel == parm.QmoutJudgmentLevel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QmoutCheckNotes), it => it.QmoutCheckNotes.Contains(parm.QmoutCheckNotes));
            return predicate;
        }
    }
}