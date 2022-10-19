using Microsoft.EntityFrameworkCore;
using ExpenseRecord.Dto;

namespace ExpenseRecord
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<ExpenseItemDto> ExpenseItems { get; set; }
  }
}
