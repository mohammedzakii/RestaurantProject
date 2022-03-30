using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcProject.ViewModel;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MvcProject.Controllers
{
    public class AccountController : Controller
    {

        SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginuser)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginuser.username);
                if (user != null)
                {
                   SignInResult result =

                   await signInManager.PasswordSignInAsync(user, loginuser.password, loginuser.Remember_Me, false);
                    if (result.Succeeded)
                        return RedirectToAction("index", "Home");//change view
                    else
                    {
                        ModelState.AddModelError("", "Invalid Password ");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password and UserName");

                }

            }


            return View(loginuser);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }




        [HttpGet]//calling from anchor tag
        public IActionResult Register()
        {


            return View();
        }
        [HttpPost]//calling submit button
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel newuser)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newuser.UserName;
                user.Email = newuser.Email;

                IdentityResult result = await userManager.CreateAsync(user, newuser.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("index", "Home");/////////change view

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newuser);
        }

        // registration to add admin

        [Authorize(Roles = "admin")] //after add admin 
        [HttpGet]//calling from anchor tag
        public IActionResult AddAdmin()
        {


            return View();
        }
        [HttpPost]//calling submit button
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddAdmin(AdminViewModel newuser)
        {
            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = newuser.UserName;
                user.Email = newuser.Email;

                IdentityResult result = await userManager.CreateAsync(user, newuser.Password);
                if (result.Succeeded)
                {
                   await userManager.AddToRoleAsync(user, "admin");
                   await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", " Resturant");/////////change view

                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(newuser);
        }

    }
}
