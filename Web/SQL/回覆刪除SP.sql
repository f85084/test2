-- =============================================
-- Author:		Anna Chen1161333
-- Create date: 2018/06/01
-- Description:	�R���^��
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