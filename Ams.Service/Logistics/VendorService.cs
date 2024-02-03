using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 厂商信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 16:26:50)
    /// </summary>
    [AppService(ServiceType = typeof(IVendorService), ServiceLifetime = LifeTime.Transient)]
    public class VendorService : BaseService<Vendor>, IVendorService
    {
        /// <summary>
        /// 查询厂商信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<VendorDto> GetList(VendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Vendor, VendorDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. VeSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="VeSFID"></param>
        /// <returns></returns>
        public Vendor GetInfo(long VeSFID)
        {
            var response = Queryable()
                .Where(x => x.VeSFID == VeSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加厂商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Vendor AddVendor(Vendor model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改厂商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateVendor(Vendor model)
        {
            return Update(model, true, "修改厂商信息");
        }

        /// <summary>
        /// 导入厂商信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportVendor(List<Vendor> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.VeSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.VeOrg.IsEmpty(), "购买组织不能为空")
                .SplitError(x => x.Item.VeIndustryType.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.VeEnterpriseNature.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.VeCode.IsEmpty(), "供应商代码不能为空")
                .SplitError(x => x.Item.VeAbbr.IsEmpty(), "供应商简称不能为空")
                .SplitError(x => x.Item.VeName.IsEmpty(), "供应商名称不能为空")
                .SplitError(x => x.Item.VeEbe.IsEmpty(), "企业法人不能为空")
                .SplitError(x => x.Item.VeBusinessNo.IsEmpty(), "营业执照不能为空")
                .SplitError(x => x.Item.VeTaxNo.IsEmpty(), "税号不能为空")
                .SplitError(x => x.Item.VeTaxType.IsEmpty(), "税别不能为空")
                .SplitError(x => x.Item.VeMainBusiness.IsEmpty(), "主营业务不能为空")
                .SplitError(x => x.Item.VeCcy.IsEmpty(), "交易币种不能为空")
                .SplitError(x => x.Item.VePayTerms.IsEmpty(), "付款条件不能为空")
                .SplitError(x => x.Item.VePayMethod.IsEmpty(), "付款方式不能为空")
                .SplitError(x => x.Item.VeRecAccount.IsEmpty(), "统驭科目不能为空")
                .SplitError(x => x.Item.VeTradeTerms.IsEmpty(), "贸易条件不能为空")
                .SplitError(x => x.Item.VeShippingTerms.IsEmpty(), "装运条件不能为空")
                .SplitError(x => x.Item.VeBankCode.IsEmpty(), "银行代码不能为空")
                .SplitError(x => x.Item.VeBankName.IsEmpty(), "银行名称不能为空")
                .SplitError(x => x.Item.VeBankCountry.IsEmpty(), "银行所在国不能为空")
                .SplitError(x => x.Item.VeBankState.IsEmpty(), "所在州省不能为空")
                .SplitError(x => x.Item.VeBankCity.IsEmpty(), "所在市不能为空")
                .SplitError(x => x.Item.VeBankCounty.IsEmpty(), "所在县不能为空")
                .SplitError(x => x.Item.VeBankAddr.IsEmpty(), "银行地址不能为空")
                .SplitError(x => x.Item.VeBankAccount.IsEmpty(), "银行账号不能为空")
                .SplitError(x => x.Item.VeAddr.IsEmpty(), "地址不能为空")
                .SplitError(x => x.Item.IsFroze.IsEmpty(), "冻结标志不能为空")
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
        /// 导出厂商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<VendorDto> ExportList(VendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new VendorDto()
                {
                    VeOrgLabel = it.VeOrg.GetConfigValue<Kernel.Model.System.SysDictData>("sys_crop_list"),
                    VeIndustryTypeLabel = it.VeIndustryType.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ind_type"),
                    VeEnterpriseNatureLabel = it.VeEnterpriseNature.GetConfigValue<Kernel.Model.System.SysDictData>("sys_nature_list"),
                    VeCcyLabel = it.VeCcy.GetConfigValue<Kernel.Model.System.SysDictData>("sys_ccy_type"),
                    VePayTermsLabel = it.VePayTerms.GetConfigValue<Kernel.Model.System.SysDictData>("sys_payment_terms"),
                    VePayMethodLabel = it.VePayMethod.GetConfigValue<Kernel.Model.System.SysDictData>("sys_payment_method"),
                    VeRecAccountLabel = it.VeRecAccount.GetConfigValue<Kernel.Model.System.SysDictData>("sql_recon_account"),
                    VeTradeTermsLabel = it.VeTradeTerms.GetConfigValue<Kernel.Model.System.SysDictData>("app_terms_trade"),
                    VeSupplierGradeLabel = it.VeSupplierGrade.GetConfigValue<Kernel.Model.System.SysDictData>("sys_grade_list"),
                    VeSupplierCreditLabel = it.VeSupplierCredit.GetConfigValue<Kernel.Model.System.SysDictData>("sys_credit_list"),
                    IsFrozeLabel = it.IsFroze.GetConfigValue<Kernel.Model.System.SysDictData>("sys_freeze_flag"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Vendor> QueryExp(VendorQueryDto parm)
        {
            var predicate = Expressionable.Create<Vendor>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeOrg), it => it.VeOrg == parm.VeOrg);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeIndustryType), it => it.VeIndustryType == parm.VeIndustryType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeEnterpriseNature), it => it.VeEnterpriseNature == parm.VeEnterpriseNature);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeCode), it => it.VeCode.Contains(parm.VeCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeAbbr), it => it.VeAbbr.Contains(parm.VeAbbr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeCcy), it => it.VeCcy == parm.VeCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VePayTerms), it => it.VePayTerms == parm.VePayTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VePayMethod), it => it.VePayMethod == parm.VePayMethod);
            return predicate;
        }
    }
}