<body>
<div class="table-responsive">
<table class="table table-striped table-sm">
	<thead>
	   <tr>
	     <th scope="col">Ligne</th>
	     <th scope="col">Libellé</th>
	     <th scope="col">Description</th>
	     <th scope="col">Prix de vente</th>
	     <th scope="col">Quantité</th>
	     <th></th>
	     <th></th>
	   </tr>
	</thead>
	<tbody>
	<c:if test="${ not empty sessionScope.order }">
		<c:forEach items="${ sessionScope.order.orderLines }" var="line">
			<tr>
			<td><c:out value="${ line.lineOrder }" /></td>
			<td><c:out value="${ line.caption }" /></td>
			<td><c:out value="${ line.clearDescription }" /></td>
			<td><c:out value="${ line.salePrice }" /></td>
			<td><c:out value="${ line.quantity }" /></td>
			</tr>
		</c:forEach>
	</c:if>
	</tbody>
</table>
<c:if test="${ not empty errorMessage }"><p style="color:red;">${errorMessage }</p></c:if>
<form action="cart" method="post" id="form">
<button type="submit" >Valider</button>
</form>
</div>
</body>
