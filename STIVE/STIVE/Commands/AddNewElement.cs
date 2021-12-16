using STIVE.Navigators;
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
			Window window = new Window();
			
			if (_viewModel is CustomerListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, FormViewType.CustomerForm, _viewModel.SelectedItem);
			else
				return;
			window.Show();
		}
	}
}
