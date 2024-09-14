//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 常规物料
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    [AppService(ServiceType = typeof(IMmMaraService), ServiceLifetime = LifeTime.Transient)]
    public class MmMaraService : BaseService<MmMara>, IMmMaraService
    {
        /// <summary>
        /// 查询常规物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMaraDto> GetList(MmMaraQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ma003 asc")
                .Where(predicate.ToExpression())
                .ToPage<MmMara, MmMaraDto>(parm);

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
        public MmMara GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加常规物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmMara AddMmMara(MmMara model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改常规物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmMara(MmMara model)
        {
            return Update(model, true, "修改常规物料");
        }

        /// <summary>
        /// 导入常规物料
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmMara(List<MmMara> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ma003.IsEmpty(), "物料号不能为空")
                .SplitError(x => x.Item.Ma007.IsEmpty(), "物料类型不能为空")
                .SplitError(x => x.Item.Ma008.IsEmpty(), "行业领域不能为空")
                .SplitError(x => x.Item.Ma011.IsEmpty(), "基本单位不能为空")
                .SplitError(x => x.Item.Ma019.IsEmpty(), "页数不能为空")
                .SplitError(x => x.Item.Ma027.IsEmpty(), "毛重不能为空")
                .SplitError(x => x.Item.Ma028.IsEmpty(), "净重不能为空")
                .SplitError(x => x.Item.Ma030.IsEmpty(), "业务量不能为空")
                .SplitError(x => x.Item.Ma041.IsEmpty(), "GR单数量不能为空")
                .SplitError(x => x.Item.Ma050.IsEmpty(), "长度不能为空")
                .SplitError(x => x.Item.Ma051.IsEmpty(), "宽度不能为空")
                .SplitError(x => x.Item.Ma052.IsEmpty(), "高度不能为空")
                .SplitError(x => x.Item.Ma058.IsEmpty(), "允许的包装重量不能为空")
                .SplitError(x => x.Item.Ma060.IsEmpty(), "允许体积不能为空")
                .SplitError(x => x.Item.Ma062.IsEmpty(), "超重量容差不能为空")
                .SplitError(x => x.Item.Ma063.IsEmpty(), "超体积容差不能为空")
                .SplitError(x => x.Item.Ma069.IsEmpty(), "最大层次不能为空")
                .SplitError(x => x.Item.Ma070.IsEmpty(), "堆栈因子不能为空")
                .SplitError(x => x.Item.Ma090.IsEmpty(), "剩余货架寿命不能为空")
                .SplitError(x => x.Item.Ma091.IsEmpty(), "总货架寿命不能为空")
                .SplitError(x => x.Item.Ma092.IsEmpty(), "仓储百分比不能为空")
                .SplitError(x => x.Item.Ma094.IsEmpty(), "净内容不能为空")
                .SplitError(x => x.Item.Ma095.IsEmpty(), "比较价格单位不能为空")
                .SplitError(x => x.Item.Ma097.IsEmpty(), "毛内容不能为空")
                .SplitError(x => x.Item.Ma099.IsEmpty(), "内部对象号不能为空")
                .SplitError(x => x.Item.Ma117.IsEmpty(), "完成水平不能为空")
                .SplitError(x => x.Item.Ma140.IsEmpty(), "最大容量不能为空")
                .SplitError(x => x.Item.Ma141.IsEmpty(), "最大容量容差不能为空")
                .SplitError(x => x.Item.Ma142.IsEmpty(), "最大长度不能为空")
                .SplitError(x => x.Item.Ma143.IsEmpty(), "最大宽度不能为空")
                .SplitError(x => x.Item.Ma144.IsEmpty(), "最大高度不能为空")
                .SplitError(x => x.Item.Ma148.IsEmpty(), "隔离期间不能为空")
                .SplitError(x => x.Item.Ma169.IsEmpty(), "ANP Code不能为空")
                .SplitError(x => x.Item.Ma176.IsEmpty(), "装载单位不能为空")
                .SplitError(x => x.Item.Ma186.IsEmpty(), "堆栈因子不能为空")
                .SplitError(x => x.Item.Ma188.IsEmpty(), "悬挂深度不能为空")
                .SplitError(x => x.Item.Ma189.IsEmpty(), "悬挂宽度不能为空")
                .SplitError(x => x.Item.Ma190.IsEmpty(), "最大叠放高度不能为空")
                .SplitError(x => x.Item.Ma191.IsEmpty(), "最小叠放高度不能为空")
                .SplitError(x => x.Item.Ma192.IsEmpty(), "叠放高度容差不能为空")
                .SplitError(x => x.Item.Ma193.IsEmpty(), "物料编号PKM不能为空")
                .SplitError(x => x.Item.Ma205.IsEmpty(), "内部特性1不能为空")
                .SplitError(x => x.Item.Ma206.IsEmpty(), "内部特性2不能为空")
                .SplitError(x => x.Item.Ma207.IsEmpty(), "内部特性3不能为空")
                .SplitError(x => x.Item.Ma215.IsEmpty(), "百分比共享1不能为空")
                .SplitError(x => x.Item.Ma217.IsEmpty(), "百分比共2不能为空")
                .SplitError(x => x.Item.Ma219.IsEmpty(), "百分比共享3不能为空")
                .SplitError(x => x.Item.Ma221.IsEmpty(), "百分比共享4不能为空")
                .SplitError(x => x.Item.Ma223.IsEmpty(), "百分比共享5不能为空")
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
        /// 导出常规物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmMaraDto> ExportList(MmMaraQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmMaraDto()
                {
                    //查询字典: <集团删除> 
                    Ma006Label = it.Ma006.GetConfigValue<SysDictData>("sys_eol_list"),
                    //查询字典: <物料类型> 
                    Ma007Label = it.Ma007.GetConfigValue<SysDictData>("sys_matl_type"),
                    //查询字典: <行业领域> 
                    Ma008Label = it.Ma008.GetConfigValue<SysDictData>("sys_ind_type"),
                    //查询字典: <物料组> 
                    Ma009Label = it.Ma009.GetConfigValue<SysDictData>("sys_matl_group"),
                    //查询字典: <基本单位> 
                    Ma011Label = it.Ma011.GetConfigValue<SysDictData>("sys_unit_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmMara> QueryExp(MmMaraQueryDto parm)
        {
            var predicate = Expressionable.Create<MmMara>();

            //查询字段: <物料号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003.Contains(parm.Ma003));
            //查询字段: <物料类型> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma007), it => it.Ma007 == parm.Ma007);
            //查询字段: <行业领域> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma008), it => it.Ma008 == parm.Ma008);
            //查询字段: <基本单位> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma011), it => it.Ma011 == parm.Ma011);
            return predicate;
        }
    }
}