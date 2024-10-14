//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 技联
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/11 16:21:09
    /// </summary>
    [AppService(ServiceType = typeof(IPpEcLiaisonService), ServiceLifetime = LifeTime.Transient)]
    public class PpEcLiaisonService : BaseService<PpEcLiaison>, IPpEcLiaisonService
    {
        /// <summary>
        /// 查询技联列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcLiaisonDto> GetList(PpEcLiaisonQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ma002 desc")
                .Where(predicate.ToExpression())
                .ToPage<PpEcLiaison, PpEcLiaisonDto>(parm);

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
        public PpEcLiaison GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加技联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PpEcLiaison AddPpEcLiaison(PpEcLiaison model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改技联
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePpEcLiaison(PpEcLiaison model)
        {
            return Update(model, true, "修改技联");
        }

        /// <summary>
        /// 导入技联
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPpEcLiaison(List<PpEcLiaison> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ma002.IsEmpty(), "发行日不能为空")
                .SplitError(x => x.Item.Ma005.IsEmpty(), "担当不能为空")
                .SplitError(x => x.Item.Ma006.IsEmpty(), "输入日不能为空")
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
        /// 导出技联
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PpEcLiaisonDto> ExportList(PpEcLiaisonQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PpEcLiaisonDto()
                {
                    //查询字典: <设变No.> 
                    Ma003Label = it.Ma003.GetConfigValue<SysDictData>("sql_ec_list"),
                    //查询字典: <机种明细> 
                    Ma004Label = it.Ma004.GetConfigValue<SysDictData>("sql_sap_model"),
                    //查询字典: <担当> 
                    Ma005Label = it.Ma005.GetConfigValue<SysDictData>("sql_ec_group"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcLiaison> QueryExp(PpEcLiaisonQueryDto parm)
        {
            var predicate = Expressionable.Create<PpEcLiaison>();

            //查询字段: <发行日> 
            //predicate = predicate.AndIF(parm.BeginMa002 == null, it => it.Ma002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMa002 != null, it => it.Ma002 >= parm.BeginMa002);
            //predicate = predicate.AndIF(parm.EndMa002 != null, it => it.Ma002 <= parm.EndMa002);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMa002 == null, it => it.Ma002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMa002 == null, it => it.Ma002 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMa002 != null, it => it.Ma002 >= parm.BeginMa002);
            predicate = predicate.AndIF(parm.EndMa002 != null, it => it.Ma002 <= parm.EndMa002);
            //查询字段: <设变No.> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma003), it => it.Ma003 == parm.Ma003);
            //查询字段: <机种明细> 
            predicate = predicate.AndIF(parm.Ma004 != null, it => it.Ma004.Contains(parm.Ma004.ToString()));
            //查询字段: <担当> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ma005), it => it.Ma005 == parm.Ma005);
            return predicate;
        }
    }
}