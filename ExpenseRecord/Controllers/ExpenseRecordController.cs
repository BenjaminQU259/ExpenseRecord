using Microsoft.AspNetCore.Mvc;
using ExpenseRecord.Dto;
using ExpenseRecord.Service;

namespace ExpenseRecord.Controllers
{
  [ApiController]
  [Route("api/items")]
  public class ExpenseRecordController : ControllerBase
  {
    private readonly IExpenseItemService _expenseItemService;

    public ExpenseRecordController(IExpenseItemService expenseItemService)
    {
      _expenseItemService = expenseItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecordsAsync()
    {
      var expenseItems = await _expenseItemService.GetAllAsync();

      return new ObjectResult(expenseItems);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItemAsync(ExpenseItemDto expenseItemDto)
    {
      try
      {
        var id = await _expenseItemService.CreateAsync(expenseItemDto);
        var obj = new Result();
        obj.Id = id;
        return Created($"api/items/{id}", obj);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteItemAsync([FromRoute] int id)
    {
      try
      {
        await _expenseItemService.DeleteAsync(id);

        return NoContent();
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetItemByIdAsync([FromRoute] int id)
    {
      try
      {
        var expenseItem = await _expenseItemService.GetById(id);

        return new ObjectResult(expenseItem);
      }
      catch (Exception e)
      {
        return NotFound(e.Message);
      }
    }
  }
}