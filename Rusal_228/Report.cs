using System;
using System.Collections.Generic;
using System.Linq;

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

    public int? SaltCount { get; set; }

    public int? CryoCount { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Time { get; set; }

    public TimeSpan? AddTime { get; set; }

    public DateTime? AddDate { get; set; }

    public string? Mark { get; set; }

    public bool Ready { get; set; }

    public int? PrevId { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual Place? From { get; set; }

    public virtual ICollection<Report> InversePrev { get; set; } = new List<Report>();

    public virtual Personal? PersR { get; set; }

    public virtual Personal PersW { get; set; } = null!;

    public virtual Report? Prev { get; set; }

    public virtual Place? To { get; set; }

    public virtual GeneralStorage Type { get; set; } = null!;
    public override string ToString()
    {
        if (ToId == 6)
        {
            return $"Составить отчёт о поставке номер: {PostNumb}";
        }
        else if (FromId == 6)
        {
            return $"Составить отчёт о снабжении: {Id}";
        }
        else if (new int?[] { 0, 1, 2, 3, 4, 5 }.Contains(ToId) && PrevId != null)
        {
            return $"Составить отчёт о принятии снабжения: {Id}";
        }
        else if (new int?[] { 0, 1, 2, 3, 4, 5 }.Contains(ToId) && ToNumber != null)
        {
            return $"Составить отчёт о загруке ванны №: {ToNumber}";
        }
        else if (new int?[] { 0, 1, 2, 3, 4, 5 }.Contains(FromId)&&FromNumber!=null&&ToId==7&&ToNumber!=null&&PrevId!=null)
        {
            return $"Составить отчёт об окончании работы ванны №: {ToNumber}";
        }
        else
        {
            return $"{Id}";
        }
    }
}
