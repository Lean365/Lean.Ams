using Ams.Model.Content;

namespace Ams.Service.Content.IService
{
    /// <summary>
    /// 点赞记录
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IArticlePraiseService : IBaseService<ArticlePraise>
    {
        int Praise(ArticlePraise dto);

        int CanclePraise(long userid, long articleId);

        int PlusPraise(long pid);
    }
}