using System;
using System.Collections.Generic;

namespace nonk.DAL.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string? UserName { get; set; }

    public byte Grade { get; set; }

    public string Qualification { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public virtual User? UserNameNavigation { get; set; }
}
