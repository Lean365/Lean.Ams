//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 公司代码
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    [AppService(ServiceType = typeof(IInstCorpService), ServiceLifetime = LifeTime.Transient)]
    public class InstCorpService : BaseService<InstCorp>, IInstCorpService
    {
        /// <summary>
        /// 查询公司代码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstCorpDto> GetList(InstCorpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ma005 asc")
                .Where(predicate.ToExpression())
                .ToPage<InstCorp, InstCorpDto>(parm);

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
        public InstCorp GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加公司代码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstCorp AddInstCorp(InstCorp model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改公司代码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstCorp(InstCorp model)
        {
            return Update(model, true, "修改公司代码");
        }

        /// <summary>
        /// 导入公司代码
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstCorp(List<InstCorp> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Ma002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Ma003.IsEmpty(), "性质不能为空")
                .SplitError(x => x.Item.Ma004.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.Ma005.IsEmpty(), "代码不能为空")
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
        /// 导出公司代码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstCorpDto> ExportList(InstCorpQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstCorpDto()
                {
                    //查询字典: <性质>
                    Ma003Label = it.Ma003.GetConfigValue<SysDictData>("sys_nature_list"),
                    //查询字典: <类别>
                    Ma004Label = it.Ma004.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <国家>
                    Ma009Label = it.Ma009.GetConfigValue<SysDictData>("sql_global_country"),
                    //查询字典: <货币码>
                    Ma010Label = it.Ma010.GetConfigValue<SysDictData>("sql_global_currency"),
                    //查询字典: <语言>
                    Ma011Label = it.Ma011.GetConfigValue<SysDictData>("sys_lang_type"),
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
        private static Expressionable<InstCorp> QueryExp(InstCorpQueryDto parm)
        {
            var predicate = Expressionable.Create<InstCorp>();

            //查询字段: <性质>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003 == parm.Ma003);
            //查询字段: <类别>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma004), it => it.Ma004 == parm.Ma004);
            //查询字段: <代码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma005), it => it.Ma005.Contains(parm.Ma005));
            //查询字段: <简称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma006), it => it.Ma006.Contains(parm.Ma006));
            //查询字段: <名称>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma007), it => it.Ma007.Contains(parm.Ma007));
            //查询字段: <国家>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma009), it => it.Ma009 == parm.Ma009);
            //查询字段: <城市>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma008), it => it.Ma008 == parm.Ma008);
            //查询字段: <货币码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma010), it => it.Ma010 == parm.Ma010);
            //查询字段: <生产公司代码>
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma036), it => it.Ma036.Contains(parm.Ma036));
            return predicate;
        }
    }
}