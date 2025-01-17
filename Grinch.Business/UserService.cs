using Grinch.Core.DataEntities;
using Grinch.Core.Dto;
using Grinch.Data;

namespace Grinch.Business;

public class UserService
{
    private readonly AppDbContext dbContext;

    public UserService()
    {
        this.dbContext = new AppDbContext();
    }

    public UserDto CreateUser(string userName)
    {
        var dbUser = dbContext.Users.FirstOrDefault(x =>
            x.UserName.ToLower() == userName.ToLower());

        if (dbUser == null)
        {
            dbUser = new User() { UserName = userName };
            dbContext.Users.Add(dbUser);
            dbContext.SaveChanges();
        }

        return new UserDto(dbUser.UserName, dbUser.Id, null);
    }

    public void DeleteUser(int userId)
    {
        var dbUser = this.dbContext.Users.First(u => u.Id == userId);
        this.dbContext.Users.Remove(dbUser);
        this.dbContext.SaveChanges();
    }
}