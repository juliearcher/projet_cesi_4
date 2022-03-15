using STIVE.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public INavigator Navigator { get; set; }
		public static AdministratorDependency Administrator { get; set; }
		public ICommand ChangeAdminStatus => new AdministratorCommand();

		public MainWindowViewModel(INavigator navigator)
		{
			Navigator = navigator;
			Administrator = new AdministratorDependency();
			Administrator.Administrator = false;
		}
		internal class AdministratorCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object parameter)
			{
				return !Administrator.Administrator;
			}

			public void Execute(object parameter)
			{
				Window window = new Window();
				window.Content = new AdminPasswordWindowViewModel();
				window.Height = 120;
				window.Width = 300;
				window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
				window.ShowDialog();
			}
		}

		/*
		 * Allows to use a changing static property in bindings
		 */
		public class AdministratorDependency : DependencyObject
		{
			public static readonly DependencyProperty AdministratorProperty =
				DependencyProperty.Register("Administrator", typeof(bool),
				typeof(AdministratorDependency));
			public bool Administrator
			{
				get { return (bool)GetValue(AdministratorProperty); }
				set { SetValue(AdministratorProperty, value); }
			}
		}
	}
}
