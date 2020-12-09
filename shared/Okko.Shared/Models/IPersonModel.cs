using System;

namespace Okko.Shared.Models
{
    public interface IPersonModel
    {
        int Id { get; set; }
        string CellPhone { get; set; }
        string Firstname { get; set; }
        DateTime DateOfBirth { get; set; }
        string IPT { get; set; }
        string Lastname { get; set; }
        string Location { get; set; }
        int LocationId { get; set; }
        string Position { get; set; }
        int PositionId { get; set; }
        DateTime RecordDate { get; set; }
        string RecordStatus { get; set; }
        string RecordUser { get; set; }
        string Title { get; set; }
        int TitleId { get; set; }
        string Picture { get; set; }
    }
}