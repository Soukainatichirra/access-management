namespace webAppProject
{
    public class Role
    {


        public int Id { get; set; }


        public string RoleName { get; set; } = string.Empty;
        public List<User> users { get; set; }

    }
}
