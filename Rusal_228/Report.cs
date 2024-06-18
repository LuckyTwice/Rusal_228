using System;
using System.Collections.Generic;

namespace Rusal_228;

public partial class Report
{
    public int Id { get; set; }

    public int? PersRId { get; set; }

    public int? PersWId { get; set; }

    public int? PostNumb { get; set; }

    public int? FromId { get; set; }

    public int? FromNumber { get; set; }

    public int? ToId { get; set; }

    public int? ToNumber { get; set; }

    public int TypeId { get; set; }

    public int Count { get; set; }

    public int? CryoCount { get; set; }

    public int? SaltCount { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public TimeSpan? AddTime { get; set; }

    public DateTime? AddDate { get; set; }

    public bool Ready { get; set; }

    public int? PrevId { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual Place? From { get; set; }

    public virtual ICollection<Report> InversePrev { get; set; } = new List<Report>();

    public virtual Personal? PersR { get; set; }

    public virtual Personal? PersW { get; set; }

    public virtual Report? Prev { get; set; }

    public virtual Place? To { get; set; }

    public virtual Material Type { get; set; } = null!;
}
