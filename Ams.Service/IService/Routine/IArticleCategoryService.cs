namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 文章目录 interface
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCategory parm);
    }
}