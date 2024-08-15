using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 标准工时
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    [AppService(ServiceType = typeof(IPpManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class PpManhoursService : BaseService<PpManhours>, IPpManhoursService
    {
        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpManhoursDto> GetList(PpManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpManhours, PpManhoursDto>(parm);

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
            int count = Count(it => it. MhSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MhSfId"></param>
        /// <returns></returns>
        public PpManhours GetInfo(long MhSfId)
        {
            var response = Queryable()
                .Where(x => x.MhSfId == MhSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpManhours AddPpManhours(PpManhours model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpManhours(PpManhours model)
        {
            return Update(model, true, "修改标准工时");
        }

        /// <summary>
        /// 导入标准工时
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpManhours(List<PpManhours> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MhSfId.IsEmpty(), "SfId不能为空")
                .SplitError(x => x.Item.MhPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MhModelType.IsEmpty(), "机种名不能为空")
                .SplitError(x => x.Item.MhWcName.IsEmpty(), "工作中心不能为空")
                .SplitError(x => x.Item.MhStdShort.IsEmpty(), "标准点数不能为空")
                .SplitError(x => x.Item.MhToMinRate.IsEmpty(), "点数换算汇率不能为空")
                .SplitError(x => x.Item.MhStdTime.IsEmpty(), "标准工时不能为空")
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
        /// 导出标准工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpManhoursDto> ExportList(PpManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpManhoursDto()
                {
                    MhPlantLabel = it.MhPlant.GetConfigValue<SysDictData>("sys_plant_list"),
                    MhWcNameLabel = it.MhWcName.GetConfigValue<SysDictData>("sys_work_center"),
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
        private static Expressionable<PpManhours> QueryExp(PpManhoursQueryDto parm)
        {
            var predicate = Expressionable.Create<PpManhours>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMhEffDate == null, it => it.MhEffDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMhEffDate == null, it => it.MhEffDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMhEffDate != null, it => it.MhEffDate >= parm.BeginMhEffDate);
            predicate = predicate.AndIF(parm.EndMhEffDate != null, it => it.MhEffDate <= parm.EndMhEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhPlant), it => it.MhPlant == parm.MhPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhModelType), it => it.MhModelType.Contains(parm.MhModelType));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhRegionType), it => it.MhRegionType.Contains(parm.MhRegionType));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhItem), it => it.MhItem == parm.MhItem);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhWcName), it => it.MhWcName == parm.MhWcName);
            return predicate;
        }
    }
}