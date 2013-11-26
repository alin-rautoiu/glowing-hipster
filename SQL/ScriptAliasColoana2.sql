--SELECT * FROM AdventureWorks2012.HumanResources.Employee
USE AdventureWorks2012

SELECT JobTitle, YEAR(hiredate) AS yearhired, COUNT(*) AS numemployees
FROM [HumanResources].Employee
WHERE hiredate >= '20030101' AND MaritalStatus='S'
GROUP BY JobTitle, YEAR(hiredate)
HAVING COUNT(*) > 1
ORDER BY JobTitle , yearhired DESC;