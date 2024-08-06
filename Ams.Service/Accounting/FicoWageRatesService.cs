using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;
using Ams.Service.Accounting.IAccountingService;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 工资率
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    [AppService(ServiceType = typeof(IFicoWageRatesService), ServiceLifetime = LifeTime.Transient)]
    public class FicoWageRatesService : BaseService<FicoWageRates>, IFicoWageRatesService
    {
        /// <summary>
        /// 查询工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoWageRatesDto> GetList(FicoWageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<FicoWageRates, FicoWageRatesDto>(parm);

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
            int count = Count(it => it. FwSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FwSfId"></param>
        /// <returns></returns>
        public FicoWageRates GetInfo(long FwSfId)
        {
            var response = Queryable()
                .Where(x => x.FwSfId == FwSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FicoWageRates AddFicoWageRates(FicoWageRates model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFicoWageRates(FicoWageRates model)
        {
            return Update(model, true, "修改工资率");
        }

        /// <summary>
        /// 导入工资率
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportFicoWageRates(List<FicoWageRates> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FwSfId.IsEmpty(), "ID不能为空")
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
        /// 导出工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<FicoWageRatesDto> ExportList(FicoWageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new FicoWageRatesDto()
                {
                    FwCropLabel = it.FwCrop.GetConfigValue<SysDictData>("sys_crop_list"),
                    FwYmLabel = it.FwYm.GetConfigValue<SysDictData>("sql_fy_list"),
                    FwCcyLabel = it.FwCcy.GetConfigValue<SysDictData>("sql_ym_list"),
                    IsDeletedLabel = it.IsDeleted.GetConfigValue<SysDictData>("sys_is_deleted"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<FicoWageRates> QueryExp(FicoWageRatesQueryDto parm)
        {
            var predicate = Expressionable.Create<FicoWageRates>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwCrop), it => it.FwCrop == parm.FwCrop);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwYm), it => it.FwYm == parm.FwYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwCcy), it => it.FwCcy == parm.FwCcy);
            return predicate;
        }
    }
}