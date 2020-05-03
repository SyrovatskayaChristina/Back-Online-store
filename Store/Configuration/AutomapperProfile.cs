using AutoMapper;
using Store.DB.Models;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Configuration
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<City, CityOutputModel>();


			CreateMap<Order, OrderOutputModel>()
						 .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
						 .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate.ToString(@"dd.MM.yyyy")))
			.ForMember(dest => dest.orderListOutputModels, opt => opt.MapFrom(src => src.OrderList))
			.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));

			
				CreateMap<OrderByTime, OrderByTimeOutputModel>()
						 .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
			.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));

			CreateMap<OrderInputModel, Order>()
				.ForPath(dest => dest.City.Id, opt => opt.MapFrom(src => src.CityId))
				.ForMember(dest => dest.OrderList, opt => opt.MapFrom(src => src.OrderListInputModels));


			CreateMap<OrderList, OrderListOutputModel>()
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
				.ForMember(dest => dest.ProductModel, opt => opt.MapFrom(src => src.Product.Model))
				.ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.Product.Brand));


			CreateMap<OrderListInputModel, OrderList>()
				.ForPath(dest => dest.Product.Id, opt => opt.MapFrom(src => src.ProductId))
				;

			CreateMap<Product, ProductStorageOutputModel>()
				.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));


			CreateMap<City, PopularProductOutputModel>()
				.ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName));

			CreateMap<City, MoneyInProductStoragesOuputModel>()
				.ForMember(dest => dest.Money, opt => opt.MapFrom(src => src.Money))
				.ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name));

			CreateMap<Category, CategoryOutputModel>();


			CreateMap<OrderByCountry, OrderByCountryOutputModel>()
				.ForMember(dest => dest.SalesMadeInRF, opt => opt.MapFrom(src => src.SalesMadeInRF))
				.ForMember(dest => dest.SalesMadeAbroad, opt => opt.MapFrom(src => src.SalesMadeAbroad));

			CreateMap<DateInputModel, DateForOrders>()
				.ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => DateTime.ParseExact(src.DateFrom, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
				.ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => DateTime.ParseExact(src.DateTo, "dd.MM.yyyy", CultureInfo.InvariantCulture)));


		}
	}
}
