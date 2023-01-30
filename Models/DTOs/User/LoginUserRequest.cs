namespace todo_list_api.Models.DTOs.User
{
    public class LoginUserRequest
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
