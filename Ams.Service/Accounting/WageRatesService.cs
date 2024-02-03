using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;
using Aliyun.OSS;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 工资率
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 7:33:39)
    /// </summary>
    [AppService(ServiceType = typeof(IWageRatesService), ServiceLifetime = LifeTime.Transient)]
    public class WageRatesService : BaseService<WageRates>, IWageRatesService
    {
        /// <summary>
        /// 查询工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WageRatesDto> GetList(WageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WageRates, WageRatesDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it.FwCrop.ToString() + it.FwYm.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="FwSFID"></param>
        /// <returns></returns>
        public WageRates GetInfo(long FwSFID)
        {
            var response = Queryable()
                .Where(x => x.FwSFID == FwSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public WageRates AddWageRates(WageRates model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改工资率
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWageRates(WageRates model)
        {
            return Update(model, true, "修改工资率");
        }

        /// <summary>
        /// 导入工资率
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportWageRates(List<WageRates> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.FwSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.FwCrop.IsEmpty(), "公司不能为空")
                .SplitError(x => x.Item.FwYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.FwCcy.IsEmpty(), "币种不能为空")
                .SplitError(x => x.Item.FwSalesVolume.IsEmpty(), "销售额不能为空")
                .SplitError(x => x.Item.FwWorkingDays.IsEmpty(), "工作天数不能为空")
                .SplitError(x => x.Item.FwDirectWageRate.IsEmpty(), "直接工资率不能为空")
                .SplitError(x => x.Item.FwDirect.IsEmpty(), "直接人数不能为空")
                .SplitError(x => x.Item.FwDirectOverTime.IsEmpty(), "直接加班费不能为空")
                .SplitError(x => x.Item.FwDirectWages.IsEmpty(), "直接工资不能为空")
                .SplitError(x => x.Item.FwInDirectWageRate.IsEmpty(), "间接工资率不能为空")
                .SplitError(x => x.Item.FwInDirect.IsEmpty(), "间接人数不能为空")
                .SplitError(x => x.Item.FwInDirectOverTime.IsEmpty(), "间接加班费不能为空")
                .SplitError(x => x.Item.FwInDirectWages.IsEmpty(), "间接工资不能为空")
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
        public PagedInfo<WageRatesDto> ExportList(WageRatesQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new WageRatesDto()
                {
                    FwCropLabel = it.FwCrop.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    FwYmLabel = it.FwYm.GetConfigValue<Kernel.Model.System.SysDictData>("sql_ficoym_list"),
                    FwCcyLabel = it.FwCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<WageRates> QueryExp(WageRatesQueryDto parm)
        {
            var predicate = Expressionable.Create<WageRates>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwCrop), it => it.FwCrop == parm.FwCrop);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwYm), it => it.FwYm == parm.FwYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FwCcy), it => it.FwCcy == parm.FwCcy);
            return predicate;
        }
    }
}