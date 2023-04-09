CREATE TABLE dbo.Products
(
ProductID int NOT NULL IDENTITY (1,1),
Name VARCHAR(100) NOT NULL,
UnitPrice money NOT NULL,
CONSTRAINT PK_Products PRIMARY KEY CLUSTERED  (ProductID)
)

INSERT INTO dbo.Products (Name, UnitPrice)
VALUES 
('Schweser CFA PremiumPlus Package', 1499.00),
('KPE Essential (Online) - Life & Health (for Iowa)', 169.00),
('KPE Total Access CE - All Lines', 59.00)