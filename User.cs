namespace webAppProject
{
    public class User
    {
        public int Id { get; set; }


        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;


        public string UserEmail { get; set; } = string.Empty;


        public int UserPhone { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
