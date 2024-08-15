using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// bom核算
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    [AppService(ServiceType = typeof(IFicoCostingBomService), ServiceLifetime = LifeTime.Transient)]
    public class FicoCostingBomService : BaseService<FicoCostingBom>, IFicoCostingBomService
    {
        /// <summary>
        /// 查询bom核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingBomDto> GetList(FicoCostingBomQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("BcLfmon desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoCostingBom, FicoCostingBomDto>(parm);

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
            int count = Count(it => it. BcSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="BcSfId"></param>
        /// <returns></returns>
        public FicoCostingBom GetInfo(long BcSfId)
        {
            var response = Queryable()
                .Where(x => x.BcSfId == BcSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加bom核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoCostingBom AddFicoCostingBom(FicoCostingBom model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改bom核算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoCostingBom(FicoCostingBom model)
        {
            return Update(model, true, "修改bom核算");
        }

        /// <summary>
        /// 导入bom核算
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoCostingBom(List<FicoCostingBom> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.BcSfId.IsEmpty(), "ID不能为空")
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
        /// 导出bom核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingBomDto> ExportList(FicoCostingBomQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoCostingBomDto()
                {
                    BcWerksLabel = it.BcWerks.GetConfigValue<SysDictData>("sys_plant_list"),
                    BcLfgjaLabel = it.BcLfgja.GetConfigValue<SysDictData>("sql_fy_list"),
                    BcLfmonLabel = it.BcLfmon.GetConfigValue<SysDictData>("sql_ym_list"),
                    BcWaersLabel = it.BcWaers.GetConfigValue<SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoCostingBom> QueryExp(FicoCostingBomQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoCostingBom>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcWerks), it => it.BcWerks == parm.BcWerks);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcLfgja), it => it.BcLfgja == parm.BcLfgja);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcLfmon), it => it.BcLfmon == parm.BcLfmon);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcPrdha), it => it.BcPrdha.Contains(parm.BcPrdha));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BcMatnr), it => it.BcMatnr.Contains(parm.BcMatnr));
            return predicate;
        }
    }
}