using ApplicationLayer.Commands;
using ApplicationLayer.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MissionControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        [HttpGet(nameof(Orders))]
        public async Task<IActionResult> Orders() => Ok(await Mediator.Send(new GetAllOrdersQuery()));

        [HttpGet(nameof(OrderData))]
        public async Task<IActionResult> OrderData() => Ok(await Mediator.Send(new GetDataQuery()));

        [HttpGet(nameof(OrderRemap))]
        public async Task<IActionResult> OrderRemap() => Ok(await Mediator.Send(new GetOrderRemapQuery()));

        [HttpGet(nameof(Methods))]
        public async Task<IActionResult> Methods() => Ok(await Mediator.Send(new GetMethodQuery()));

        [HttpGet(nameof(StandarReasons))]
        public async Task<IActionResult> StandarReasons() => Ok(await Mediator.Send(new GetStandarReasonQuery()));

        [HttpPost(nameof(SaveOrderData))]
        public async Task<IActionResult> SaveOrderData(CreateOrUpdateOrderRemap command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(SaveAuditData))]
        public async Task<IActionResult> SaveAuditData(CreateOrderAuditCommand command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(EditAuditData))]
        public async Task<IActionResult> EditAuditData(UpdateAuditCommand command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(DeleteAuditData))]
        public async Task<IActionResult> DeleteAuditData(DeleteAuditData command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(OrderById))]
        public async Task<IActionResult> OrderById(GetOrdersById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(OrderRemapById))]
        public async Task<IActionResult> OrderRemapById(GetOrderRemapById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(DeleteOrderRemap))]
        public async Task<IActionResult> DeleteOrderRemap(DeleteOrderRemapById command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(RolesById))]
        public async Task<IActionResult> RolesById(GetRoleById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(UsersById))]
        public async Task<IActionResult> UsersById(GetUsersById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(ModulesById))]
        public async Task<IActionResult> ModulesById(GetModule query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(Roles))]
        public async Task<IActionResult> Roles() => Ok(await Mediator.Send(new GetRole()));

        [HttpGet(nameof(MCADMIN))]
        public async Task<IActionResult> MCADMIN() => Ok(await Mediator.Send(new GetRoles()));
    }
}
