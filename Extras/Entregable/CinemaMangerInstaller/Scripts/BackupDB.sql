USE [master]
GO

/****** Object:  StoredProcedure [dbo].[BackupDB]    Script Date: 4/8/2022 10:57:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[BackupDB]
	@name VARCHAR(MAX),
	@path VARCHAR(MAX)	
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @fileName VARCHAR(max)
	DECLARE @fileDate VARCHAR(max)


	SELECT @fileDate = CONVERT(VARCHAR(20),GETDATE(),112)
	SET @fileName = 'Backup_' + @name + '_'+ @fileDate + '.BAK'

	BEGIN
	DECLARE @SQL varchar(max)
	SET @SQL = 'BACKUP DATABASE '
	SET @SQL = @SQL + @name
	SET @SQL = @SQL + ' TO DISK = ''' + @path + '\' + @fileName + ''''

	EXECUTE(@SQL)
 	END
END
GO

