﻿using System;
using System.Collections.Generic;

namespace E_Commerce.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }
}
