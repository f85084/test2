-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	Ū���|�����
-- =============================================
CREATE PROCEDURE usp_User_Get
AS
    BEGIN
		SET NOCOUNT ON;

        SELECT  [Id],[UserAccount],[UserClass] ,[Email],[Password],[UserName],[CreatDate],[MofiyDate],[Delete]
        FROM    [User];
    END;
GO 
