package repositories;

import java.util.ArrayList;

import beans.Customer;
import beans.Order;
import jakarta.ws.rs.WebApplicationException;
import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.core.GenericType;
import jakarta.ws.rs.core.MediaType;
import utils.SetCertificatePath;

public class CustomerRepository {
	private Client client;
	private final String baseUri;
	public CustomerRepository() {
		this.client = ClientBuilder.newClient();
	    baseUri = "https://localhost:5001/api/customers";
	    SetCertificatePath.Execute();
	}
	
	public ArrayList<Customer> getAllCustomers() {
		ArrayList<Customer> customers = new ArrayList<>();
		try {
			customers = client.target(baseUri)
                    .request(MediaType.APPLICATION_JSON)
                    .get(new GenericType<ArrayList<Customer>>() {
            });
            if (customers == null) {
                customers = new ArrayList<>();
            }
        } catch (WebApplicationException ex) {
            System.out.println(ex.getMessage());
        }
		return customers;
	}
}
