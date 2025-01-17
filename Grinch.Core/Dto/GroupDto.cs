using Grinch.Core.DataEntities;

namespace Grinch.Core.Dto;

public class GroupDto
{
    public GroupDto(Group newGroup, List<UserDto> users)
    {
        this.Name = newGroup.Name;
        this.Currency = newGroup.Currency;
        this.Users = users;
        this.Id = newGroup.Id;
    }

    public string Name { get; set; }

    public string Currency { get; set; }

    public List<UserDto> Users { get; set; }

    public int Id { get; set; }

    public void PrintGroup()
    {
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Group Id: {this.Id}");
        Console.WriteLine($"Group Name: {this.Name}");
        Console.WriteLine($"Group Currency: {this.Currency}");
        Console.WriteLine($"Group Users:");
        foreach (var user in this.Users)
        {
            Console.WriteLine($"User Name: {user.UserName}");
        }

        Console.WriteLine("--------------------------------------------------------------");
    }

    public void PrintGroupAsListItem()
    {
        Console.WriteLine($"Group Id: {this.Id}  Name: {this.Name}");
    }

    public void PrintGroupWithExpenses()
    {
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Group Id: {this.Id}");
        Console.WriteLine($"Group Name: {this.Name}");
        Console.WriteLine($"Group Currency: {this.Currency}");
        Console.WriteLine($"Group Users:");
        var totalPaidAmount = this.Users.Sum(user => user.Expenses?.Sum(s => s.Amount) ?? 0);
        var eachUserShare = totalPaidAmount / this.Users.Count;

        foreach (var user in this.Users)
        {
            var currentUserPaidAmount = user.Expenses?.Sum(expense => expense.Amount) ?? 0;
            var message = "";
            if (eachUserShare > currentUserPaidAmount)
            {
                message = $"must pay {(eachUserShare - currentUserPaidAmount):F2} more expenses";
            }
            else
            {
                message = $"must receive {(currentUserPaidAmount - eachUserShare):F2} more expenses";
            }

            Console.WriteLine($"User Name: {user.UserName} Paid: {currentUserPaidAmount:F2} {message}");
        }

        Console.WriteLine("--------------------------------------------------------------");
    }
}