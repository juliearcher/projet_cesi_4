using STIVE.PrepAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.Models
{
	public class IventoryDataError : DataErrorModelBase, IItem
	{

		private string _documentDate;
		public string DocumentDate
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
				OnPropertyChanged(DocumentDate);
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
				OnPropertyChanged(DocumentNumber);
			}
		}

		private string _documentState;
		public string DocumentState
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
				OnPropertyChanged(DocumentState);
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
				OnPropertyChanged(Notes);
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
				OnPropertyChanged(NotesClear);
			}
		}


		public DateTime DocumentDate { get; set; }
		public string DocumentNumber { get; set; }
		public int DocumentState { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }
		public IEnumerable<InventoryLine> InventoryLines { get; set; }

		public InventoryDataError(Inventory inventory = null)
		{
			if (inventory != null)
			{
				DocumentDate = inventory.DocumentDate;
				DocumentNumber = inventory.DocumentNumber;
				DocumentState = inventory.DocumentState;
				Notes = inventory.Notes;
				NotesClear = inventory.NotesClear;
				

			}
		}
	}
}
