using Ams.Model;
using Ams.Model.Content;
using Ams.Model.Dto;

namespace Ams.Service.Content.IService
{
    /// <summary>
    /// 生产班组
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IArticleCategoryService : IBaseService<ArticleCategory>
    {
        PagedInfo<ArticleCategory> GetList(ArticleCategoryQueryDto parm);

        List<ArticleCategory> GetTreeList(ArticleCategoryQueryDto parm);

        int AddArticleCategory(ArticleCategory parm);
    }
}