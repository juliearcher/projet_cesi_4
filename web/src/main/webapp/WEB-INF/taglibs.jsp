<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>
<head>
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
	<meta charset="UTF-8">
	<title>Site STIVE</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
	<style>
		.article-container{
			display: flex;
			justify-content: space-between;
			width :100%;
			padding:10px;
			align-items: center;
		}
		.article-item{
			display: flex;
			align-items: center;
		}
		.name-description{
			display: flex;
			flex-direction: column;
			justify-content: flex-start;
			width: 75%;
		}
		.name{
			font-weight: bold;
			font-size: 16px;
			text-decoration: underline;
		}
		.price{
			min-width: 40px;
			text-align: center;

		}
		.quantity{
			width: 50px;
		}
		.cart-img{
			width: 20px;
			height: auto;
		}
		.button{
			border: none
		}
	</style>
</head>

<%@ include file="navigationBar.jsp" %>
