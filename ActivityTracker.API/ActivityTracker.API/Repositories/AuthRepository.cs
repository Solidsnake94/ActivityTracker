using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ActivityTracker.API.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ActivityTracker.API.Repositories
{
    public class AuthRepository: IDisposable
    {
        private readonly EntityModel _ctx;

        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new EntityModel();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(User userModel)
        {
            IdentityUser identityUser = new IdentityUser
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
            var result = await _userManager.CreateAsync(identityUser, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }
//
//        public async Task<IdentityUser> FindUserByName(string userName)
//        {
//            IdentityUser user = await _userManager.FindByNameAsync(userName);
//
//            return user;
//        }
//
//        public async Task<IdentityUser> FindUserById(string id)
//        {
//            IdentityUser user = await _userManager.FindByIdAsync(id);
//
//            return user;
//       }

        public async Task<IdentityUser> FindUserByEmail(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return user;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}