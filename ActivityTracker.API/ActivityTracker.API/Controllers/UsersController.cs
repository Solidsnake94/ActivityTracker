using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ActivityTracker.API.Repositories;

namespace ActivityTracker.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {

        private IUserRepository _userRepository;

//        public UsersController(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

        public UsersController()
        {
            _userRepository = new UserRepository();
        }


        // GET api/users
        public IEnumerable<User> Get()
        {   
            return _userRepository.GetAllUsers();            
        }

        // GET api/users/5
        public async Task<User> Get(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        // POST api/users
        public async Task<HttpResponseMessage> Post([FromBody] User user)
        {
            string response = await _userRepository.CreateUserAsync(user);
            
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