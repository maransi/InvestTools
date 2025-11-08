using investTools.Web.Data;
using investTools.Web.Extensions;
using investTools.Web.Models;
using investTools.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace investTools.Web.Controllers.Api;

[ApiController]
[Route("[controller]/api/")]
public class InvestidorAPIController : ControllerBase
{
    private readonly IInvestidorRepository _investidorRepository;

    // Linha alterada
    public InvestidorAPIController(IInvestidorRepository investidorRepository)
    {
        _investidorRepository = investidorRepository;
    }

    [HttpGet("v1")]
    public async Task<ActionResult<List<Investidor>>> GetAllAsync()
    {
        try
        {
            var investidores = await _investidorRepository.GetAllAsync();

            // Linha eliminada
            // return Ok(new ResultViewModel<List<Investidor>>(investidores));

            // Linha inserida
            return Ok(new
            {
                Data = investidores
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<List<Investidor>>($"Ocorreu o seguinte erro [ {ex.Message} ]"));
        }
    }

    [HttpPost("v1")]
    public async Task<ActionResult<Investidor>> PostAsync([FromBody] CreateInvestidorViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Investidor>(ModelState.GetErrors()));

        try
        {
            var resultRet = await _investidorRepository.InsertAsync(model);

            var investidor = await _investidorRepository.GetByIdAsync(model);

            if (investidor != null)
            {
                return Created($"investidor/v1/cpf/{investidor.CPF}", new ResultViewModel<Investidor>(investidor));
            }
            else
            {
                return StatusCode(500, new ResultViewModel<Investidor>($"Ocorreu o seguinte erro "));
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Investidor>($"Ocorreu o seguinte erro [ {ex.Message} ]"));  // Linha alterada

        }
    }

    [HttpPut("v1")]
    public async Task<ActionResult<Investidor>> PutAsync([FromBody] CreateInvestidorViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Investidor>(ModelState.GetErrors()));

        try
        {
            var investidor = await _investidorRepository.GetByIdAsync(model);

            if (investidor == null)
                return NotFound(new ResultViewModel<Investidor>("Investidor não encontrado"));

            var resultRet = await _investidorRepository.UpdateAsync(model);

            investidor = await _investidorRepository.GetByIdAsync(model);

            return Ok(new ResultViewModel<Investidor>(investidor));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Investidor>($"Ocorreu o seguinte erro [ {ex.Message} ]"));  // Linha alterada
        }
    }

    [HttpDelete("v1")]
    public async Task<ActionResult> Delete([FromBody] CreateInvestidorViewModel model)
    {
        try
        {
            var investidor = await _investidorRepository.GetByIdAsync(model);

            if (investidor == null)
                return NotFound(new ResultViewModel<Investidor>("Investidor não encontrado"));

            await _investidorRepository.DeleteAsync(model);

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new ResultViewModel<Investidor>(ex.Message));
        }
    }

    [HttpGet("v1/{id:int}")]
    public async Task<ActionResult<Investidor>> GetByIdAsync([FromRoute] int id)
    {
        try
        {
            var createInvestidorViewModel = new CreateInvestidorViewModel{ Id = id };

            var investidor = await _investidorRepository.GetByIdAsync(createInvestidorViewModel);

            return investidor == null ?
                            NotFound(new { Id = 1, error = $"Não foi encontrado o investidor" }) :
                            Ok(new ResultViewModel<Investidor>(investidor));


        }
        catch (System.Exception)
        {
            throw;
        }
    }


}
