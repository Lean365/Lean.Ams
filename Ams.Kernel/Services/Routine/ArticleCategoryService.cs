using Ams.Kernel.Model.Dto.Routine;
using Ams.Model.System;
using Ams.Repository;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 文章目录
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(IArticleCategoryService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleCategoryService : BaseService<ArticleCategory>, IArticleCategoryService
    {
        /// <summary>
        /// 查询文章目录列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm)
        {
            var predicate = Expressionable.Create<ArticleCategory>();
            predicate.AndIF(parm.CategoryType != null, m => m.CategoryType == parm.CategoryType);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询文章目录树列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm)
        {
            var predicate = Expressionable.Create<ArticleCategory>();
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
        public int AddArticleCategory(ArticleCategory parm)
        {
            var response = Add(parm);
            return response;
        }
    }
}