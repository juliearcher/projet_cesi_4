using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.ViewModels.Factories
{
	public interface IViewModelFormFactory<T> where T : FormViewModelBase
	{
		T CreateViewModel(ListViewModelBase viewModelBase, ApiModelBase elem);
	}
}
