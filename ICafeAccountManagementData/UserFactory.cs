//INTEG FINALS
using ICafeAccountModels;
namespace ICafeAccountManagementData
{
    public class UserFactory
    {
        private List<User> dummyUsers = new List<User>();

        public List<User> GetDummyUsers()
        {
            dummyUsers.Add(CreateDummyUser("Liam", "Pogi123"));
            dummyUsers.Add(CreateDummyUser("Edwardz", "06KO"));
            

            return dummyUsers;
        }

        private User CreateDummyUser(string username, string password)
        {
            User user = new User
            {
                username = username,
                password = password,
            };

            return user;
        }
    }
}

