CREATE PROCEDURE Proc_Update (@EmpCode INT, @Name VARCHAR(50), @Email VARCHAR(50), @Extra VARCHAR(50)) 
AS  
	 BEGIN
	 	DECLARE @Type int
	 	DECLARE @Id int
		--fetching type and id
	 	SELECT @Type = Type, @Id = Id FROM Staff WHERE EmpCode = @EmpCode

		--update row on Staff table
		UPDATE Staff SET Name = @Name, Email = @Email WHERE Id = @Id

		--update corresponding row
	 	IF (@Type = 1)
	 	BEGIN
	 		UPDATE Teacher SET Subject = @Extra WHERE StaffId = @Id
	 	END
	 	ELSE IF (@Type = 2)
	 	BEGIN
	 		UPDATE Support SET Department = @Extra WHERE StaffId = @Id
	 	END
	 	ELSE IF (@Type = 3)
	 	BEGIN
	 		UPDATE Administrator SET Role = @Extra WHERE StaffId = @Id
	 	END
	END