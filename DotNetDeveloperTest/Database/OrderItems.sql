/*
CREATE TABLE dbo.OrderItems
(
OrderID int NOT NULL,
LineNumber smallint NOT NULL,
ProductID int NOT NULL,
Quantity smallint NOT NULL,
Price money NOT NULL,
CONSTRAINT CK_OrderItems_Quantity CHECK ((Quantity>(0))),
CONSTRAINT PK_OrderItems PRIMARY KEY CLUSTERED  (OrderID, LineNumber),
CONSTRAINT FK_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES dbo.Orders (OrderID),
CONSTRAINT FK_OrderItems_Products FOREIGN KEY (ProductID) REFERENCES dbo.Products (ProductID)
)

INSERT INTO dbo.OrderItems (OrderID, LineNumber, ProductID, Quantity, Price)
SELECT TOP 10 o.OrderID, 1, p.ProductID, 1, p.UnitPrice
FROM dbo.Products AS p
JOIN dbo.Orders AS o
  ON 1 = 1
WHERE NOT EXISTS (
SELECT 1 FROM dbo.OrderItems oi WHERE oi.OrderID = o.OrderID
)
  ORDER BY NEWID()
*/

  SELECT oi.*
    FROM dbo.Orders o
	JOIN dbo.OrderItems oi
	  ON oi.OrderID = o.OrderID
	JOIN dbo.Persons p
	  ON p.PersonID = o.OrderingPersonID
	JOIN dbo.Products pr
	  ON oi.ProductID = pr.ProductID

