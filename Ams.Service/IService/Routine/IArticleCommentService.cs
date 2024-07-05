namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 文章评论服务接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IArticleCommentService
    {
        PagedInfo<ArticleCommentDto> GetMessageList(MessageQueryDto dto);

        ArticleComment AddMessage(ArticleComment message);

        int PraiseMessage(long mid);

        int DeleteMessage(long mid, long userId);

        PagedInfo<ArticleCommentDto> GetReplyComments(long mid, MessageQueryDto pager);

        PagedInfo<ArticleCommentDto> GetMyMessageList(MessageQueryDto dto);

        long TopMessage(long commentId, long top);
    }
}