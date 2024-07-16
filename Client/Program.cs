using ICafeAccountManagementData;
using ICafeAccountManagementServices;
using ICafeAccountModels;
namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserGetServices getServices = new UserGetServices();

            var users = getServices.GetAllUsers();

            foreach (var item in users)
            {
                Console.WriteLine("Account username: " + item.username);
                Console.WriteLine("Account password: " + item.password);
            }
        }
    }
}
