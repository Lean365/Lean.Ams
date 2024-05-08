using Ams.Model.Content;

namespace Ams.Service.Content.IService
{
    public interface IArticlePraiseService : IBaseService<ArticlePraise>
    {
        int Praise(ArticlePraise dto);
        int CanclePraise(long userid, long articleId);
        int PlusPraise(long pid);
    }
}
