USE AdventureWorks2012

--SELECT UnitPrice from SALES.SalesOrderDetail AS a INNER JOIN Sales.SalesOrderHeader AS b ON a.SalesOrderID = b.SalesOrderID

--SELECT UnitPrice from SALES.SalesOrderDetail AS a INNER JOIN Sales.SalesOrderHeader AS b ON a.ModifiedDate = b.ModifiedDate

--SELECT UnitPrice from SALES.SalesOrderDetail AS a RIGHT OUTER JOIN Sales.SalesOrderHeader AS b ON a.SalesOrderID = b.SalesOrderID

--SELECT SalesQuota from SALES.SalesOrderHeader AS a LEFT OUTER JOIN Sales.SalesPerson AS b ON a.SalesPersonID = b.BusinessEntityID

SELECT SalesQuota, a.TaxAmt, a.TerritoryID from SALES.SalesOrderHeader AS a RIGHT OUTER JOIN Sales.SalesPerson AS b ON (a.SalesPersonID = b.BusinessEntityID) AND (a.TerritoryID = b.TerritoryID)
WHERE a.TaxAmt > 10000

SELECT SalesQuota, a.TaxAmt, a.TerritoryID from SALES.SalesOrderHeader AS a RIGHT OUTER JOIN Sales.SalesPerson AS b ON (a.SalesPersonID = b.BusinessEntityID)
WHERE a.TaxAmt > 10000  AND (a.TerritoryID = b.TerritoryID)