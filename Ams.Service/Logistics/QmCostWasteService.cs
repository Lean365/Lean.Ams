using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 废弃部品
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    [AppService(ServiceType = typeof(IQmCostWasteService), ServiceLifetime = LifeTime.Transient)]
    public class QmCostWasteService : BaseService<QmCostWaste>, IQmCostWasteService
    {
        /// <summary>
        /// 查询废弃部品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostWasteDto> GetList(QmCostWasteQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<QmCostWaste, QmCostWasteDto>(parm);

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
            int count = Count(it => it. QcwdSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="QcwdSfId"></param>
        /// <returns></returns>
        public QmCostWaste GetInfo(long QcwdSfId)
        {
            var response = Queryable()
                .Where(x => x.QcwdSfId == QcwdSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加废弃部品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCostWaste AddQmCostWaste(QmCostWaste model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改废弃部品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCostWaste(QmCostWaste model)
        {
            return Update(model, true, "修改废弃部品");
        }

        /// <summary>
        /// 导入废弃部品
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCostWaste(List<QmCostWaste> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.QcwdSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.Qcwd003.IsEmpty(), "间接人员赁率不能为空")
                .SplitError(x => x.Item.Qcwd007.IsEmpty(), "废弃费用不能为空")
                .SplitError(x => x.Item.Qcwd008.IsEmpty(), "废弃数量不能为空")
                .SplitError(x => x.Item.Qcwd009.IsEmpty(), "部品单价不能为空")
                .SplitError(x => x.Item.Qcwd010.IsEmpty(), "废弃处理费用不能为空")
                .SplitError(x => x.Item.Qcwd011.IsEmpty(), "运费不能为空")
                .SplitError(x => x.Item.Qcwd012.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Qcwd013.IsEmpty(), "处理作业时间(分)不能为空")
                .SplitError(x => x.Item.Qcwd014.IsEmpty(), "关税不能为空")
                .SplitError(x => x.Item.Qcwd015.IsEmpty(), "处理发生其他费用不能为空")
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
        /// 导出废弃部品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostWasteDto> ExportList(QmCostWasteQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCostWasteDto()
                {
                    Qcwd002Label = it.Qcwd002.GetConfigValue<SysDictData>("sql_oph_model"),
                    QcwdrecLabel = it.Qcwdrec.GetConfigValue<SysDictData>("sql_inspector_list"),
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
        private static Expressionable<QmCostWaste> QueryExp(QmCostWasteQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCostWaste>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginQcwd001 == null, it => it.Qcwd001 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginQcwd001 == null, it => it.Qcwd001 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginQcwd001 != null, it => it.Qcwd001 >= parm.BeginQcwd001);
            predicate = predicate.AndIF(parm.EndQcwd001 != null, it => it.Qcwd001 <= parm.EndQcwd001);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcwd002), it => it.Qcwd002 == parm.Qcwd002);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcwd004), it => it.Qcwd004 == parm.Qcwd004);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcwd016), it => it.Qcwd016 == parm.Qcwd016);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Qcwdrec), it => it.Qcwdrec == parm.Qcwdrec);
            return predicate;
        }
    }
}