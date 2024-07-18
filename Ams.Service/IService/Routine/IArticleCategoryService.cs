using Ams.Model;

namespace Ams.Service.IService.Routine
{
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCategory parm);
    }
}