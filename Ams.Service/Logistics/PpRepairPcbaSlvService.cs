using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 修理日报slv
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:03:40
    /// </summary>
    [AppService(ServiceType = typeof(IPpRepairPcbaSlvService), ServiceLifetime = LifeTime.Transient)]
    public class PpRepairPcbaSlvService : BaseService<PpRepairPcbaSlv>, IPpRepairPcbaSlvService
    {
        /// <summary>
        /// 查询修理日报slv列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaSlvDto> GetList(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<PpRepairPcbaSlv, PpRepairPcbaSlvDto>(parm);

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
            int count = Count(it => it. PdrSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PdrSfId"></param>
        /// <returns></returns>
        public PpRepairPcbaSlv GetInfo(long PdrSfId)
        {
            var response = Queryable()
                .Where(x => x.PdrSfId == PdrSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加修理日报slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpRepairPcbaSlv AddPpRepairPcbaSlv(PpRepairPcbaSlv model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }
        /// <summary>
        /// 修改修理日报slv
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpRepairPcbaSlv(PpRepairPcbaSlv model)
        {
            return Update(model, true, "修改修理日报slv");
        }

        /// <summary>
        /// 导入修理日报slv
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpRepairPcbaSlv(List<PpRepairPcbaSlv> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.PdrSfId.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.PdrParentSfId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Pdrrealqty.IsEmpty(), "当日生产数不能为空")
                .SplitError(x => x.Item.Pdrrealtotal.IsEmpty(), "累计完成数不能为空")
                .SplitError(x => x.Item.Pdrbadqty.IsEmpty(), "不良数量不能为空")
                .SplitError(x => x.Item.Pdrbadtotal.IsEmpty(), "累计不良台数不能为空")
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
        /// 导出修理日报slv
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpRepairPcbaSlvDto> ExportList(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpRepairPcbaSlvDto()
                {
                    PdrpcbtypeLabel = it.Pdrpcbtype.GetConfigValue<SysDictData>("sql_pcb_type"),
                    PdrpcbcheckoutLabel = it.Pdrpcbcheckout.GetConfigValue<SysDictData>("sql_insp_eng"),
                    PdrbadresponsibilityLabel = it.Pdrbadresponsibility.GetConfigValue<SysDictData>("sql_resp_bel"),
                    PdrbadpropLabel = it.Pdrbadprop.GetConfigValue<SysDictData>("sql_bad_prop"),
                    PdrbadrepairmanLabel = it.Pdrbadrepairman.GetConfigValue<SysDictData>("sql_repair_list"),
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
        private static Expressionable<PpRepairPcbaSlv> QueryExp(PpRepairPcbaSlvQueryDto parm)
        {
            var predicate = Expressionable.Create<PpRepairPcbaSlv>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrlot), it => it.Pdrlot.Contains(parm.Pdrlot));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrpcbtype), it => it.Pdrpcbtype == parm.Pdrpcbtype);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrpcbcheckout), it => it.Pdrpcbcheckout == parm.Pdrpcbcheckout);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Pdrbadresponsibility), it => it.Pdrbadresponsibility == parm.Pdrbadresponsibility);
            return predicate;
        }
    }
}