namespace Ams.Model.Admin
{
    /// <summary>
    /// 用户消息
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_user_msg", "用户消息")]
    [Tenant(0)]
    public class SysUserMsg : SysBase
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MsgId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public int IsRead { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [SugarColumn(InsertServerTime = true)]
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 目标ID
        /// </summary>
        public long? TargetId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public UserMsgType MsgType { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// 来源用户
        /// </summary>
        public long FromUserid { get; set; }

        /// <summary>
        /// 关联用户
        /// </summary>
        [Navigate(NavigateType.OneToOne, nameof(FromUserid), nameof(SysUser.UserId))]//变量名不要等类名
        public SysUser User { get; set; }
    }
}