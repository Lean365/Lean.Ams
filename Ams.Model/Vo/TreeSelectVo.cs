namespace Ams.Model.Vo
{
    /// <summary>
    /// Treeselect树结构实体类
    /// </summary>
    public class TreeSelectVo
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string Label { get; set; }

        public int IsStatus { get; set; }
        public string MenuType { get; set; }
        public string Permission { get; set; }

        public TreeSelectVo()
        { }

        public TreeSelectVo(SysMenu menu)
        {
            Id = menu.MenuId;
            Label = menu.MenuName;
            IsStatus = menu.IsStatus;
            MenuType = menu.MenuType;
            Permission = menu.Perms;

            List<TreeSelectVo> child = new List<TreeSelectVo>();
            foreach (var item in menu.Children)
            {
                child.Add(new TreeSelectVo(item));
            }

            Children = child;
        }

        public TreeSelectVo(SysDept dept)
        {
            Id = dept.DeptId;
            Label = dept.DeptName;

            //menu.getChildren().stream().map(TreeSelect::new).collect(Collectors.toList()); java写法
            List<TreeSelectVo> child = new List<TreeSelectVo>();
            foreach (var item in dept.children)
            {
                child.Add(new TreeSelectVo(item));
            }

            Children = child;
        }

        public TreeSelectVo(FicoBudgetAccounting BudgetAccounting)
        {
            Id = long.Parse(BudgetAccounting.Md006);//BudgetAccounting.Id;//
            Label = BudgetAccounting.Md009;

            //menu.getChildren().stream().map(TreeSelect::new).collect(Collectors.toList()); java写法
            List<TreeSelectVo> child = new List<TreeSelectVo>();
            foreach (var item in BudgetAccounting.Children)
            {
                child.Add(new TreeSelectVo(item));
            }

            Children = child;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<TreeSelectVo> Children { get; set; }
    }
}