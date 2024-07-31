using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 机构信息
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    [AppService(ServiceType = typeof(IInstInfoService), ServiceLifetime = LifeTime.Transient)]
    public class InstInfoService : BaseService<InstInfo>, IInstInfoService
    {
        /// <summary>
        /// 查询机构信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstInfoDto> GetList(InstInfoQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InstInfo, InstInfoDto>(parm);

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
            int count = Count(it => it.IiInstCode.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="IiSfId"></param>
        /// <returns></returns>
        public InstInfo GetInfo(long IiSfId)
        {
            var response = Queryable()
                .Where(x => x.IiSfId == IiSfId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加机构信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InstInfo AddInstInfo(InstInfo model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改机构信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInstInfo(InstInfo model)
        {
            return Update(model, true, "修改机构信息");
        }

        /// <summary>
        /// 导入机构信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportInstInfo(List<InstInfo> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.IiSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.IiLangkey.IsEmpty(), "语言不能为空")
                .SplitError(x => x.Item.IiCategory.IsEmpty(), "类别不能为空")
                .SplitError(x => x.Item.IiInstCode.IsEmpty(), "编号不能为空")
                .SplitError(x => x.Item.IiShortName.IsEmpty(), "简称不能为空")
                .SplitError(x => x.Item.IiFullName.IsEmpty(), "全称不能为空")
                .SplitError(x => x.Item.IiNature.IsEmpty(), "性质不能为空")
                .SplitError(x => x.Item.IiOuterPhone.IsEmpty(), "外线不能为空")
                .SplitError(x => x.Item.IiInnerPhone.IsEmpty(), "内线不能为空")
                .SplitError(x => x.Item.IiFax.IsEmpty(), "传真不能为空")
                .SplitError(x => x.Item.IiOrgCode.IsEmpty(), "组织代码不能为空")
                .SplitError(x => x.Item.IiCorporate.IsEmpty(), "法人不能为空")
                .SplitError(x => x.Item.IiRegionId.IsEmpty(), "地区不能为空")
                .SplitError(x => x.Item.IiProvinceId.IsEmpty(), "省不能为空")
                .SplitError(x => x.Item.IiCityId.IsEmpty(), "市不能为空")
                .SplitError(x => x.Item.IiCountyId.IsEmpty(), "县/区不能为空")
                .SplitError(x => x.Item.IiAddress.IsEmpty(), "地址不能为空")
                .SplitError(x => x.Item.IiEnAddress.IsEmpty(), "英文地址不能为空")
                .SplitError(x => x.Item.IiFoundedTime.IsEmpty(), "成立日期不能为空")
                .SplitError(x => x.Item.IiBusinessScope.IsEmpty(), "经营范围不能为空")
                .SplitError(x => x.Item.IiSortCode.IsEmpty(), "排序不能为空")
                .SplitError(x => x.Item.IiisEnabled.IsEmpty(), "启用不能为空")
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
        /// 导出机构信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InstInfoDto> ExportList(InstInfoQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InstInfoDto()
                {
                    IiLangkeyLabel = it.IiLangkey.GetConfigValue<SysDictData>("sys_lang_type"),
                    IiCategoryLabel = it.IiCategory.GetConfigValue<SysDictData>("sys_ind_type"),
                    IiNatureLabel = it.IiNature.GetConfigValue<SysDictData>("sys_nature_list"),
                    IiisEnabledLabel = it.IiisEnabled.GetConfigValue<SysDictData>("sys_normal_whether"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<InstInfo> QueryExp(InstInfoQueryDto parm)
        {
            var predicate = Expressionable.Create<InstInfo>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IiCategory), it => it.IiCategory == parm.IiCategory);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IiInstCode), it => it.IiInstCode.Contains(parm.IiInstCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IiShortName), it => it.IiShortName.Contains(parm.IiShortName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IiFullName), it => it.IiFullName.Contains(parm.IiFullName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IiNature), it => it.IiNature == parm.IiNature);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginIiFoundedTime == null, it => it.IiFoundedTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginIiFoundedTime == null, it => it.IiFoundedTime >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginIiFoundedTime != null, it => it.IiFoundedTime >= parm.BeginIiFoundedTime);
            predicate = predicate.AndIF(parm.EndIiFoundedTime != null, it => it.IiFoundedTime <= parm.EndIiFoundedTime);
            predicate = predicate.AndIF(parm.IiisEnabled != null, it => it.IiisEnabled == parm.IiisEnabled);
            return predicate;
        }
    }
}