using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public interface IViewModelListFactory<T> where T : ListViewModelBase
	{
		T CreateViewModel(IViewModelAbstractFactory factory);
	}
}
