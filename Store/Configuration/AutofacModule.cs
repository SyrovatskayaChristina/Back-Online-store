using Autofac;
using Store.Controllers;
using Store.DB;
using Store.DB.Storeges;
using StoreRepository;
using StoreRepository.Repositories;

namespace Store
{
	public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderStorage>().As<IOrderStorage>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderController>().As<IOrderController>();
            builder.RegisterType<ReportStorage>().As<IReportStorage>();
            builder.RegisterType<ReportRepository>().As<IReportRepository>();
            builder.RegisterType<ReportController>().As<IReportController>();
        }
    }
}
