1. last 10 records but displayed in their original/ascending order, use a subquery.

SELECT *
FROM
(
    SELECT TOP 10 *
    FROM Employee
    ORDER BY Id DESC
) t
ORDER BY Id ASC;

2. Give me the next 20 records after ID 1,000,000.

SELECT TOP 20 *
FROM Orders
WHERE Id > 1000000
ORDER BY Id;

3. Find Duplicate Records

SELECT Email, COUNT(*)
FROM Employee
GROUP BY Email
HAVING COUNT(*) > 1;

4.Highest Salary Department Wise

SELECT DepartmentId,
       MAX(Salary) AS HighestSalary
FROM Employee
GROUP BY DepartmentId;

5. Top 3 Highest Salaries

SELECT *
FROM
(
SELECT *,
DENSE_RANK() OVER(ORDER BY Salary DESC) rnk
FROM Employee
)t
WHERE rnk<=3;

6. Employees Whose Salary Is Greater Than Average

SELECT *
FROM Employee
WHERE Salary >
(
SELECT AVG(Salary)
FROM Employee
);

7.Find Employees Without Manager

SELECT *
FROM Employee
WHERE ManagerId IS NULL;

8. Employees Joined in Last 30 Days
SELECT *
FROM Employee
WHERE JoiningDate >= DATEADD(day,-30,GETDATE());

using PostgreSQL

SELECT *
FROM employee
WHERE joining_date >= CURRENT_DATE - INTERVAL '30 days';

9. Count Employees Department Wise

SELECT DepartmentId,
COUNT(*) TotalEmployees
FROM Employee
GROUP BY DepartmentId;

10. INNER JOIN

SELECT e.Name,d.DepartmentName
FROM Employee e
INNER JOIN Department d
ON e.DepartmentId=d.Id;

11. LEFT JOIN
//Returns all employees even if department doesn't exist.
SELECT *
FROM Employee e
LEFT JOIN Department d
ON e.DepartmentId=d.Id;

12. Self Join

SELECT
e.Name Employee,
m.Name Manager
FROM Employee e
LEFT JOIN Employee m
ON e.ManagerId=m.Id;

13. Find Employees Having Same Salary

SELECT Salary,COUNT(*)
FROM Employee
GROUP BY Salary
HAVING COUNT(*)>1;

14. Pagination

SELECT *
FROM Employee
ORDER BY Id
OFFSET 20 ROWS
FETCH NEXT 10 ROWS ONLY;

using Postgre SQL
1. OFFSET pagination
SELECT *
FROM employee
ORDER BY id
LIMIT 20 OFFSET 100;

2.KEY Set Paginatoin

SELECT *
FROM employee
WHERE id > 1000
ORDER BY id
LIMIT 20;

Note : This is preferred for large datasets when the access pattern supports it.

15. Temporary Table

CREATE TABLE #HighSalaryEmployees
(
    Id INT,
    Name VARCHAR(100),
    Salary DECIMAL(18,2)
);

INSERT INTO #HighSalaryEmployees
SELECT Id, Name, Salary
FROM Employee
WHERE Salary > 50000;

SELECT *
FROM #HighSalaryEmployees;

#Employee → local temporary table, available to the current session.

##Employee → global temporary table, visible to other sessions.

Interview comparison

| CTE                                        | Temporary Table                                          |
| ------------------------------------------ | -------------------------------------------------------- |
| Exists for one statement                   | Can be used across multiple statements                   |
| Usually simpler                            | More suitable for multi-step processing                  |
| Can be recursive                           | Can have indexes created on it                           |
| Doesn't have separately created indexes    | Can create indexes                                       |
| Good for readability and recursive queries | Good for large intermediate datasets/multiple operations |
| Not automatically materialized             | Materialized in `tempdb`                                 |


16. Stored Procedure vs Function

Procedure

CREATE PROCEDURE GetEmployees @DepartmentId INT
AS
BEGIN
    SELECT *
    FROM Employee
    WHERE DepartmentId = @DepartmentId;
END

Call to excute:

EXEC GetEmployees 10;

Function:

CREATE FUNCTION GetEmployeeCount
(
    @DepartmentId INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Count INT;

    SELECT @Count = COUNT(*)
    FROM Employee
    WHERE DepartmentId = @DepartmentId;

    RETURN @Count;
END

Use:
SELECT dbo.GetEmployeeCount(10);

17. ACID Properties
ACID guarantees reliable database transactions.

A — Atomicity

All or nothing.

Example: 

Transfer ₹1000

Debit Account A
Credit Account B

If credit fails, debit should also be rolled back.

Debit ✅
Credit ❌
   ↓
ROLLBACK

C — Consistency
The transaction takes the database from one valid state to another valid state.
For example:

Balance cannot become negative
Foreign-key constraints remain valid

I — Isolation
Concurrent transactions should not incorrectly interfere with each other.

This is controlled through transaction isolation levels.

D — Durability
After a transaction is committed, the data should survive failures such as a database restart.

COMMIT
  ↓
Database crash
  ↓
Data still exists

18. Trigger

A trigger is automatically executed when an event occurs on a table/view.

Types:

AFTER trigger — executes after INSERT, UPDATE, or DELETE
INSTEAD OF trigger — executes instead of the operation

19. Cursor
A cursor processes rows one by one.

DECLARE employee_cursor CURSOR FOR
SELECT Id, Name FROM Employee;

OPEN employee_cursor;

FETCH NEXT FROM employee_cursor INTO @Id, @Name;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Process row

    FETCH NEXT FROM employee_cursor INTO @Id, @Name;
END;

CLOSE employee_cursor;
DEALLOCATE employee_cursor;

20. SCOPE_IDENTITY()

Used to get the last identity value generated in the current scope.

INSERT INTO Employee(Name, Salary)
VALUES ('John', 50000);

SELECT SCOPE_IDENTITY();

Suppose SQL Server generates:
EmployeeId = 105
SELECT SCOPE_IDENTITY();
returns 105.

Why not @@IDENTITY?

@@IDENTITY can return an identity generated by a trigger.

SCOPE_IDENTITY() is safer because it returns the identity generated in the same scope.


///Post gre LIMIT

PostgreSQL LIMIT
Get top 10 employees by salary.
SELECT *
FROM employee
ORDER BY salary DESC
LIMIT 10;

COALESCE

COALESCE() returns the first non-null value.

SELECT
    name,
    COALESCE(phone, 'No Phone') AS phone
FROM employee;

CASE Statement

SELECT
    name,
    salary,
    CASE
        WHEN salary >= 100000 THEN 'High'
        WHEN salary >= 50000 THEN 'Medium'
        ELSE 'Low'
    END AS salary_category
FROM employee;

PostgreSQL EXPLAIN
Very important for performance interviews.

EXPLAIN
SELECT *
FROM employee
WHERE department_id = 10;

For actual execution statistics:

EXPLAIN ANALYZE
SELECT *
FROM employee
WHERE department_id = 10;

EXPLAIN shows the planned execution strategy.

EXPLAIN ANALYZE actually executes the query and reports runtime information.

How Do You Optimize a Slow PostgreSQL Query?

First I reproduce the issue and run EXPLAIN ANALYZE to understand the actual 
execution plan. I check for sequential scans, inefficient joins, incorrect row 
estimates, sorting, excessive I/O and whether appropriate indexes are being used. 
Then I review indexes, query predicates, joins, returned columns and statistics. 
I also check for blocking, lock contention and whether the query is returning more 
data than necessary. Finally, I compare the execution plan and runtime before and
after the change.


















