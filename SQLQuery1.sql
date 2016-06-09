
Create Procedure spInsertRegistration
@gender varchar(10),
@age int,
@username varchar(50),
@password varchar(50),
@confirmpassword varchar(50)
As
Begin
INSERT INTO dbo.User(Gender, Age, Username, UserPassword, ConfirmPassword) 
VALUES (@gender, @age, @username, @password, @confirmpassword) 
End 


