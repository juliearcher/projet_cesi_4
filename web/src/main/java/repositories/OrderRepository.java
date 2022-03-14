package repositories;

import java.util.ArrayList;

import beans.Item;
import beans.Order;
import jakarta.ws.rs.WebApplicationException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.core.GenericType;
import jakarta.ws.rs.core.MediaType;
import utils.SetCertificatePath;

public class OrderRepository {
	private Client client;
	private final String baseUri;
	public OrderRepository() {
	    this.client = ClientBuilder.newClient();
	    baseUri = "https://localhost:5001/api/orders";
	    SetCertificatePath.Execute();
	}
	
	public ArrayList<Order> getAllOrders() {
		ArrayList<Order> orders = new ArrayList<>();
		try {
			orders = client.target(baseUri)
                    .request(MediaType.APPLICATION_JSON)
                    .get(new GenericType<ArrayList<Order>>() {
            });
            if (orders == null) {
                orders = new ArrayList<>();
            }
        } catch (WebApplicationException ex) {
            System.out.println(ex.getMessage());
        }
		return orders;
	}
}
