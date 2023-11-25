using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Post
{
    public int Id { get; set; }

    public int NumberPost { get; set; }

    public int Company { get; set; }

    public int TypeMaterial { get; set; }

    public int MarkaMaterial { get; set; }

    public int Count { get; set; }

    public int Unit { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public virtual Company CompanyNavigation { get; set; } = null!;

    public virtual MarkaMaterial MarkaMaterialNavigation { get; set; } = null!;

    public virtual TypeMaterial TypeMaterialNavigation { get; set; } = null!;

    public virtual Unit UnitNavigation { get; set; } = null!;
}
