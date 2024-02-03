using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Repository;
using Ams.Service.Logistics.ILogisticsService;
using System.Linq;

namespace Ams.Service.Logistics
{
    /// <summary>
    /// 标准工时
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:28:16)
    /// </summary>
    [AppService(ServiceType = typeof(IManhoursService), ServiceLifetime = LifeTime.Transient)]
    public class ManhoursService : BaseService<Manhours>, IManhoursService
    {
        /// <summary>
        /// 查询标准工时列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ManhoursDto> GetList(ManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Manhours, ManhoursDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it.MhPlant.ToString()+ it.MhItem.ToString()+ it.MhWcName.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MhSFID"></param>
        /// <returns></returns>
        public Manhours GetInfo(long MhSFID)
        {
            var response = Queryable()
                .Where(x => x.MhSFID == MhSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Manhours AddManhours(Manhours model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改标准工时
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateManhours(Manhours model)
        {
            return Update(model, true, "修改标准工时");
        }

        /// <summary>
        /// 导入标准工时
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportManhours(List<Manhours> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MhSFID.IsEmpty(), "SFID不能为空")
                .SplitError(x => x.Item.MhPlant.IsEmpty(), "工厂不能为空")
                .SplitError(x => x.Item.MhWcName.IsEmpty(), "工作中心不能为空")
                .SplitError(x => x.Item.MhStdShort.IsEmpty(), "标准点数不能为空")
                .SplitError(x => x.Item.MhToMinRate.IsEmpty(), "点数换算汇率不能为空")
                .SplitError(x => x.Item.MhStdTime.IsEmpty(), "标准工时不能为空")
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
        public PagedInfo<ManhoursDto> ExportList(ManhoursQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ManhoursDto()
                {
                    MhPlantLabel = it.MhPlant.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                    MhItemLabel = it.MhItem.GetConfigValue<Kernel.Model.System.SysDictData>("sql_item_manhour"),
                    MhWcNameLabel = it.MhWcName.GetConfigValue<Kernel.Model.System.SysDictData>("app_work_center"),
                    MhToMinRateLabel = it.MhToMinRate.GetConfigValue<Kernel.Model.System.SysDictData>("app_short_convert"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Manhours> QueryExp(ManhoursQueryDto parm)
        {
            var predicate = Expressionable.Create<Manhours>();

            predicate = predicate.AndIF(parm.BeginMhEffDate == null, it => it.MhEffDate >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginMhEffDate != null, it => it.MhEffDate >= parm.BeginMhEffDate);
            predicate = predicate.AndIF(parm.EndMhEffDate != null, it => it.MhEffDate <= parm.EndMhEffDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhPlant), it => it.MhPlant == parm.MhPlant);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhItem), it => it.MhItem.Contains(parm.MhItem));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MhWcName), it => it.MhWcName == parm.MhWcName);
            return predicate;
        }
    }
}