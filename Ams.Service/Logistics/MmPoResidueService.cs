//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// PO残清单
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:51
    /// </summary>
    [AppService(ServiceType = typeof(IMmPoResidueService), ServiceLifetime = LifeTime.Transient)]
    public class MmPoResidueService : BaseService<MmPoResidue>, IMmPoResidueService
    {
        /// <summary>
        /// 查询PO残清单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmPoResidueDto> GetList(MmPoResidueQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Me007 desc")
                .Where(predicate.ToExpression())
                .ToPage<MmPoResidue, MmPoResidueDto>(parm);

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
        public MmPoResidue GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加PO残清单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MmPoResidue AddMmPoResidue(MmPoResidue model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改PO残清单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMmPoResidue(MmPoResidue model)
        {
            return Update(model, true, "修改PO残清单");
        }

        /// <summary>
        /// 导入PO残清单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMmPoResidue(List<MmPoResidue> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "ID不能为空")
                .SplitError(x => x.Item.Me016.IsEmpty(), "价格单位不能为空")
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
        /// 导出PO残清单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MmPoResidueDto> ExportList(MmPoResidueQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MmPoResidueDto()
                {
                    //查询字典: <工厂> 
                    Me002Label = it.Me002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <供应商ID> 
                    Me003Label = it.Me003.GetConfigValue<SysDictData>("sql_supplier_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<MmPoResidue> QueryExp(MmPoResidueQueryDto parm)
        {
            var predicate = Expressionable.Create<MmPoResidue>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me002), it => it.Me002 == parm.Me002);
            //查询字段: <供应商ID> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me003), it => it.Me003 == parm.Me003);
            //查询字段: <供应商名称> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me004), it => it.Me004.Contains(parm.Me004));
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Me005), it => it.Me005.Contains(parm.Me005));
            //查询字段: <交货日期> 
            //predicate = predicate.AndIF(parm.BeginMe007 == null, it => it.Me007 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMe007 != null, it => it.Me007 >= parm.BeginMe007);
            //predicate = predicate.AndIF(parm.EndMe007 != null, it => it.Me007 <= parm.EndMe007);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMe007 == null, it => it.Me007 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMe007 == null, it => it.Me007 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMe007 != null, it => it.Me007 >= parm.BeginMe007);
            predicate = predicate.AndIF(parm.EndMe007 != null, it => it.Me007 <= parm.EndMe007);
            //查询字段: <采购日期> 
            //predicate = predicate.AndIF(parm.BeginMe014 == null, it => it.Me014 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMe014 != null, it => it.Me014 >= parm.BeginMe014);
            //predicate = predicate.AndIF(parm.EndMe014 != null, it => it.Me014 <= parm.EndMe014);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMe014 == null, it => it.Me014 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMe014 == null, it => it.Me014 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMe014 != null, it => it.Me014 >= parm.BeginMe014);
            predicate = predicate.AndIF(parm.EndMe014 != null, it => it.Me014 <= parm.EndMe014);
            //查询字段: <PO残发行日期> 
            //predicate = predicate.AndIF(parm.BeginMe020 == null, it => it.Me020 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMe020 != null, it => it.Me020 >= parm.BeginMe020);
            //predicate = predicate.AndIF(parm.EndMe020 != null, it => it.Me020 <= parm.EndMe020);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMe020 == null, it => it.Me020 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMe020 == null, it => it.Me020 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMe020 != null, it => it.Me020 >= parm.BeginMe020);
            predicate = predicate.AndIF(parm.EndMe020 != null, it => it.Me020 <= parm.EndMe020);
            return predicate;
        }
    }
}