using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;
using static Ams.Kernel.Model.Routine.Article;

namespace Ams.Kernel.Services.IService.Routine
{
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
        int TopArticle(Article model);
        int ChangeArticlePublic(Article model);
    }
}