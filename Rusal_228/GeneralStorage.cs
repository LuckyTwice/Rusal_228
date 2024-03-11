using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class GeneralStorage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? PlacesId { get; set; }

    public int Count { get; set; }

    public virtual Place? Places { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
