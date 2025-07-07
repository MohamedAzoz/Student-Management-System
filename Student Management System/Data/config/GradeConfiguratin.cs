using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Management_System.Entities;

namespace Student_Management_System.Data.config
{
    public class GradeConfiguratin : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(g => g.Id);
          
            builder.Property(g => g.Id).HasColumnType("int")
                .ValueGeneratedNever();

            builder.Property(c => c.EnrollmentId).HasColumnType("VARCHAR")
               .HasMaxLength(14).ValueGeneratedNever();


            builder.Property(g => g.Value)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.HasOne(x=>x.Enrollment)
                .WithOne(x => x.Grade)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Grades");

            builder.HasData(
                new Grade {  Id = 1 ,EnrollmentId = "#7994", Value = 85.50},
                new Grade {  Id = 2 ,EnrollmentId = "#9451", Value = 90.00},
                new Grade {  Id = 3 ,EnrollmentId ="#2454" , Value = 78.00},
              
                new Grade {  Id = 4 ,EnrollmentId ="#1454" , Value = 82.00 },
                new Grade {  Id = 5 ,EnrollmentId ="#8541" , Value = 87.50 },
                new Grade {  Id = 6,EnrollmentId ="#1234" , Value = 79.00 },
                      
                new Grade {  Id = 7,EnrollmentId ="#1245" , Value = 88.00 },
                new Grade {  Id = 8,EnrollmentId ="#9884" , Value = 85.00 },
                new Grade {  Id = 9,EnrollmentId ="#7845" , Value = 90.00 }

                );
        }
    }
}
