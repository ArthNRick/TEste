begin tran
    begin try

        if not exists (select * from sysobjects where name='users' and xtype='U')
            CREATE TABLE [dbo].[Users]
            (
    	        [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
    	    , [Name] VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
    	    , [LastName] VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
    	    , [Email] VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
            )

        if not exists (select * from sysobjects where name='details' and xtype='U')
            CREATE TABLE [dbo].[Details]
            (
            	  [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY
    	        , [UserId] INT NULL FOREIGN KEY REFERENCES Users(Id)
            	, [Type] TINYINT NULL
            	, [Value] VARCHAR(512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
            )

commit

end try
begin catch
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @ErrorSeverity INT;
    DECLARE @ErrorState INT;

    SELECT 
        @ErrorMessage = 'Impossível criar as tabelas >> ' + ERROR_MESSAGE(),
        @ErrorSeverity = ERROR_SEVERITY(),
        @ErrorState = ERROR_STATE();

    RAISERROR (@ErrorMessage,
               @ErrorSeverity,
               @ErrorState
               );

    rollback
end catch