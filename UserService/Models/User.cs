namespace UserService.Models
{

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Role { get; set; } // "client" or "freelancer"
            public string Bio { get; set; }
        }
}
