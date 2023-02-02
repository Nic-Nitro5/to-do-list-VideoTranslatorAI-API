namespace todo_list_api.Models.Entities
{
    public class Todo
    {
        public Guid id { get; set; }
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public bool translated { get; set; } = false;
        public bool completed { get; set; } = false;
        public Guid createdBy { get; set; }
        public DateTime createdAt { get; set; }
    }
}
