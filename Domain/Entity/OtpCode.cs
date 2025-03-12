using Domain.Common;

namespace Domain.Entity;

public class OtpCode : BaseEntity
{
    public OtpCode()
    {

    }
    public string Code { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
    public OtpCodeStatus Status { get; set; }
    public int Attempts { get; set; } = 0;
    public Guid UserId { get; }
    public User User { get; }
}
public enum OtpCodeStatus
{
    Unverified = 1,
    Verified,
    Expired,
    Blocked
}
