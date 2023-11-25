using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
