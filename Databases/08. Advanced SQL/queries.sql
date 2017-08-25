USE TelerikAcademy

/*1. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement.*/
SELECT FirstName + ' ' + LastName AS [Employee], Salary
FROM Employees
WHERE Salary = 
	(SELECT MIN(Salary) FROM Employees)

--2. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT FirstName + ' ' + LastName AS [Employee], Salary
FROM Employees
WHERE Salary <
	(SELECT (MIN(Salary) * 0.1 + MIN(Salary)) FROM Employees)
ORDER BY Salary

/*3. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
Use a nested SELECT statement.*/
SELECT FirstName + ' ' + LastName AS [Employee], Salary, d.Name AS [Department]
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE Salary =
	(SELECT MIN(Salary) FROM Employees
	 WHERE DepartmentID = d.DepartmentID)

--4. Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS [Average Salary]
FROM Employees
WHERE DepartmentID = 1

--5. Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(Salary) AS [Average Salary], 'Sales' AS [Department]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--6. Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*)
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--7. Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID)
FROM Employees 
WHERE ManagerID IS NOT NULL --not necessary since group functions ignore NULL values

--8. Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) -- or EmployeeID
FROM Employees
WHERE ManagerID IS NULL

--9. Write a SQL query to find all departments and the average salary for each of them.
SELECT DepartmentID, AVG(Salary) AS [Average Salary]
FROM Employees
GROUP BY DepartmentID

--10. Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS [Department], t.Name AS [Town], COUNT(EmployeeID) AS [Count Employees]
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
		JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

--11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
