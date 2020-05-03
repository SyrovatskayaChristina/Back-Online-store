using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public interface IOrderController
	{
		ValueTask<ActionResult<OrderOutputModel>> Order(OrderInputModel orderInputModel);
	}
}