using System;
using System.Collections.Generic;

namespace nonk.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte Age { get; set; }

    public string Gender { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public decimal PhoneNumber { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public virtual ICollection<Code> Codes { get; set; } = new List<Code>();

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
