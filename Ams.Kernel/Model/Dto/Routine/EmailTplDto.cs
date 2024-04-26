using System.ComponentModel.DataAnnotations;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 邮件模板
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class EmailTplQueryDto : PagerInfo
    {
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 邮件模板
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class EmailTplDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>

        [Required(ErrorMessage = "Name不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>

        [Required(ErrorMessage = "模板内容不能为空")]
        public string Content { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人员
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Remark { get; set; }
    }
}