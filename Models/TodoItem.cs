using System;
using System.Collections.Generic;

namespace TodoBasicAPI.Models;

public partial class TodoItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public sbyte IsComplete { get; set; }

    public int Uid { get; set; }

    public virtual User user { get; set; } = null!;
}
