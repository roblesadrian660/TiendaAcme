using Domain.Common.Dto;
using Domain.Service.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Applicacion.Acme.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        IOrderService _orderService; 
        public OrdersController(IOrderService orderServic ) {
            _orderService = orderServic;
        }

        [HttpPost("SubmitOrder")]
        public async Task<IActionResult> SubmitOrder(OrderRequest order)
        {
            _orderService.CreateOrder(order);
            return Ok("");
        }
    }
}
