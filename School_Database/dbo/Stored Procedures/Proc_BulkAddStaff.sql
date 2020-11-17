CREATE PROCEDURE Proc_BulkAddStaff (@Staffs [UT_Staff] readonly)  
AS  
	BEGIN
		--inserting into Staff
		INSERT INTO Staff (EmpCode, "Name", Email, "Type")
		SELECT s.EmpCode, s.Name, s.Email, s.Type FROM @Staffs as s

		--inserting into Teacher
		INSERT INTO Teacher (StaffId, "Subject") 
		SELECT st.id, s.Extra 
		FROM Staff as st inner join @Staffs as s ON st.EmpCode = s.EmpCode
		WHERE s.Type = 1

		--inserting into Support
		INSERT INTO Support (StaffId, Department) 
		SELECT st.id, s.Extra 
		FROM Staff as st inner join @Staffs as s ON st.EmpCode = s.EmpCode
		WHERE s.Type = 2

		--inserting into Administrator
		INSERT INTO Administrator (StaffId, "Role") 
		SELECT st.id, s.Extra 
		FROM Staff as st inner join @Staffs as s ON st.EmpCode = s.EmpCode
		WHERE s.Type = 3
	END