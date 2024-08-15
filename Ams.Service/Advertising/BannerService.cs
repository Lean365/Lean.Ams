using Ams.Service.Advertising.IAdvertisingService;
using Mapster;

namespace Ams.Service.Advertising
{
    /// <summary>
    /// 横幅广告Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IBannerService), ServiceLifetime = LifeTime.Transient)]
    public class BannerService : BaseService<Banner>, IBannerService
    {
        /// <summary>
        /// 查询横幅广告列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<BannerDto> GetList(BannerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Banner, BannerDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Banner GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.SfId == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加横幅广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Banner AddBannerConfig(Banner model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改横幅广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBannerConfig(Banner model)
        {
            return Update(model, false, "修改横幅广告");
        }

        /// <summary>
        /// 导出横幅广告
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<BannerDto> ExportList(BannerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new BannerDto()
                {
                    ShowStatusLabel = it.ShowStatus.GetConfigValue<SysDictData>("sys_common_status"),
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Banner> QueryExp(BannerQueryDto parm)
        {
            var predicate = Expressionable.Create<Banner>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), it => it.Title.Contains(parm.Title));
            predicate = predicate.AndIF(parm.JumpType != null, it => it.JumpType == parm.JumpType);
            predicate = predicate.AndIF(parm.ShowStatus != null, it => it.ShowStatus == parm.ShowStatus);
            predicate = predicate.AndIF(parm.AdType != null, it => it.AdType == parm.AdType);
            return predicate;
        }

        /// <summary>
        /// 查询横幅广告列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<BannerDto> GetBannerList(BannerQueryDto parm)
        {
            var predicate = Expressionable.Create<Banner>();
            var now = DateTime.Now;
            predicate = predicate.And(it => it.ShowStatus == 0);
            predicate = predicate.AndIF(parm.AdType != null, it => it.AdType == parm.AdType);
            predicate = predicate.And(it => it.BeginTime <= now && it.EndTime >= now);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();

            return response.Adapt<List<BannerDto>>();
        }
    }
}