using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class SalesmanController : ControllerBase
{
    private readonly ICommissionService _commissionService;

    public SalesmanController(ICommissionService commissionService)
    {
        _commissionService = commissionService;
    }

    [HttpPost("calculate-commission")]
    public ActionResult<double> CalculateCommission([FromBody] Salesman salesman)
    {
        var commission = _commissionService.CalculateCommission(salesman);
        return Ok(commission);
    }
}
