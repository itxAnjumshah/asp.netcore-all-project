using System;
using System.Collections.Generic;

namespace MutiModelObject40.Models;

public partial class Student
{
    public int StuId { get; set; }

    public string StuName { get; set; } = null!;

    public string StuGender { get; set; } = null!;

    public DateOnly StuDob { get; set; }

    public string Stuphone { get; set; } = null!;

    public int? CourseId { get; set; }

    public virtual Course? Course { get; set; }
}
