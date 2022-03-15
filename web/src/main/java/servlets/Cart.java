package servlets;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import repositories.CustomerRepository;
import repositories.OrderRepository;

import java.io.IOException;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Date;

import beans.Customer;
import beans.Order;

/**
 * Servlet implementation class Cart
 */
public class Cart extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private final CustomerRepository customerRepository;
	private final OrderRepository orderRepository;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Cart() {
        super();
        customerRepository = new CustomerRepository();
        orderRepository = new OrderRepository();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		this.getServletContext().getRequestDispatcher("/WEB-INF/cart.jsp").forward(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		HttpSession session = request.getSession(true);
		Order order = (Order) session.getAttribute("order");
		if (order == null) {
			this.getServletContext().getRequestDispatcher("/WEB-INF/cart.jsp").forward(request, response);
			session.setAttribute("errorMessage", "Panier vide");
			return;
		}
		order.setDocumentNumber("C" + new SimpleDateFormat("yyMMddHHmmss").format(new Date()).toString());
		order.setDocumentDate(new SimpleDateFormat("yyyy-MM-dd").format(new Date()).toString());
		order.setDeliveryDate(new SimpleDateFormat("yyyy-MM-dd").format(new Date()).toString());
		order.setDocumentState(0);
		order.setDiscountRate(0);
		Customer customer = customerRepository.getWebCustomer();
		if (customer == null) {
			this.getServletContext().getRequestDispatcher("/WEB-INF/cart.jsp").forward(request, response);
			session.setAttribute("errorMessage", "Une erreur s'est produite, essayez ultérieurement");
			return;
		}
		order.setCustomerId(customer.getId());
		order.setDeliveryAddress_Address1(customer.getDeliveryAddress_Address1());
		order.setDeliveryAddress_City(customer.getDeliveryAddress_City());
		order.setDeliveryAddress_ZipCode(customer.getDeliveryAddress_ZipCode());
		order.setInvoicingAddress_Address1(customer.getInvoicingAddress_Address1());
		order.setInvoicingAddress_City(customer.getInvoicingAddress_City());
		order.setInvoicingAddress_ZipCode(customer.getInvoicingAddress_ZipCode());
		if (orderRepository.createOrder(order))
			session.removeAttribute("order");
		else
			session.setAttribute("errorMessage", "Une erreur s'est produite, essayez ultérieurement");
		this.getServletContext().getRequestDispatcher("/WEB-INF/cart.jsp").forward(request, response);
	}
}
