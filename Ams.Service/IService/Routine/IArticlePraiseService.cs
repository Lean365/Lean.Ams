namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 文章点赞服务接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IArticlePraiseService : IBaseService<ArticlePraise>
    {
        int Praise(ArticlePraise dto);

        int CanclePraise(long userid, long articleId);

        int PlusPraise(long pid);
    }
}