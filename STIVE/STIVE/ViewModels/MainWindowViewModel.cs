using STIVE.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		public INavigator Navigator { get; set; }

		public MainWindowViewModel(INavigator navigator)
		{
			Navigator = navigator;
		}
	}
}
