using Grinch.Core.DataEntities;
using Grinch.Core.Dto;
using Grinch.Data;
using Microsoft.EntityFrameworkCore;

namespace Grinch.Business;

public class GroupService
{
    private AppDbContext dbContext { get; set; }

    public GroupService()
    {
        this.dbContext = new AppDbContext();
    }

    public GroupDto CreateGroup(string groupName, string currency, List<UserDto> users)
    {
        var newGroup = new Group()
        {
            Name = groupName,
            Currency = currency
        };
        this.dbContext.Groups.Add(newGroup);
        this.dbContext.SaveChanges();

        this.AssignUsersToGroup(newGroup.Id, users);

        return new GroupDto(newGroup, users);
    }

    private void AssignUsersToGroup(int groupId, List<UserDto> users)
    {
        foreach (var user in users)
        {
            this.dbContext.GroupUsers.Add(new GroupUser()
            {
                GroupId = groupId,
                UserId = user.Id
            });
        }

        this.dbContext.SaveChanges();
    }

    public List<GroupDto> GetAllGroups()
    {
        var allGroups = this.dbContext.Groups
            .Include(g => g.GroupUsers)
            .ThenInclude(g => g.Expenses)
            .Include(g => g.GroupUsers)
            .ThenInclude(g => g.User).ToList();

        var result = new List<GroupDto>();
        foreach (var group in allGroups)
        {
            var users = group.GroupUsers.Select(g => new UserDto(g.User.UserName, g.UserId, g.Expenses?.ToList()))
                .ToList();
            result.Add(new GroupDto(group, users));
        }

        return result;
    }

    public void AddParticipantIntoGroup(int groupId, string username)
    {
        var dbUser = this.dbContext.Users.First(u => u.UserName == username);
        this.dbContext.GroupUsers.Add(new GroupUser() { UserId = dbUser.Id, GroupId = groupId });
        this.dbContext.SaveChanges();
    }

    public void DeleteParticipantFromGroup(int selectedGroupId, string username)
    {
        var dbUser = this.dbContext.Users.First(u => u.UserName == username);
        var groupUser = this.dbContext.GroupUsers.First(g => g.GroupId == selectedGroupId && g.UserId == dbUser.Id);
        this.dbContext.GroupUsers.Remove(groupUser);
        this.dbContext.SaveChanges();
    }
}