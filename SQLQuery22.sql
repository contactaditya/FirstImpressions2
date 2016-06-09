---Select * FROM [dbo].[Photos] WHERE PictureId IN (Select PictureId from [dbo].[Photos] where (RaterSlot = 'm1' and BeautyRatingDisplayed IS NULL) OR (RaterSlot = 'm2' and BeautyRatingDisplayed IS NULL) OR (RaterSlot = 'm3' and BeautyRatingDisplayed IS NULL))
Select Count, Condition, NumberofPictures, PictureId from [dbo].[Photos] where NumberofPictures = 2
