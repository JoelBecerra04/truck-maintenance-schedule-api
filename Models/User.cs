﻿using System;
using System.Collections.Generic;

namespace truck_maintenance_schedule_api.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public bool Status { get; set; }
}
