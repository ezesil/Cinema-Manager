USE [CinemaDB]
GO

/****** Object:  Trigger [dbo].[TriggerEnInsertDeleteUpdate]    Script Date: 4/8/2022 12:49:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================

CREATE TRIGGER [dbo].[TriggerEnInsertDeleteUpdate] 
   ON [dbo].[Usuario]
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here

	if((select count(*) from inserted) > 0)
	BEGIN

		if((select count(*) from deleted) > 0)
		BEGIN		
			INSERT into [LogDB].dbo.[ChangeLogs] (tipodecambio, tabla, sentencia) --UPDATE
			values ('UPDATE', '[CinemaDB].[Usuario]', 'Valores anteriores: "' 
			+ CAST((select deleted.guid_usuario from deleted)AS VARCHAR(50)) + '-' 
			+ CAST((select deleted.nombredeusuario from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.contraseña from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.emailprincipal from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.habilitado from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.DVH from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.nombre_completo from deleted) as varchar(max)) + '-' 
			+ CAST((select deleted.dni_usuario from deleted) as varchar(max)))
		END
		
		ELSE 
		BEGIN
			INSERT into [LogDB].dbo.[ChangeLogs] (tipodecambio, tabla, sentencia) --INSERT
			values ('INSERT', '[CinemaDB].[Usuario]', ''
			+ CAST((select inserted.guid_usuario from inserted)AS VARCHAR(50)) + '-' 
			+ CAST((select inserted.nombredeusuario from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.contraseña from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.emailprincipal from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.habilitado from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.DVH from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.nombre_completo from inserted) as varchar(max)) + '-' 
			+ CAST((select inserted.dni_usuario from inserted) as varchar(max)))
		END

	END


	ELSE
	BEGIN
		INSERT into [LogDB].dbo.[ChangeLogs] (tipodecambio, tabla, sentencia) --DELETE
		values ('DELETE', '[CinemaDB].[Usuario]', 'Valores anteriores: "' 
		+ CAST((select deleted.guid_usuario from deleted)AS VARCHAR(50)) + '-' 
		+ CAST((select deleted.nombredeusuario from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.contraseña from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.emailprincipal from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.habilitado from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.DVH from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.nombre_completo from deleted) as varchar(max)) + '-' 
		+ CAST((select deleted.dni_usuario from deleted) as varchar(max)))
	END 

END
GO

ALTER TABLE [dbo].[Usuario] ENABLE TRIGGER [TriggerEnInsertDeleteUpdate]
GO

