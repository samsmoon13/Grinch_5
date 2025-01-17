using Grinch.Core.DataEntities;

namespace Grinch.Core.Dto;

public class ExpenseDto
{
    public ExpenseDto(Expense expense)
    {
        this.Amount = expense.Amount;
        this.PaidFor = expense.PaidFor;
    }

    public string PaidFor { get; set; }

    public decimal Amount { get; set; }
}