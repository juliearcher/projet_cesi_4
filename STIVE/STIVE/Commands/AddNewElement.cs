using STIVE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.Commands
{
	class AddNewElement : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private ListViewModelBase _viewModel;

		public AddNewElement(ListViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			/*Window window = new Window();
			if (_viewModel is SiteListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.SiteForm, _viewModel.SelectedItem);
			else if (_viewModel is DepartmentListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.DepartmentForm, _viewModel.SelectedItem);
			else if (_viewModel is EmployeeListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, ViewType.EmployeeForm, _viewModel.SelectedItem);
			else
				return;
			window.Show();*/
		}
	}
}
