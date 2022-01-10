using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class InventoryDataError : DataErrorModelBase, IInventory
	{
		private DateTime _documentDate;
		public DateTime DocumentDate
		{
			get => _documentDate;
			set
			{
				_documentDate = value;
				ClearErrors(nameof(DocumentDate));
				/*if (...)
				{
					AddError(nameof(DocumentDate), "...");
				}*/
				OnPropertyChanged(nameof(DocumentDate));
			}
		}

		private string _documentNumber;
		public string DocumentNumber
		{
			get => _documentNumber;
			set
			{
				_documentNumber = value;
				ClearErrors(nameof(DocumentNumber));
				/*if (...)
				{
					AddError(nameof(DocumentNumber), "...");
				}*/
				OnPropertyChanged(nameof(DocumentNumber));
			}
		}

		private int _documentState;
		public int DocumentState
		{
			get => _documentState;
			set
			{
				_documentState = value;
				ClearErrors(nameof(DocumentState));
				/*if (...)
				{
					AddError(nameof(DocumentState), "...");
				}*/
				OnPropertyChanged(nameof(DocumentState));
			}
		}

		private string _notes;
		public string Notes
		{
			get => _notes;
			set
			{
				_notes = value;
				ClearErrors(nameof(Notes));
				/*if (...)
				{
					AddError(nameof(Notes), "...");
				}*/
				OnPropertyChanged(nameof(Notes));
			}
		}

		private string _notesClear;
		public string NotesClear
		{
			get => _notesClear;
			set
			{
				_notesClear = value;
				ClearErrors(nameof(NotesClear));
				/*if (...)
				{
					AddError(nameof(NotesClear), "...");
				}*/
				OnPropertyChanged(nameof(NotesClear));
			}
		}

		private IEnumerable<IInventoryLine> _inventoryLines;
		public IEnumerable<IInventoryLine> InventoryLines
		{
			get => _inventoryLines;
			set
			{
				_inventoryLines = value;
				ClearErrors(nameof(InventoryLines));
				/*if (...)
				{
					AddError(nameof(InventoryLines), "...");
				}*/
				OnPropertyChanged(nameof(InventoryLines));
			}
		}

		public int Id { get; set; }
		public DateTime SysCreatedDate { get; set; }
		public DateTime SysModifiedDate { get; set; }
		public string CreatedUser { get; set; }
		public string ModifiedUser { get; set; }

		public InventoryDataError(Inventory inventory = null)
		{
			if (inventory != null)
			{
				DocumentDate = inventory.DocumentDate;
				DocumentNumber = inventory.DocumentNumber;
				DocumentState = inventory.DocumentState;
				Notes = inventory.Notes;
				NotesClear = inventory.NotesClear;
				Id = inventory.Id;
				SysCreatedDate = inventory.SysCreatedDate;
				SysModifiedDate = inventory.SysModifiedDate;
				CreatedUser = inventory.CreatedUser;
				ModifiedUser = inventory.ModifiedUser;
			}
			if (InventoryLines == null)
				InventoryLines = new ObservableCollection<InventoryLineDataError>();
		}
	}
}
