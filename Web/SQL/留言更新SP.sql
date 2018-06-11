USE [Web]
GO
/****** Object:  StoredProcedure [dbo].[spSaveMessage]    Script Date: 2018/5/31 上午 09:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spSaveMessage]
    (
      @Id INT ,
      @UserId INT ,
      @UserName NVARCHAR(20) , 
      @Context NVARCHAR(200) , 
      @CreatDate DateTime
    )
AS
    BEGIN      
        UPDATE  "Message"
        SET     UserId = @UserId ,
                UserName = @UserName ,
                Context = @Context ,
                CreatDate = getdate()
        WHERE   UserId = @UserId; 
    END; 
