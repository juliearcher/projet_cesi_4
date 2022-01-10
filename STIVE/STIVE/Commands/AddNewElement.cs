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
		public enum Mode
		{
			CREATE,
			UPDATE
		}

		public event EventHandler CanExecuteChanged;

		private ListViewModelBase _viewModel;

		private Mode _mode;

		public AddNewElement(ListViewModelBase viewModel, Mode mode)
		{
			_viewModel = viewModel;
			_mode = mode;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Window window = new Window();

			if (_mode == Mode.UPDATE && _viewModel.SelectedItem == null)
				return;
			if (_viewModel is CustomerListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, FormViewType.CustomerForm, _mode == Mode.CREATE ? null : _viewModel.SelectedItem);
			else if (_viewModel is OrderListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, FormViewType.OrderForm, _mode == Mode.CREATE ? null : _viewModel.SelectedItem);
			else if (_viewModel is PurchaseOrderListViewModel)
				window.Content = _viewModel.ViewModelFactory.CreateFormViewModel(_viewModel, FormViewType.PurchaseOrderForm, _mode == Mode.CREATE ? null : _viewModel.SelectedItem);
			else
				return;
			window.Show();
		}
	}
}
