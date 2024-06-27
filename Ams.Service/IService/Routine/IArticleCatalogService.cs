namespace Ams.Service.IService.Routine
{
    public interface IArticleCatalogService : IBaseService<ArticleCatalog>
    {
        PagedInfo<ArticleCatalog> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCatalog> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCatalog parm);
    }
}