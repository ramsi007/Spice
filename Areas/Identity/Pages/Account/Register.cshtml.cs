using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Spice.Data;
using Spice.Models;
using Spice.Utility;

namespace Spice.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;


        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name ="Nom ")]
            public string Name { get; set; }

            [Display(Name = "Adresse")]
            public string StreetAdress { get; set; }

            [Display(Name = "Code Postal")]
            public string PostalCode { get; set; }

            [Display(Name = "Ville")]
            public string City { get; set; }

            [Display(Name = "Pays")]
            public string State { get; set; }

            [Display(Name = "N° Tél ")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    Name = Input.Name,
                    PhoneNumber= Input.PhoneNumber,
                    StreetAdress = Input.StreetAdress,
                    City = Input.City,
                    State = Input.State,
                    PostalCode = Input.PostalCode
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if(! await _roleManager.RoleExistsAsync(SD.ManagerUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.KitchenUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.KitchenUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.FrontDeskUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.CustomerAndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.CustomerAndUser));
                    }

                    string role = HttpContext.Request.Form["rdUserRole"].ToString();


                    var userInDb = _db.ApplicationUsers.ToList();
                    if (userInDb.Count <= 1)
                    {
                        await _userManager.AddToRoleAsync(user, SD.ManagerUser);
                        await _db.SaveChangesAsync();
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(role))
                        {
                            await _userManager.AddToRoleAsync(user, SD.CustomerAndUser);
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, role);
                        }
                    }

                    return RedirectToAction("Index", "Users", new { area = "Admin" });
                    /*
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                    */


                    //if(_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
