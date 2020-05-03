using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.DB.Models;
using Store.Models;
using StoreRepository;

namespace Store.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase, IOrderController
	{
		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;
		public OrderController(IOrderRepository orderRepository, IMapper mapper)
		{
			_orderRepository = orderRepository;
			_mapper = mapper;
		}


		[HttpPost]
		public async ValueTask<ActionResult<OrderOutputModel>> Order(OrderInputModel orderInputModel)
		{
			var result = await _orderRepository.AddOrder(_mapper.Map<Order>(orderInputModel));
			if (result.IsOkay)
			{
				if (result.RequestData == null) { return NotFound("Order not done"); }
				return Ok(_mapper.Map<OrderOutputModel>(result.RequestData));
			}
			return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
		}
	}
}