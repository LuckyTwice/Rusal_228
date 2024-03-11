using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Place
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Count { get; set; }

    public virtual ICollection<GeneralStorage> GeneralStorages { get; set; } = new List<GeneralStorage>();

    public virtual ICollection<Report> ReportFroms { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportTos { get; set; } = new List<Report>();
}
