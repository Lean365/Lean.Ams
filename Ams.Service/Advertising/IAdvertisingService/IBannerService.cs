namespace Ams.Service.Advertising.IAdvertisingService
{
    /// <summary>
    /// 横幅广告service接口
    /// </summary>
    public interface IBannerService : IBaseService<Banner>
    {
        PagedInfo<BannerDto> GetList(BannerQueryDto parm);

        Banner GetInfo(int Id);

        Banner AddBannerConfig(Banner parm);

        int UpdateBannerConfig(Banner parm);

        List<BannerDto> GetBannerList(BannerQueryDto parm);

        PagedInfo<BannerDto> ExportList(BannerQueryDto parm);
    }
}