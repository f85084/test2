-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	Ū���d�����
-- =============================================
CREATE PROCEDURE usp_Message_Get
AS
    BEGIN
		SET NOCOUNT ON;

        SELECT  [Id],[UserId],[UserName],[Context],[CreatDate],[Delete]
        FROM    [Message];
    END;
GO 