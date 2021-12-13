﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using STIVE.Navigators;
using STIVE.ViewModels;

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


			services.AddScoped<INavigator, Navigator>();
			services.AddScoped<MainWindowViewModel>();
			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

			return services.BuildServiceProvider();
		}
	}
}
