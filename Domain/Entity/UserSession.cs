namespace Domain.Entity;

public class UserSession
{
    public UserSession(string token, Guid userId)
    {
        Token = token;
        UserId = userId;
        Status = SessionStatus.Verified;
        CreatedAt = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string Token { get; private set; }
    public SessionStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public Guid UserId { get; private set; }
    public User User { get; private set; }
}
public enum SessionStatus
{
    Unverified = 1,
    Verified,
    Expired
}
