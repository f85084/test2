-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	�R���|�����
-- =============================================
CREATE PROCEDURE usp_User_Delete ( @Id int )
AS
    BEGIN
        DELETE  FROM [User] 
        WHERE   Id = @Id;
    END;
GO