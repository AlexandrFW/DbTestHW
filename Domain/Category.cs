using Microsoft.EntityFrameworkCore;

namespace DbTestHW.Domain;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}