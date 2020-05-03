using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Common;
using Store.Models;
using StoreRepository.Repositories;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase, IReportController
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }


        //Сколько у тебя гипотетических денег в каждом городе, а также на складе 
        [HttpGet("money-in-each-store")]
        public async ValueTask<ActionResult<List<MoneyInProductStoragesOuputModel>>> GetHowMuchMoneyYouHave()
        {
            var result = await _reportRepository.FindOutHowMuchMoney();
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("City not found"); }
                return Ok(_mapper.Map<List<MoneyInProductStoragesOuputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        //Ты хочешь узнать товары, по которым были продажи, но которых нет ни в представительствах, ни на Складе.

        [HttpGet("products-were-saled-not-available-now")]
        public async ValueTask<ActionResult<List<ProductStorageOutputModel>>> GetProductsWereSaledButEndedInStore()
        {
            ReportTypeEnum reportType = ReportTypeEnum.WereSaledButEndedInStore;
            var result = await _reportRepository.Report(reportType);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("No such products"); }
                return Ok(_mapper.Map<List<ProductStorageOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        //Ты хочешь узнать, какие товары есть на Складе, но при этом отсутствуют в СПб и Москве.
        [HttpGet("products-available-on-warehouse")]
        public async ValueTask<ActionResult<List<ProductStorageOutputModel>>> GetProductsInWarehouseAndNotInSpbAndMsc()
        {
            ReportTypeEnum reportType = ReportTypeEnum.InWarehouseNotInCities;
            var result = await _reportRepository.Report(reportType);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("No such products"); }
                return Ok(_mapper.Map<List<ProductStorageOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

        //Ты хочешь узнать самый часто продаваемый товар в каждом городе.
        [HttpGet("most-popular-product")]
        public async ValueTask<ActionResult<List<PopularProductOutputModel>>> GetMostPopularProductInCities()
        {
            var result = await _reportRepository.GetMostPopularProduct();
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Product not found"); }
                return Ok(_mapper.Map<List<PopularProductOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }


        // Ты хочешь узнать категории, в которых заведено 5 и более разных товаров
        [HttpGet("categories-more-five-products")]
        public async ValueTask<ActionResult<List<CategoryOutputModel>>> FindCategoryMoreThen5Goods()
        {
            var result = await _reportRepository.GetCategoryMoreThen5Goods();
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Category not found"); }
                return Ok(_mapper.Map<List<CategoryOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }


        //Ты хочешь узнать товары, которые никто ни разу не заказывал.
        [HttpGet("nobody-ordered")]
        public async ValueTask<ActionResult<List<ProductOutputModel>>> FindNoOrderProduct()
        {
            ReportTypeEnum reportType = ReportTypeEnum.NobodyOrdered;
            var result = await _reportRepository.Report(reportType);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Product not found"); }
                return Ok(_mapper.Map<List<ProductOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }


        //Ты хочешь увидеть информацию о продажах за определённый период времени: в таком-то городе было куплено столько то единиц такого-то товара за такую-то сумму.

        [HttpGet("sales-by-dates")]
        public async ValueTask<ActionResult<List<OrderByTimeOutputModel>>> FindOrdersByTime(DateInputModel dateInputModel)
        {
            DateTime DateFrom = Convert.ToDateTime(dateInputModel.DateFrom);
            DateTime DateTo = Convert.ToDateTime(dateInputModel.DateTo);
            var result = await _reportRepository.GetOrdersByTime(DateFrom,DateTo);
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Orders not found"); }
                return Ok(_mapper.Map<List<OrderByTimeOutputModel>>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }


        //Ты хочешь узнать сумму заказов внутри РФ и за рубежом 

        [HttpGet("sales-russia-and-others")]
        public async ValueTask<ActionResult<OrderByCountryOutputModel>> OrdersSumByCountry()
        {
            var result = await _reportRepository.GetOrdersSumByCountry();
            if (result.IsOkay)
            {
                if (result.RequestData == null) { return NotFound("Orders not found"); }
                return Ok(_mapper.Map<OrderByCountryOutputModel>(result.RequestData));
            }
            return Problem($"Transaction failed {result.ExMessage}", statusCode: 520);
        }

    }
}