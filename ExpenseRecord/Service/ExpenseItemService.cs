using Microsoft.EntityFrameworkCore;
using ExpenseRecord.Dto;

namespace ExpenseRecord.Service
{
  public class ExpenseItemService : IExpenseItemService
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public ExpenseItemService(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ExpenseItemDto>> GetAllAsync()
    {
      List<ExpenseItemDto> expenseItems = await _applicationDbContext.ExpenseItems.ToListAsync();

      return expenseItems;
    }

    public async Task<int> CreateAsync(ExpenseItemDto expenseItemDto)
    {
      var addedExpenseItem = new ExpenseItemDto
      {
        Description = expenseItemDto.Description,
        Type = expenseItemDto.Type,
        Amount = expenseItemDto.Amount,
        Date = DateTime.Now
      };

      _applicationDbContext.ExpenseItems.Add(addedExpenseItem);
      await _applicationDbContext.SaveChangesAsync();

      return addedExpenseItem.Id;
    }

    public async Task DeleteAsync(int id)
    {
      var expenseItem = await GetById(id);
      _applicationDbContext.ExpenseItems.Remove(expenseItem);
      await _applicationDbContext.SaveChangesAsync();
    }

    public async Task<ExpenseItemDto> GetById(int id)
    {
      var expenseItem = await _applicationDbContext.ExpenseItems.FindAsync(id);

      if (expenseItem == null) throw new Exception($"Expense item #{id} not found");
      _applicationDbContext.Entry(expenseItem).State = EntityState.Detached;
      return expenseItem;
    }

  }
}
