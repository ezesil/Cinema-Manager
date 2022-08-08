USE [master]
GO

/****** Object:  StoredProcedure [dbo].[RestoreDB]    Script Date: 4/8/2022 10:57:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Pranita Pendharkar>
-- Create date: <11-03-2017>
-- Description: <To Restore backup >
-- =============================================
/*
EXEC [DBRestore] 'DBRestore'
*/
CREATE PROCEDURE [dbo].[RestoreDB]
@name VARCHAR(MAX) = '', -- DB NAME TO Restore
@path VARCHAR(MAX)
AS
BEGIN
DECLARE @setoffline VARCHAR(MAX)
SET @setoffline = 'ALTER DATABASE ' + @name + ' SET OFFLINE WITH ROLLBACK IMMEDIATE' 
EXECUTE(@setoffline)
DECLARE @SQL VARCHAR(MAX)
SET @SQL ='RESTORE DATABASE ' + @name
SET @SQL = @SQL + ' FROM DISK = ''' + @path + ''''
SET @SQL = @SQL + ' WITH REPLACE'

EXECUTE(@SQL)
END
GO

