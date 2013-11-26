USE AdventureWorks2012

SELECT SickLeaveHours, COUNT(*) as number FROM HumanResources.Employee
GROUP BY SickLeaveHours
HAVING COUNT(*) > 1
--ORDER BY SickLeaveHours
ORDER BY number

SELECT SickLeaveHours, COUNT(*) as number FROM HumanResources.Employee
GROUP BY SickLeaveHours
HAVING COUNT(*) > 1
--ORDER BY SickLeaveHours
ORDER BY 2

SELECT * FROM HumanResources.Employee AS tabla
