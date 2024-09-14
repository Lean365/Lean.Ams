//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceMaterialService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceMaterialService : BaseService<PpSourceMaterial>, IPpSourceMaterialService
    {
        /// <summary>
        /// 查询源物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceMaterialDto> GetList(PpSourceMaterialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Zd003 asc")
                .Where(predicate.ToExpression())
                .ToPage<PpSourceMaterial, PpSourceMaterialDto>(parm);

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
        public PpSourceMaterial GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加源物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceMaterial AddPpSourceMaterial(PpSourceMaterial model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改源物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceMaterial(PpSourceMaterial model)
        {
            return Update(model, true, "修改源物料");
        }

        /// <summary>
        /// 导入源物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceMaterial(List<PpSourceMaterial> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Zd002.IsEmpty(), "Plnt不能为空")
                .SplitError(x => x.Item.Zd003.IsEmpty(), "品目不能为空")
                .SplitError(x => x.Item.Zd014.IsEmpty(), "最小起订量不能为空")
                .SplitError(x => x.Item.Zd016.IsEmpty(), "舍入值不能为空")
                .SplitError(x => x.Item.Zd019.IsEmpty(), "自制天数不能为空")
                .SplitError(x => x.Item.Zd027.IsEmpty(), "移动平均价格/周期单价不能为空")
                .SplitError(x => x.Item.Zd034.IsEmpty(), "库存不能为空")
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
        /// 导出源物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceMaterialDto> ExportList(PpSourceMaterialQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceMaterialDto()
                {
                    //查询字典: <Plnt> 
                    Zd002Label = it.Zd002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <采购组> 
                    Zd010Label = it.Zd010.GetConfigValue<SysDictData>("sys_pur_group"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpSourceMaterial> QueryExp(PpSourceMaterialQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceMaterial>();

            //查询字段: <Plnt> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zd002), it => it.Zd002 == parm.Zd002);
            //查询字段: <品目> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zd003), it => it.Zd003.Contains(parm.Zd003));
            //查询字段: <采购组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zd010), it => it.Zd010 == parm.Zd010);
            return predicate;
        }
    }
}