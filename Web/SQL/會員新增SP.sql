-- =============================================
-- Author:		Anna Chen
-- Create date: 2018/06/01
-- Description:	�s�W�|�����
-- =============================================
CREATE PROCEDURE usp_User_Add
    (
      @UserAccount NVARCHAR(50) , 
      @UserClass tinyint , 
      @Email NVARCHAR(50) , 
      @Password NVARCHAR(20) , 
      @UserName NVARCHAR(20) , 
      @CreatDate DateTime , 
      @MofiyDate DateTime ,
	  @Delete bit
    )
AS
    BEGIN  
        INSERT  INTO "User" 

        VALUES  ( @UserAccount, @UserClass, @Email, @Password, @UserName, getdate(), null , @Delete) 
    END;
GO 

