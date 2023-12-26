using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 通知公告表service接口
    ///
    /// @author zr
    /// @date 2021-12-15
    /// </summary>
    public interface INoticesService : IBaseService<RoutineNotices>
    {
        List<RoutineNotices> GetNoticess();

        PagedInfo<RoutineNotices> GetPageList(NoticesQueryDto parm);
    }
}
