Create Procedure spInsertBeautyRatings
@userid int,
@beautylist1a int,
@beautylist2a int,
@beautylist3a int,
@beautylist4a int,
@beautylist4b int
As
Begin
INSERT INTO [dbo].[BeautyRatings](UserId, BeautyList1a, BeautyList2a, BeautyList3a, BeautyList4a, BeautyList4b) 
VALUES (@userid, @beautylist1a, @beautylist2a, @beautylist3a, @beautylist4a, @beautylist4b) 
End