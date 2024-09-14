using Ams.Service;

namespace Ams.Service.Routine.IRoutineService
{
    public interface IArticleCatalogService : IBaseService<ArticleCatalog>
    {
        PagedInfo<ArticleCatalog> GetList(ArticleCatalogQueryDto parm);

        List<ArticleCatalog> GetTreeList(ArticleCatalogQueryDto parm);

        int AddArticleCategory(ArticleCatalog parm);
    }
}