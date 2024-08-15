using Ams.Model.Routine.Dto;

namespace Ams.Service.Routine.IRoutineService
{
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCategory parm);
    }
}