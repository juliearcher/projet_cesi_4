using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using STIVE.Navigators;
using STIVE.PrepAPI.Services;
using STIVE.ViewModels;
using STIVE.ViewModels.Factories;

namespace STIVE
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IServiceProvider serviceProvider = CreateServiceProvider();

			Window window = serviceProvider.GetRequiredService<MainWindow>();
			window.Show();
			base.OnStartup(e);
		}
		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<ICustomerService, CustomerService>();
			services.AddSingleton<IInventoryService, InventoryService>();
			services.AddSingleton<IItemFamilyService, ItemFamilyService>();
			services.AddSingleton<IItemService, ItemService>();
			services.AddSingleton<IOrderService, OrderService>();
			services.AddSingleton<IPurchaseOrderService, PurchaseOrderService>();
			services.AddSingleton<ISupplierService, SupplierService>();
			services.AddSingleton<IApiServicesCollection, ApiServicesCollection>();

			services.AddScoped<IViewModelTabFactory<CustomerTabViewModel>, CustomerTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<InventoryTabViewModel>, InventoryTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<ItemTabViewModel>, ItemTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<ItemFamilyTabViewModel>,ItemFamilyTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<OrderTabViewModel>, OrderTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<PurchaseOrderTabViewModel>, PurchaseOrderTabViewModelFactory>();
			services.AddScoped<IViewModelTabFactory<SupplierTabViewModel>, SupplierTabViewModelFactory>();

			services.AddScoped<IViewModelListFactory<CustomerListViewModel>, CustomerListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<InventoryListViewModel>, InventoryListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<ItemListViewModel>, ItemListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<ItemFamilyListViewModel>, ItemFamilyListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<OrderListViewModel>, OrderListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<PurchaseOrderListViewModel>, PurchaseOrderListViewModelFactory>();
			services.AddScoped<IViewModelListFactory<SupplierListViewModel>, SupplierListViewModelFactory>();

			services.AddScoped<IViewModelFormFactory<CustomerFormViewModel>, CustomerFormViewModelFactory>();

			services.AddScoped<IViewModelAbstractFactory, ViewModelAbstractFactory>();

			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			services.AddScoped<INavigator, Navigator>();
			services.AddScoped<MainWindowViewModel>();
			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

			return services.BuildServiceProvider();
		}
	}
}
