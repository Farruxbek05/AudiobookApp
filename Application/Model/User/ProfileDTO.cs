namespace Application.Model.User
{
    public class ProfileDTO
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string ProfilePictureUrl { get; set; }

    }
}
