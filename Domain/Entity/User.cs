using Domain.Common;

namespace Domain.Entity;

public class User : BaseEntity
{
    public UserRole Role { get; set; } = UserRole.User;
    public UserStatus Status { get; set; } = UserStatus.Inactive;
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string FullName { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string? ProfilePictureUrl { get; set; }
    public string? TempPassword { get; set; }  
    public DateTime? TempPasswordExpiry { get; set; } 
    public string Salt { get; set; }
    public string? RefreshToken { get; set; }
    public string? ResetPasswordToken { get; set; }
    public DateTime? ResetPasswordTokenExpiry { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public ICollection<OtpCode> OtpCodes { get; set; } = new List<OtpCode>();
    public enum UserRole
    {
        Admin = 1,
        User
    }
    public enum UserStatus
    {
        New = 1,
        Active,
        Inactive,
        Deleted
    }
}


