namespace Ams.Service.IService.Advertising
{
    /// <summary>
    /// 横幅广告service接口
    /// </summary>
    public interface IBannerService : IBaseService<Banner>
    {
        PagedInfo<BannerDto> GetList(BannerConfigQueryDto parm);

        Banner GetInfo(int Id);

        Banner AddBannerConfig(Banner parm);

        int UpdateBannerConfig(Banner parm);

        List<BannerDto> GetBannerList(BannerConfigQueryDto parm);

        PagedInfo<BannerDto> ExportList(BannerConfigQueryDto parm);
    }
}