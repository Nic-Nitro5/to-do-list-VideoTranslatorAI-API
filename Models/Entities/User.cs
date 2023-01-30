namespace todo_list_api.Models.Entities
{
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool admin { get; set; } = false;
        public DateTime createdAt { get; set; }
    }
}
