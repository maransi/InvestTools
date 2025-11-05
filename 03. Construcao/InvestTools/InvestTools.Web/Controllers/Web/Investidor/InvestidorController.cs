using investTools.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace investTools.Web.Controllers.Web.Investidor;

public class InvestidorController : Controller
{

    private readonly IInvestidorRepository _investidorRepository;

    public InvestidorController(IInvestidorRepository InvestidorRepository)
    {
        _investidorRepository = InvestidorRepository;
    }


    public IActionResult List()
    {
        ViewBag.Title = "Investidores";

        return View();
    }

    public IActionResult GetModalPartial()
    {
        return PartialView("_InvestidorModal");
    }

}
