using System;
using System.Collections.Generic;

namespace MyMiniPOS_Backend.Database.AppDbContextModels;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
