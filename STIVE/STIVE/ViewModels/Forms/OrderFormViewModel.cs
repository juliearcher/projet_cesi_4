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

		private bool _inProgress;
		public bool InProgress
		{
			get
			{
				return _inProgress;
			}
			set
			{
				_inProgress = value;
				OnPropertyChanged(nameof(InProgress));
			}
		}

		public Dictionary<int, string> OrderStates { get; private set; }

		public OrderFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_inProgress = true;
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
					InProgress = task.Result.DocumentState == (int)IOrder.OrderState.NotDelivered;
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
				((_viewModel.NewElem as OrderDataError).OrderLines as ObservableCollection<OrderLineDataError>).Add(newLine);
			}
		}

		public override bool IsValid()
		{
			OrderDataError elem = NewElem as OrderDataError;
			ICustomer customer = CustomerList.Where(c => c.Id == ((OrderDataError)NewElem).CustomerId).FirstOrDefault();
			((OrderDataError)NewElem).CreatedUser = "admin";
			((OrderDataError)NewElem).ModifiedUser = "admin";
			((OrderDataError)NewElem).DeliveryAddress_City = customer.DeliveryAddress_City;
			((OrderDataError)NewElem).InvoicingAddress_City = customer.InvoicingAddress_City;
			((OrderDataError)NewElem).DeliveryAddress_ZipCode = customer.DeliveryAddress_ZipCode;
			((OrderDataError)NewElem).InvoicingAddress_ZipCode = customer.InvoicingAddress_ZipCode;
			((OrderDataError)NewElem).DeliveryAddress_Address1 = customer.DeliveryAddress_Address1;
			((OrderDataError)NewElem).InvoicingAddress_Address1 = customer.InvoicingAddress_Address1;
			((OrderDataError)NewElem).DeliveryContact_Email = customer.DeliveryContact_Email;
			foreach (OrderLineDataError line in (NewElem as OrderDataError).OrderLines)
			{
				line.CreatedUser = "admin";
				line.ModifiedUser = "admin";
			}
			return (true);
		}

		public override async Task SendToAPI()
		{
			if (_mode == EditMode.CREATE)
			{
				Order newOrder = await _apiServicesCollection.OrderService.CreateOrder(_mapper.Map<Order>(NewElem));
				_oldElem = newOrder;
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.OrderService.UpdateOrder(_mapper.Map<Order>(NewElem));
			}
		}

		public override async void ToDoAfterSave()
		{
			List<PurchaseOrder> purchaseOrders = new List<PurchaseOrder>();
			int count = 0;
			foreach (OrderLineDataError line in (NewElem as OrderDataError).OrderLines)
			{
				Item item = line.Item;
				if (item != null && (item.RealStock - line.Quantity < 0 || item.VirtualStock - line.Quantity < 0))
				{
					var result = MessageBox.Show("Voulez vous faire une commande fournisseur pour l'article " +
						item.Caption + " ?\nStock réel = " + item.RealStock + "\nStock virtuel = " + item.VirtualStock,
						"Attention", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
					if (result == MessageBoxResult.Yes)
					{
						var purchaseOrder = purchaseOrders.Where(po => po.SupplierId == item.SupplierId).FirstOrDefault();
						if (purchaseOrder == null)
						{
							DateTime today = DateTime.Today;
							purchaseOrder = new PurchaseOrder
							{
								DocumentNumber = "CF" + today.ToString("yyddMMHHmmss") + count++,
								DocumentDate = today,
								DeliveryDate = today.AddDays(7),
								DocumentState = (int)IPurchaseOrder.PurchaseOrderState.NotReceived,
								SupplierId = item.SupplierId,
								PurchaseOrderLines = new List<PurchaseOrderLine>(),
								InvoicingAddress_Address1 = "To complete",
								InvoicingAddress_City = "To complete",
								InvoicingAddress_ZipCode = "0000000",
								CreatedUser = "admin",
								ModifiedUser = "admin"
							};
							purchaseOrders.Add(purchaseOrder);
						}
						int Real = (int)item.RealStock - line.Quantity;
						int Virtual = (int)item.VirtualStock - line.Quantity;

						((List<PurchaseOrderLine>)purchaseOrder.PurchaseOrderLines).Add(new PurchaseOrderLine
						{
							LineOrder = purchaseOrder.PurchaseOrderLines.Count(),
							Description = item.Description,
							ClearDescription = item.ClearDescription,
							PurchasePrice = item.PurchasePrice,
							Vat = item.Vat,
							ItemId = item.Id,
							Quantity = Real < Virtual ? -Real : -Virtual,
							CreatedUser = "admin",
							ModifiedUser = "admin"
						});
					}
				}
			}
			foreach (PurchaseOrder po in purchaseOrders)
				await _apiServicesCollection.PurchaseOrderService.CreatePurchaseOrder(po);
		}
	}
}
