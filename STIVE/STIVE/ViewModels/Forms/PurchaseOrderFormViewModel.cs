using AutoMapper;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public class PurchaseOrderFormViewModel : FormViewModelBase
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

		private IEnumerable<IItem> _filteredItemList;
		public IEnumerable<IItem> FilteredItemList
		{
			get
			{
				return _filteredItemList;
			}
			set
			{
				_filteredItemList = value;
				OnPropertyChanged(nameof(FilteredItemList));
			}
		}

		private IEnumerable<ISupplier> _supplierList;
		public IEnumerable<ISupplier> SupplierList
		{
			get
			{
				return _supplierList;
			}
			set
			{
				_supplierList = value;
				OnPropertyChanged(nameof(SupplierList));
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

		public Dictionary<int, string> PurchaseOrderStates { get; private set; }

		public PurchaseOrderFormViewModel(PrepAPI.Services.IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_inProgress = true;
			PurchaseOrderStates = new Dictionary<int, string>();
			PurchaseOrderStates.Add((int)IPurchaseOrder.PurchaseOrderState.NotReceived, "En cours de rédaction");
			PurchaseOrderStates.Add((int)IPurchaseOrder.PurchaseOrderState.Received, "Reçu");
			_oldElem = elem ?? new Order();
			if (elem != null)
			{
				_mode = FormViewModelBase.EditMode.UPDATE;
				LoadPurchaseOrder();
			}
			else
			{
				LoadLists();
				_mode = FormViewModelBase.EditMode.CREATE;
				NewElem = new PurchaseOrderDataError();
				(NewElem as PurchaseOrderDataError).DocumentDate = DateTime.Today;
				(NewElem as PurchaseOrderDataError).DeliveryDate = DateTime.Today;
			}
		}

		private void LoadPurchaseOrder()
		{
			_apiServicesCollection.PurchaseOrderService.GetPurchaseOrderById(_oldElem.Id).ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					PurchaseOrder result = task.Result;
					var purchaseOrderLines = result.PurchaseOrderLines;
					result.PurchaseOrderLines = null;
					NewElem = new PurchaseOrderDataError(task.Result);
					(NewElem as PurchaseOrderDataError).PurchaseOrderLines = _mapper.Map<ObservableCollection<PurchaseOrderLineDataError>>(purchaseOrderLines);
					InProgress = task.Result.DocumentState == (int)IPurchaseOrder.PurchaseOrderState.NotReceived;
					NewElem.PropertyChanged += SupplierChanged;
					LoadLists();
				}
			});
		}

		private void LoadLists()
		{
			_apiServicesCollection.SupplierService.GetAllSuppliers().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					SupplierList = task.Result;
				}
			});
			_apiServicesCollection.ItemService.GetAllItems().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					ItemList = task.Result;
					FilteredItemList = ItemList.Where(item => item.SupplierId == (NewElem as PurchaseOrderDataError)?.SupplierId);
					foreach (PurchaseOrderLineDataError line in (NewElem as PurchaseOrderDataError).PurchaseOrderLines)
					{
						line.Item = (Item)ItemList.FirstOrDefault(item => item.Id == line.ItemId);
						line.PropertyChanged += LineChanged;
					}
					(NewElem as PurchaseOrderDataError).LineAmountsChanged();
				}
			});
		}

		private void SupplierChanged(object sender, PropertyChangedEventArgs e)
		{
			int numberOfChanges = 0;
			int supplierId;
			string propertyName = e.PropertyName;
			if (propertyName != nameof(PurchaseOrderDataError.SupplierId))
				return;
			supplierId = (NewElem as PurchaseOrderDataError).SupplierId;
			FilteredItemList = ItemList.Where(item => item.SupplierId == supplierId);
			foreach (PurchaseOrderLineDataError line in (NewElem as PurchaseOrderDataError)?.PurchaseOrderLines.ToList())
			{
				line.LineOrder -= numberOfChanges;
				if (line.Item.SupplierId != supplierId)
				{
					++numberOfChanges;
					(NewElem as PurchaseOrderDataError)?.PurchaseOrderLines.ToList().Remove(line);
				}
			}
		}

		private void LineChanged(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (propertyName == nameof(PurchaseOrderLineDataError.Quantity) || propertyName == nameof(PurchaseOrderLineDataError.PurchasePrice) || propertyName == nameof(PurchaseOrderLineDataError.Vat) || propertyName == nameof(PurchaseOrderLineDataError.DiscountRate))
			{
				(NewElem as PurchaseOrderDataError).LineAmountsChanged();
			}
		}

		public ICommand AddNewLine => new AddNewPurchaseOrderLineCommand(this);

		protected internal class AddNewPurchaseOrderLineCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly PurchaseOrderFormViewModel _viewModel;

			public AddNewPurchaseOrderLineCommand(PurchaseOrderFormViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				var newLine = new PurchaseOrderLineDataError();
				newLine.PropertyChanged += _viewModel.LineChanged;
				newLine.LineOrder = (_viewModel.NewElem as PurchaseOrderDataError).PurchaseOrderLines.Count();
				var test = (_viewModel.NewElem as PurchaseOrderDataError).PurchaseOrderLines;
				((_viewModel.NewElem as PurchaseOrderDataError).PurchaseOrderLines as ObservableCollection<PurchaseOrderLineDataError>).Add(newLine);
			}
		}

		public override bool IsValid()
		{
			PurchaseOrderDataError elem = NewElem as PurchaseOrderDataError;
			ISupplier supplier = SupplierList.Where(c => c.Id == ((PurchaseOrderDataError)NewElem).SupplierId).FirstOrDefault();
			((PurchaseOrderDataError)NewElem).CreatedUser = "admin";
			((PurchaseOrderDataError)NewElem).ModifiedUser = "admin";
			((PurchaseOrderDataError)NewElem).InvoicingAddress_City = supplier.InvoicingAddress_City;
			((PurchaseOrderDataError)NewElem).InvoicingAddress_ZipCode = supplier.InvoicingAddress_ZipCode;
			((PurchaseOrderDataError)NewElem).InvoicingAddress_Address1 = supplier.InvoicingAddress_Address1;
			foreach (PurchaseOrderLineDataError line in (NewElem as PurchaseOrderDataError).PurchaseOrderLines)
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
				PurchaseOrder newPurchaseOrder = await _apiServicesCollection.PurchaseOrderService.CreatePurchaseOrder(_mapper.Map<PurchaseOrder>(NewElem));
				_oldElem = newPurchaseOrder;
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.PurchaseOrderService.UpdatePurchaseOrder(_mapper.Map<PurchaseOrder>(NewElem));
			}
		}
	}
}
