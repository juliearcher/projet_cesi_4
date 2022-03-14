package servlets;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import repositories.CustomerRepository;
import repositories.ItemFamilyRepository;
import repositories.ItemRepository;
import repositories.OrderRepository;

import java.io.IOException;
import java.util.ArrayList;

import beans.Customer;
import beans.Item;
import beans.ItemFamily;
import beans.Order;

/**
 * Servlet implementation class GetItemFamilies
 */
public class GetItemFamilies extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private final ItemFamilyRepository itemFamilyRepository;
	private final ItemRepository itemRepository;
	private final OrderRepository orderRepository;
	private final CustomerRepository customerRepository;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public GetItemFamilies() {
        super();
        itemFamilyRepository = new ItemFamilyRepository();
        itemRepository = new ItemRepository();
        orderRepository = new OrderRepository();
        customerRepository = new CustomerRepository();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		ArrayList<ItemFamily> itemFamilies = itemFamilyRepository.getAllItemFamilies();
		request.setAttribute("itemFamilies", itemFamilies);
		ArrayList<Item> items = itemRepository.getAllItems();
		request.setAttribute("items", items);
		ArrayList<Order> orders = orderRepository.getAllOrders();
		request.setAttribute("orders", orders);
		ArrayList<Customer> customers = customerRepository.getAllCustomers();
		request.setAttribute("customers", customers);
		this.getServletContext().getRequestDispatcher("/WEB-INF/home.jsp").forward(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
