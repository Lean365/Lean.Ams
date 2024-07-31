using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 厂商信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    [AppService(ServiceType = typeof(IMmVendorService), ServiceLifetime = LifeTime.Transient)]
    public class MmVendorService : BaseService<MmVendor>, IMmVendorService
    {
        /// <summary>
        /// 查询厂商信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmVendorDto> GetList(MmVendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmVendor, MmVendorDto>(parm);

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
            int count = Count(it => it. VeSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="VeSfId"></param>
        /// <returns></returns>
        public MmVendor GetInfo(long VeSfId)
        {
            var response = Queryable()
                .Where(x => x.VeSfId == VeSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加厂商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmVendor AddMmVendor(MmVendor model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改厂商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmVendor(MmVendor model)
        {
            return Update(model, true, "修改厂商信息");
        }

        /// <summary>
        /// 导入厂商信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmVendor(List<MmVendor> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.VeSfId.IsEmpty(), "SfId不能为空")
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
                .SplitError(x => x.Item.UDF51.IsEmpty(), "自定义1不能为空")
                .SplitError(x => x.Item.UDF52.IsEmpty(), "自定义2不能为空")
                .SplitError(x => x.Item.UDF53.IsEmpty(), "自定义3不能为空")
                .SplitError(x => x.Item.UDF54.IsEmpty(), "自定义4不能为空")
                .SplitError(x => x.Item.UDF55.IsEmpty(), "自定义5不能为空")
                .SplitError(x => x.Item.UDF56.IsEmpty(), "自定义6不能为空")
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
        /// 导出厂商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmVendorDto> ExportList(MmVendorQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmVendorDto()
                {
                    VeOrgLabel = it.VeOrg.GetConfigValue<SysDictData>("sys_plant_list"),
                    VeIndustryTypeLabel = it.VeIndustryType.GetConfigValue<SysDictData>("sys_ind_type"),
                    VeEnterpriseNatureLabel = it.VeEnterpriseNature.GetConfigValue<SysDictData>("sys_nature_list"),
                    VeTaxTypeLabel = it.VeTaxType.GetConfigValue<SysDictData>("sys_tax_list"),
                    VeCcyLabel = it.VeCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    VePayTermsLabel = it.VePayTerms.GetConfigValue<SysDictData>("sys_payment_terms"),
                    VePayMethodLabel = it.VePayMethod.GetConfigValue<SysDictData>("sys_payment_method"),
                    VeRecAccountLabel = it.VeRecAccount.GetConfigValue<SysDictData>("sql_recon_account"),
                    VeTradeTermsLabel = it.VeTradeTerms.GetConfigValue<SysDictData>("sys_terms_trade"),
                    VeShippingTermsLabel = it.VeShippingTerms.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    VeSupplierGradeLabel = it.VeSupplierGrade.GetConfigValue<SysDictData>("sys_grade_list"),
                    VeSupplierCreditLabel = it.VeSupplierCredit.GetConfigValue<SysDictData>("sys_credit_list"),
                    VeBankCountryLabel = it.VeBankCountry.GetConfigValue<SysDictData>("sys_country_list"),
                    IsFrozeLabel = it.IsFroze.GetConfigValue<SysDictData>("sys_freeze_flag"),
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
        private static Expressionable<MmVendor> QueryExp(MmVendorQueryDto parm)
        {
            var predicate = Expressionable.Create<MmVendor>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeOrg), it => it.VeOrg == parm.VeOrg);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeIndustryType), it => it.VeIndustryType == parm.VeIndustryType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeEnterpriseNature), it => it.VeEnterpriseNature == parm.VeEnterpriseNature);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeCode), it => it.VeCode.Contains(parm.VeCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeAbbr), it => it.VeAbbr.Contains(parm.VeAbbr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeName), it => it.VeName.Contains(parm.VeName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeTaxType), it => it.VeTaxType == parm.VeTaxType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeCcy), it => it.VeCcy == parm.VeCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VePayTerms), it => it.VePayTerms == parm.VePayTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VePayMethod), it => it.VePayMethod == parm.VePayMethod);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeRecAccount), it => it.VeRecAccount == parm.VeRecAccount);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeTradeTerms), it => it.VeTradeTerms == parm.VeTradeTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeShippingTerms), it => it.VeShippingTerms == parm.VeShippingTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeSupplierGrade), it => it.VeSupplierGrade == parm.VeSupplierGrade);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeSupplierCredit), it => it.VeSupplierCredit == parm.VeSupplierCredit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginVeFirstTransDate == null, it => it.VeFirstTransDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginVeFirstTransDate == null, it => it.VeFirstTransDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginVeFirstTransDate != null, it => it.VeFirstTransDate >= parm.BeginVeFirstTransDate);
            predicate = predicate.AndIF(parm.EndVeFirstTransDate != null, it => it.VeFirstTransDate <= parm.EndVeFirstTransDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.VeRegionCode), it => it.VeRegionCode == parm.VeRegionCode);
            predicate = predicate.AndIF(parm.IsFroze != null, it => it.IsFroze == parm.IsFroze);
            return predicate;
        }
    }
}