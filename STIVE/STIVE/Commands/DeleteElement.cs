﻿using STIVE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.Commands
{
	public class DeleteElement : ICommand
	{
		private ListViewModelBase _viewModel;

		public event EventHandler CanExecuteChanged;

		public DeleteElement(ListViewModelBase viewModel)
		{
			_viewModel = viewModel;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public async void Execute(object parameter)
		{
			if (_viewModel.SelectedItem == null)
				return;
			var result = MessageBox.Show("Voulez vous supprimer cet élément ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
			if (result == MessageBoxResult.Yes)
			{
				await _viewModel.DeleteSelectedItem();
				_viewModel.LoadList();
			}
		}
	}
}
