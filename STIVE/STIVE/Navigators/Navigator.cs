using STIVE.Commands;
using STIVE.Models;
using STIVE.ViewModels;
using STIVE.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STIVE.Navigators
{
	public class Navigator : ObservableObject, INavigator
	{
		private ViewModelBase _currentViewModel;
		public ViewModelBase CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

		public ICommand UpdateCurrentViewModelCommand { get; set; }

		public Navigator(IViewModelAbstractFactory viewModelFactory)
		{
			UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
		}
	}
}