using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Personal
{
    public int Id { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public int Профессия { get; set; }

    public virtual Password? Password { get; set; }

    public virtual Professium ПрофессияNavigation { get; set; } = null!;
}
