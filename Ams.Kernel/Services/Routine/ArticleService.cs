using Ams.Infrastructure.Attribute;
using Ams.Model;
using Ams.Repository;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Services.IService.Routine;
using Microsoft.IdentityModel.Tokens;

namespace Ams.Kernel.Services.Routine
{
    /// <summary>
    /// 
    /// </summary>
    [AppService(ServiceType = typeof(IArticleService), ServiceLifetime = LifeTime.Transient)]
    public class ArticleService : BaseService<RoutineArticle>, IArticleService
    {
        /// <summary>
        /// 查询文章管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleDto> GetList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineArticle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsState.ToString()), m => m.IsState == parm.IsState);

            //搜索条件查询语法参考Sqlsugar
            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav) //填充子对象
                .Where(predicate.ToExpression())
                .OrderBy(x => x.CreateTime, OrderByType.Desc)
                .ToPage<RoutineArticle, ArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 查询我的文章列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ArticleDto> GetMyList(ArticleQueryDto parm)
        {
            var predicate = Expressionable.Create<RoutineArticle>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Title), m => m.Title.Contains(parm.Title));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IsState.ToString()), m => m.IsState == parm.IsState);
            predicate = predicate.AndIF(parm.BeginTime != null, m => m.CreateTime >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, m => m.CreateTime <= parm.EndTime);
            predicate = predicate.And(m => m.UserId == parm.UserId);

            var response = Queryable()
                .Includes(x => x.ArticleCategoryNav)
                .Where(predicate.ToExpression())
                .ToPage<RoutineArticle, ArticleDto>(parm);

            return response;
        }

        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(RoutineArticle model)
        {
            var response = Update(w => w.Cid == model.Cid, it => new RoutineArticle()
            {
                Title = model.Title,
                Content = model.Content,
                IsState = model.IsState,
                Tags = model.Tags,
                UpdateTime = DateTime.Now,
                CoverUrl = model.CoverUrl,
                CategoryId = model.CategoryId,
                FmtType = model.FmtType,
                IsPublic = model.IsPublic,
            });
            return response;
        }
    }
}
