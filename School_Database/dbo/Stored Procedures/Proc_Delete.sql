CREATE PROCEDURE [dbo].[Proc_Delete] (@EmpCode INT) 
AS  
	 BEGIN
	 	DECLARE @Type int
	 	DECLARE @Id int
		--fetching type and id
	 	SELECT @Type = Type, @Id = Id FROM Staff WHERE EmpCode = @EmpCode

		--Delete row from corresponding table
	 	IF (@Type = 1)
	 	BEGIN
	 		DELETE FROM Teacher WHERE StaffId = @Id
	 	END
	 	ELSE IF (@Type = 2)
	 	BEGIN
	 		DELETE FROM Support WHERE StaffId = @Id
	 	END
	 	ELSE IF (@Type = 3)
	 	BEGIN
	 		DELETE FROM Administrator WHERE StaffId = @Id
	 	END

		--Delete row from Staff table
		DELETE FROM Staff WHERE Id = @Id

	END