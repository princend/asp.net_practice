using Microsoft.AspNetCore.Mvc;

public interface IUserLogic
{
    void Create(User user);
}

public class UserLogic : IUserLogic
{
    public void Create(User user)
    {

    }
}

public class UserCotroller : Controller
{
    public void Register(User user)
    {
        var logic = new UserLogic();
        logic.Create(user);
    }
}


public class User
{

}