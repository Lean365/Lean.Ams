using Ams.Kernel.Model.Dto.Routine;
using Ams.Model.System;

namespace Ams.Kernel.Services.IService.Routine
{
    /// <summary>
    /// 文章目录
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCategory parm);
    }
}