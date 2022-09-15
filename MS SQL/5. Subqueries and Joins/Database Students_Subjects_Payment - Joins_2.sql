SELECT * FROM Students AS s
	RIGHT JOIN Majors AS m ON s.MajorID = m.MajorID
	JOIN StudentsSubjects AS ss ON s.StudentID = ss.StudentID
	RIGHT JOIN Subjects AS sb ON ss.SubjectID = sb.SubjectID;

SELECT s.StudentID, 
	   s.StudentNumber, 
	   s.StudentName,
	   sb.SubjectName
	   FROM Students AS s
	JOIN StudentsSubjects AS ss ON s.StudentID = ss.StudentID
	RIGHT JOIN Subjects AS sb ON ss.SubjectID = sb.SubjectID
	WHERE s.StudentID IS NULL;

SELECT s.StudentID, 
	   s.StudentNumber, 
	   s.StudentName,
	   sb.SubjectName
	   FROM Students AS s
	JOIN StudentsSubjects AS ss ON s.StudentID = ss.StudentID
	JOIN Subjects AS sb ON ss.SubjectID = sb.SubjectID
	WHERE SubjectName LIKE 'C#%'
	ORDER BY SubjectName

SELECT * FROM StudentsSubjects AS ss
	RIGHT JOIN Subjects AS sb ON ss.SubjectID = sb.SubjectID
	WHERE SubjectName LIKE '%Basics%'
	ORDER BY sb.SubjectName





	


