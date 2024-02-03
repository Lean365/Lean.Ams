using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 14:46:50)
    /// </summary>
    [AppService(ServiceType = typeof(IDeptConsumingService), ServiceLifetime = LifeTime.Transient)]
    public class DeptConsumingService : BaseService<DeptConsuming>, IDeptConsumingService
    {
        /// <summary>
        /// 查询部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DeptConsumingDto> GetList(DeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<DeptConsuming, DeptConsumingDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. DcSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="DcSFID"></param>
        /// <returns></returns>
        public DeptConsuming GetInfo(long DcSFID)
        {
            var response = Queryable()
                .Where(x => x.DcSFID == DcSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DeptConsuming AddDeptConsuming(DeptConsuming model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改部门消耗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateDeptConsuming(DeptConsuming model)
        {
            return Update(model, true, "修改部门消耗");
        }

        /// <summary>
        /// 导入部门消耗
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportDeptConsuming(List<DeptConsuming> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.DcSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.DcFy.IsEmpty(), "期间不能为空")
                .SplitError(x => x.Item.DcYm.IsEmpty(), "年月不能为空")
                .SplitError(x => x.Item.DcCorpCode.IsEmpty(), "公司代码不能为空")
                .SplitError(x => x.Item.DcCorpName.IsEmpty(), "公司名称不能为空")
                .SplitError(x => x.Item.DcExpCategory.IsEmpty(), "统计类别不能为空")
                .SplitError(x => x.Item.DcCostCode.IsEmpty(), "成本代码不能为空")
                .SplitError(x => x.Item.DcCostName.IsEmpty(), "成本名称不能为空")
                .SplitError(x => x.Item.DcTitleCode.IsEmpty(), "科目代码不能为空")
                .SplitError(x => x.Item.DcTitleName.IsEmpty(), "科目名称不能为空")
                .SplitError(x => x.Item.DcTitleNote.IsEmpty(), "科目分类不能为空")
                .SplitError(x => x.Item.DcBudgetAmt.IsEmpty(), "预算不能为空")
                .SplitError(x => x.Item.DcActualAmt.IsEmpty(), "实际不能为空")
                .SplitError(x => x.Item.DcDiffAmt.IsEmpty(), "差异不能为空")
                .SplitError(x => x.Item.DcPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.DcMateriel.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.DcStorageLocation.IsEmpty(), "仓库不能为空")
                .SplitError(x => x.Item.DcMoveType.IsEmpty(), "移动类型不能为空")
                .SplitError(x => x.Item.DcMaterielDoc.IsEmpty(), "物料凭证不能为空")
                .SplitError(x => x.Item.DcMaterielDocDetails.IsEmpty(), "凭证明细不能为空")
                .SplitError(x => x.Item.DcUseQty.IsEmpty(), "数量不能为空")
                .SplitError(x => x.Item.DcUseAmt.IsEmpty(), "金额不能为空")
                .SplitError(x => x.Item.DcReserveDoc.IsEmpty(), "预留单不能为空")
                .SplitError(x => x.Item.DcAccountant.IsEmpty(), "预留明细不能为空")
                .SplitError(x => x.Item.DcBalanceDate.IsEmpty(), "登录日期不能为空")
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
        public PagedInfo<DeptConsumingDto> ExportList(DeptConsumingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new DeptConsumingDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<DeptConsuming> QueryExp(DeptConsumingQueryDto parm)
        {
            var predicate = Expressionable.Create<DeptConsuming>();

            return predicate;
        }
    }
}