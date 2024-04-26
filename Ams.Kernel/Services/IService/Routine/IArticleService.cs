using Ams.Kernel.Model.Dto.Routine;
using Ams.Model.System;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 文章管理
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IArticleService : IBaseService<Article>
    {
        PagedInfo<ArticleDto> GetList(ArticleQueryDto parm);

        PagedInfo<ArticleDto> GetMyList(ArticleQueryDto parm);

        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(Article model);

        PagedInfo<ArticleDto> GetHotList(ArticleQueryDto parm);

        PagedInfo<ArticleDto> GetMonentList(ArticleQueryDto parm);

        int TopArticle(Article model);

        int ChangeArticlePublic(Article model);

        int UpdateArticleHit(int cid);

        int PraiseArticle(int cid);

        Article PublishArticle(Article article);
    }
}