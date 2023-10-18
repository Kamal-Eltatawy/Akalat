using Aklat.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Aklat.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController
            (UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.Adress = userVM.Address;
                user.PhoneNumber = userVM.Phone;
                user.UserName = userVM.UserName;
                user.Name = userVM.Name;
                user.PasswordHash = userVM.Password;


                IdentityResult result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }


            }

            return View(userVM);
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(userVm.UserName);
                if (user != null)
                {
                    bool found = await userManager.CheckPasswordAsync(user, userVm.Password);

                    if (found)
                    {
                        await signInManager.SignInAsync(user, userVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "userName or password is wrong");

            }
            return View(userVm);
        }
    }
}
