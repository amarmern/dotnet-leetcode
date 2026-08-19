SELECT Salary
FROM
(
SELECT Salary,
DENSE_RANK() OVER(ORDER BY Salary DESC) rnk
FROM Employee
)t
WHERE rnk=5;