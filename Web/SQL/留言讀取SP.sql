-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: Ū���d�����

-- =============================================
CREATE PROCEDURE msp_GetMessage
AS
    BEGIN
        SELECT  *
        FROM    "Message";
    END;
GO 