<body>
<h2>Liste des familles</h2>
<div class="table-responsive">
<table class="table table-striped table-sm">
	<thead>
	   <tr>
	     <th scope="col">Code de la famille</th>
	     <th scope="col">Description</th>
	   </tr>
	</thead>
	<tbody>
		<c:forEach items="${ itemFamilies }" var="family">
			<tr>
			<td><c:out value="${ family.code }" /></td>
			<td><c:out value="${ family.designation }" /></td>
			</tr>
		</c:forEach>
	</tbody>
</table>
</div>
<h2>Liste des articles</h2>
<div class="table-responsive">
<table class="table table-striped table-sm">
	<tbody>
		<c:forEach items="${ items }" var="item">
			<div class="article-container">
				<!-- <div class="article-item"><c:out value="${ item.code }" /></div> -->
				<div class="name-description">
					<div class="article-item name"><c:out value="${ item.caption }" /></div>
					<div class="article-item description"><c:out value="${ item.clearDescription }" /></div>
				</div>
				<div class="article-item">
					<div class="price"><c:out value="${ item.salePrice }" />&#8364</div>
				</div>
			</div>
		</c:forEach>
		
		
	</tbody>
</table>
</div>
</body>
</html>