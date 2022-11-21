﻿using Microsoft.EntityFrameworkCore;

namespace DbTestHW.Domain;

public class Category
{
    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;
}