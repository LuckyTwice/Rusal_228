using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Personal
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int ProfId { get; set; }

    public virtual Profession Prof { get; set; } = null!;

    public virtual ICollection<Report> ReportPersRs { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportPersWs { get; set; } = new List<Report>();
}
