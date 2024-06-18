using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Batch
{
    public int Id { get; set; }

    public int ReportId { get; set; }

    public int? Length { get; set; }

    public int? Radius { get; set; }

    public int SizeId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Report Report { get; set; } = null!;

    public virtual SizeName Size { get; set; } = null!;
}
