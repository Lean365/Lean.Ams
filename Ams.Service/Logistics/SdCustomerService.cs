using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 顾客信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:49:23
    /// </summary>
    [AppService(ServiceType = typeof(ISdCustomerService), ServiceLifetime = LifeTime.Transient)]
    public class SdCustomerService : BaseService<SdCustomer>, ISdCustomerService
    {
        /// <summary>
        /// 查询顾客信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdCustomerDto> GetList(SdCustomerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<SdCustomer, SdCustomerDto>(parm);

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
            int count = Count(it => it. ScSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="ScSfId"></param>
        /// <returns></returns>
        public SdCustomer GetInfo(long ScSfId)
        {
            var response = Queryable()
                .Where(x => x.ScSfId == ScSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加顾客信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SdCustomer AddSdCustomer(SdCustomer model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改顾客信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSdCustomer(SdCustomer model)
        {
            return Update(model, true, "修改顾客信息");
        }

        /// <summary>
        /// 导入顾客信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSdCustomer(List<SdCustomer> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ScSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.ScOrg.IsEmpty(), "销售组织不能为空")
                .SplitError(x => x.Item.ScIndustryType.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.ScEnterpriseNature.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.ScCode.IsEmpty(), "客户代码不能为空")
                .SplitError(x => x.Item.ScAbbr.IsEmpty(), "客户简称不能为空")
                .SplitError(x => x.Item.ScName.IsEmpty(), "客户名称不能为空")
                .SplitError(x => x.Item.ScEbe.IsEmpty(), "企业法人不能为空")
                .SplitError(x => x.Item.ScTaxNo.IsEmpty(), "税号不能为空")
                .SplitError(x => x.Item.ScBusinessNo.IsEmpty(), "营业执照不能为空")
                .SplitError(x => x.Item.ScTaxType.IsEmpty(), "税别不能为空")
                .SplitError(x => x.Item.ScMainBusiness.IsEmpty(), "主营业务不能为空")
                .SplitError(x => x.Item.ScCcy.IsEmpty(), "交易币种不能为空")
                .SplitError(x => x.Item.ScPayTerms.IsEmpty(), "付款条件不能为空")
                .SplitError(x => x.Item.ScPayMethod.IsEmpty(), "付款方式不能为空")
                .SplitError(x => x.Item.ScRecAccount.IsEmpty(), "统驭科目不能为空")
                .SplitError(x => x.Item.ScTradeTerms.IsEmpty(), "贸易条件不能为空")
                .SplitError(x => x.Item.ScShippingTerms.IsEmpty(), "装运条件不能为空")
                .SplitError(x => x.Item.ScBankCode.IsEmpty(), "银行代码不能为空")
                .SplitError(x => x.Item.ScBankName.IsEmpty(), "银行名称不能为空")
                .SplitError(x => x.Item.ScBankCountry.IsEmpty(), "银行所在国不能为空")
                .SplitError(x => x.Item.ScBankState.IsEmpty(), "银行所在州省不能为空")
                .SplitError(x => x.Item.ScBankCity.IsEmpty(), "银行所在市不能为空")
                .SplitError(x => x.Item.ScBankCounty.IsEmpty(), "银行所在县不能为空")
                .SplitError(x => x.Item.ScBankAddr.IsEmpty(), "银行地址不能为空")
                .SplitError(x => x.Item.ScBankAccount.IsEmpty(), "银行账号不能为空")
                .SplitError(x => x.Item.ScAddr.IsEmpty(), "地址不能为空")
                .SplitError(x => x.Item.IsFroze.IsEmpty(), "冻结标记不能为空")
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
        /// 导出顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SdCustomerDto> ExportList(SdCustomerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SdCustomerDto()
                {
                    ScOrgLabel = it.ScOrg.GetConfigValue<SysDictData>("sys_crop_list"),
                    ScIndustryTypeLabel = it.ScIndustryType.GetConfigValue<SysDictData>("sys_ind_type"),
                    ScEnterpriseNatureLabel = it.ScEnterpriseNature.GetConfigValue<SysDictData>("sys_nature_list"),
                    ScTaxTypeLabel = it.ScTaxType.GetConfigValue<SysDictData>("sys_tax_list"),
                    ScCcyLabel = it.ScCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    ScPayTermsLabel = it.ScPayTerms.GetConfigValue<SysDictData>("sys_payment_terms"),
                    ScPayMethodLabel = it.ScPayMethod.GetConfigValue<SysDictData>("sys_payment_method"),
                    ScRecAccountLabel = it.ScRecAccount.GetConfigValue<SysDictData>("sql_recon_account"),
                    ScTradeTermsLabel = it.ScTradeTerms.GetConfigValue<SysDictData>("sys_terms_trade"),
                    ScShippingTermsLabel = it.ScShippingTerms.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    ScCustomerGradeLabel = it.ScCustomerGrade.GetConfigValue<SysDictData>("sys_grade_list"),
                    ScCustomerCreditLabel = it.ScCustomerCredit.GetConfigValue<SysDictData>("sys_credit_list"),
                    ScBankCountryLabel = it.ScBankCountry.GetConfigValue<SysDictData>("sys_country_list"),
                    ScBankStateLabel = it.ScBankState.GetConfigValue<SysDictData>("sql_region_province"),
                    ScBankCityLabel = it.ScBankCity.GetConfigValue<SysDictData>("sql_region_city"),
                    ScBankCountyLabel = it.ScBankCounty.GetConfigValue<SysDictData>("sql_region_county"),
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
        private static Expressionable<SdCustomer> QueryExp(SdCustomerQueryDto parm)
        {
            var predicate = Expressionable.Create<SdCustomer>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScOrg), it => it.ScOrg == parm.ScOrg);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScIndustryType), it => it.ScIndustryType == parm.ScIndustryType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScEnterpriseNature), it => it.ScEnterpriseNature == parm.ScEnterpriseNature);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScCode), it => it.ScCode.Contains(parm.ScCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScAbbr), it => it.ScAbbr.Contains(parm.ScAbbr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScName), it => it.ScName.Contains(parm.ScName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScTaxNo), it => it.ScTaxNo == parm.ScTaxNo);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScTaxType), it => it.ScTaxType == parm.ScTaxType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScCcy), it => it.ScCcy == parm.ScCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScPayTerms), it => it.ScPayTerms == parm.ScPayTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScPayMethod), it => it.ScPayMethod == parm.ScPayMethod);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScRecAccount), it => it.ScRecAccount == parm.ScRecAccount);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScTradeTerms), it => it.ScTradeTerms == parm.ScTradeTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScShippingTerms), it => it.ScShippingTerms == parm.ScShippingTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScCustomerGrade), it => it.ScCustomerGrade == parm.ScCustomerGrade);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScCustomerCredit), it => it.ScCustomerCredit == parm.ScCustomerCredit);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScRegionCode), it => it.ScRegionCode == parm.ScRegionCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ScState), it => it.ScState == parm.ScState);
            predicate = predicate.AndIF(parm.IsFroze != null, it => it.IsFroze == parm.IsFroze);
            return predicate;
        }
    }
}