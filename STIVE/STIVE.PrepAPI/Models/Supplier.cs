using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STIVE.PrepAPI.Models
{
	public class Supplier : ApiModelBase, ISupplier
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Civility { get; set; }

		public string Notes { get; set; }

		#region Informations de facturation

		public string InvoicingAddress_Address1 { get; set; }
		public string InvoicingAddress_City { get; set; }
		public string InvoicingAddress_ZipCode { get; set; }
		public string InvoicingContact_Civility { get; set; }
		public string InvoicingContact_Name { get; set; }
		public string InvoicingContact_FirstName { get; set; }
		public string InvoicingContact_Email { get; set; }
		public string InvoicingContact_Phone { get; set; }
		public string InvoicingContact_CellPhone { get; set; }

		#endregion
	}
}
