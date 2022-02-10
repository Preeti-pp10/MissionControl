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

        [HttpGet(nameof(Roles))]
        public async Task<IActionResult> Roles() => Ok(await Mediator.Send(new GetRole()));

        [HttpGet(nameof(MCADMIN))]
        public async Task<IActionResult> MCADMIN() => Ok(await Mediator.Send(new GetRoles()));

        [HttpPost(nameof(GetCustomer))]
        public async Task<IActionResult> GetCustomer(GetCustomers query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(InsertOrUpdateCustomer))]
        public async Task<IActionResult> InsertOrUpdateCustomer(CreateOrUpdateCustomers command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(GetAggregatedCustomers))]
        public async Task<IActionResult> GetAggregatedCustomers(GetAggregateCustomer query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(GetAllCustomer))]
        public async Task<IActionResult> GetAllCustomer(GetAllCustomers query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(CustomerById))]
        public async Task<IActionResult> CustomerById(GetCustomersById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(AggregateCustomer))]
        public async Task<IActionResult> AggregateCustomer(GetAllAggregateCustomers query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(UpdateCustomer))]
        public async Task<IActionResult> UpdateCustomer(UpdateAggregateCustomer command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(CustomersById))]
        public async Task<IActionResult> CustomersById(GetAggregateCustomerById query) => Ok(await Mediator.Send(query));

        [HttpPost(nameof(SaveAggregatedAudit))]
        public async Task<IActionResult> SaveAggregatedAudit(CreateAggregateAuditCommand command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(UpdateAuditAggregate))]
        public async Task<IActionResult> UpdateAuditAggregate(UpdateAggregatedAudit command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(MapAggregatedAuditCommamd))]
        public async Task<IActionResult> MapAggregatedAuditCommamd(MapAggregatedAudit command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(Funnel))]
        public async Task<IActionResult> Funnel(FunnelCoverage command) => Ok(await Mediator.Send(command));

        [HttpGet(nameof(GetFunnel))]
        public async Task<IActionResult> GetFunnel() => Ok(await Mediator.Send(new GetAllFunnel()));

        [HttpPost(nameof(FunnelAudit))]
        public async Task<IActionResult> FunnelAudit(FunnelCoverageAudit command) => Ok(await Mediator.Send(command));

        [HttpGet(nameof(GetAllReportStatus))]
        public async Task<IActionResult> GetAllReportStatus() => Ok(await Mediator.Send(new GetReportStatus()));

        [HttpPost(nameof(UpdateReport))]
        public async Task<IActionResult> UpdateReport(UpdateReportStatus command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(UpdateReportStatusDeactive))]
        public async Task<IActionResult> UpdateReportStatusDeactive(DeactivateReportBit command) => Ok(await Mediator.Send(command));

        [HttpGet(nameof(GetAllReportPeroid))]
        public async Task<IActionResult> GetAllReportPeroid() => Ok(await Mediator.Send(new GetReportPeriod()));

        [HttpGet(nameof(GetAllReportPeroid1))]
        public async Task<IActionResult> GetAllReportPeroid1() => Ok(await Mediator.Send(new GetReportPeriod1()));

        [HttpPost(nameof(UpdatePeroid))]
        public async Task<IActionResult> UpdatePeroid(UpdateReportPeriod command) => Ok(await Mediator.Send(command));

        [HttpPost(nameof(UpdateReportPeriodDeactive))]
        public async Task<IActionResult> UpdateReportPeriodDeactive(DeactivateReport command) => Ok(await Mediator.Send(command));
    }
}
