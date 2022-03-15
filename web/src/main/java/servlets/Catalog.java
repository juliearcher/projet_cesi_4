package servlets;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import repositories.ItemFamilyRepository;
import repositories.ItemRepository;

import java.io.IOException;
import java.util.ArrayList;

import beans.Customer;
import beans.Item;
import beans.ItemFamily;
import beans.Order;

/**
 * Servlet implementation class Catalog
 */
public class Catalog extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private final ItemFamilyRepository itemFamilyRepository;
	private final ItemRepository itemRepository;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Catalog() {
        super();
        itemFamilyRepository = new ItemFamilyRepository();
        itemRepository = new ItemRepository();
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		ArrayList<ItemFamily> itemFamilies = itemFamilyRepository.getAllItemFamilies();
		request.setAttribute("itemFamilies", itemFamilies);
		ArrayList<Item> items = itemRepository.getAllItems();
		request.setAttribute("items", items);
		this.getServletContext().getRequestDispatcher("/WEB-INF/catalog.jsp").forward(request, response);
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
