using STIVE.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public interface IViewModelAbstractFactory
	{
		ViewModelBase CreateTabViewModel(ViewType viewType);
	}
}
