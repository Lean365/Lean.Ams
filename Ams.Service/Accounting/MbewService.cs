using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel.Model;
using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;
using Ams.Repository;
using Ams.Service.Accounting.IAccountingService;
using System.Linq;

namespace Ams.Service.Accounting
{
    /// <summary>
    /// 物料评估
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 15:30:16)
    /// </summary>
    [AppService(ServiceType = typeof(IMbewService), ServiceLifetime = LifeTime.Transient)]
    public class MbewService : BaseService<Mbew>, IMbewService
    {
        /// <summary>
        /// 查询物料评估列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MbewDto> GetList(MbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Mbew, MbewDto>(parm);

            return response;
        }

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString)
        {
            int count = Count(it => it. MbewSFID.ToString() == enterString);
            if (count > 0)
            {
                return UserConstants.NOT_UNIQUE;
            }
            return UserConstants.UNIQUE;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="MbewSFID"></param>
        /// <returns></returns>
        public Mbew GetInfo(long MbewSFID)
        {
            var response = Queryable()
                .Where(x => x.MbewSFID == MbewSFID)
                .First();

            return response;
        }

        /// <summary>
        /// 添加物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Mbew AddMbew(Mbew model)
        {
            Insertable(model).ExecuteReturnSnowflakeId();
            return model;
        }

        /// <summary>
        /// 修改物料评估
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMbew(Mbew model)
        {
            return Update(model, true, "修改物料评估");
        }

        /// <summary>
        /// 导入物料评估
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMbew(List<Mbew> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.MbewSFID.IsEmpty(), "ID主键不能为空")
                .SplitError(x => x.Item.MbewBWKEY.IsEmpty(), "评估范围不能为空")
                .SplitError(x => x.Item.MbewBWPEI.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.MbewBWPH1.IsEmpty(), "商业价格 2不能为空")
                .SplitError(x => x.Item.MbewBWPRH.IsEmpty(), "商业价格 1不能为空")
                .SplitError(x => x.Item.MbewBWPRS.IsEmpty(), "税价1不能为空")
                .SplitError(x => x.Item.MbewBWPS1.IsEmpty(), "税价2不能为空")
                .SplitError(x => x.Item.MbewBWSPA.IsEmpty(), "评价毛利不能为空")
                .SplitError(x => x.Item.MbewBWTAR.IsEmpty(), "评估类型不能为空")
                .SplitError(x => x.Item.MbewFPLPX.IsEmpty(), "固定的未来计划价格不能为空")
                .SplitError(x => x.Item.MbewLBKUM.IsEmpty(), "总库存 不能为空")
                .SplitError(x => x.Item.MbewLPLPR.IsEmpty(), "当前计划价格不能为空")
                .SplitError(x => x.Item.MbewLPLPX.IsEmpty(), "固定的当前计划价格不能为空")
                .SplitError(x => x.Item.MbewMANDT.IsEmpty(), "集团不能为空")
                .SplitError(x => x.Item.MbewMATNR.IsEmpty(), "物料不能为空")
                .SplitError(x => x.Item.MbewPEINH.IsEmpty(), "价格单位不能为空")
                .SplitError(x => x.Item.MbewSALK3.IsEmpty(), "总价值 不能为空")
                .SplitError(x => x.Item.MbewSALKV.IsEmpty(), "价值/MA价格不能为空")
                .SplitError(x => x.Item.MbewSTPRS.IsEmpty(), "标准价格不能为空")
                .SplitError(x => x.Item.MbewSTPRV.IsEmpty(), "上期价格不能为空")
                .SplitError(x => x.Item.MbewTIMESTAMP.IsEmpty(), "时戳不能为空")
                .SplitError(x => x.Item.MbewVERPR.IsEmpty(), "移动价格不能为空")
                .SplitError(x => x.Item.MbewVJBWH.IsEmpty(), "商业价格 3不能为空")
                .SplitError(x => x.Item.MbewVJBWS.IsEmpty(), "税价3不能为空")
                .SplitError(x => x.Item.MbewVJKUM.IsEmpty(), "前年总库存值 不能为空")
                .SplitError(x => x.Item.MbewVJPEI.IsEmpty(), "上年价格单位不能为空")
                .SplitError(x => x.Item.MbewVJSAL.IsEmpty(), "上年总值 不能为空")
                .SplitError(x => x.Item.MbewVJSAV.IsEmpty(), "上年价值 不能为空")
                .SplitError(x => x.Item.MbewVJSTP.IsEmpty(), "去年标准价格不能为空")
                .SplitError(x => x.Item.MbewVJVER.IsEmpty(), "去年移动平均价不能为空")
                .SplitError(x => x.Item.MbewVKSAL.IsEmpty(), "总SP值 不能为空")
                .SplitError(x => x.Item.MbewVMKUM.IsEmpty(), "前期总库存 不能为空")
                .SplitError(x => x.Item.MbewVMPEI.IsEmpty(), "上期间价格单位不能为空")
                .SplitError(x => x.Item.MbewVMSAL.IsEmpty(), "前期总值 不能为空")
                .SplitError(x => x.Item.MbewVMSAV.IsEmpty(), "上期的价值 不能为空")
                .SplitError(x => x.Item.MbewVMSTP.IsEmpty(), "前期标准价格不能为空")
                .SplitError(x => x.Item.MbewVMVER.IsEmpty(), "前期移动平均价不能为空")
                .SplitError(x => x.Item.MbewVPLPR.IsEmpty(), "上期标准价格不能为空")
                .SplitError(x => x.Item.MbewVPLPX.IsEmpty(), "固定的上年计划价格不能为空")
                .SplitError(x => x.Item.MbewVVJLB.IsEmpty(), "前年的总库存 不能为空")
                .SplitError(x => x.Item.MbewVVJSL.IsEmpty(), "计价在 不能为空")
                .SplitError(x => x.Item.MbewVVMLB.IsEmpty(), "前期的总库存值不能为空")
                .SplitError(x => x.Item.MbewVVSAL.IsEmpty(), "计价在 不能为空")
                .SplitError(x => x.Item.MbewZKPRS.IsEmpty(), "未来价格不能为空")
                .SplitError(x => x.Item.MbewZPLP1.IsEmpty(), "计划价格 1不能为空")
                .SplitError(x => x.Item.MbewZPLP2.IsEmpty(), "计划价格 2不能为空")
                .SplitError(x => x.Item.MbewZPLP3.IsEmpty(), "计划价格 3不能为空")
                .SplitError(x => x.Item.MbewZPLPR.IsEmpty(), "未来计划价格不能为空")
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
        /// 导出物料评估
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MbewDto> ExportList(MbewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MbewDto()
                {
                    MbewBKLASLabel = it.MbewBKLAS.GetConfigValue<Kernel.Model.System.SysDictData>("app_val_type"),
                    MbewBWKEYLabel = it.MbewBWKEY.GetConfigValue<Kernel.Model.System.SysDictData>("app_plant_list"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Mbew> QueryExp(MbewQueryDto parm)
        {
            var predicate = Expressionable.Create<Mbew>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MbewBKLAS), it => it.MbewBKLAS == parm.MbewBKLAS);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MbewBWKEY), it => it.MbewBWKEY == parm.MbewBWKEY);
            return predicate;
        }
    }
}