using System.Threading.Tasks;
using TradeManagementApp.Server.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TradeManagementApp.Server.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RoleController(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var roleViewModel = new RoleViewModel()
            {
                LoginModel = model
            };
            return View(roleViewModel);
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Index(RoleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please, try again.");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.LoginModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "User not found");
                return View(model);
            }

            if (!_userManager.IsInRoleAsync(user, model.RoleValue).Result)
            {
                _ = _userManager.AddToRoleAsync(user, model.RoleValue).Result;
            }

            return Redirect(model.LoginModel.ReturnUrl);
        }
    }
}
