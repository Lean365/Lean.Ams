//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 返工改修
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:47:36
    /// </summary>
    [AppService(ServiceType = typeof(IQmCostReworkService), ServiceLifetime = LifeTime.Transient)]
    public class QmCostReworkService : BaseService<QmCostRework>, IQmCostReworkService
    {
        /// <summary>
        /// 查询返工改修列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostReworkDto> GetList(QmCostReworkQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Md003 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmCostRework, QmCostReworkDto>(parm);

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
        public QmCostRework GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加返工改修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCostRework AddQmCostRework(QmCostRework model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改返工改修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCostRework(QmCostRework model)
        {
            return Update(model, true, "修改返工改修");
        }

        /// <summary>
        /// 导入返工改修
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCostRework(List<QmCostRework> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Md002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Md003.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Md006.IsEmpty(), "直接人员赁率不能为空")
                .SplitError(x => x.Item.Md007.IsEmpty(), "间接人员赁率不能为空")
                .SplitError(x => x.Item.Md009.IsEmpty(), "检讨.调查.试验费用不能为空")
                .SplitError(x => x.Item.Md010.IsEmpty(), "检讨会使用时间(分)不能为空")
                .SplitError(x => x.Item.Md011.IsEmpty(), "直接人员参加人数不能为空")
                .SplitError(x => x.Item.Md012.IsEmpty(), "间接人员参加人数不能为空")
                .SplitError(x => x.Item.Md013.IsEmpty(), "调查评价试验工作时间(分)不能为空")
                .SplitError(x => x.Item.Md014.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Md015.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Md016.IsEmpty(), "其他作业時間(分)不能为空")
                .SplitError(x => x.Item.Md017.IsEmpty(), "其他设备购入费,工程费,搬运费不能为空")
                .SplitError(x => x.Item.Md018.IsEmpty(), "需要不良改修对应不能为空")
                .SplitError(x => x.Item.Md023.IsEmpty(), "选别.改修费用不能为空")
                .SplitError(x => x.Item.Md024.IsEmpty(), "选别.改修时间(分)不能为空")
                .SplitError(x => x.Item.Md025.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Md026.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Md027.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Md028.IsEmpty(), "选别.改修其他费用不能为空")
                .SplitError(x => x.Item.Md030.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Md033.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Md034.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Md040.IsEmpty(), "选别.改修费用不能为空")
                .SplitError(x => x.Item.Md041.IsEmpty(), "选别.改修时间(分)不能为空")
                .SplitError(x => x.Item.Md042.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Md043.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Md044.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Md045.IsEmpty(), "选别.改修其他费用不能为空")
                .SplitError(x => x.Item.Md047.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Md050.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Md051.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Md057.IsEmpty(), "选别.改修费用不能为空")
                .SplitError(x => x.Item.Md058.IsEmpty(), "选别.改修时间(分)不能为空")
                .SplitError(x => x.Item.Md059.IsEmpty(), "再检查时间(分)不能为空")
                .SplitError(x => x.Item.Md060.IsEmpty(), "交通费、旅费不能为空")
                .SplitError(x => x.Item.Md061.IsEmpty(), "仓库管理费不能为空")
                .SplitError(x => x.Item.Md062.IsEmpty(), "选别.改修其他费用不能为空")
                .SplitError(x => x.Item.Md064.IsEmpty(), "向顾客的费用请求不能为空")
                .SplitError(x => x.Item.Md067.IsEmpty(), "请求费用不能为空")
                .SplitError(x => x.Item.Md068.IsEmpty(), "其他费用不能为空")
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
        /// 导出返工改修
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostReworkDto> ExportList(QmCostReworkQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCostReworkDto()
                {
                    //查询字典: <工厂> 
                    Md002Label = it.Md002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <机种> 
                    Md004Label = it.Md004.GetConfigValue<SysDictData>("sql_sap_model"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmCostRework> QueryExp(QmCostReworkQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCostRework>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md002), it => it.Md002 == parm.Md002);
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMd003 == null, it => it.Md003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMd003 != null, it => it.Md003 >= parm.BeginMd003);
            //predicate = predicate.AndIF(parm.EndMd003 != null, it => it.Md003 <= parm.EndMd003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMd003 == null, it => it.Md003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMd003 == null, it => it.Md003 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMd003 != null, it => it.Md003 >= parm.BeginMd003);
            predicate = predicate.AndIF(parm.EndMd003 != null, it => it.Md003 <= parm.EndMd003);
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md004), it => it.Md004 == parm.Md004);
            return predicate;
        }
    }
}