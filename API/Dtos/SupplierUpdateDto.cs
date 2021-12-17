using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
	public partial class SupplierUpdateDto : UpdateDtoBase
	{
		[Required]
		[MaxLength(15)]
		public string Code { get; set; }

		[Required]
		[MaxLength(256)]
		public string Name { get; set; }

		[MaxLength(16)]
		public string Civility { get; set; }

		public string Notes { get; set; }

		#region Informations de facturation

		[Required]
		[MaxLength(256)]
		public string InvoicingAddress_Address1 { get; set; }
		[Required]
		[MaxLength(128)]
		public string InvoicingAddress_City { get; set; }
		[Required]
		[MaxLength(7)]
		public string InvoicingAddress_ZipCode { get; set; }

		[MaxLength(16)]
		public string InvoicingContact_Civility { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_Name { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_FirstName { get; set; }
		[MaxLength(256)]
		public string InvoicingContact_Email { get; set; }
		[MaxLength(16)]
		public string InvoicingContact_Phone { get; set; }
		[MaxLength(16)]
		public string InvoicingContact_CellPhone { get; set; }

		#endregion
	}
}