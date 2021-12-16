using STIVE.Navigators;
using STIVE.PrepAPI.Models;
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
		FormViewModelBase CreateFormViewModel(ListViewModelBase viewmodel, FormViewType viewType, ApiModelBase elem);
	}
}
