using Ams.Service;
using Ams.Service.Routine.IRoutineService;
using Ams.Repository;

namespace Ams.Service.Routine
{
    /// <summary>
    /// 文章目录Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IArticleCatalogService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleCatalogService : BaseService<ArticleCatalog>, IArticleCatalogService
    {
        /// <summary>
        /// 查询文章目录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleCatalog> GetList(ArticleCatalogQueryDto parm)
        {
            var predicate = Expressionable.Create<ArticleCatalog>();
            predicate.AndIF(parm.CategoryType != null, m => m.CategoryType == parm.CategoryType);
            predicate.AndIF(parm.ParentId != null, m => m.ParentId == parm.ParentId);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .WithCache(60 * 5)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询文章目录树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<ArticleCatalog> GetTreeList(ArticleCatalogQueryDto parm)
        {
            var predicate = Expressionable.Create<ArticleCatalog>();
            predicate.AndIF(parm.CategoryType != null, m => m.CategoryType == parm.CategoryType);

            var response = Queryable()
                .Where(predicate.ToExpression());

            if (parm.Sort.IsNotEmpty())
            {
                response = response.OrderByPropertyName(parm.Sort, parm.SortType.Contains("desc") ? OrderByType.Desc : OrderByType.Asc);
            }
            return response.ToTree(it => it.Children, it => it.ParentId, 0); ;
        }

        /// <summary>
        /// 添加文章目录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddArticleCategory(ArticleCatalog parm)
        {
            var response = Add(parm);
            return response;
        }
    }
}