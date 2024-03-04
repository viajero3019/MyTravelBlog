using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyTravelBlog.Infrastructure.Identity;
using MyTravelBlog.Web.Areas.Identity.Pages.Account.Models;

namespace MyTravelBlog.Web.Areas.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<RegisterModel> logger )
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    public string? ReturnUrl{ get; set; }

    public IList<AuthenticationScheme>? ExternalLogins { get; set; }

    [BindProperty]
    public required RegisterInputModel Input { get; set; }

    [TempData]
    public string? ErrorMessage { get; set; }

    public void OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
    {
        returnUrl = returnUrl ?? Url.Content("~/");
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser { UserName = Input?.Email, Email = Input?.Email };
            var result = await _userManager.CreateAsync(user, Input?.Password!);

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { user.Id, code = code },
                    protocol: Request.Scheme
                );

                // Guard.Against.Null(callbackUrl, nameof(callbackUrl));

                await _signInManager.SignInAsync(user, isPersistent: true);

                return LocalRedirect(returnUrl);
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