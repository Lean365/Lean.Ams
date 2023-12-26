using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    public interface IArticleService : IBaseService<RoutineArticle>
    {
        PagedInfo<ArticleDto> GetList(ArticleQueryDto parm);
        PagedInfo<ArticleDto> GetMyList(ArticleQueryDto parm);
        /// <summary>
        /// 修改文章管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateArticle(RoutineArticle model);
    }
}
