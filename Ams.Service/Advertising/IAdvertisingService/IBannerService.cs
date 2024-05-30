using Ams.Model;
using Ams.Model.Advertising;
using Ams.Model.Dto.Advertising;

namespace Ams.Service.Advertising.IAdvertisingService
{
    /// <summary>
    /// 广告管理
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 9:01:20
    /// </summary>
    public interface IBannerService : IBaseService<Banner>
    {
        PagedInfo<BannerDto> GetList(BannerQueryDto parm);

        Banner GetInfo(int Id);

        Banner AddBanner(Banner parm);

        int UpdateBanner(Banner parm);

        List<BannerDto> GetBannerList(BannerQueryDto parm);

        PagedInfo<BannerDto> ExportList(BannerQueryDto parm);
    }
}