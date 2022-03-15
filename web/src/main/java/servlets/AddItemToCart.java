package servlets;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import repositories.ItemRepository;

import java.io.IOException;

import beans.Item;
import beans.Order;
import beans.OrderLine;

/**
 * Servlet implementation class AddItemToCart
 */
public class AddItemToCart extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private final ItemRepository itemRepository;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public AddItemToCart() {
        super();
        itemRepository = new ItemRepository();
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.getWriter().append("Served at: ").append(request.getContextPath());
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		HttpSession session = request.getSession(true);
		Order order = (Order) session.getAttribute("order");
		if (order == null) {
			order = new Order();
		}
		String itemId = request.getParameter("itemId");
		String quantity = request.getParameter("quantity"+itemId);
		if (itemId == null || quantity == null)
			return;
		Item item = itemRepository.getItemById(itemId);
		if (item == null)
			return;
		OrderLine line = null;
		for (OrderLine orderLine : order.orderLines) {
			if (orderLine.getItemId() == item.getId())
				line = orderLine;
		}
		if (line == null)
			order.orderLines.add(new OrderLine(order.orderLines.size() + 1, 0, item.getClearDescription(),
				item.getSalePrice(), item.getVat(), item.getId(), Integer.parseInt(quantity)));
		else
			line.setQuantity(line.getQuantity() + 1);
		session.setAttribute("order", order);
		response.sendRedirect(request.getContextPath() + "/cart");
	}

}