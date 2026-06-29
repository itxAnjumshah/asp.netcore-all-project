using System;
using System.Collections.Generic;

namespace MutiModelObject40.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseDuration { get; set; } = null!;

    public int CourseFee { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
