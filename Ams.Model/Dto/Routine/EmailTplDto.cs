namespace Ams.Model.Dto.Routine
{
    /// <summary>
    /// 邮件模板
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class EmailTplQueryDto : PagerInfo
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// 邮件模板
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class EmailTplDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "模板内容不能为空")]
        public string Content { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string Remark { get; set; }
    }
}