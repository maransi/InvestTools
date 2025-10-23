using investTools.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using investTools.Web.Services.Email;           // Linha inserida

namespace investTools.Web.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IEmailSender emailSender;                  // Linha inserida

    public AccountController(UserManager<IdentityUser> userManager,
                                        SignInManager<IdentityUser> signInManager,
                                        IEmailSender emailSender)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.emailSender = emailSender;                         // Linha inserida
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Copia os dados do RegisterViewModel para o IdentityUser
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            // Copia os dados do usuário na tabela AspNetUsers
            var result = await userManager.CreateAsync(user, model.Password);

            // Se o usuário foi criado com sucesso, faz o login do usuário
            // usando o serviço SignInManager e redireciona para o Método /action Index
            if (result.Succeeded)
            {
                // await signInManager.SignInAsync(user, isPersistent: false);

                // Linha inserida
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                // Linha inserida
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);

                // Linha inserida
                var message = new Message(new string[] { user.Email }, "Link para Confirmação da sua Conta", confirmationLink, null);

                // Linha inserida
                await emailSender.SendEmailAsync(message);


                // return RedirectToAction("Index", "home");
                // Linha inserida
                return RedirectToAction(nameof(SuccessRegistration));
            }

            // Se houver erros então inclui no ModelState
            // que será exibido pela tag helper summary na validação
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {

            // Linha inserida
            var currentUser = userManager.FindByNameAsync(model.Email);

            // If inserido
            if (!currentUser.Result.EmailConfirmed)
            {
                ModelState.AddModelError(string.Empty, "Conta não Confirmada, Favor Verificar seu Email");

                return View();
            }

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }

            // ModelState.AddModelError(string.Empty, "Login Inválido");
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction("login", "account");
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
    {
        if (!ModelState.IsValid)
            return View(forgotPasswordModel);

        var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
        if (user == null)
            return RedirectToAction(nameof(ForgotPasswordConfirmation));

        var token = await userManager.GeneratePasswordResetTokenAsync(user);

        // Linha com erro temporariamente, nos passos abaixo vem o acerto qdo fizermos o "Reset Password"
        var callback = Url.Action(nameof(ResetPassword), "Account", new { token, email = user.Email }, Request.Scheme);

        var message = new Message(new string[] { user.Email }, "Reset password token", callback, null);
        await emailSender.SendEmailAsync(message);

        return RedirectToAction(nameof(ForgotPasswordConfirmation));
    }

    public IActionResult ForgotPasswordConfirmation()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ResetPassword(string token, string email)                              // Metodo inserido
    {
        var model = new ResetPasswordModel { Token = token, Email = email };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)       // Metodo inserido
    {
        if (!ModelState.IsValid)
            return View(resetPasswordModel);

        var user = await userManager.FindByEmailAsync(resetPasswordModel.Email);
        if (user == null)
            RedirectToAction(nameof(ResetPasswordConfirmation));

        var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
        if (!resetPassResult.Succeeded)
        {
            foreach (var error in resetPassResult.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }

            return View();
        }

        return RedirectToAction(nameof(ResetPasswordConfirmation));
    }

    [HttpGet]
    public IActionResult ResetPasswordConfirmation()                                            // Metodo inserido
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        if (user == null)
            return View("Error");

        var result = await userManager.ConfirmEmailAsync(user, token);

        return View(result.Succeeded ? nameof(ConfirmEmail) : "Error");
    }

    [HttpGet]
    public IActionResult SuccessRegistration()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Error()
    {
        return View();
    }

}

