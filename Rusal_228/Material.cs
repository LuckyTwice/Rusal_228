using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<GeneralStorage> GeneralStorages { get; set; } = new List<GeneralStorage>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
