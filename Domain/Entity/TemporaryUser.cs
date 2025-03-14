namespace Domain.Entity;

public class TemporaryUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string? PhotoPath { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
}

