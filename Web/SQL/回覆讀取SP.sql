-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	Ū���^�и��
-- =============================================
CREATE PROCEDURE usp_Reply_Get
AS
    BEGIN
		SET NOCOUNT ON;

        SELECT  [Id],[UserId],[MessageId],[UserName],[Context],[CreatDate],[Delete]
        FROM    Reply;
    END;
GO 