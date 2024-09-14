using Ams.Repository;
using Mapster;

namespace Ams.Service.Advert
{
    /// <summary>
    /// 广告管理Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IBannerService), ServiceLifetime = LifeTime.Transient)]
    public class BannerService : BaseService<Banner>, IBannerService
    {
        /// <summary>
        /// 查询广告管理列表
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
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加广告管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Banner AddBannerConfig(Banner model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改广告管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateBannerConfig(Banner model)
        {
            return Update(model, false, "修改广告管理");
        }

        /// <summary>
        /// 导出广告管理
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
                    Mb008Label = it.Mb008.GetConfigValue<Model.Admin.SysDictData>("sys_common_status"),
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

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mb002), it => it.Mb002.Contains(parm.Mb002));
            predicate = predicate.AndIF(parm.Mb006 != -1, it => it.Mb006 == parm.Mb006);
            predicate = predicate.AndIF(parm.Mb008 != -1, it => it.Mb008 == parm.Mb008);
            predicate = predicate.AndIF(parm.Mb009 != -1, it => it.Mb009 == parm.Mb009);
            return predicate;
        }

        /// <summary>
        /// 查询广告管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<BannerDto> GetBannerList(BannerQueryDto parm)
        {
            var predicate = Expressionable.Create<Banner>();
            var now = DateTime.Now;
            predicate = predicate.And(it => it.Mb008 == 0);
            predicate = predicate.AndIF(parm.Mb009 != -1, it => it.Mb009 == parm.Mb009);
            predicate = predicate.And(it => it.Mb010 <= now && it.Mb011 >= now);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();

            return response.Adapt<List<BannerDto>>();
        }
    }
}