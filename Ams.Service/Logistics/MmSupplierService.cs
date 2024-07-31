using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 供应商信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    [AppService(ServiceType = typeof(IMmSupplierService), ServiceLifetime = LifeTime.Transient)]
    public class MmSupplierService : BaseService<MmSupplier>, IMmSupplierService
    {
        /// <summary>
        /// 查询供应商信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmSupplierDto> GetList(MmSupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MmSupplier, MmSupplierDto>(parm);

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
            int count = Count(it => it. SuSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SuSfId"></param>
        /// <returns></returns>
        public MmSupplier GetInfo(long SuSfId)
        {
            var response = Queryable()
                .Where(x => x.SuSfId == SuSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加供应商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmSupplier AddMmSupplier(MmSupplier model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmSupplier(MmSupplier model)
        {
            return Update(model, true, "修改供应商信息");
        }

        /// <summary>
        /// 导入供应商信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmSupplier(List<MmSupplier> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SuSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.SuOrg.IsEmpty(), "购买组织不能为空")
                .SplitError(x => x.Item.SuIndustryType.IsEmpty(), "行业类别不能为空")
                .SplitError(x => x.Item.SuEnterpriseNature.IsEmpty(), "企业性质不能为空")
                .SplitError(x => x.Item.SuCode.IsEmpty(), "供应商代码不能为空")
                .SplitError(x => x.Item.SuAbbr.IsEmpty(), "供应商简称不能为空")
                .SplitError(x => x.Item.SuName.IsEmpty(), "供应商名称不能为空")
                .SplitError(x => x.Item.SuEbe.IsEmpty(), "企业法人不能为空")
                .SplitError(x => x.Item.SuBusinessNo.IsEmpty(), "营业执照不能为空")
                .SplitError(x => x.Item.SuTaxNo.IsEmpty(), "税号不能为空")
                .SplitError(x => x.Item.SuTaxType.IsEmpty(), "税别不能为空")
                .SplitError(x => x.Item.SuMainBusiness.IsEmpty(), "主营业务不能为空")
                .SplitError(x => x.Item.SuCcy.IsEmpty(), "交易币种不能为空")
                .SplitError(x => x.Item.SuPayTerms.IsEmpty(), "付款条件不能为空")
                .SplitError(x => x.Item.SuPayMethod.IsEmpty(), "付款方式不能为空")
                .SplitError(x => x.Item.SuRecAccount.IsEmpty(), "统驭科目不能为空")
                .SplitError(x => x.Item.SuTradeTerms.IsEmpty(), "贸易条件不能为空")
                .SplitError(x => x.Item.SuShippingTerms.IsEmpty(), "装运条件不能为空")
                .SplitError(x => x.Item.SuBankCode.IsEmpty(), "银行代码不能为空")
                .SplitError(x => x.Item.SuBankName.IsEmpty(), "银行名称不能为空")
                .SplitError(x => x.Item.SuBankCountry.IsEmpty(), "银行所在国不能为空")
                .SplitError(x => x.Item.SuBankState.IsEmpty(), "所在州省不能为空")
                .SplitError(x => x.Item.SuBankCity.IsEmpty(), "所在市不能为空")
                .SplitError(x => x.Item.SuBankCounty.IsEmpty(), "所在县不能为空")
                .SplitError(x => x.Item.SuBankAddr.IsEmpty(), "银行地址不能为空")
                .SplitError(x => x.Item.SuBankAccount.IsEmpty(), "银行账号不能为空")
                .SplitError(x => x.Item.SuAddr.IsEmpty(), "地址不能为空")
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
        /// 导出供应商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmSupplierDto> ExportList(MmSupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmSupplierDto()
                {
                    SuOrgLabel = it.SuOrg.GetConfigValue<SysDictData>("sys_plant_list"),
                    SuIndustryTypeLabel = it.SuIndustryType.GetConfigValue<SysDictData>("sys_ind_type"),
                    SuEnterpriseNatureLabel = it.SuEnterpriseNature.GetConfigValue<SysDictData>("sys_nature_list"),
                    SuTaxTypeLabel = it.SuTaxType.GetConfigValue<SysDictData>("sys_tax_list"),
                    SuCcyLabel = it.SuCcy.GetConfigValue<SysDictData>("sys_ccy_type"),
                    SuPayTermsLabel = it.SuPayTerms.GetConfigValue<SysDictData>("sys_payment_terms"),
                    SuPayMethodLabel = it.SuPayMethod.GetConfigValue<SysDictData>("sys_payment_method"),
                    SuRecAccountLabel = it.SuRecAccount.GetConfigValue<SysDictData>("sql_recon_account"),
                    SuTradeTermsLabel = it.SuTradeTerms.GetConfigValue<SysDictData>("sys_terms_trade"),
                    SuShippingTermsLabel = it.SuShippingTerms.GetConfigValue<SysDictData>("sys_cond_shipment"),
                    SuSupplierGradeLabel = it.SuSupplierGrade.GetConfigValue<SysDictData>("sys_grade_list"),
                    SuSupplierCreditLabel = it.SuSupplierCredit.GetConfigValue<SysDictData>("sys_credit_list"),
                    SuBankCountryLabel = it.SuBankCountry.GetConfigValue<SysDictData>("sys_country_list"),
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
        private static Expressionable<MmSupplier> QueryExp(MmSupplierQueryDto parm)
        {
            var predicate = Expressionable.Create<MmSupplier>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuOrg), it => it.SuOrg == parm.SuOrg);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuIndustryType), it => it.SuIndustryType == parm.SuIndustryType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuEnterpriseNature), it => it.SuEnterpriseNature == parm.SuEnterpriseNature);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuCode), it => it.SuCode.Contains(parm.SuCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuAbbr), it => it.SuAbbr.Contains(parm.SuAbbr));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuName), it => it.SuName.Contains(parm.SuName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuTaxType), it => it.SuTaxType == parm.SuTaxType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuCcy), it => it.SuCcy == parm.SuCcy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuPayTerms), it => it.SuPayTerms == parm.SuPayTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuPayMethod), it => it.SuPayMethod == parm.SuPayMethod);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuRecAccount), it => it.SuRecAccount == parm.SuRecAccount);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuTradeTerms), it => it.SuTradeTerms == parm.SuTradeTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuShippingTerms), it => it.SuShippingTerms == parm.SuShippingTerms);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuSupplierGrade), it => it.SuSupplierGrade == parm.SuSupplierGrade);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuSupplierCredit), it => it.SuSupplierCredit == parm.SuSupplierCredit);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginSuFirstTransDate == null, it => it.SuFirstTransDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginSuFirstTransDate == null, it => it.SuFirstTransDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginSuFirstTransDate != null, it => it.SuFirstTransDate >= parm.BeginSuFirstTransDate);
            predicate = predicate.AndIF(parm.EndSuFirstTransDate != null, it => it.SuFirstTransDate <= parm.EndSuFirstTransDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SuRegionCode), it => it.SuRegionCode == parm.SuRegionCode);
            predicate = predicate.AndIF(parm.IsFroze != null, it => it.IsFroze == parm.IsFroze);
            return predicate;
        }
    }
}