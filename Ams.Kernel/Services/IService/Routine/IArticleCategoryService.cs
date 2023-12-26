using Ams.Model;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Model.Routine;

namespace Ams.Kernel.Services.IService.Routine
{
    public interface IArticleCategoryService : IBaseService<RoutineArticleCategory>
    {
        PagedInfo<RoutineArticleCategory> GetList(ArticleCategoryQueryDto parm);
        List<RoutineArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);
        int AddArticleCategory(RoutineArticleCategory parm);
    }
}
