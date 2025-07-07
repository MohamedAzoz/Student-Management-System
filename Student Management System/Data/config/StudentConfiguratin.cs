using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Management_System.Entities;

namespace Student_Management_System.Data.config
{
    public class StudentConfiguratin : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.SSN);
            builder.Property(s => s.SSN)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .ValueGeneratedNever();

            builder.Property(s => s.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(s => s.College)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(s => s.Department)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(s => s.DateOfBirth)
                .HasColumnType("DATE");


            builder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId);

            builder.ToTable("Students");
            builder.HasData(
                new Student { College = "Engineering College", Department = "Computer Science", DateOfBirth = new DateTime(2000, 1, 1), Name = "John Doe", SSN = "12345678901234" },
                new Student { College = "Arts College", Department = "English Literature", DateOfBirth = new DateTime(2001, 2, 2), Name = "Jane Smith", SSN = "23456789012345" },
                new Student { College = "Science College", Department = "Physics", DateOfBirth = new DateTime(2002, 3, 3), Name = "Alice Johnson", SSN = "34567890123456" }

                );
        }
    }
 }