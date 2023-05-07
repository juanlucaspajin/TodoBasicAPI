using System;
using System.Collections.Generic;

namespace TodoBasicAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string ProfilePic { get; set; } = null!;

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
