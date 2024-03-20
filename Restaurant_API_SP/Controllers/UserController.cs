using System.Collections.Generic;
using System.Web.Http;
using Restaurant_API_SP.DAL;
using Restaurant_API_SP.Repository;

namespace Restaurant_API_SP.Controllers
{
    public class UserController : ApiController
    {
        private UserRepository UserRepository;

        public UserController()
        {
            UserRepository = new UserRepository();
        }

        // GET: api/User
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            List<User> Users = UserRepository.GetAllUsers();
            return Ok(Users);
        }

        // POST: api/User
        [HttpPost]
        public IHttpActionResult AddUser(User User)
        {
            if (UserRepository.AddUser(User))
            {
                return Ok("User added successfully");
            }
            else
            {
                return BadRequest("Failed to add User");
            }
        }

        // PUT: api/User/5
        [HttpPut]
        public IHttpActionResult UpdateUser(User User)
        {
            if (UserRepository.UpdateUser(User))
            {
                return Ok("User updated successfully");
            }
            else
            {
                return BadRequest("Failed to update User");
            }
        }

        // DELETE: api/User/5
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            if (UserRepository.DeleteUser(id))
            {
                return Ok("User deleted successfully");
            }
            else
            {
                return BadRequest("Failed to delete User");
            }
        }
    }
}