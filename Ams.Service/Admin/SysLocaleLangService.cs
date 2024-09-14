using Ams.Repository;

namespace Ams.Service.Admin
{
    /// <summary>
    /// 本地语言
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/29 13:30:50
    /// </summary>
    [AppService(ServiceType = typeof(ISysLocaleLangService), ServiceLifetime = LifeTime.Transient)]
    public class SysLocaleLangService : BaseService<SysLocaleLang>, ISysLocaleLangService
    {
        #region 业务逻辑代码

        /// <summary>
        /// 查询本地语言列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SysLocaleLang> GetList(SysLocaleLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysLocaleLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            predicate = predicate.AndIF(parm.BeginAddtime != null, it => it.Create_time >= parm.BeginAddtime && it.Create_time <= parm.EndAddtime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);
            return response;
        }

        /// <summary>
        /// 行转列
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic GetListToPivot(SysLocaleLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysLocaleLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            predicate = predicate.AndIF(parm.BeginAddtime != null, it => it.Create_time >= parm.BeginAddtime && it.Create_time <= parm.EndAddtime);
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPivotList(it => it.LangCode, it => it.LangKey, it => it.Max(f => f.LangName));
            return response;
        }

        public List<SysLocaleLang> GetLangList(SysLocaleLangQueryDto parm)
        {
            var predicate = Expressionable.Create<SysLocaleLang>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangCode), it => it.LangCode == parm.LangCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.LangKey), it => it.LangKey.Contains(parm.LangKey));
            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();
            return response;
        }

        public void StorageSysLocaleLang(SysLocaleLangDto parm)
        {
            List<SysLocaleLang> langs = new();
            foreach (var item in parm.LangList)
            {
                langs.Add(new SysLocaleLang()
                {
                    Create_time = DateTime.Now,
                    LangKey = parm.LangKey,
                    LangCode = item.LangCode,
                    LangName = item.LangName,
                });
            }
            var storage = Context.Storageable(langs)
                .WhereColumns(it => new { it.LangKey, it.LangCode })
                .ToStorage();

            storage.AsInsertable.ExecuteReturnSnowflakeIdList();//执行插入
            storage.AsUpdateable.UpdateColumns(it => new { it.LangName }).ExecuteCommand();//执行修改
        }

        public Dictionary<string, object> SetLang(List<SysLocaleLang> msgList)
        {
            Dictionary<string, object> dic = new();

            foreach (var item in msgList)
            {
                if (!dic.ContainsKey(item.LangKey))
                {
                    dic.Add(item.LangKey, item.LangName);
                }
            }
            return dic;
        }

        /// <summary>
        /// 导入多语言设置
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSysLocaleLang(List<SysLocaleLang> list)
        {
            var x = Context.Storageable(list)
                .WhereColumns(it => new { it.LangKey, it.LangCode })
                .ToStorage();
            x.AsInsertable.ExecuteReturnSnowflakeIdList();//插入可插入部分;
            x.AsUpdateable.UpdateColumns(it => new { it.LangName }).ExecuteCommand();

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";

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

        #endregion 业务逻辑代码
    }
}