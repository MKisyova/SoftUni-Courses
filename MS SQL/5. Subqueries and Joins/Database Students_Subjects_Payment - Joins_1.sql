SELECT * FROM Students AS s
	JOIN Majors AS m ON s.MajorID = m.MajorID
	ORDER BY StudentNumber;

SELECT * FROM Students AS s
	LEFT JOIN Payments AS p ON s.StudentID = p.StudentID;

SELECT * FROM Students AS s
	JOIN Majors AS m ON s.MajorID = m.MajorID
	JOIN Payments AS p ON s.StudentID = p.StudentID
	JOIN StudentsSubjects AS ss ON s.StudentID = ss.StudentID;

SELECT * FROM Students
	CROSS JOIN StudentsSubjects;

SELECT * FROM Payments p
	RIGHT JOIN Students AS s ON p.StudentID = s.StudentID

SELECT * FROM Students s
	JOIN Payments AS p ON s.StudentID = p.StudentID
	WHERE DATEPART(MONTH, PaymentDate) < 5
	ORDER BY DATEPART(MONTH, PaymentDate), DATEPART(DAY, PaymentDate);

SELECT * FROM StudentsSubjects ss
	RIGHT JOIN Students AS st ON ss.StudentID  = st.StudentID
	RIGHT JOIN Subjects AS sb ON ss.SubjectID = sb.SubjectID
	ORDER BY ss.SubjectID 
