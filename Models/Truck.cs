using System;
using System.Collections.Generic;

namespace truck_maintenance_schedule_api.Models;

public partial class Truck
{
    public int Id { get; set; }

    public string Truck1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }
}
