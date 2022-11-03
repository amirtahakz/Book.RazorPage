using Book.RazorPage.Models;
using Book.RazorPage.Models.Comments;

namespace Book.RazorPage.Services.Comments;

public interface ICommentService
{
    Task<ApiResult> AddComment(AddCommentCommand command);
    Task<ApiResult> EditComment(EditCommentCommand command);
    Task<ApiResult> ChangeStatus(Guid commentId, CommentStatus status);
    Task<ApiResult> DeleteComment(Guid commentId);


    Task<CommentFilterResult> GetCommentsByFilter(CommentFilterParams filterParams);
    Task<CommentFilterResult> GetProductComments(int pageId, int take, Guid productId);
    Task<CommentDto?> GetCommentById(Guid id);
}