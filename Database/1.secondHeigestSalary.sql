SELECT Salary
FROM
(
SELECT Salary,
DENSE_RANK() OVER(ORDER BY Salary DESC) rnk
FROM Employee
)t
WHERE rnk=2;
........................
SELECT MAX(Salary) AS SecondHighestSalary
FROM Employee
WHERE Salary < (SELECT MAX(Salary) FROM Employee);

.........................
Delete Duplicate Records

WITH CTE AS
(
SELECT *,
ROW_NUMBER() OVER(PARTITION BY Email ORDER BY Id) rn
FROM Employee
)

DELETE FROM CTE
WHERE rn > 1;
