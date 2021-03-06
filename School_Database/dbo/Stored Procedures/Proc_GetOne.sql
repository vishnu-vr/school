﻿CREATE PROCEDURE [dbo].[Proc_GetOne] (@EmpCode INT) 
AS  
	BEGIN
		SELECT Staff.id, Staff.EmpCode, Staff.Name, Staff.Email, Staff.Type, Teacher.Subject, Administrator.Role, Support.Department 
		FROM Staff LEFT JOIN Teacher ON Teacher.StaffId = Staff.Id 
		LEFT JOIN Administrator ON Administrator.StaffId = Staff.Id
		LEFT JOIN Support ON Support.StaffId = Staff.Id
		WHERE Staff.EmpCode = @EmpCode
	END