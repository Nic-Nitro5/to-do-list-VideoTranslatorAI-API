﻿namespace todo_list_api.Models.DTOs.Todo
{
    public class UpdateTodoRequest
    {
        public bool completed { get; set; } = false;
        public bool translated { get; set; } = false;
    }
}
