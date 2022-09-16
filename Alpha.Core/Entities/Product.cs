﻿namespace Alpha.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}