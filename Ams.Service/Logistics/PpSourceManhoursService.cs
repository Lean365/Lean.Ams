using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 源工时
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    [AppService(ServiceType = typeof(IPpSourceManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class PpSourceManhoursService : BaseService<PpSourceManhours>, IPpSourceManhoursService
    {
        /// <summary>
        /// 查询源工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceManhoursDto> GetList(PpSourceManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpSourceManhours, PpSourceManhoursDto>(parm);

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
            int count = Count(it => it. SfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        public PpSourceManhours GetInfo(long SfId)
        {
            var response = Queryable()
                .Where(x => x.SfId == SfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加源工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpSourceManhours AddPpSourceManhours(PpSourceManhours model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改源工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpSourceManhours(PpSourceManhours model)
        {
            return Update(model, true, "修改源工时");
        }

        /// <summary>
        /// 导入源工时
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpSourceManhours(List<PpSourceManhours> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.SfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Zpbldz001.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Zpbldz002.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Zpbldz003.IsEmpty(), "工作中心不能为空")
                .SplitError(x => x.Item.Zpbldz005.IsEmpty(), "标准值不能为空")
                .SplitError(x => x.Item.Zpbldz007.IsEmpty(), "标准值不能为空")
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
        /// 导出源工时
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpSourceManhoursDto> ExportList(PpSourceManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpSourceManhoursDto()
                {
                    Zpbldz001Label = it.Zpbldz001.GetConfigValue<SysDictData>("sys_plant_list"),
                    Zpbldz003Label = it.Zpbldz003.GetConfigValue<SysDictData>("sys_work_center"),
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
        private static Expressionable<PpSourceManhours> QueryExp(PpSourceManhoursQueryDto parm)
        {
            var predicate = Expressionable.Create<PpSourceManhours>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpbldz001), it => it.Zpbldz001 == parm.Zpbldz001);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpbldz002), it => it.Zpbldz002 == parm.Zpbldz002);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Zpbldz003), it => it.Zpbldz003 == parm.Zpbldz003);
            return predicate;
        }
    }
}