namespace Ams.Service.Routine.IRoutineService
{
    public interface IArticlePraiseService : IBaseService<ArticlePraise>
    {
        int Praise(ArticlePraise dto);

        int CanclePraise(long userid, long articleId);

        int PlusPraise(long pid);
    }
}