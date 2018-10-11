-- =============================================
<<<<<<< HEAD
-- Author:		Anna Chen11
=======
-- Author:		Anna Chen1
>>>>>>> 41228c81dc5fe7197b333e56fa58d46805371c83
-- Create date: 2018/06/01
-- Description:	§R°£¦^ÂÐ
-- =============================================
CREATE PROCEDURE usp_Reply_Delete
    (
	  @Id int,
	  @Delete bit
    )
AS
    BEGIN      
                UPDATE  Reply
        SET     
				[Delete] = @Delete

        WHERE   Id = @Id; 
    END; 
GO