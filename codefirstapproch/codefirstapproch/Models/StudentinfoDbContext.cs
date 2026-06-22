//using Microsoft.EntityFrameworkCore;

//namespace codefirstapproch.Models
//{
//    public class StudentinfoDbContext: DbContext
//    {
//        public StudentinfoDbContext(DbContextOptions options) : base(options)
//        {
//        }
//        DbSet<Student> Students { get; set; }
//    }
//}


using Microsoft.EntityFrameworkCore;

namespace codefirstapproch.Models
{
    public class StudentinfoDbContext : DbContext
    {
        public StudentinfoDbContext(DbContextOptions<StudentinfoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}   