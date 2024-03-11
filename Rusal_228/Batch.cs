using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Batch
{
    public int Id { get; set; }

    public int ReportId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Report Report { get; set; } = null!;
}
