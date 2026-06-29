using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MutiModelObject40.Models;

public partial class StudentInfoDbContext : DbContext
{
    public StudentInfoDbContext()
    {
    }

    public StudentInfoDbContext(DbContextOptions<StudentInfoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("pk_courseId");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CourseDuration)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("courseDuration");
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("courseName");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StuId).HasName("pk_stuId");

            entity.ToTable("Student");

            entity.Property(e => e.StuGender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StuName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Stuphone)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Student_Course");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
