-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	�R���|��
-- =============================================
CREATE PROCEDURE usp_User_Delete
    (
	  @Id int,
	  @Delete bit
    )
AS
    BEGIN      
                UPDATE  [User]
        SET     
				[Delete] = @Delete

        WHERE   Id = @Id; 
    END; 
GO

