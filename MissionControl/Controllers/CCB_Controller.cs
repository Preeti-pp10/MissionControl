using ApplicationLayer;
using ApplicationLayer.Commands.CCB_Adjustments;
using ApplicationLayer.Queries.CCB_Adjustments;
using DomainLayer.CCB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace MissionControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCB_Controller : BaseController
    {
        [HttpGet(nameof(CCB))]
        public async Task<IActionResult> CCB() => Ok(await Mediator.Send(new GetCCB()));

        [HttpPost(nameof(CCB_ById))]
        public async Task<IActionResult> CCB_ById(GetCCBById query) =>  Ok(await Mediator.Send(query));

        [HttpGet(nameof(Region))]
        public async Task<IActionResult> Region() => Ok(await Mediator.Send(new GetSalesLeader()));

        [HttpPost(nameof(SubRegion))]
        public async Task<IActionResult> SubRegion(GetSubRegion query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(Distrcit))]
        public async Task<IActionResult> Distrcit(GetDistrict query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(CustomSplit))]
        public async Task<ActionResult> CustomSplit (CreateCustomCommand command) =>Ok( await Mediator.Send(command));  



    }
}


