using STIVE.Commands;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using STIVE.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public abstract class ListViewModelBase : ViewModelBase
	{
		protected IApiServicesCollection _apiServicesCollection;
		public IViewModelAbstractFactory ViewModelFactory { get; protected set; }

		protected abstract Func<ApiModelBase, bool> Predicate { get; }

		public ApiModelBase SelectedItem { get; set; }
		protected IEnumerable<ApiModelBase> _initialList;
		protected IEnumerable<ApiModelBase> _elementsList;
		public IEnumerable<ApiModelBase> ElementsList
		{
			get
			{
				return _elementsList;
			}
			set
			{
				if (value != null)
				{
					_elementsList = value;
					OnPropertyChanged(nameof(ElementsList));
				}
			}
		}

		protected string _searchFilter;
		public string SearchFilter
		{
			get
			{
				return _searchFilter;
			}
			set
			{
				if (_searchFilter != value)
				{
					_searchFilter = value.ToLower();
					ElementsList = _initialList.Where(Predicate);
					OnPropertyChanged(nameof(SearchFilter));
				}
			}
		}

		public ICommand AddNewElement
		{
			get
			{
				SelectedItem = null;
				return new AddNewElement(this);
			}
		}

		public ICommand UpdateElement => new AddNewElement(this);

		public ICommand DeleteElement => new DeleteElement(this);

		public abstract void LoadList();

		public abstract Task DeleteSelectedItem();
	}
}
