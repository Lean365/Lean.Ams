//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 品质业务
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    [AppService(ServiceType = typeof(IQmCostOperationService), ServiceLifetime = LifeTime.Transient)]
    public class QmCostOperationService : BaseService<QmCostOperation>, IQmCostOperationService
    {
        /// <summary>
        /// 查询品质业务列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostOperationDto> GetList(QmCostOperationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mc003 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmCostOperation, QmCostOperationDto>(parm);

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
        public QmCostOperation GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加品质业务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmCostOperation AddQmCostOperation(QmCostOperation model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改品质业务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmCostOperation(QmCostOperation model)
        {
            return Update(model, true, "修改品质业务");
        }

        /// <summary>
        /// 导入品质业务
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmCostOperation(List<QmCostOperation> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mc002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Mc003.IsEmpty(), "日期不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "间接赁率不能为空")
                .SplitError(x => x.Item.Mc005.IsEmpty(), "IQC检查费用不能为空")
                .SplitError(x => x.Item.Mc006.IsEmpty(), "检查时间不能为空")
                .SplitError(x => x.Item.Mc007.IsEmpty(), "差旅费不能为空")
                .SplitError(x => x.Item.Mc008.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Mc010.IsEmpty(), "初期检定.定期检定业务费用不能为空")
                .SplitError(x => x.Item.Mc011.IsEmpty(), "作业时间不能为空")
                .SplitError(x => x.Item.Mc012.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Mc014.IsEmpty(), "测定器校正业务费用不能为空")
                .SplitError(x => x.Item.Mc015.IsEmpty(), "校正时间不能为空")
                .SplitError(x => x.Item.Mc016.IsEmpty(), "外部委托，搬运费不能为空")
                .SplitError(x => x.Item.Mc017.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Mc019.IsEmpty(), "其他通常费用不能为空")
                .SplitError(x => x.Item.Mc020.IsEmpty(), "通常作业时间不能为空")
                .SplitError(x => x.Item.Mc021.IsEmpty(), "通常其他费用不能为空")
                .SplitError(x => x.Item.Mc025.IsEmpty(), "出货检查费用不能为空")
                .SplitError(x => x.Item.Mc026.IsEmpty(), "检查时间不能为空")
                .SplitError(x => x.Item.Mc027.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Mc029.IsEmpty(), "信赖性评价.ORT业务费用不能为空")
                .SplitError(x => x.Item.Mc030.IsEmpty(), "评价时间不能为空")
                .SplitError(x => x.Item.Mc031.IsEmpty(), "其他费用不能为空")
                .SplitError(x => x.Item.Mc033.IsEmpty(), "顾客品质要求对应业务费用不能为空")
                .SplitError(x => x.Item.Mc034.IsEmpty(), "评价作业时间不能为空")
                .SplitError(x => x.Item.Mc035.IsEmpty(), "评价其他费用不能为空")
                .SplitError(x => x.Item.Mc037.IsEmpty(), "其他通常业务费用不能为空")
                .SplitError(x => x.Item.Mc038.IsEmpty(), "通常业务作业时间不能为空")
                .SplitError(x => x.Item.Mc039.IsEmpty(), "通常业务其他费用不能为空")
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
        /// 导出品质业务
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmCostOperationDto> ExportList(QmCostOperationQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmCostOperationDto()
                {
                    //查询字典: <工厂> 
                    Mc002Label = it.Mc002.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmCostOperation> QueryExp(QmCostOperationQueryDto parm)
        {
            var predicate = Expressionable.Create<QmCostOperation>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc002), it => it.Mc002 == parm.Mc002);
            //查询字段: <日期> 
            //predicate = predicate.AndIF(parm.BeginMc003 == null, it => it.Mc003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMc003 != null, it => it.Mc003 >= parm.BeginMc003);
            //predicate = predicate.AndIF(parm.EndMc003 != null, it => it.Mc003 <= parm.EndMc003);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMc003 == null, it => it.Mc003 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMc003 == null, it => it.Mc003 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMc003 != null, it => it.Mc003 >= parm.BeginMc003);
            predicate = predicate.AndIF(parm.EndMc003 != null, it => it.Mc003 <= parm.EndMc003);
            return predicate;
        }
    }
}