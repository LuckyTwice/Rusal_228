using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Profession
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
