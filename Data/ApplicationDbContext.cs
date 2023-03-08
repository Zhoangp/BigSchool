using BigSchool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BigSchool.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<CourseModel> CourseModel {set; get;}
    public DbSet<CategoryModel> CategoryModel {set; get;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
