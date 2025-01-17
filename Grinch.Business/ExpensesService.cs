using Grinch.Core.DataEntities;
using Grinch.Data;

namespace Grinch.Business;

public class ExpensesService
{
    public void AddExpense(int selectedGroupId, int userId, decimal amount, string? paidFor)
    {
        var dbContext = new AppDbContext();
        var groupUser = dbContext.GroupUsers.FirstOrDefault(g => g.GroupId == selectedGroupId && g.UserId == userId);
        dbContext.Expenses.Add(new Expense()
        {
            Amount = amount,
            GroupUserId = groupUser.Id,
            PaidFor = paidFor,
        });
        dbContext.SaveChanges();
    }
}