using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public interface IViewModelTabFactory<T> where T : TabViewModelBase
	{
		T CreateViewModel(IViewModelAbstractFactory factory);
	}
}
