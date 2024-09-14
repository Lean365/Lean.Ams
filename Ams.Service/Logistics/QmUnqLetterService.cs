//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 不合格联络
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    [AppService(ServiceType = typeof(IQmUnqLetterService), ServiceLifetime = LifeTime.Transient)]
    public class QmUnqLetterService : BaseService<QmUnqLetter>, IQmUnqLetterService
    {
        /// <summary>
        /// 查询不合格联络列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmUnqLetterDto> GetList(QmUnqLetterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Ml009 desc")
                .Where(predicate.ToExpression())
                .ToPage<QmUnqLetter, QmUnqLetterDto>(parm);

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
        public QmUnqLetter GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加不合格联络
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QmUnqLetter AddQmUnqLetter(QmUnqLetter model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改不合格联络
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateQmUnqLetter(QmUnqLetter model)
        {
            return Update(model, true, "修改不合格联络");
        }

        /// <summary>
        /// 导入不合格联络
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportQmUnqLetter(List<QmUnqLetter> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Ml002.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.Ml007.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.Ml009.IsEmpty(), "查验日期不能为空")
                .SplitError(x => x.Item.Ml012.IsEmpty(), "验退数不能为空")
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
        /// 导出不合格联络
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<QmUnqLetterDto> ExportList(QmUnqLetterQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new QmUnqLetterDto()
                {
                    //查询字典: <工厂> 
                    Ml002Label = it.Ml002.GetConfigValue<SysDictData>("sql_plant_list"),
                    //查询字典: <检查员> 
                    Ml003Label = it.Ml003.GetConfigValue<SysDictData>("sql_insp_list"),
                    //查询字典: <班组> 
                    Ml004Label = it.Ml004.GetConfigValue<SysDictData>("sql_line_list"),
                    //查询字典: <级别> 
                    Ml013Label = it.Ml013.GetConfigValue<SysDictData>("sys_insp_bad"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<QmUnqLetter> QueryExp(QmUnqLetterQueryDto parm)
        {
            var predicate = Expressionable.Create<QmUnqLetter>();

            //查询字段: <工厂> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml002), it => it.Ml002 == parm.Ml002);
            //查询字段: <检查员> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml003), it => it.Ml003 == parm.Ml003);
            //查询字段: <班组> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml004), it => it.Ml004 == parm.Ml004);
            //查询字段: <订单> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml005), it => it.Ml005.Contains(parm.Ml005));
            //查询字段: <机种> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml006), it => it.Ml006.Contains(parm.Ml006));
            //查询字段: <物料> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml007), it => it.Ml007.Contains(parm.Ml007));
            //查询字段: <仕向> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml008), it => it.Ml008.Contains(parm.Ml008));
            //查询字段: <查验日期> 
            //predicate = predicate.AndIF(parm.BeginMl009 == null, it => it.Ml009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMl009 != null, it => it.Ml009 >= parm.BeginMl009);
            //predicate = predicate.AndIF(parm.EndMl009 != null, it => it.Ml009 <= parm.EndMl009);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMl009 == null, it => it.Ml009 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMl009 == null, it => it.Ml009 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMl009 != null, it => it.Ml009 >= parm.BeginMl009);
            predicate = predicate.AndIF(parm.EndMl009 != null, it => it.Ml009 <= parm.EndMl009);
            //查询字段: <级别> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Ml013), it => it.Ml013 == parm.Ml013);
            return predicate;
        }
    }
}