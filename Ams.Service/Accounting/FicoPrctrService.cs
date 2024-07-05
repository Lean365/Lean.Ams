using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 利润中心
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/5 11:21:00
    /// </summary>
    [AppService(ServiceType = typeof(IFicoPrctrService), ServiceLifetime = LifeTime.Transient)]
    public class FicoPrctrService : BaseService<FicoPrctr>, IFicoPrctrService
    {
        /// <summary>
        /// 查询利润中心列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoPrctrDto> GetList(FicoPrctrQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoPrctr, FicoPrctrDto>(parm);

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
            int count = Count(it => it. FpSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FpSFID"></param>
        /// <returns></returns>
        public FicoPrctr GetInfo(long FpSFID)
        {
            var response = Queryable()
                .Where(x => x.FpSFID == FpSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoPrctr AddFicoPrctr(FicoPrctr model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改利润中心
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoPrctr(FicoPrctr model)
        {
            return Update(model, true, "修改利润中心");
        }

        /// <summary>
        /// 导入利润中心
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoPrctr(List<FicoPrctr> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FpSFID.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.FpCorp.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FpCode.IsEmpty(), "代码不能为空")
                .SplitError(x => x.Item.FpName.IsEmpty(), "名称不能为空")
                .SplitError(x => x.Item.FpType.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.FpActDate.IsEmpty(), "有效从不能为空")
                .SplitError(x => x.Item.FpExpDate.IsEmpty(), "有效到不能为空")
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
        /// 导出利润中心
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoPrctrDto> ExportList(FicoPrctrQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoPrctrDto()
                {
                    FpCorpLabel = it.FpCorp.GetConfigValue<SysDictData>("sys_crop_list"),
                    FpTypeLabel = it.FpType.GetConfigValue<SysDictData>("sys_costs_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoPrctr> QueryExp(FicoPrctrQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoPrctr>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpCorp), it => it.FpCorp == parm.FpCorp);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpCode), it => it.FpCode.Contains(parm.FpCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpName), it => it.FpName.Contains(parm.FpName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FpType), it => it.FpType == parm.FpType);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginFpActDate == null, it => it.FpActDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginFpActDate == null, it => it.FpActDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginFpActDate != null, it => it.FpActDate >= parm.BeginFpActDate);
            predicate = predicate.AndIF(parm.EndFpActDate != null, it => it.FpActDate <= parm.EndFpActDate);
            return predicate;
        }
    }
}