<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<!DOCTYPE html>
<html>
<head>
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
	<meta charset="UTF-8">
	<title>Projet 4</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
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
	<thead>
	   <tr>
	     <th scope="col">Code</th>
	     <th scope="col">Libellé</th>
	     <th scope="col">Description</th>
	     <th scope="col">Prix de vente</th>
	   </tr>
	</thead>
	<tbody>
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
</body>
</html>