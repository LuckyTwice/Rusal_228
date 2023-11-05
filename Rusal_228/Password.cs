using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Password
{
    public int Id { get; set; }

    public int Password1 { get; set; }

    public virtual Personal IdNavigation { get; set; } = null!;
}
