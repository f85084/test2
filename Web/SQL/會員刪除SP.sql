-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: �R���|�����

-- =============================================
CREATE PROCEDURE msp_DeleteUser ( @Id int )
AS
    BEGIN
        DELETE  FROM "User" 
        WHERE   Id = @Id;
    END;
GO