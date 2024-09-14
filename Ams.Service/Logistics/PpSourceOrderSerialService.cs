//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源订单序列号
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:43:48
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceOrderSerialService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceOrderSerialService : BaseService<PpSourceOrderSerial>, IPpSourceOrderSerialService
    {
        /// <summary>
        /// 查询源订单序列号列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderSerialDto> GetList(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Zg003 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceOrderSerial, PpSourceOrderSerialDto>(parm);

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
        public PpSourceOrderSerial GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加源订单序列号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceOrderSerial AddPpSourceOrderSerial(PpSourceOrderSerial model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改源订单序列号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceOrderSerial(PpSourceOrderSerial model)
        {
            return Update(model, true, "修改源订单序列号");
        }

        /// <summary>
        /// 导入源订单序列号
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceOrderSerial(List<PpSourceOrderSerial> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Zg002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Zg003.IsEmpty(), "生产订单不能为空")
                .SplitError(x => x.Item.Zg004.IsEmpty(), "品号不能为空")
                .SplitError(x => x.Item.Zg005.IsEmpty(), "序列号不能为空")
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
        /// 导出源订单序列号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceOrderSerialDto> ExportList(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceOrderSerialDto()
                {
                    //查询字典: <工厂> 
                    Zg002Label = it.Zg002.GetConfigValue<SysDictData>("sql_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpSourceOrderSerial> QueryExp(PpSourceOrderSerialQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceOrderSerial>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zg002), it => it.Zg002 == parm.Zg002);
            //查询字段: <品号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zg004), it => it.Zg004.Contains(parm.Zg004));
            return predicate;
        }
    }
}