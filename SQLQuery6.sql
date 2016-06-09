Create Procedure spSelectPhoto
as
Begin
  Select * from [dbo].[Photos] where (RaterSlot = m1 and BeautyRatingDisplayed = 'No') OR (RaterSlot = m2 and BeautyRatingDisplayed = 'No') OR (RaterSlot = m3 and BeautyRatingDisplayed = 'No')
End