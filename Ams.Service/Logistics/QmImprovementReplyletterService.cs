using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 分析对策
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    [AppService(ServiceType = typeof(IQmImprovementReplyletterService), ServiceLifetime = LifeTime.Transient)]
    public class QmImprovementReplyletterService : BaseService<QmImprovementReplyletter>, IQmImprovementReplyletterService
    {
        /// <summary>
        /// 查询分析对策列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmImprovementReplyletterDto> GetList(QmImprovementReplyletterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmImprovementReplyletter, QmImprovementReplyletterDto>(parm);

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
            int count = Count(it => it. QirdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QirdSfId"></param>
        /// <returns></returns>
        public QmImprovementReplyletter GetInfo(long QirdSfId)
        {
            var response = Queryable()
                .Where(x => x.QirdSfId == QirdSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加分析对策
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmImprovementReplyletter AddQmImprovementReplyletter(QmImprovementReplyletter model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改分析对策
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmImprovementReplyletter(QmImprovementReplyletter model)
        {
            return Update(model, true, "修改分析对策");
        }

        /// <summary>
        /// 导入分析对策
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmImprovementReplyletter(List<QmImprovementReplyletter> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QirdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QirdInspector.IsEmpty(), "检查员不能为空")
                .SplitError(x => x.Item.QirdLine.IsEmpty(), "班组不能为空")
                .SplitError(x => x.Item.QirdOrder.IsEmpty(), "订单不能为空")
                .SplitError(x => x.Item.QirdMaterial.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.QirdCheckDate.IsEmpty(), "检验日期不能为空")
                .SplitError(x => x.Item.QirdRejectQty.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.QirdJudgmentLevel.IsEmpty(), "不良级别不能为空")
                .SplitError(x => x.Item.QirdCheckNotes.IsEmpty(), "不良内容不能为空")
                .SplitError(x => x.Item.QirdPersonnel.IsEmpty(), "对策人员不能为空")
                .SplitError(x => x.Item.QirdVerify.IsEmpty(), "检证人员不能为空")
                .SplitError(x => x.Item.QirdCarryoutverify.IsEmpty(), "实施查证不能为空")
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
        /// 导出分析对策
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmImprovementReplyletterDto> ExportList(QmImprovementReplyletterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmImprovementReplyletterDto()
                {
                    QirdInspectorLabel = it.QirdInspector.GetConfigValue<SysDictData>("sql_inspector_list"),
                    QirdJudgmentLevelLabel = it.QirdJudgmentLevel.GetConfigValue<SysDictData>("sys_insp_bad"),
                    QirdCarryoutverifyLabel = it.QirdCarryoutverify.GetConfigValue<SysDictData>("sys_normal_whether"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmImprovementReplyletter> QueryExp(QmImprovementReplyletterQueryDto parm)
        {
            var predicate = Expressionable.Create<QmImprovementReplyletter>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdInspector), it => it.QirdInspector == parm.QirdInspector);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdLine), it => it.QirdLine.Contains(parm.QirdLine));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdOrder), it => it.QirdOrder.Contains(parm.QirdOrder));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdModels), it => it.QirdModels.Contains(parm.QirdModels));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdMaterial), it => it.QirdMaterial.Contains(parm.QirdMaterial));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdRegion), it => it.QirdRegion.Contains(parm.QirdRegion));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQirdCheckDate == null, it => it.QirdCheckDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQirdCheckDate == null, it => it.QirdCheckDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQirdCheckDate != null, it => it.QirdCheckDate >= parm.BeginQirdCheckDate);
            predicate = predicate.AndIF(parm.EndQirdCheckDate != null, it => it.QirdCheckDate <= parm.EndQirdCheckDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdProLot), it => it.QirdProLot.Contains(parm.QirdProLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdJudgmentLevel), it => it.QirdJudgmentLevel == parm.QirdJudgmentLevel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdCheckNotes), it => it.QirdCheckNotes == parm.QirdCheckNotes);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdPersonnel), it => it.QirdPersonnel == parm.QirdPersonnel);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQirdDate == null, it => it.QirdDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQirdDate == null, it => it.QirdDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQirdDate != null, it => it.QirdDate >= parm.BeginQirdDate);
            predicate = predicate.AndIF(parm.EndQirdDate != null, it => it.QirdDate <= parm.EndQirdDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QirdVerify), it => it.QirdVerify == parm.QirdVerify);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQirdCarryoutdate == null, it => it.QirdCarryoutdate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQirdCarryoutdate == null, it => it.QirdCarryoutdate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQirdCarryoutdate != null, it => it.QirdCarryoutdate >= parm.BeginQirdCarryoutdate);
            predicate = predicate.AndIF(parm.EndQirdCarryoutdate != null, it => it.QirdCarryoutdate <= parm.EndQirdCarryoutdate);
            predicate = predicate.AndIF(parm.QirdCarryoutverify != null, it => it.QirdCarryoutverify == parm.QirdCarryoutverify);
            return predicate;
        }
    }
}