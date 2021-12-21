using AutoMapper;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public class OrderFormViewModel : FormViewModelBase
	{
		private IEnumerable<IItem> _itemList;
		public IEnumerable<IItem> ItemList
		{
			get
			{
				return _itemList;
			}
			set
			{
				_itemList = value;
				OnPropertyChanged(nameof(ItemList));
			}
		}

		private IEnumerable<ICustomer> _customerList;
		public IEnumerable<ICustomer> CustomerList
		{
			get
			{
				return _customerList;
			}
			set
			{
				_customerList = value;
				OnPropertyChanged(nameof(CustomerList));
			}
		}

		public Dictionary<int, string> OrderStates { get; private set; }

		public OrderFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			OrderStates = new Dictionary<int, string>();
			OrderStates.Add((int)IOrder.OrderState.NotDelivered, "En cours de rédaction");
			OrderStates.Add((int)IOrder.OrderState.Delivered, "Livré");
			_oldElem = elem ?? new Order();
			if (elem != null)
			{
				_mode = FormViewModelBase.EditMode.UPDATE;
				LoadOrder();
			}
			else
			{
				LoadLists();
				_mode = FormViewModelBase.EditMode.CREATE;
				NewElem = new OrderDataError();
				(NewElem as OrderDataError).DocumentDate = DateTime.Today;
				(NewElem as OrderDataError).DeliveryDate = DateTime.Today;
			}
		}

		private void LoadOrder()
		{
			_apiServicesCollection.OrderService.GetOrderById(_oldElem.Id).ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					Order result = task.Result;
					var orderLines = result.OrderLines;
					result.OrderLines = null;
					NewElem = new OrderDataError(task.Result);
					(NewElem as OrderDataError).OrderLines = _mapper.Map<ObservableCollection<OrderLineDataError>>(orderLines);
					LoadLists();
				}
			});
		}

		private void LoadLists()
		{
			_apiServicesCollection.CustomerService.GetAllCustomers().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					CustomerList = task.Result;
				}
			});
			_apiServicesCollection.ItemService.GetAllItems().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					ItemList = task.Result;
					foreach (OrderLineDataError line in (NewElem as OrderDataError).OrderLines)
					{
						line.Item = (Item)ItemList.FirstOrDefault(item => item.Id == line.ItemId);
						line.PropertyChanged += LineChanged;
					}
					(NewElem as OrderDataError).LineAmountsChanged();
				}
			});
		}

		private void LineChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (propertyName == nameof(OrderLineDataError.Quantity) || propertyName == nameof(OrderLineDataError.SalePrice) || propertyName == nameof(OrderLineDataError.Vat) || propertyName == nameof(OrderLineDataError.DiscountRate))
			{
				(NewElem as OrderDataError).LineAmountsChanged();
			}
		}

		public ICommand AddNewLine => new AddNewOrderLineCommand(this);

		protected internal class AddNewOrderLineCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly OrderFormViewModel _viewModel;

			public AddNewOrderLineCommand(OrderFormViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				var newLine = new OrderLineDataError();
				newLine.PropertyChanged += _viewModel.LineChanged;
				newLine.LineOrder = (_viewModel.NewElem as OrderDataError).OrderLines.Count();
				var test = (_viewModel.NewElem as OrderDataError).OrderLines;
				((_viewModel.NewElem as OrderDataError).OrderLines as ObservableCollection<OrderLineDataError>).Add(newLine);
			}
		}

		public override bool IsValid()
		{
			return false;
		}

		public override Task SendToAPI()
		{
			//
			return null;
		}
	}
}
