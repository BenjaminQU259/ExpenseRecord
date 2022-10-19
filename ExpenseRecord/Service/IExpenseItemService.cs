using ExpenseRecord.Dto;

namespace ExpenseRecord.Service
{
  public interface IExpenseItemService
  {
    Task<List<ExpenseItemDto>> GetAllAsync();
    Task<int> CreateAsync(ExpenseItemDto expenseItemDto);
    Task DeleteAsync(int id);
    Task<ExpenseItemDto> GetById(int id);
  }
}
