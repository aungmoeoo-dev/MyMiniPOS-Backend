using System;
using System.Collections.Generic;

namespace MyMiniPOS_Backend.Database.AppDbContextModels;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
