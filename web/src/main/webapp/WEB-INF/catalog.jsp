<body>

<input class="form-control" id="filter" type="text" placeholder="Recherche...">

<div class="table-responsive">
<table class="table table-striped table-sm">
	<thead>
	   <tr>
	     <th scope="col">Code</th>
	     <th scope="col">Libellé</th>
	     <th scope="col">Description</th>
	     <th scope="col">Prix de vente</th>
	   </tr>
	</thead>
	<tbody id="itemListBody">
		<c:forEach items="${ items }" var="item">
			<tr>
			<td><c:out value="${ item.code }" /></td>
			<td><c:out value="${ item.caption }" /></td>
			<td><c:out value="${ item.clearDescription }" /></td>
			<td><c:out value="${ item.salePrice }" /></td>
			</tr>
		</c:forEach>
	</tbody>
</table>
</div>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script>
$(document).ready(function(){
	  $("#filter").on("keyup", function() {
	    var value = $(this).val().toLowerCase();
	    $("#itemListBody tr").filter(function() {
	      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
	    });
	  });
	});
</script>
</body>