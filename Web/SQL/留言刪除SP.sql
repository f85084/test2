-- =============================================

-- Author: Anna Chen

-- Create date: 2018/06/01

-- Description: �R���d�����

-- =============================================
CREATE PROCEDURE msp_DeleteMessage ( @Id int )
AS
    BEGIN
        DELETE  FROM Message
        WHERE   Id = @Id;
    END;
GO 