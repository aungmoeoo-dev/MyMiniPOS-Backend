using System;
using System.Collections.Generic;

namespace MyMiniPOS_Backend.Database.AppDbContextModels;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool IsDeleted { get; set; }
}
