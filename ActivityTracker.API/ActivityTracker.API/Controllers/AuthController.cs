using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ActivityTracker.API.Entities;
using ActivityTracker.API.IRepositories;
using ActivityTracker.API.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityTracker.API.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private AuthRepository authRepo;
        private UserRepository _userRepo;



        //        public AuthController(IUserRepository userRepo, AuthRepository _authRepo)
        //        {
        //            authRepo = _authRepo;
        //            _userRepo = userRepo;
        //        }

        public AuthController()
        {
            authRepo =  new AuthRepository();
            _userRepo = new UserRepository();
        }




        // POST api/auth/register
        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(User userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await authRepo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
            else
            {

                var identityUser = await authRepo.FindUserByEmail(userModel.Email);
                await _userRepo.CreateUserAsync(identityUser, userModel);

            }


            return Ok();
        }

        [AllowAnonymous]
        [Route("FindUserByEmail")]
        [HttpGet]
        public async Task<IHttpActionResult> FindUserByEmail()
        {
            var user = await authRepo.FindUserByEmail("pawel.identity@gmail.com");

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                authRepo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
