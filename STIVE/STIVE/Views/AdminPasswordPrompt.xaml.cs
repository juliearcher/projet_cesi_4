using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STIVE.Views
{
	/// <summary>
	/// Logique d'interaction pour AdminPasswordPrompt.xaml
	/// </summary>
	public partial class AdminPasswordPrompt : UserControl
	{
		public AdminPasswordPrompt()
		{
			InitializeComponent();
		}

		private void PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (this.DataContext != null)
			{
				((dynamic)this.DataContext).PasswordGuess = ((PasswordBox)sender).Password;
			}
		}
	}
}
