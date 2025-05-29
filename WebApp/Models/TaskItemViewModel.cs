namespace WebApp.Models
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ClientId { get; set; }
        public string? FreelancerId { get; set; }
    }
}
