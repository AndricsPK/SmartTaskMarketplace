namespace TaskService.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // e.g., "Open", "In Progress", "Completed"
        public string ClientId { get; set; }
        public string? FreelancerId { get; set; }
    }

}
