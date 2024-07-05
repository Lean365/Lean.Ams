namespace Ams.Model.Dto.Kernel
{
    /// <summary>
    /// 系统部门
    /// 查询对象模型
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class SysDeptQueryDto : PagerInfo
    {
        public int? IsStatus { get; set; }
        public int? IsDeleted { get; set; }
        public string DeptName { get; set; }
    }

    /// <summary>
    /// 系统部门
    /// 输入输出对象模型
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class SysDeptDto : SysBase
    {
        public long DeptId { get; set; }

        public long ParentId { get; set; }

        public string Ancestors { get; set; }

        public string DeptName { get; set; }

        public int SortingNum { get; set; }

        public string Leader { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int IsStatus { get; set; }

        public int IsDeleted { get; set; }
        public int UserNum { get; set; }
    }
}