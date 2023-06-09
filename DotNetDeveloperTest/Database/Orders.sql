﻿CREATE TABLE dbo.Orders
(
OrderID INTEGER NOT NULL IDENTITY (1, 1),
OrderingPersonID INTEGER NOT NULL,
CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Orders_CreatedAt DEFAULT (SYSDATETIME()),
CONSTRAINT PK_Orders PRIMARY KEY (OrderID),
CONSTRAINT FK_Orders_Persons FOREIGN KEY (OrderingPersonID) REFERENCES dbo.Persons (PersonID)
)

INSERT INTO dbo.Orders (OrderingPersonID)
SELECT TOP 10 PersonID
  FROM Persons
ORDER BY NEWID()
  