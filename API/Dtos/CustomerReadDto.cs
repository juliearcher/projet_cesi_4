using System;

namespace API.Dtos
{
	public partial class CustomerReadDto : ReadDtoBase
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Civility { get; set; }

		public string Notes { get; set; }
		public string NotesClear { get; set; }

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

		#region Informations de livraison

		public string DeliveryAddress_Address1 { get; set; }
		public string DeliveryAddress_City { get; set; }
		public string DeliveryAddress_ZipCode { get; set; }
		public string DeliveryContact_Civility { get; set; }
		public string DeliveryContact_Name { get; set; }
		public string DeliveryContact_FirstName { get; set; }
		public string DeliveryContact_Email { get; set; }
		public string DeliveryContact_Phone { get; set; }
		public string DeliveryContact_CellPhone { get; set; }
		#endregion

	}
}