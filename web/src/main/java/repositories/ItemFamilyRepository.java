package repositories;

import java.util.ArrayList;

import beans.ItemFamily;
import jakarta.ws.rs.WebApplicationException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.core.GenericType;
import jakarta.ws.rs.core.MediaType;
import utils.SetCertificatePath;

public class ItemFamilyRepository {
	private Client client;
	private final String baseUri;
	public ItemFamilyRepository() {
	    this.client = ClientBuilder.newClient();
	    baseUri = "https://localhost:5001/api/itemFamilies";
	    SetCertificatePath.Execute();
	}
	
	public ArrayList<ItemFamily> getAllItemFamilies() {
		ArrayList<ItemFamily> itemFamilies = new ArrayList<>();
		try {
			itemFamilies = client.target(baseUri)
                    .request(MediaType.APPLICATION_JSON)
                    .get(new GenericType<ArrayList<ItemFamily>>() {
            });
            if (itemFamilies == null) {
                itemFamilies = new ArrayList<>();
            }
        } catch (WebApplicationException ex) {
            System.out.println(ex.getMessage());
        }
		return itemFamilies;
	}
}
