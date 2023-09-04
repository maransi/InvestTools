using investTools.Web.Data;
using investTools.Web.Extensions;
using investTools.Web.Models.Pessoa;
using investTools.Web.ViewModels;
using investTools.Web.ViewModels.Pessoa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace investTools.Web.Controllers.Api.Pessoa;

[ApiController]
[Route("[controller]/api/")]
public class InvestidorAPIController: ControllerBase
{
    private readonly IInvestidorRepository _investidorRepository;

    public InvestidorAPIController(IInvestidorRepository investidorRepository)
    {
        _investidorRepository = investidorRepository;
    }

    [HttpGet("v1")]
    public async Task<ActionResult<List<Investidor>>> GetAllAsync()
    {
        try
        {
            var investidores = _investidorRepository.GetAllAsync();

            return Ok( new ResultViewModel< Task<List<Investidor>> >( investidores ));
        }
        catch( Exception ex)
        {
            return StatusCode( 500, new ResultViewModel<List<Investidor>>($"Ocorreu o seguinte erro [ {ex.Message} ]"));
        }
    }

    [HttpPost("v1")]
    public async Task<ActionResult<Investidor>> PostAsync( [FromBody] CreateInvestidorViewModel model )
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Investidor>(ModelState.GetErrors()));

        try
        {
            var resultRet = await _investidorRepository.InsertAsync( model );

            if (resultRet > 0 )
            {
                return Created($"investidor/v1/cpf/{model.CPF}", new ResultViewModel<CreateInvestidorViewModel>(model));
            }
            else
            {
                return StatusCode(500, new ResultViewModel<Investidor>($"Ocorreu o seguinte erro "));  // Linha alterada
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Investidor>($"Ocorreu o seguinte erro [ {ex.Message} ]"));  // Linha alterada

        }
    }
}
