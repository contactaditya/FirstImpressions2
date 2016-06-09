Create Procedure spInsertRegistration
(@gender varchar(10), @age int, @username varchar(50), @userpassword varchar(50), @confirmpassword varchar(50))
as
Begin
  Insert into [dbo].[User] (Gender, Age, Username, UserPassword, ConfirmPassword) values (@gender, @age, @username, @userpassword, @confirmpassword) 
End