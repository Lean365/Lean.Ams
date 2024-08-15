using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 不合格联络
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    [AppService(ServiceType = typeof(IQmUnqualifiedContactletterService), ServiceLifetime = LifeTime.Transient)]
    public class QmUnqualifiedContactletterService : BaseService<QmUnqualifiedContactletter>, IQmUnqualifiedContactletterService
    {
        /// <summary>
        /// 查询不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmUnqualifiedContactletterDto> GetList(QmUnqualifiedContactletterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmUnqualifiedContactletter, QmUnqualifiedContactletterDto>(parm);

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
            int count = Count(it => it. QucdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QucdSfId"></param>
        /// <returns></returns>
        public QmUnqualifiedContactletter GetInfo(long QucdSfId)
        {
            var response = Queryable()
                .Where(x => x.QucdSfId == QucdSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加不合格联络
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmUnqualifiedContactletter AddQmUnqualifiedContactletter(QmUnqualifiedContactletter model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改不合格联络
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmUnqualifiedContactletter(QmUnqualifiedContactletter model)
        {
            return Update(model, true, "修改不合格联络");
        }

        /// <summary>
        /// 导入不合格联络
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmUnqualifiedContactletter(List<QmUnqualifiedContactletter> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QucdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.QucdInspector.IsEmpty(), "检查员不能为空")
                .SplitError(x => x.Item.QucdLine.IsEmpty(), "班组不能为空")
                .SplitError(x => x.Item.QucdOrder.IsEmpty(), "订单不能为空")
                .SplitError(x => x.Item.QucdMaterial.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.QucdCheckDate.IsEmpty(), "查验日期不能为空")
                .SplitError(x => x.Item.QucdRejectQty.IsEmpty(), "验退数不能为空")
                .SplitError(x => x.Item.QucdJudgmentLevel.IsEmpty(), "级别不能为空")
                .SplitError(x => x.Item.QucdCheckNotes.IsEmpty(), "判定说明不能为空")
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
        /// 导出不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmUnqualifiedContactletterDto> ExportList(QmUnqualifiedContactletterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmUnqualifiedContactletterDto()
                {
                    QucdInspectorLabel = it.QucdInspector.GetConfigValue<SysDictData>("sql_inspector_list"),
                    QucdJudgmentLevelLabel = it.QucdJudgmentLevel.GetConfigValue<SysDictData>("sys_insp_bad"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmUnqualifiedContactletter> QueryExp(QmUnqualifiedContactletterQueryDto parm)
        {
            var predicate = Expressionable.Create<QmUnqualifiedContactletter>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdInspector), it => it.QucdInspector == parm.QucdInspector);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdLine), it => it.QucdLine.Contains(parm.QucdLine));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdOrder), it => it.QucdOrder.Contains(parm.QucdOrder));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdModels), it => it.QucdModels.Contains(parm.QucdModels));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdMaterial), it => it.QucdMaterial.Contains(parm.QucdMaterial));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdRegion), it => it.QucdRegion.Contains(parm.QucdRegion));
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQucdCheckDate == null, it => it.QucdCheckDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQucdCheckDate == null, it => it.QucdCheckDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQucdCheckDate != null, it => it.QucdCheckDate >= parm.BeginQucdCheckDate);
            predicate = predicate.AndIF(parm.EndQucdCheckDate != null, it => it.QucdCheckDate <= parm.EndQucdCheckDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdProLot), it => it.QucdProLot.Contains(parm.QucdProLot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdProSerial), it => it.QucdProSerial.Contains(parm.QucdProSerial));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdJudgmentLevel), it => it.QucdJudgmentLevel == parm.QucdJudgmentLevel);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.QucdIssueno), it => it.QucdIssueno.Contains(parm.QucdIssueno));
            return predicate;
        }
    }
}