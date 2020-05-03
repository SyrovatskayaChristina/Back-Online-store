using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public interface IReportController
	{
		ValueTask<ActionResult<List<CategoryOutputModel>>> FindCategoryMoreThen5Goods();
		ValueTask<ActionResult<OrderByCountryOutputModel>> OrdersSumByCountry();
		ValueTask<ActionResult<List<MoneyInProductStoragesOuputModel>>> GetHowMuchMoneyYouHave();
		ValueTask<ActionResult<List<PopularProductOutputModel>>> GetMostPopularProductInCities();
		ValueTask<ActionResult<List<ProductStorageOutputModel>>> GetProductsInWarehouseAndNotInSpbAndMsc();
		ValueTask<ActionResult<List<ProductStorageOutputModel>>> GetProductsWereSaledButEndedInStore();
		ValueTask<ActionResult<List<OrderByTimeOutputModel>>> FindOrdersByTime(DateInputModel dateInputModel);
	}
}