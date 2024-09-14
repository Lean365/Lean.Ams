//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 工厂代码
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    [AppService(ServiceType = typeof(IInstPlantService), ServiceLifetime = LifeTime.Transient)]
    public class InstPlantService : BaseService<InstPlant>, IInstPlantService
    {
        /// <summary>
        /// 查询工厂代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstPlantDto> GetList(InstPlantQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mc005 asc")
                .Where(predicate.ToExpression())
                .ToPage<InstPlant, InstPlantDto>(parm);

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
            int count = Count(it => it.Id.ToString() == enterString);
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
        public InstPlant GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工厂代码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstPlant AddInstPlant(InstPlant model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改工厂代码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstPlant(InstPlant model)
        {
            return Update(model, true, "修改工厂代码");
        }

        /// <summary>
        /// 导入工厂代码
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstPlant(List<InstPlant> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Mc002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Mc003.IsEmpty(), "性质不能为空")
                .SplitError(x => x.Item.Mc004.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.Mc005.IsEmpty(), "工厂不能为空")
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
        /// 导出工厂代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstPlantDto> ExportList(InstPlantQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstPlantDto()
                {
                    //查询字典: <性质>
                    Mc003Label = it.Mc003.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <类别>
                    Mc004Label = it.Mc004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <国家>
                    Mc022Label = it.Mc022.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <语言>
                    Mc031Label = it.Mc031.GetConfigValue<SysDictData>("sys_lang_type"),
                    //查询字典: <软删除>
                    //IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_Is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<InstPlant> QueryExp(InstPlantQueryDto parm)
        {
            var predicate = Expressionable.Create<InstPlant>();

            //查询字段: <性质>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc003), it => it.Mc003 == parm.Mc003);
            //查询字段: <类别>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc004), it => it.Mc004 == parm.Mc004);
            //查询字段: <工厂>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc005), it => it.Mc005.Contains(parm.Mc005));
            //查询字段: <名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc006), it => it.Mc006.Contains(parm.Mc006));
            //查询字段: <评估范围>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc007), it => it.Mc007.Contains(parm.Mc007));
            //查询字段: <城市>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc015), it => it.Mc015 == parm.Mc015);
            //查询字段: <采购组织>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc016), it => it.Mc016.Contains(parm.Mc016));
            //查询字段: <销售组织>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc017), it => it.Mc017.Contains(parm.Mc017));
            //查询字段: <国家>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc022), it => it.Mc022 == parm.Mc022);
            //查询字段: <语言>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mc031), it => it.Mc031 == parm.Mc031);
            return predicate;
        }
    }
}