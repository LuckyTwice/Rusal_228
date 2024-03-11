using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class DefType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
