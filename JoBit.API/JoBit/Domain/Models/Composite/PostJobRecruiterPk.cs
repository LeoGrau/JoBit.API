namespace JoBit.API.JoBit.Domain.Models.Composite;

public class PostJobRecruiterPk
{
    public long PostId { get; set; }
    public long RecruiterId { get; set; }

    public PostJobRecruiterPk(long postId, long recruiterId)
    {
        PostId = postId;
        RecruiterId = recruiterId;
    }
}