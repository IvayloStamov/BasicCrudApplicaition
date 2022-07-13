namespace BasicCrudApplicaition.Models
{
    public class User
    {
        public User()
        {
            Activities = new HashSet<Activity>();
        }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string City { get; set; } = string.Empty;

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
