package beans;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class OrderLine {
	
	private int id;
	private Timestamp sysCreatedDate;
	private Timestamp sysModifiedDate;
	private String createdUser = "web client";
	private String modifiedUser = "web client";
	
	private int orderId;
	private int lineOrder;
	private float discountRate;
	private String clearDescription;
	
	private BigDecimal salePrice;
	private float vat;

	private int itemId;
	private String Item;

	private int quantity;
	
	public OrderLine() {
		
	}

	public OrderLine(int id, Timestamp sysCreatedDate, Timestamp sysModifiedDate, int orderId, int lineOrder,
			float discountRate, String clearDescription, BigDecimal salePrice, float vat, int itemId, int quantity) {
		this.id = id;
		this.sysCreatedDate = sysCreatedDate;
		this.sysModifiedDate = sysModifiedDate;
		this.orderId = orderId;
		this.lineOrder = lineOrder;
		this.discountRate = discountRate;
		this.clearDescription = clearDescription;
		this.salePrice = salePrice;
		this.vat = vat;
		this.itemId = itemId;
		this.quantity = quantity;
	}
	
	public OrderLine(int lineOrder, float discountRate, String clearDescription, BigDecimal salePrice, float vat, int itemId, int quantity) {
		this.lineOrder = lineOrder;
		this.discountRate = discountRate;
		this.clearDescription = clearDescription;
		this.salePrice = salePrice;
		this.vat = vat;
		this.itemId = itemId;
		this.quantity = quantity;
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

	public int getOrderId() {
		return orderId;
	}

	public void setOrderId(int orderId) {
		this.orderId = orderId;
	}

	public int getLineOrder() {
		return lineOrder;
	}

	public void setLineOrder(int lineOrder) {
		this.lineOrder = lineOrder;
	}

	public float getDiscountRate() {
		return discountRate;
	}

	public void setDiscountRate(float discountRate) {
		this.discountRate = discountRate;
	}

	public String getClearDescription() {
		return clearDescription;
	}

	public void setClearDescription(String clearDescription) {
		this.clearDescription = clearDescription;
	}

	public BigDecimal getSalePrice() {
		return salePrice;
	}

	public void setSalePrice(BigDecimal salePrice) {
		this.salePrice = salePrice;
	}

	public float getVat() {
		return vat;
	}

	public void setVat(float vat) {
		vat = vat;
	}

	public int getItemId() {
		return itemId;
	}

	public void setItemId(int itemId) {
		this.itemId = itemId;
	}

	public String getItem() {
		return Item;
	}

	public void setItem(String item) {
		Item = item;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	
}
