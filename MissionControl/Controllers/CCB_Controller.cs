using ApplicationLayer.Queries.CCB_Adjustments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MissionControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCB_Controller : BaseController
    {
        [HttpGet(nameof(CCB))]
        public async Task<IActionResult> CCB() => Ok(await Mediator.Send(new GetCCB()));

        [HttpPost(nameof(CCB_ById))]
        public async Task<IActionResult> CCB_ById(GetCCBById query) => Ok(await Mediator.Send(query));
    }
}
