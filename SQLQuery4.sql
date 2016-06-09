Create Procedure spSelectRegistration
(@username varchar(50), @userpassword varchar(50))
as
Begin
  Select * from [dbo].[User] where UserName = @username and UserPassword = @userpassword
End