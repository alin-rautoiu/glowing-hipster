USE AdventureWorks2012

SELECT DAY(tabla.BirthDate) FROM HumanResources.Employee AS tabla

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

