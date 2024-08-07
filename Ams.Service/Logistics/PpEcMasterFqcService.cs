using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 品管
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:49:12
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcMasterFqcService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcMasterFqcService : BaseService<PpEcMasterFqc>, IPpEcMasterFqcService
    {
        /// <summary>
        /// 查询品管列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterFqcDto> GetList(PpEcMasterFqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.Includes(x => x.PpEcSlaveFqcNav) //填充子对象
                //.OrderBy("EcmIssueDate desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcMasterFqc, PpEcMasterFqcDto>(parm);

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
            int count = Count(it => it. EcmSfId.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="EcmSfId"></param>
        /// <returns></returns>
        public PpEcMasterFqc GetInfo(long EcmSfId)
        {
            var response = Queryable()
                .Includes(x => x.PpEcSlaveFqcNav) //填充子对象
                .Where(x => x.EcmSfId == EcmSfId)
                .First();

            return response;
        }
        /// <summary>
        /// 添加品管
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcMasterFqc AddPpEcMasterFqc(PpEcMasterFqc model)
        {
            return Context.InsertNav(model).Include(s1 => s1.PpEcSlaveFqcNav).ExecuteReturnEntity();
        }
        /// <summary>
        /// 修改品管
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcMasterFqc(PpEcMasterFqc model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.PpEcSlaveFqcNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导入品管
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcMasterFqc(List<PpEcMasterFqc> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
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
        /// 导出品管
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcMasterFqcDto> ExportList(PpEcMasterFqcQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcMasterFqcDto()
                {
                    EcmLeaderLabel = it.EcmLeader.GetConfigValue<SysDictData>("sql_ec_group"),
                    EcmManageCategoryLabel = it.EcmManageCategory.GetConfigValue<SysDictData>("sys_ec_mgtype"),
                    EcmSopStatedLabel = it.EcmSopStated.GetConfigValue<SysDictData>("sys_flag_list"),
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
        private static Expressionable<PpEcMasterFqc> QueryExp(PpEcMasterFqcQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcMasterFqc>();

            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEcmIssueDate == null, it => it.EcmIssueDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEcmIssueDate == null, it => it.EcmIssueDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEcmIssueDate != null, it => it.EcmIssueDate >= parm.BeginEcmIssueDate);
            predicate = predicate.AndIF(parm.EndEcmIssueDate != null, it => it.EcmIssueDate <= parm.EndEcmIssueDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmNo), it => it.EcmNo.Contains(parm.EcmNo));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmTitle), it => it.EcmTitle.Contains(parm.EcmTitle));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmContent), it => it.EcmContent.Contains(parm.EcmContent));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EcmLeader), it => it.EcmLeader == parm.EcmLeader);
            predicate = predicate.AndIF(parm.EcmManageCategory != null, it => it.EcmManageCategory == parm.EcmManageCategory);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginEcmEnteredDate == null, it => it.EcmEnteredDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginEcmEnteredDate == null, it => it.EcmEnteredDate >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginEcmEnteredDate != null, it => it.EcmEnteredDate >= parm.BeginEcmEnteredDate);
            predicate = predicate.AndIF(parm.EndEcmEnteredDate != null, it => it.EcmEnteredDate <= parm.EndEcmEnteredDate);
            predicate = predicate.AndIF(parm.EcmSopStated != null, it => it.EcmSopStated == parm.EcmSopStated);
            predicate = predicate.AndIF(parm.EcmImplStated != null, it => it.EcmImplStated == parm.EcmImplStated);
            return predicate;
        }
    }
}