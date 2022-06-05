namespace HMSApi.Dto
{
    public class UserDto
    {
        public UserDto(string fullName, string email, string userName, DateTime dateCreated)
        {
            FullName = fullName;
            Email = email;
            UserName = userName;
            DateCreated = dateCreated;
        }

        public string UserName { get; set; }    
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; } 
        // For testing git push
    }
}
