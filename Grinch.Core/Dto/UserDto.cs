using Grinch.Core.DataEntities;

namespace Grinch.Core.Dto;

public class UserDto
{
    public UserDto(string userName, int id, List<Expense>? expenses)
    {
        this.UserName = userName;
        this.Id = id;
        this.Expenses = [];
        if (expenses is not null)
        {
            foreach (var expense in expenses)
            {
                this.Expenses.Add(new ExpenseDto(expense));
            }
        }
    }

    public string UserName { get; set; }

    public int Id { get; set; }

    public List<ExpenseDto> Expenses { get; set; }

    public void PrintUserAsListItem()
    {
        Console.WriteLine($"UserName: {this.UserName}");
    }
}