-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	Ū���|�����
-- =============================================
CREATE PROCEDURE usp_User_CheckAccount_Get ( @UserAccount NVARCHAR(50) )
AS
    BEGIN
        SELECT  [Id],[UserAccount]
		FROM     [User]
		WHERE  UserAccount = @UserAccount;
    END;
GO 
