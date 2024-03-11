using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Product
{
    public int Id { get; set; }

    public string Mark { get; set; } = null!;

    public int StatusId { get; set; }

    public int? DefTypeId { get; set; }

    public int BatchId { get; set; }

    public int? Length { get; set; }

    public virtual Batch Batch { get; set; } = null!;

    public virtual DefType? DefType { get; set; }

    public virtual Status Status { get; set; } = null!;
}
