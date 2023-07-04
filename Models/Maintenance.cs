using System;
using System.Collections.Generic;

namespace truck_maintenance_schedule_api.Models;

public partial class Maintenance
{
    public int Id { get; set; }

    public string Maintenance1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }
}
