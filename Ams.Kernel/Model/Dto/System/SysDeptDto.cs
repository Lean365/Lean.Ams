namespace Ams.Kernel.Model.Dto.System
{
    public class SysDeptQueryDto : PagerInfo
    {
        public int? IsStated { get; set; }
        public int? IsDeleted { get; set; }
        public string DeptName { get; set; }
    }

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