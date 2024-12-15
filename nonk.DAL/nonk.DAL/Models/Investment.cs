using System;
using System.Collections.Generic;

namespace nonk.DAL.Models;

public partial class Investment
{
    public string UserName { get; set; } = null!;

    public decimal? InvestmentAmount { get; set; }

    public string Entity { get; set; } = null!;

    public string Assets { get; set; } = null!;

    public string Liabilities { get; set; } = null!;

    public virtual ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
