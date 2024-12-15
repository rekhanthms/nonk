using System;
using System.Collections.Generic;

namespace nonk.DAL.Models;

public partial class Mission
{
    public decimal MissionCode { get; set; }

    public string? UserName { get; set; }

    public decimal NoOfMissions { get; set; }

    public string Status { get; set; } = null!;

    public virtual Investment? UserNameNavigation { get; set; }
}
