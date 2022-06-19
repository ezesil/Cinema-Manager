USE [master]
GO
/****** Object:  Database [CinemaDB]    Script Date: 19/6/2022 03:04:41 ******/
CREATE DATABASE [CinemaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CinemaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CinemaDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CinemaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CinemaDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CinemaDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CinemaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CinemaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CinemaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CinemaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CinemaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CinemaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CinemaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CinemaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CinemaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CinemaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CinemaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CinemaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CinemaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CinemaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CinemaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CinemaDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CinemaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CinemaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CinemaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CinemaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CinemaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CinemaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CinemaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CinemaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CinemaDB] SET  MULTI_USER 
GO
ALTER DATABASE [CinemaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CinemaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CinemaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CinemaDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CinemaDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CinemaDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CinemaDB', N'ON'
GO
ALTER DATABASE [CinemaDB] SET QUERY_STORE = OFF
GO
USE [CinemaDB]
GO
/****** Object:  Table [dbo].[DigitoVerificadorVertical]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigitoVerificadorVertical](
	[Entity_ID] [numeric](18, 0) NOT NULL,
	[DVV] [decimal](18, 0) NULL,
 CONSTRAINT [PK_DigitoVerificadorVertical] PRIMARY KEY CLUSTERED 
(
	[Entity_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Peliculas]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Peliculas](
	[guid_pelicula] [uniqueidentifier] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idioma] [varchar](50) NOT NULL,
	[idioma_subtitulado] [varchar](50) NOT NULL,
	[activo] [binary](1) NOT NULL,
	[duracion] [int] NOT NULL,
 CONSTRAINT [PK_Peliculas] PRIMARY KEY CLUSTERED 
(
	[guid_pelicula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[id_permiso] [numeric](18, 0) NOT NULL,
	[codigo_permiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id_rol] [numeric](18, 0) NOT NULL,
	[nombre_rol] [varchar](50) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolesXPermisos]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesXPermisos](
	[id_rol] [numeric](18, 0) NOT NULL,
	[id_permiso] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_RolesXPermisos] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salas]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salas](
	[guid_sala] [uniqueidentifier] NOT NULL,
	[codigo_identificador] [varchar](10) NOT NULL,
	[es_pantalla_gigante] [binary](1) NOT NULL,
	[es_3D] [binary](1) NOT NULL,
	[activo] [binary](1) NOT NULL,
 CONSTRAINT [PK_Salas] PRIMARY KEY CLUSTERED 
(
	[guid_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesiones]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesiones](
	[guid_sesion] [uniqueidentifier] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[guid_pelicula] [uniqueidentifier] NOT NULL,
	[guid_sala] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Sesiones] PRIMARY KEY CLUSTERED 
(
	[guid_sesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[guid_ticket] [uniqueidentifier] NOT NULL,
	[fecha_creacion] [datetime] NOT NULL,
	[fila] [int] NOT NULL,
	[asiento] [int] NOT NULL,
	[guid_sesion] [uniqueidentifier] NOT NULL,
	[guid_usuario_creador] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Tickets_1] PRIMARY KEY CLUSTERED 
(
	[guid_ticket] ASC,
	[fila] ASC,
	[asiento] ASC,
	[guid_sesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[guid_usuario] [uniqueidentifier] NOT NULL,
	[nombredeusuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](max) NOT NULL,
	[emailprincipal] [varchar](50) NOT NULL,
	[habilitado] [varchar](50) NOT NULL,
	[DVH] [int] NOT NULL,
	[nombre_completo] [varchar](50) NOT NULL,
	[dni_usuario] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[guid_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosXRoles]    Script Date: 19/6/2022 03:04:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosXRoles](
	[guid_usuario] [uniqueidentifier] NOT NULL,
	[id_rol] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_UsuariosXRoles] PRIMARY KEY CLUSTERED 
(
	[guid_usuario] ASC,
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Peliculas] ADD  CONSTRAINT [DF_Peliculas_activo]  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[Salas] ADD  CONSTRAINT [DF_Salas_activo]  DEFAULT ((1)) FOR [activo]
GO
ALTER TABLE [dbo].[RolesXPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolesXPermisos_Permisos] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[Permisos] ([id_permiso])
GO
ALTER TABLE [dbo].[RolesXPermisos] CHECK CONSTRAINT [FK_RolesXPermisos_Permisos]
GO
ALTER TABLE [dbo].[RolesXPermisos]  WITH CHECK ADD  CONSTRAINT [FK_RolesXPermisos_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[RolesXPermisos] CHECK CONSTRAINT [FK_RolesXPermisos_Roles]
GO
ALTER TABLE [dbo].[Sesiones]  WITH CHECK ADD  CONSTRAINT [FK_Sesiones_Peliculas] FOREIGN KEY([guid_pelicula])
REFERENCES [dbo].[Peliculas] ([guid_pelicula])
GO
ALTER TABLE [dbo].[Sesiones] CHECK CONSTRAINT [FK_Sesiones_Peliculas]
GO
ALTER TABLE [dbo].[Sesiones]  WITH CHECK ADD  CONSTRAINT [FK_Sesiones_Salas] FOREIGN KEY([guid_sala])
REFERENCES [dbo].[Salas] ([guid_sala])
GO
ALTER TABLE [dbo].[Sesiones] CHECK CONSTRAINT [FK_Sesiones_Salas]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sesiones] FOREIGN KEY([guid_sesion])
REFERENCES [dbo].[Sesiones] ([guid_sesion])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Sesiones]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Usuario] FOREIGN KEY([guid_usuario_creador])
REFERENCES [dbo].[Usuario] ([guid_usuario])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Usuario]
GO
ALTER TABLE [dbo].[UsuariosXRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosXRoles_Roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Roles] ([id_rol])
GO
ALTER TABLE [dbo].[UsuariosXRoles] CHECK CONSTRAINT [FK_UsuariosXRoles_Roles]
GO
ALTER TABLE [dbo].[UsuariosXRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosXRoles_Usuario1] FOREIGN KEY([guid_usuario])
REFERENCES [dbo].[Usuario] ([guid_usuario])
GO
ALTER TABLE [dbo].[UsuariosXRoles] CHECK CONSTRAINT [FK_UsuariosXRoles_Usuario1]
GO
USE [master]
GO
ALTER DATABASE [CinemaDB] SET  READ_WRITE 
GO
