using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    [AppService(ServiceType = typeof(IFicoCostingDeptConsumingService), ServiceLifetime = LifeTime.Transient)]
    public class FicoCostingDeptConsumingService : BaseService<FicoCostingDeptConsuming>, IFicoCostingDeptConsumingService
    {
        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingDeptConsumingDto> GetList(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("DcLfmon desc")
                .Where(predicate.ToExpression())
                .ToPage<FicoCostingDeptConsuming, FicoCostingDeptConsumingDto>(parm);

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
            int count = Count(it => it. DcSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="DcSfId"></param>
        /// <returns></returns>
        public FicoCostingDeptConsuming GetInfo(long DcSfId)
        {
            var response = Queryable()
                .Where(x => x.DcSfId == DcSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoCostingDeptConsuming AddFicoCostingDeptConsuming(FicoCostingDeptConsuming model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoCostingDeptConsuming(FicoCostingDeptConsuming model)
        {
            return Update(model, true, "修改部门消耗");
        }

        /// <summary>
        /// 导入部门消耗
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoCostingDeptConsuming(List<FicoCostingDeptConsuming> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.DcSfId.IsEmpty(), "ID不能为空")
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
        /// 导出部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoCostingDeptConsumingDto> ExportList(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoCostingDeptConsumingDto()
                {
                    DcLfgjaLabel = it.DcLfgja.GetConfigValue<SysDictData>("sql_fy_list"),
                    DcLfmonLabel = it.DcLfmon.GetConfigValue<SysDictData>("sql_ym_list"),
                    DcBukrsLabel = it.DcBukrs.GetConfigValue<SysDictData>("sys_crop_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoCostingDeptConsuming> QueryExp(FicoCostingDeptConsumingQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoCostingDeptConsuming>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcLfgja), it => it.DcLfgja == parm.DcLfgja);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcLfmon), it => it.DcLfmon == parm.DcLfmon);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcBukrs), it => it.DcBukrs == parm.DcBukrs);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DcMatnr), it => it.DcMatnr.Contains(parm.DcMatnr));
            return predicate;
        }
    }
}