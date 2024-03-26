using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 公告通知
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface INoticesService : IBaseService<Notices>
    {
        List<Notices> GetNoticess();

        PagedInfo<Notices> GetPageList(NoticesQueryDto parm);
    }
}