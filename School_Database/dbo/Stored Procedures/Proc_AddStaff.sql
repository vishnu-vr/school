CREATE PROCEDURE Proc_AddStaff (@EmpCode INT, @Name VARCHAR(50), @Email VARCHAR(50), @Type INT, @Extra VARCHAR(50)) 
AS  
	BEGIN   
		INSERT INTO Staff (EmpCode, "Name", Email, "Type") VALUES  (@EmpCode, @Name, @Email, @Type);
		IF (@Type = 1)
		BEGIN
		  INSERT INTO Teacher (StaffId, "Subject") VALUES (@@IDENTITY, @Extra);
		END
		ELSE IF (@Type = 2)
		BEGIN
			INSERT INTO Support (StaffId, Department) VALUES (@@IDENTITY, @Extra);
		END
		ELSE IF (@Type = 3)
		BEGIN
			INSERT INTO Administrator(StaffId, "Role") VALUES (@@IDENTITY, @Extra);
		END
	END