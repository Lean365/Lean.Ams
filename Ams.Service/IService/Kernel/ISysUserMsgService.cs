namespace Ams.Service.IService.Kernel
{
    /// <summary>
    /// 用户系统消息service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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