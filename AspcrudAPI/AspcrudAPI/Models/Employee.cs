using System;
using System.Collections.Generic;

namespace AspcrudAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Faculty { get; set; } = null!;
}
