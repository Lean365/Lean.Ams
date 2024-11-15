using Ams.Model;
using Ams.Model.Admin.Dto;

namespace Ams.Service.Admin.IAdminService
{
    /// <summary>
    /// 用户消息service接口
    /// </summary>
    public interface ISysUserMsgService : IBaseService<SysUserMsg>
    {
        PagedInfo<SysUserMsgDto> GetList(SysUserMsgQueryDto parm);

        SysUserMsg GetInfo(long MsgId);
        int ReadMsg(long userId, long msgId, UserMsgType msgType);

        SysUserMsg AddSysUserMsg(SysUserMsg parm);
        SysUserMsg AddSysUserMsg(long userId, string content, UserMsgType msgType);
        bool TruncateSysUserMsg();


        PagedInfo<SysUserMsgDto> ExportList(SysUserMsgQueryDto parm);
    }
}
