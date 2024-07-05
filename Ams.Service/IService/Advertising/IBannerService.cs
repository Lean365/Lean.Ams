namespace Ams.Service.IService.Advertising
{
    /// <summary>
    /// 横幅广告service
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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