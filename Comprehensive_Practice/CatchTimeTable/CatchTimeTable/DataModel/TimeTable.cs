using System;
using System.Collections.Generic;

namespace CatchTimeTable.DataModel;

public partial class TimeTable
{
    public int Id { get; set; }

    public string RouteId { get; set; } = null!;

    public int Direction { get; set; }

    public string Stop { get; set; } = null!;

    public string Time { get; set; } = null!;

    public string? Car { get; set; }
}
