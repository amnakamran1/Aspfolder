using System;
using System.Collections.Generic;

namespace AspcrudAPI.Models;

public partial class Stdtable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;
}
