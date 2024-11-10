using System;
using System.Collections.Generic;

namespace BANKACCOUNTT.Models;

public partial class ExchangeRate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }
}
