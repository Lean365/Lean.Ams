//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 物料评估
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    [AppService(ServiceType = typeof(IMmMbewService), ServiceLifetime = LifeTime.Transient)]
    public class MmMbewService : BaseService<MmMbew>, IMmMbewService
    {
        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMbewDto> GetList(MmMbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Md003 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmMbew, MmMbewDto>(parm);

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
            int count = Count(it => it. Id.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MmMbew GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMbew AddMmMbew(MmMbew model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMbew(MmMbew model)
        {
            return Update(model, true, "修改物料评估");
        }

        /// <summary>
        /// 导入物料评估
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMbew(List<MmMbew> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Md002.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.Md003.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Md004.IsEmpty(), "评估范围不能为空")
                .SplitError(x => x.Item.Md005.IsEmpty(), "评估类型不能为空")
                .SplitError(x => x.Item.Md007.IsEmpty(), "总库存不能为空")
                .SplitError(x => x.Item.Md008.IsEmpty(), "估价值不能为空")
                .SplitError(x => x.Item.Md010.IsEmpty(), "移动价格不能为空")
                .SplitError(x => x.Item.Md011.IsEmpty(), "标准价格不能为空")
                .SplitError(x => x.Item.Md012.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.Md014.IsEmpty(), "价值/MA价格不能为空")
                .SplitError(x => x.Item.Md015.IsEmpty(), "前期总库存不能为空")
                .SplitError(x => x.Item.Md016.IsEmpty(), "前期总价值不能为空")
                .SplitError(x => x.Item.Md018.IsEmpty(), "前期移动平均价不能为空")
                .SplitError(x => x.Item.Md019.IsEmpty(), "前期标准价格不能为空")
                .SplitError(x => x.Item.Md020.IsEmpty(), "上期价格单位不能为空")
                .SplitError(x => x.Item.Md022.IsEmpty(), "上期价值不能为空")
                .SplitError(x => x.Item.Md023.IsEmpty(), "前年总库存不能为空")
                .SplitError(x => x.Item.Md024.IsEmpty(), "上年总价值不能为空")
                .SplitError(x => x.Item.Md026.IsEmpty(), "去年移动平均价不能为空")
                .SplitError(x => x.Item.Md027.IsEmpty(), "去年标准价格不能为空")
                .SplitError(x => x.Item.Md028.IsEmpty(), "上年价格单位不能为空")
                .SplitError(x => x.Item.Md030.IsEmpty(), "上年价值不能为空")
                .SplitError(x => x.Item.Md031.IsEmpty(), "当前会计年度不能为空")
                .SplitError(x => x.Item.Md032.IsEmpty(), "当前期间不能为空")
                .SplitError(x => x.Item.Md034.IsEmpty(), "上期价格不能为空")
                .SplitError(x => x.Item.Md036.IsEmpty(), "未来价格不能为空")
                .SplitError(x => x.Item.Md038.IsEmpty(), "时戳不能为空")
                .SplitError(x => x.Item.Md039.IsEmpty(), "税价1不能为空")
                .SplitError(x => x.Item.Md040.IsEmpty(), "商业价格1不能为空")
                .SplitError(x => x.Item.Md041.IsEmpty(), "税价3不能为空")
                .SplitError(x => x.Item.Md042.IsEmpty(), "商业价格3不能为空")
                .SplitError(x => x.Item.Md043.IsEmpty(), "计价不能为空")
                .SplitError(x => x.Item.Md044.IsEmpty(), "前年总库存不能为空")
                .SplitError(x => x.Item.Md045.IsEmpty(), "前期总价值不能为空")
                .SplitError(x => x.Item.Md046.IsEmpty(), "计价在不能为空")
                .SplitError(x => x.Item.Md047.IsEmpty(), "未来计划价格不能为空")
                .SplitError(x => x.Item.Md048.IsEmpty(), "未来计划价格1不能为空")
                .SplitError(x => x.Item.Md049.IsEmpty(), "未来计划价格 2不能为空")
                .SplitError(x => x.Item.Md050.IsEmpty(), "未来计划价格 3不能为空")
                .SplitError(x => x.Item.Md063.IsEmpty(), "商业价格2不能为空")
                .SplitError(x => x.Item.Md064.IsEmpty(), "税价2不能为空")
                .SplitError(x => x.Item.Md065.IsEmpty(), "贬值标志不能为空")
                .SplitError(x => x.Item.Md067.IsEmpty(), "产品成本核算不能为空")
                .SplitError(x => x.Item.Md068.IsEmpty(), "成本估算编号不能为空")
                .SplitError(x => x.Item.Md072.IsEmpty(), "成本核算版本1不能为空")
                .SplitError(x => x.Item.Md073.IsEmpty(), "成本核算版本2不能为空")
                .SplitError(x => x.Item.Md074.IsEmpty(), "成本核算版本3不能为空")
                .SplitError(x => x.Item.Md077.IsEmpty(), "计价期间不能为空")
                .SplitError(x => x.Item.Md078.IsEmpty(), "当前期间不能为空")
                .SplitError(x => x.Item.Md079.IsEmpty(), "前一期间不能为空")
                .SplitError(x => x.Item.Md080.IsEmpty(), "未来会计年度不能为空")
                .SplitError(x => x.Item.Md081.IsEmpty(), "当前会计年度不能为空")
                .SplitError(x => x.Item.Md082.IsEmpty(), "上一会计年度不能为空")
                .SplitError(x => x.Item.Md084.IsEmpty(), "上期标准价格不能为空")
                .SplitError(x => x.Item.Md087.IsEmpty(), "当前计划价格不能为空")
                .SplitError(x => x.Item.Md088.IsEmpty(), "总SP值不能为空")
                .SplitError(x => x.Item.Md094.IsEmpty(), "评价毛利不能为空")
                .SplitError(x => x.Item.Md095.IsEmpty(), "当前计划价格的固定金额不能为空")
                .SplitError(x => x.Item.Md096.IsEmpty(), "上年计划价格的固定比例不能为空")
                .SplitError(x => x.Item.Md097.IsEmpty(), "未来计划价格的固定比例不能为空")
                .SplitError(x => x.Item.Md107.IsEmpty(), "价格单位不能为空")
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
        /// 导出物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMbewDto> ExportList(MmMbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMbewDto()
                {
                    //查询字典: <评估范围> 
                    Md004Label = it.Md004.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <评估类型> 
                    Md005Label = it.Md005.GetConfigValue<SysDictData>("sys_val_type"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMbew> QueryExp(MmMbewQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMbew>();

            //查询字段: <物料号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md003), it => it.Md003.Contains(parm.Md003));
            //查询字段: <评估范围> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md004), it => it.Md004 == parm.Md004);
            //查询字段: <评估类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Md005), it => it.Md005 == parm.Md005);
            return predicate;
        }
    }
}