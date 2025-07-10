using System;
using System.Collections.Generic;

namespace DNATestingSystem.Repository.ThinhLC.Models;

public partial class AppointmentStatusesTienDm
{
    public int AppointmentStatusesTienDmid { get; set; }

    public string StatusName { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<AppointmentsTienDm> AppointmentsTienDms { get; set; } = new List<AppointmentsTienDm>();
}
