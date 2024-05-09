using Ams.Model;
using Ams.Model.Content;
using Ams.Model.Dto;

namespace Ams.Service.Content.IService
{
    /// <summary>
    /// 评论记录
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface IArticleCommentService
    {
        PagedInfo<ArticleCommentDto> GetMessageList(MessageQueryDto dto);

        ArticleComment AddMessage(ArticleComment message);

        int PraiseMessage(long mid);

        int DeleteMessage(long mid, long userId);

        PagedInfo<ArticleCommentDto> GetReplyComments(long mid, MessageQueryDto pager);

        PagedInfo<ArticleCommentDto> GetMyMessageList(MessageQueryDto dto);
    }
}