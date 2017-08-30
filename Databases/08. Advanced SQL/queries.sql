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
SELECT m.FirstName, m.LastName
FROM Employees e JOIN Employees m
	ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5

--12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' + e.LastName AS [Employee], ISNULL(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
FROM Employees e LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(lastName) = 5

/*14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
Search in Google to find how to format dates in SQL Server.*/
SELECT CONVERT(VARCHAR, GETDATE(), 113)
--OR
SELECT FORMAT(GETDATE(), 'dd MMM yyyy hh:mi:ss:mmm')

/*15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
Define the primary key column as identity to facilitate inserting records.
Define unique constraint to avoid repeating usernames.
Define a check constraint to ensure the password is at least 5 characters long.*/
CREATE TABLE Users (
	UserID int IDENTITY(1, 1) PRIMARY KEY, 
	Username nvarchar(30) NOT NULL UNIQUE,
	UserPassword nvarchar(30) NOT NULL CHECK (LEN(UserPassword) >= 5),
	FullName nvarchar(100) NOT NULL,
	LoginTime datetime NULL	
)
GO

/*16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
Test if the view works correctly.*/
CREATE VIEW V_TodayVisitors AS
SELECT Username, LoginTime
FROM Users
WHERE CAST(LoginTime AS date) = CAST(GETDATE() AS date)
GO 

--Checking if VIEW works
SELECT * FROM V_TodayVisitors

/*17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
Define primary key and identity column.*/
CREATE TABLE Groups (
	GroupID int IDENTITY(1, 1) PRIMARY KEY,
	Name nvarchar(100) NOT NULL UNIQUE
)
GO

/*18. Write a SQL statement to add a column GroupID to the table Users.
Fill some data in this new column and as well in the `Groups table.
Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.*/
ALTER TABLE Users
ADD GroupID int
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)
GO

--19. Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups VALUES 
('JAVA'),
('CSharp'),
('JavaScript')
GO

INSERT INTO Users (Username, UserPassword, FullName, LoginTime, GroupID) VALUES
('Pesho_89', 'kaksibe', 'Peter Georgiev', '2017-04-12', 1),
('Marcheto', 'mimiplus', 'Maria Liubenova', '2017-05-22', 1),
('Mind_Control', 'glowlow', 'Atanas Petrov', '2017-08-29', 2),
('wow_999', 'machinegun', 'Dara Simova', '2017-08-29', 3),
('LazerGot', 'gogogo', 'Lycho Kirov', '2017-08-29', 2)
GO

--20. Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET UserPassword = 'kaksi'
WHERE UserID = 1
GO

UPDATE Groups
SET Name = 'C#'
WHERE Name = 'CSharp'

UPDATE Groups
SET Name = 'Java'
WHERE Name = 'JAVA'
GO

--21. Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE UserID = 1

/*22. Write SQL statements to insert in the Users table the names of all employees from the Employees table.
Combine the first and last names as a full name.
For username use the first letter of the first name + the last name (in lowercase).
Use the same for the password, and NULL for last login time.*/
INSERT INTO Users (Username, UserPassword, FullName, LoginTime)
SELECT LOWER(SUBSTRING(FirstName, 1, 3)) + '.' + LOWER(LastName), -- Username should be unique so added 3 symbols from first name instead of 1
	   LOWER(SUBSTRING(FirstName, 1, 3)) + '.' + LOWER(LastName),
	   FirstName + ' ' + LastName,
	   NULL
FROM Employees

--23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
	-- First allow password to be null (constraint from prevous task where password.length >= 5)
ALTER TABLE Users
ALTER COLUMN UserPassword nvarchar(30) NULL
GO
	-- Since all users have NULL as LoginTime from previous task, update some data
UPDATE TOP (20) Users
SET LoginTime = GETDATE() -- OR CURRENT_TIMESTAMP
GO

UPDATE Users
SET UserPassword = NULL
WHERE CAST(LoginTime AS DATE) < CAST('20100310 00:00:00.000' AS DATE)

--24. Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE UserPassword IS NULL
GO

--25. Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS [Department], e.JobTitle, AVG(e.Salary) AS [Average Salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name

--26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT d.Name AS [Department], e.JobTitle, MIN(e.Salary) AS [Average Salary], MIN(CONCAT(FirstName, ' ', LastName)) AS [Employee with min salary]
FROM Employees e JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name

-- 27. Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS [Town], COUNT(*) AS [Count Employees]
FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(e.EmployeeID) DESC

--28. Write a SQL query to display the number of managers from each town.
SELECT t.Name AS [Town], COUNT(DISTINCT e.ManagerID) AS [Manager Count]
FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Manager Count] DESC