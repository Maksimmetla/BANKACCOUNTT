﻿using System;
using System.Collections.Generic;

namespace BANKACCOUNTT.Models;

public partial class CardType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
