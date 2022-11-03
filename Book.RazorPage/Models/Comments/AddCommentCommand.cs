namespace Book.RazorPage.Models.Comments;

public class AddCommentCommand
{
    public string Text { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
public class EditCommentCommand
{
    public Guid CommentId { get; set; }
    public string Text { get; set; }
    public Guid UserId { get; set; }
}