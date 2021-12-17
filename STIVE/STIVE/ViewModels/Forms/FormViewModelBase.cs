using AutoMapper;
using STIVE.Commands;
using STIVE.Models;
using STIVE.PrepAPI.Models;
using STIVE.PrepAPI.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace STIVE.ViewModels
{
	public abstract class FormViewModelBase : ViewModelBase
	{
		protected enum EditMode
		{
			CREATE, UPDATE
		}

		protected EditMode _mode = EditMode.UPDATE;

		protected IApiServicesCollection _apiServicesCollection;
		protected IMapper _mapper;

		protected ApiModelBase _oldElem;
		private DataErrorModelBase _newElem;
		public DataErrorModelBase NewElem
		{
			get
			{
				return _newElem;
			}
			set
			{
				_newElem = value;
				OnPropertyChanged(nameof(NewElem));
			}
		}
		public ListViewModelBase ListViewModelBase { get; protected set; }

		public abstract Task SendToAPI();
		public abstract bool IsValid();
		public ICommand SaveElement => new SaveElement(this);
		public ICommand SaveElementAndClose => new SaveElement(this, closeWindow: true);
		public ICommand CloseWindowCommand => new SaveElement(this, save: false, closeWindow: true);

		public void CloseWindow(Window window) => window.Close();
	}
}
