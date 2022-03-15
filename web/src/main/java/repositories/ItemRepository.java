package repositories;

import java.util.ArrayList;

import beans.Item;
import beans.ItemFamily;
import jakarta.ws.rs.WebApplicationException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.core.GenericType;
import jakarta.ws.rs.core.MediaType;
import utils.SetCertificatePath;

public class ItemRepository {
	private Client client;
	private final String baseUri;
	public ItemRepository() {
	    this.client = ClientBuilder.newClient();
	    baseUri = "https://localhost:5001/api/items";
	    SetCertificatePath.Execute();
	}
	
	public ArrayList<Item> getAllItems() {
		ArrayList<Item> items = new ArrayList<>();
		try {
			items = client.target(baseUri)
                    .request(MediaType.APPLICATION_JSON)
                    .get(new GenericType<ArrayList<Item>>() {
            });
            if (items == null) {
                items = new ArrayList<>();
            }
        } catch (WebApplicationException ex) {
            System.out.println(ex.getMessage());
        }
		return items;
	}
	
	public Item getItemById(String id) {
		Item item = null;
		try {
			item = client.target(baseUri).path(id)
                    .request(MediaType.APPLICATION_JSON)
                    .get(new GenericType<Item>() {
            });
        } catch (WebApplicationException ex) {
            System.out.println(ex.getMessage());
        }
		return item;
	}
}
