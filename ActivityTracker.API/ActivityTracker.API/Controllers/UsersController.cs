using ActivityTracker.API.Entities;
using ActivityTracker.API.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    public class UsersController : ApiController
    {

        private UserRepository _repo;

        private UsersController()
        {
            _repo = new UserRepository();
        }


        // GET api/users
        public IEnumerable<User> Get()
        {   
            return _repo.GetAllUsers();            
        }

        // GET api/users/5
        public async Task<User> Get(int id)
        {
            return await _repo.GetUserById(id);
        }

        // POST api/users
        public async Task<HttpResponseMessage> Post([FromBody] User user)
        {
            string response = await _repo.CreateUserAsync(user);
            
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}