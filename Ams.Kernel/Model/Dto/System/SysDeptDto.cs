using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 部门信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysDeptQueryDto : PagerInfo
    {
        public int? IsStated { get; set; }
        public int? IsDeleted { get; set; }
        public string DeptName { get; set; }
    }

    /// <summary>
    /// 部门信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysDeptDto : SysBase
    {
        public long DeptId { get; set; }

        public long ParentId { get; set; }

        public string Ancestors { get; set; }

        public string DeptName { get; set; }

        public int OrderNum { get; set; }

        public string Leader { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int IsStated { get; set; }

        public int IsDeleted { get; set; }
        public int UserNum { get; set; }
    }
}