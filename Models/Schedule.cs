using System;
using System.Collections.Generic;

namespace truck_maintenance_schedule_api.Models;

public partial class Schedule
{
    public int? Id { get; set; }

    public string Truck { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Driver { get; set; } = null!;

    public string Dispatcher { get; set; } = null!;

    public DateTime Duedate { get; set; }

    public string Mechanic { get; set; } = null!;
}
