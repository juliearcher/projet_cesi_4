package beans;

import java.sql.Timestamp;

public class Customer {
	private int id;
	private Timestamp sysCreatedDate;
	private Timestamp sysModifiedDate;
	
	private String code;
	private String name;
	private String civility;
	private String notesClear;

	private String invoicingAddress_Address1;
	private String invoicingAddress_City;
	private String invoicingAddress_ZipCode;
	private String invoicingContact_Civility;
	private String invoicingContact_Name;
	private String invoicingContact_FirstName;
	private String invoicingContact_Email;
	private String invoicingContact_Phone;
	private String invoicingContact_CellPhone;

	private String deliveryAddress_Address1;
	private String deliveryAddress_City;
	private String deliveryAddress_ZipCode;
	private String deliveryContact_Civility;
	private String deliveryContact_Name;
	private String deliveryContact_FirstName;
	private String deliveryContact_Email;
	private String deliveryContact_Phone;
	private String deliveryContact_CellPhone;
	
	public Customer() {
	 
 }

	public Customer(int id, Timestamp sysCreatedDate, Timestamp sysModifiedDate, String code, String name,
			String civility, String notesClear, String invoicingAddress_Address1, String invoicingAddress_City,
			String invoicingAddress_ZipCode, String invoicingContact_Civility, String invoicingContact_Name,
			String invoicingContact_FirstName, String invoicingContact_Email, String invoicingContact_Phone,
			String invoicingContact_CellPhone, String deliveryAddress_Address1, String deliveryAddress_City,
			String deliveryAddress_ZipCode, String deliveryContact_Civility, String deliveryContact_Name,
			String deliveryContact_FirstName, String deliveryContact_Email, String deliveryContact_Phone,
			String deliveryContact_CellPhone) {
		this.id = id;
		this.sysCreatedDate = sysCreatedDate;
		this.sysModifiedDate = sysModifiedDate;
		this.code = code;
		this.name = name;
		this.civility = civility;
		this.notesClear = notesClear;
		this.invoicingAddress_Address1 = invoicingAddress_Address1;
		this.invoicingAddress_City = invoicingAddress_City;
		this.invoicingAddress_ZipCode = invoicingAddress_ZipCode;
		this.invoicingContact_Civility = invoicingContact_Civility;
		this.invoicingContact_Name = invoicingContact_Name;
		this.invoicingContact_FirstName = invoicingContact_FirstName;
		this.invoicingContact_Email = invoicingContact_Email;
		this.invoicingContact_Phone = invoicingContact_Phone;
		this.invoicingContact_CellPhone = invoicingContact_CellPhone;
		this.deliveryAddress_Address1 = deliveryAddress_Address1;
		this.deliveryAddress_City = deliveryAddress_City;
		this.deliveryAddress_ZipCode = deliveryAddress_ZipCode;
		this.deliveryContact_Civility = deliveryContact_Civility;
		this.deliveryContact_Name = deliveryContact_Name;
		this.deliveryContact_FirstName = deliveryContact_FirstName;
		this.deliveryContact_Email = deliveryContact_Email;
		this.deliveryContact_Phone = deliveryContact_Phone;
		this.deliveryContact_CellPhone = deliveryContact_CellPhone;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public Timestamp getSysCreatedDate() {
		return sysCreatedDate;
	}

	public void setSysCreatedDate(Timestamp sysCreatedDate) {
		this.sysCreatedDate = sysCreatedDate;
	}

	public Timestamp getSysModifiedDate() {
		return sysModifiedDate;
	}

	public void setSysModifiedDate(Timestamp sysModifiedDate) {
		this.sysModifiedDate = sysModifiedDate;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getCivility() {
		return civility;
	}

	public void setCivility(String civility) {
		this.civility = civility;
	}

	public String getNotesClear() {
		return notesClear;
	}

	public void setNotesClear(String notesClear) {
		this.notesClear = notesClear;
	}

	public String getInvoicingAddress_Address1() {
		return invoicingAddress_Address1;
	}

	public void setInvoicingAddress_Address1(String invoicingAddress_Address1) {
		this.invoicingAddress_Address1 = invoicingAddress_Address1;
	}

	public String getInvoicingAddress_City() {
		return invoicingAddress_City;
	}

	public void setInvoicingAddress_City(String invoicingAddress_City) {
		this.invoicingAddress_City = invoicingAddress_City;
	}

	public String getInvoicingAddress_ZipCode() {
		return invoicingAddress_ZipCode;
	}

	public void setInvoicingAddress_ZipCode(String invoicingAddress_ZipCode) {
		this.invoicingAddress_ZipCode = invoicingAddress_ZipCode;
	}

	public String getInvoicingContact_Civility() {
		return invoicingContact_Civility;
	}

	public void setInvoicingContact_Civility(String invoicingContact_Civility) {
		this.invoicingContact_Civility = invoicingContact_Civility;
	}

	public String getInvoicingContact_Name() {
		return invoicingContact_Name;
	}

	public void setInvoicingContact_Name(String invoicingContact_Name) {
		this.invoicingContact_Name = invoicingContact_Name;
	}

	public String getInvoicingContact_FirstName() {
		return invoicingContact_FirstName;
	}

	public void setInvoicingContact_FirstName(String invoicingContact_FirstName) {
		this.invoicingContact_FirstName = invoicingContact_FirstName;
	}

	public String getInvoicingContact_Email() {
		return invoicingContact_Email;
	}

	public void setInvoicingContact_Email(String invoicingContact_Email) {
		this.invoicingContact_Email = invoicingContact_Email;
	}

	public String getInvoicingContact_Phone() {
		return invoicingContact_Phone;
	}

	public void setInvoicingContact_Phone(String invoicingContact_Phone) {
		this.invoicingContact_Phone = invoicingContact_Phone;
	}

	public String getInvoicingContact_CellPhone() {
		return invoicingContact_CellPhone;
	}

	public void setInvoicingContact_CellPhone(String invoicingContact_CellPhone) {
		this.invoicingContact_CellPhone = invoicingContact_CellPhone;
	}

	public String getDeliveryAddress_Address1() {
		return deliveryAddress_Address1;
	}

	public void setDeliveryAddress_Address1(String deliveryAddress_Address1) {
		this.deliveryAddress_Address1 = deliveryAddress_Address1;
	}

	public String getDeliveryAddress_City() {
		return deliveryAddress_City;
	}

	public void setDeliveryAddress_City(String deliveryAddress_City) {
		this.deliveryAddress_City = deliveryAddress_City;
	}

	public String getDeliveryAddress_ZipCode() {
		return deliveryAddress_ZipCode;
	}

	public void setDeliveryAddress_ZipCode(String deliveryAddress_ZipCode) {
		this.deliveryAddress_ZipCode = deliveryAddress_ZipCode;
	}

	public String getDeliveryContact_Civility() {
		return deliveryContact_Civility;
	}

	public void setDeliveryContact_Civility(String deliveryContact_Civility) {
		this.deliveryContact_Civility = deliveryContact_Civility;
	}

	public String getDeliveryContact_Name() {
		return deliveryContact_Name;
	}

	public void setDeliveryContact_Name(String deliveryContact_Name) {
		this.deliveryContact_Name = deliveryContact_Name;
	}

	public String getDeliveryContact_FirstName() {
		return deliveryContact_FirstName;
	}

	public void setDeliveryContact_FirstName(String deliveryContact_FirstName) {
		this.deliveryContact_FirstName = deliveryContact_FirstName;
	}

	public String getDeliveryContact_Email() {
		return deliveryContact_Email;
	}

	public void setDeliveryContact_Email(String deliveryContact_Email) {
		this.deliveryContact_Email = deliveryContact_Email;
	}

	public String getDeliveryContact_Phone() {
		return deliveryContact_Phone;
	}

	public void setDeliveryContact_Phone(String deliveryContact_Phone) {
		this.deliveryContact_Phone = deliveryContact_Phone;
	}

	public String getDeliveryContact_CellPhone() {
		return deliveryContact_CellPhone;
	}

	public void setDeliveryContact_CellPhone(String deliveryContact_CellPhone) {
		this.deliveryContact_CellPhone = deliveryContact_CellPhone;
	}
}
