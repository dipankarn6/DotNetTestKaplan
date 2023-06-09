# Dot Net Developer Test

## Recommended Tools

* Visual Studio 2022 - The Community Edition is available for you to use for individual use
* [.NET Framework 4.8.1 Developer Pack](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks?cid=getdotnetsdk) installed 
* A Rest Client (Postman, Advanced REST Client, or Fiddler)

## System Notes

* The project contains a sql server compact database named Test.mdf
* The WebApi help page is located here: http://localhost:49861/Help
* Orders have both an ordering customer and can contain multiple students tied to each item ordered.

## Code Tasks

1. Fix the following bugs in the REST API:
    * The web service call to http://localhost:49861/api/Orders/3/Summary `GET` fails
     => Single() method was causing the issue, as there are multiple items, single was throwing error
     => Fixed by using First(), FirstOrDefault() can also be used
    * Unable to add items to the order
     => Fixed by removing the Quantity constraint 'CK_OrderItems_Quantity' 
     => and Foreign key constraint 'FK_OrderItems_Products'

2. Create a new resource to delete an Item from the order.

=> api/Orders/{OrderId}, query param = line number, could be the product id as well.

3. Change the OrderItems GET resource to return a 404 when the OrderID does not exist in the database and add a unit test for it.

=> Done by sending a http response of not found
4. Feel free to implement any changes/improvements you see fit.
