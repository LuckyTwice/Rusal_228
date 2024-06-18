using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class SizeName
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();
}
