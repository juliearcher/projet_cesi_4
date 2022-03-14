package beans;

import java.sql.Timestamp;

public class ItemFamily {
	private int id;
	private Timestamp sysCreatedDate;
	private Timestamp sysModifiedDate;
	private String code;
	private String designation;

	public ItemFamily() {
		
	}
	
	public ItemFamily(int id, Timestamp sysCreatedDate, Timestamp sysModifiedDate, String code, String designation) {
		this.id = id;
		this.sysCreatedDate = sysCreatedDate;
		this.sysModifiedDate = sysModifiedDate;
		this.code = code;
		this.designation = designation;
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
	public String getDesignation() {
		return designation;
	}
	public void setDesignation(String designation) {
		this.designation = designation;
	}
}
