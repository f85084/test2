-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: Ū���|�����

-- =============================================
CREATE PROCEDURE msp_GetUser
AS
    BEGIN
        SELECT  *
        FROM    "User";
    END;
GO 
