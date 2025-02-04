using System;
using System.Collections.Generic;

namespace MyMiniPOS_Backend.Database.AppDbContextModels;

public partial class Order
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
