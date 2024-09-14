//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 检查明细
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:55
    /// </summary>
    [AppService(ServiceType = typeof(IPpInspPcbaSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpInspPcbaSlvService : BaseService<PpInspPcbaSlv>, IPpInspPcbaSlvService
    {
        /// <summary>
        /// 查询检查明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaSlvDto> GetList(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpInspPcbaSlv, PpInspPcbaSlvDto>(parm);

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
        public PpInspPcbaSlv GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加检查明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpInspPcbaSlv AddPpInspPcbaSlv(PpInspPcbaSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改检查明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpInspPcbaSlv(PpInspPcbaSlv model)
        {
            return Update(model, true, "修改检查明细");
        }

        /// <summary>
        /// 导入检查明细
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpInspPcbaSlv(List<PpInspPcbaSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Mv004.IsEmpty(), "Lot数不能为空")
                .SplitError(x => x.Item.Mv012.IsEmpty(), "当日完成数不能为空")
                .SplitError(x => x.Item.Mv013.IsEmpty(), "累计完成数不能为空")
                .SplitError(x => x.Item.Mv014.IsEmpty(), "检查台数不能为空")
                .SplitError(x => x.Item.Mv017.IsEmpty(), "检查工数不能为空")
                .SplitError(x => x.Item.Mv018.IsEmpty(), "AOI工数不能为空")
                .SplitError(x => x.Item.Mv019.IsEmpty(), "不良数量不能为空")
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
        /// 导出检查明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpInspPcbaSlvDto> ExportList(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpInspPcbaSlvDto()
                {
                    //查询字典: <板别> 
                    Mv005Label = it.Mv005.GetConfigValue<SysDictData>("sql_pcb_type"),
                    //查询字典: <目视线别> 
                    Mv006Label = it.Mv006.GetConfigValue<SysDictData>("sys_visual_type"),
                    //查询字典: <AOI线别> 
                    Mv007Label = it.Mv007.GetConfigValue<SysDictData>("sys_aoi_type"),
                    //查询字典: <生产班别> 
                    Mv010Label = it.Mv010.GetConfigValue<SysDictData>("sys_shifts_list"),
                    //查询字典: <检查状态> 
                    Mv015Label = it.Mv015.GetConfigValue<SysDictData>("sql_smt_status"),
                    //查询字典: <生产线别> 
                    Mv016Label = it.Mv016.GetConfigValue<SysDictData>("sql_smt_line"),
                    //查询字典: <个所区分> 
                    Mv023Label = it.Mv023.GetConfigValue<SysDictData>("sql_pcb_place"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpInspPcbaSlv> QueryExp(PpInspPcbaSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpInspPcbaSlv>();

            return predicate;
        }
    }
}