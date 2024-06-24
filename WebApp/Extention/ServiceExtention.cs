using Gat.BusinessLayer.Abstract;
using Gat.BusinessLayer.Concrete;
using Gat.DataAccessLayer.Abstract;
using Gat.DataAccessLayer.Concrete;

namespace WebApp.Extention
{
	public static class ServiceExtention
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IAdressService, AdressService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<IJobService, JobService>();
			services.AddScoped<IOrderDetailService, OrderDetailService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IProductOperationsService,ProductOperationsService>();
			services.AddScoped<IProductService,ProductService>();			
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IContractService, ContractService>();
			services.AddScoped<IEtherscanService, EtherscanService>();
			
			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		
		{
			services.AddScoped<IAdressRepository, AdressRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<ICommentRepository, CommentRepository>();
			services.AddScoped<IJobRepository, JobRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
			services.AddScoped<IProductOperationsRepository, ProductOperationsRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IUserRepository, UserRepository>();	
			services.AddScoped<IContractRepository, ContractRepository>();	
			services.AddScoped<IEtherscanRepository, EtherscanRepository>();	
			return services;
		}
	}
}
