using AutoMapper;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public class InventoryFormViewModel : FormViewModelBase
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

		public Dictionary<int, string> InventoryStates { get; private set; }

		public InventoryFormViewModel(IApiServicesCollection apiServicesCollection, ListViewModelBase listViewModel, ApiModelBase elem, IMapper mapper)
		{
			_apiServicesCollection = apiServicesCollection;
			ListViewModelBase = listViewModel;
			_mapper = mapper;
			_inProgress = true;
			InventoryStates = new Dictionary<int, string>();
			InventoryStates.Add((int)IInventory.InventoryState.InProgress, "En cours de rédaction");
			InventoryStates.Add((int)IInventory.InventoryState.Validated, "Validé");
			_oldElem = elem ?? new Inventory();
			if (elem != null)
			{
				_mode = FormViewModelBase.EditMode.UPDATE;
				LoadInventory();
			}
			else
			{
				LoadItems();
				_mode = FormViewModelBase.EditMode.CREATE;
				NewElem = new InventoryDataError();
				(NewElem as InventoryDataError).DocumentDate = DateTime.Today;
			}
		}

		private void LoadInventory()
		{
			_apiServicesCollection.InventoryService.GetInventoryById(_oldElem.Id).ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					Inventory result = task.Result;
					var inventoryLines = result.InventoryLines;
					result.InventoryLines = null;
					NewElem = new InventoryDataError(task.Result);
					(NewElem as InventoryDataError).InventoryLines = _mapper.Map<ObservableCollection<InventoryLineDataError>>(inventoryLines);
					InProgress = task.Result.DocumentState == (int)IInventory.InventoryState.InProgress;
					LoadItems();
				}
			});
		}

		private void LoadItems()
		{
			_apiServicesCollection.ItemService.GetAllItems().ContinueWith(task =>
			{
				if (task.Exception == null)
				{
					ItemList = task.Result;
					foreach (InventoryLineDataError line in (NewElem as InventoryDataError).InventoryLines)
					{
						line.Item = (Item)ItemList.FirstOrDefault(item => item.Id == line.ItemId);
					}
				}
			});
		}
		public ICommand AddNewLine => new AddNewInventoryLineCommand(this);

		protected internal class AddNewInventoryLineCommand : ICommand
		{
			public event EventHandler CanExecuteChanged;
			private readonly InventoryFormViewModel _viewModel;

			public AddNewInventoryLineCommand(InventoryFormViewModel viewModel)
			{
				_viewModel = viewModel;
			}

			public bool CanExecute(object parameter)
			{
				return true;
			}

			public void Execute(object parameter)
			{
				var newLine = new InventoryLineDataError();
				newLine.LineOrder = (_viewModel.NewElem as InventoryDataError).InventoryLines.Count();
				((_viewModel.NewElem as InventoryDataError).InventoryLines as ObservableCollection<InventoryLineDataError>).Add(newLine);
			}
		}

		public override bool IsValid()
		{
			InventoryDataError elem = NewElem as InventoryDataError;
			((InventoryDataError)NewElem).CreatedUser = "admin";
			((InventoryDataError)NewElem).ModifiedUser = "admin";
			foreach (InventoryLineDataError line in (NewElem as InventoryDataError).InventoryLines)
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
				Inventory newInventory = await _apiServicesCollection.InventoryService.CreateInventory(_mapper.Map<Inventory>(NewElem));
				_oldElem = newInventory;
				_mode = EditMode.UPDATE;
			}
			else
			{
				await _apiServicesCollection.InventoryService.UpdateInventory(_mapper.Map<Inventory>(NewElem));
			}
		}

	}
}
