using Ams.Infrastructure.Attribute;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Services.IService.Routine;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 文章目录
    /// 业务层处理
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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
            //开始拼装查询条件
            var predicate = Expressionable.Create<ArticleCategory>();

            //搜索条件查询语法参考Sqlsugar
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
            //开始拼装查询条件
            var predicate = Expressionable.Create<ArticleCategory>();

            //搜索条件查询语法参考Sqlsugar

            var response = Queryable().Where(predicate.ToExpression())
                .ToTree(it => it.Children, it => it.ParentId, 0);

            return response;
        }

        /// <summary>
        /// 添加文章目录
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int AddArticleCategory(ArticleCategory parm)
        {
            var response = Insert(parm, it => new
            {
                it.Name,
                it.Create_time,
                it.ParentId,
            });
            return response;
        }
    }
}