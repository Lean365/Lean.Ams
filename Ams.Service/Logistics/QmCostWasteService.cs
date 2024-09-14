//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 废弃部品
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:46:48
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
                //.OrderBy("Me003 desc")
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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public QmCostWaste GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
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
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Me002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Me003.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Me005.IsEmpty(), "间接人员赁率不能为空")
                .SplitError(x => x.Item.Me006.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Me009.IsEmpty(), "废弃费用不能为空")
                .SplitError(x => x.Item.Me010.IsEmpty(), "废弃数量不能为空")
                .SplitError(x => x.Item.Me011.IsEmpty(), "部品单价不能为空")
                .SplitError(x => x.Item.Me012.IsEmpty(), "废弃处理费用不能为空")
                .SplitError(x => x.Item.Me013.IsEmpty(), "运费不能为空")
                .SplitError(x => x.Item.Me014.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Me015.IsEmpty(), "处理作业时间(分)不能为空")
                .SplitError(x => x.Item.Me016.IsEmpty(), "关税不能为空")
                .SplitError(x => x.Item.Me017.IsEmpty(), "处理发生其他费用不能为空")
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
                    //查询字典: <工厂> 
                    Me002Label = it.Me002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <机种> 
                    Me004Label = it.Me004.GetConfigValue<SysDictData>("sql_sap_model"),
                    //查询字典: <物料> 
                    Me006Label = it.Me006.GetConfigValue<SysDictData>("sql_mats_list"),
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

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me002), it => it.Me002 == parm.Me002);
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMe003 == null, it => it.Me003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMe003 != null, it => it.Me003 >= parm.BeginMe003);
            //predicate = predicate.AndIF(parm.EndMe003 != null, it => it.Me003 <= parm.EndMe003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMe003 == null, it => it.Me003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMe003 == null, it => it.Me003 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMe003 != null, it => it.Me003 >= parm.BeginMe003);
            predicate = predicate.AndIF(parm.EndMe003 != null, it => it.Me003 <= parm.EndMe003);
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me004), it => it.Me004 == parm.Me004);
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me006), it => it.Me006 == parm.Me006);
            return predicate;
        }
    }
}