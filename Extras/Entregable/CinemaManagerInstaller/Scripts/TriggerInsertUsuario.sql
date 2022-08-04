USE [CinemaDB]
GO

/****** Object:  Trigger [dbo].[TriggerAntesDeInsert]    Script Date: 4/8/2022 10:58:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[TriggerAntesDeInsert]
	ON [dbo].[Usuario]
	INSTEAD OF INSERT
AS
BEGIN
	IF EXISTS ( SELECT 1 FROM Usuario A 
	INNER JOIN inserted B ON B.nombredeusuario=A.nombredeusuario) 
	BEGIN
		RAISERROR('El nombre de usuario ya existe.', 16, 1);
	END

	IF EXISTS ( SELECT 1 FROM Usuario A 
	INNER JOIN inserted B ON B.emailprincipal=A.emailprincipal)
	BEGIN
		RAISERROR('La direccion de correo ya existe.', 16, 1);
	END

	IF EXISTS ( SELECT 1 FROM Usuario A 
	INNER JOIN inserted B ON B.dni_usuario=A.dni_usuario)
	BEGIN
		RAISERROR('El numero de documento especificado ya existe.', 16, 1);
	END

	ELSE
	BEGIN
		Declare 
		@guid_usuario uniqueidentifier,
		@nombredeusuario varchar(50),
		@contraseña varchar(max), 
		@emailprincipal varchar(50), 
		@habilitado varchar(50),
		@DVH int, 
		@nombre_completo varchar(max),
		@dni_usuario varchar(9)

		
		SELECT @guid_usuario=guid_usuario,
			   @nombredeusuario=nombredeusuario,
			   @contraseña=contraseña, 
			   @emailprincipal=emailprincipal, 
			   @habilitado=habilitado,
			   @DVH = DVH,
			   @nombre_completo = nombre_completo,
			   @dni_usuario = dni_usuario
			   
			   
		FROM inserted
		
		INSERT INTO Usuario (guid_usuario, nombredeusuario, contraseña, emailprincipal, habilitado, DVH, nombre_completo, dni_usuario)
		VALUES (@guid_usuario, @nombredeusuario, @contraseña, @emailprincipal, @habilitado, @DVH, @nombre_completo, @dni_usuario)
	END

END
GO

ALTER TABLE [dbo].[Usuario] ENABLE TRIGGER [TriggerAntesDeInsert]
GO

