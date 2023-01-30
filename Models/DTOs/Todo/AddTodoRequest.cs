namespace todo_list_api.Models.DTOs.Todo
{
    public class AddTodoRequest
    {
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public bool completed { get; set; } = false;
        public Guid createdBy { get; set; }
        public DateTime createdAt { get; set; }
    }
}
