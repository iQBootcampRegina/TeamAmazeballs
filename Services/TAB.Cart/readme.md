# Cart Service

## Service Endpoints
/carts POST
/carts(Id) DELETE
/carts(Id)/items GET/POST
/carts(Id)/items(Id) GET/PUT/DELETE
/completeCart(Id) GET

## Service Resources
Cart:	Id

CartItem:	Id
		ProductId
		Quantity
		ProductName
		ProductDescription
		ProductSKU

CompleteCart:	CartId
		CartItems[]


		
