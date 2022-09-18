SELECT 
	MIN(AverageSalary) AS MinimumAverageSalary, 
	MAX(AverageSalary) AS MaximumAverageSalary
	FROM (
		   SELECT DepartmentId, 
		   AVG(Salary) AS AverageSalary 
	       FROM Employees
	       GROUP BY DepartmentId
	     ) 
		   AS AverageSalaryByDepartment;

SELECT DepartmentId,
	CASE	
		WHEN MinimumSalary < 2000 THEN 'Low Minimum Salary'
		WHEN MinimumSalary > 8000 THEN 'High Minimum Salary'
		ELSE 'Normal Minimum Salary'
	END
	FROM (
		   SELECT DepartmentId, 
		   MIN(Salary) AS MinimumSalary 
	       FROM Employees
	       GROUP BY DepartmentId
	     ) 
		   AS MinimumSalaryByDepartment
		   ORDER BY MinimumSalary;

SELECT AVG(AverageStartingYear)
	FROM (
		  SELECT DepartmentId, 
		  AVG(YEAR(HireDate)) AS AverageStartingYear
		  FROM Employees
	      GROUP BY DepartmentId
		 ) 
		  AS AverageStartingYearByDepartment;

SELECT 
	MIN(JobCount) AS MinimumJobCount,
	MAX(JobCount) AS MaximumJobCount
	FROM (
		  SELECT  DepartmentId, 
		  COUNT(JobTitle) AS JobCount 
		  FROM Employees
		  GROUP BY  DepartmentId
		 )
		  AS JobTitleCount;

