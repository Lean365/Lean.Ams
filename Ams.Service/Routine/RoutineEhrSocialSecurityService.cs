//using Ams.Infrastructure.Attribute;
//using Ams.Infrastructure.Extensions;
using Ams.Model.Routine.Dto;
using Ams.Model.Routine;
using Ams.Repository;
using Ams.Service.Routine.IRoutineService;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 社保
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:14:24
    /// </summary>
    [AppService(ServiceType = typeof(IRoutineEhrSocialSecurityService), ServiceLifetime = LifeTime.Transient)]
    public class RoutineEhrSocialSecurityService : BaseService<RoutineEhrSocialSecurity>, IRoutineEhrSocialSecurityService
    {
        /// <summary>
        /// 查询社保列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrSocialSecurityDto> GetList(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Mp003 asc")
                .Where(predicate.ToExpression())
                .ToPage<RoutineEhrSocialSecurity, RoutineEhrSocialSecurityDto>(parm);

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
        public RoutineEhrSocialSecurity GetInfo(long Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加社保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RoutineEhrSocialSecurity AddRoutineEhrSocialSecurity(RoutineEhrSocialSecurity model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改社保
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateRoutineEhrSocialSecurity(RoutineEhrSocialSecurity model)
        {
            return Update(model, true, "修改社保");
        }

        /// <summary>
        /// 导入社保
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportRoutineEhrSocialSecurity(List<RoutineEhrSocialSecurity> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ParentId.IsEmpty(), "父ID不能为空")
                .SplitError(x => x.Item.Is_deleted.IsEmpty(), "软删除不能为空")
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
        /// 导出社保
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<RoutineEhrSocialSecurityDto> ExportList(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new RoutineEhrSocialSecurityDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<RoutineEhrSocialSecurity> QueryExp(RoutineEhrSocialSecurityQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineEhrSocialSecurity>();

            //查询字段: <工号> 
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mp003), it => it.Mp003.Contains(parm.Mp003));
            //查询字段: <生效日> 
            //predicate = predicate.AndIF(parm.BeginMp004 == null, it => it.Mp004 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginMp004 != null, it => it.Mp004 >= parm.BeginMp004);
            //predicate = predicate.AndIF(parm.EndMp004 != null, it => it.Mp004 <= parm.EndMp004);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginMp004 == null, it => it.Mp004 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(parm.BeginMp004 == null, it => it.Mp004 >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginMp004 != null, it => it.Mp004 >= parm.BeginMp004);
            predicate = predicate.AndIF(parm.EndMp004 != null, it => it.Mp004 <= parm.EndMp004);
            return predicate;
        }
    }
}