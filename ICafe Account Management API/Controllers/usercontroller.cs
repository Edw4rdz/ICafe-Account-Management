
using ICafeAccountManagementServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using ICafeAccountModels;

namespace ICafeAccountManagementAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        UserGetServices userGetServices;
        UserTransactionServices userTransactionServices;

        public UserController()
        {
            userGetServices = new UserGetServices();
            userTransactionServices = new UserTransactionServices();
        }

        [HttpGet]
        public IEnumerable<ICafeAccountManagementAPI.User> GetUsers()
        {
            var activeusers = userGetServices.GetAllUsers();

            List<ICafeAccountManagementAPI.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new ICafeAccountManagementAPI.User { username = item.username, password = item.password });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = userTransactionServices.CreateUser(request.username, request.password);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = userTransactionServices.UpdateUser(request.username, request.password);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(ICafeAccountManagementAPI.User request)
        {

            var userToDelete = new ICafeAccountModels.User
            {
                username = request.username

            };

            var result = userTransactionServices.DeleteUser(userToDelete);

            return new JsonResult(result);
        }
    }
}
