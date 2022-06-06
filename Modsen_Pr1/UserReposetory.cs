using Modsen_Pr1.Models;

namespace Modsen_Pr1
{
    public class UserReposetory
    {
        public static List<User> Users = new()
        {
            new() { Login = "12345", Password = "12345" },
            new() { Login = "55555", Password = "55555" },
        };
    }
}
