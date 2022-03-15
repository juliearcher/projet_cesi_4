package beans;

import java.sql.Timestamp;

public class Item {
	private int id;
	private Timestamp sysCreatedDate;
	private Timestamp sysModifiedDate;
	private String code;
	private String caption;
	private String clearDescription;
	private String notes;
	private float realStock;
	private double salePrice;
	private float vat;
	private int itemFamilyId;
	private String ItemFamily;
	private int supplierId;
	private String Supplier;

	public Item() {
		
	}
	
	public Item(int id, Timestamp sysCreatedDate, Timestamp sysModifiedDate, String code, String caption,
			String clearDescription, String notes, float realStock, double salePrice, float vat, int itemFamilyId,
			int supplierId) {
		this.id = id;
		this.sysCreatedDate = sysCreatedDate;
		this.sysModifiedDate = sysModifiedDate;
		this.code = code;
		this.caption = caption;
		this.clearDescription = clearDescription;
		this.notes = notes;
		this.realStock = realStock;
		this.salePrice = salePrice;
		this.vat = vat;
		this.itemFamilyId = itemFamilyId;
		this.supplierId = supplierId;
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
	public String getCaption() {
		return caption;
	}
	public void setCaption(String caption) {
		this.caption = caption;
	}
	public String getClearDescription() {
		return clearDescription;
	}
	public void setClearDescription(String clearDescription) {
		this.clearDescription = clearDescription;
	}
	public String getNotes() {
		return notes;
	}
	public void setNotes(String notes) {
		this.notes = notes;
	}
	public float getRealStock() {
		return realStock;
	}
	public void setRealStock(float realStock) {
		this.realStock = realStock;
	}
	public double getSalePrice() {
		return salePrice;
	}
	public void setSalePrice(double salePrice) {
		this.salePrice = salePrice;
	}
	public int getItemFamilyId() {
		return itemFamilyId;
	}
	public void setItemFamilyId(int itemFamilyId) {
		this.itemFamilyId = itemFamilyId;
	}
	public String getItemFamily() {
		return ItemFamily;
	}
	public void setItemFamily(String itemFamily) {
		ItemFamily = itemFamily;
	}
	public int getSupplierId() {
		return supplierId;
	}
	public void setSupplierId(int supplierId) {
		this.supplierId = supplierId;
	}
	public String getSupplier() {
		return Supplier;
	}
	public void setSupplier(String supplier) {
		Supplier = supplier;
	}

	public float getVat() {
		return vat;
	}

	public void setVat(float vat) {
		this.vat = vat;
	}
}
