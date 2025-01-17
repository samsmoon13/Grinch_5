using Grinch.Core.Dto;

namespace Grinch.Business;

public class ProcessManagementService
{
    private GroupService groupService;
    private UserService userService;

    public ProcessManagementService()
    {
        this.groupService = new GroupService();
        this.userService = new UserService();
    }

    public void CreateGroupProcess()
    {
        Console.WriteLine("Please enter Group Name: ");
        var groupName = Console.ReadLine();
        Console.WriteLine("Please enter the used currency: ");
        var currency = Console.ReadLine();

        var usersList = new List<UserDto>();
        while (true)
        {
            Console.WriteLine("Please enter the username: ");
            var username = Console.ReadLine();
            usersList.Add(userService.CreateUser(username));
            Console.WriteLine("Do you want to add more users?(y/n)");
            if (Console.ReadLine() == "n")
            {
                break;
            }
        }

        var createdGroup = groupService.CreateGroup(groupName, currency, usersList);
        Console.WriteLine("Do you want to see the created group?(y/n)");

        if (Console.ReadLine() == "y")
        {
            createdGroup.PrintGroup();
        }

        Console.WriteLine($"Enter to continue");
        Console.ReadLine();
    }

    public void ManageProcesses()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Do you want to Create a new Group?(y/n) ");
            var yesNo = Console.ReadLine();
            if (yesNo == "y")
            {
                this.CreateGroupProcess();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to Add expenses into a existing group?(y/n) ");
                yesNo = Console.ReadLine();
                if (yesNo == "y")
                {
                    this.AddExpensesIntoGroupProcess();
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to Add/Delete participants from the group?(y/n) ");
                yesNo = Console.ReadLine();
                if (yesNo == "y")
                {
                    this.AddOrDeleteParticipantsFromGroupProcess();
                }
                else
                {
                    break;
                }
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to see the expenses?(y/n) ");
                yesNo = Console.ReadLine();
                if (yesNo == "y")
                {
                    this.ShowAllExpensesInGroupProcess();
                }
                else
                {
                    break;
                }
            }
        }
    }

    private void ShowAllExpensesInGroupProcess()
    {
        var groups = PrintAllGroups();
        Console.WriteLine($"Please enter the group Id see the details? ");
        var groupId = Console.ReadLine();
        var selectedGroup = groups.First(g => g.Id == int.Parse(groupId));
        selectedGroup.PrintGroupWithExpenses();
        Console.WriteLine($"Enter to continue");
        Console.ReadLine();
    }

    private void AddOrDeleteParticipantsFromGroupProcess()
    {
        Console.WriteLine("Do you want to Add or Delete a participant from the group?(add/delete) ");
        var addOrDelete = Console.ReadLine();
        var groups = PrintAllGroups();
        Console.WriteLine($"Please enter the group Id to {addOrDelete} a Participant? ");
        var groupId = Console.ReadLine();
        var selectedGroup = groups.First(g => g.Id == int.Parse(groupId));

        foreach (var user in selectedGroup.Users)
        {
            user.PrintUserAsListItem();
        }

        Console.WriteLine($"Please enter the username to {addOrDelete}? ");
        var username = Console.ReadLine();
        if (addOrDelete == "add")
        {
            groupService.AddParticipantIntoGroup(selectedGroup.Id, username);
        }
        else if (addOrDelete == "delete")
        {
            groupService.DeleteParticipantFromGroup(selectedGroup.Id, username);
        }

        Console.WriteLine($"The user with username {username} has been {addOrDelete}ed.");

        Console.WriteLine($"Enter to continue");
        Console.ReadLine();
    }

    private void AddExpensesIntoGroupProcess()
    {
        var groups = PrintAllGroups();

        Console.WriteLine("Please enter the group Id to add expenses to?");
        var groupId = Console.ReadLine();
        var selectedGroup = groups.First(g => g.Id == int.Parse(groupId));
        foreach (var user in selectedGroup.Users)
        {
            user.PrintUserAsListItem();
        }

        Console.WriteLine("Please enter the username to add paid for?");
        var username = Console.ReadLine();
        var userId = selectedGroup.Users.First(u => u.UserName == username).Id;

        Console.WriteLine("Please enter the amount of expenses to add?");
        var amount = decimal.Parse(Console.ReadLine());
        Console.WriteLine("What for?");
        var paidFor = Console.ReadLine();
        var expensesService = new ExpensesService();
        expensesService.AddExpense(selectedGroup.Id, userId, amount, paidFor);
        Console.WriteLine("The expenses have been added to the group.");
        Console.WriteLine($"Enter to continue");
        Console.ReadLine();
    }

    private List<GroupDto> PrintAllGroups()
    {
        var groups = groupService.GetAllGroups();
        Console.WriteLine("Here is the groups:");
        foreach (var group in groups)
        {
            group.PrintGroupAsListItem();
        }

        return groups;
    }
}