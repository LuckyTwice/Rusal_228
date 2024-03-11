using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Account
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Personal IdNavigation { get; set; } = null!;
}
