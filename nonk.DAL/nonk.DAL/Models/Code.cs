using System;
using System.Collections.Generic;

namespace nonk.DAL.Models;

public partial class Code
{
    public string CodeNames { get; set; } = null!;

    public string Codewords { get; set; } = null!;

    public string? UserName { get; set; }

    public string Area { get; set; } = null!;

    public virtual User? UserNameNavigation { get; set; }
}
