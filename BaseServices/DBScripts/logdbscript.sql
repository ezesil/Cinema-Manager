USE [master]
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'dCk9D4MaGxMhFtdsii7oagsnxTPP6mHpdfn9RfmNrSg=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'WX5jg7Uy63P97XpSxfI0s34MewU+54ZWiH6IkbxuFYY=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/****** Object:  Login [DESKTOP-JJADIK1\eze_9]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [DESKTOP-JJADIK1\eze_9] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT Service\MSSQLSERVER]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT Service\MSSQLSERVER] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLSERVERAGENT]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT SERVICE\SQLSERVERAGENT] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLTELEMETRY]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT SERVICE\SQLTELEMETRY] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLWriter]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT SERVICE\SQLWriter] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\Winmgmt]    Script Date: 20/4/2022 14:38:36 ******/
CREATE LOGIN [NT SERVICE\Winmgmt] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [DESKTOP-JJADIK1\eze_9]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT Service\MSSQLSERVER]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLSERVERAGENT]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\SQLWriter]
GO
ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT SERVICE\Winmgmt]
GO
USE [LogDB]
GO
/****** Object:  Table [dbo].[ChangeLogs]    Script Date: 20/4/2022 14:38:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeLogs](
	[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[fecha_evento] [datetime] NOT NULL,
	[tipodecambio] [varchar](50) NOT NULL,
	[tabla] [varchar](50) NOT NULL,
	[sentencia] [varchar](max) NOT NULL,
 CONSTRAINT [PK_ChangeLogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 20/4/2022 14:38:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[id_log] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[log_message] [varchar](max) NOT NULL,
	[severity] [varchar](max) NOT NULL,
	[fecha_evento] [datetime] NULL,
	[traza] [varchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[id_log] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ChangeLogs] ON 

INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(N'2020-11-15T20:55:07.090' AS DateTime), N'UPDATE', N'[AnuncioDB].[Persona]', N'Valores anteriores: "88A1A8A5-B7EB-4323-9F9F-178E147D2735-Usuario-7HRt5ysHdmWXsnA97Oe3CdEXR279nLKZPyw5Ya+svdi/sNzb554cP/ukW3PUtduKMHUAAA==-correo@mail.com-True-1-8685')
INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(N'2020-11-15T20:57:48.020' AS DateTime), N'INSERT', N'[AnuncioDB].[Persona]', N'1990195C-0972-4C14-8F89-B638C9B431FA-Usuarionuevito-UvZIXIM+mRJ2tk5tL5bVKh16Iawk9mDMaT98eLaP+apQQS5QPQXashU6UZhnspeFMHUAAA==-correonuevito@mail.com-True-0-8773')
INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(N'2020-11-16T15:17:32.280' AS DateTime), N'INSERT', N'[AnuncioDB].[Persona]', N'392B0529-DE5E-4B82-82D0-FCAF73D2BB44-Usuario33-Gz/SVoPOBqJojcPbhhSp0hXm7EbiV/uLHkuPh9YE2lSxUzvu5tcUe7+hiAWMMBNKMHUAAA==-correo33@mail.com-True-0-8788-1')
INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(N'2020-11-16T15:19:02.323' AS DateTime), N'INSERT', N'[AnuncioDB].[Persona]', N'01AF338D-19F5-41CB-9193-B95347206C11-Usuariofacil-FVUZDkNYHwHbtvsgB4omrrQVvKHfGczp3mKNLEF/fvKkvTpPhuEj2I/FdYD/HRmfMHUAAA==-correofacil@mail.com-True-0-8727-1')
INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(N'2020-11-16T18:12:53.890' AS DateTime), N'INSERT', N'[AnuncioDB].[Persona]', N'D0EA8DE4-9A9D-490F-9F74-6C307FFBE9FA-admin-PHnNtXdArhrk1zgYOlx4gMWH3Iu6Sp/GSU8kkJDNnXR3gfuMQ57s2x5sjw4X/QSjMHUAAA==-ezesil96@gmail.com-True-0-8634-1')
INSERT [dbo].[ChangeLogs] ([id], [fecha_evento], [tipodecambio], [tabla], [sentencia]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(N'2020-11-16T18:16:02.780' AS DateTime), N'UPDATE', N'[AnuncioDB].[Persona]', N'Valores anteriores: "D0EA8DE4-9A9D-490F-9F74-6C307FFBE9FA-admin-PHnNtXdArhrk1zgYOlx4gMWH3Iu6Sp/GSU8kkJDNnXR3gfuMQ57s2x5sjw4X/QSjMHUAAA==-ezesil96@gmail.com-True-0-8634-1')
SET IDENTITY_INSERT [dbo].[ChangeLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10266 AS Numeric(18, 0)), N'Error de chqueo de integridad en el usuario: Usuario, por favor revise los datos.', N'High', CAST(N'2020-11-15T20:46:56.070' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10267 AS Numeric(18, 0)), N'Error de chequeo de integridad en la cuentas: Faltan datos.', N'Critical', CAST(N'2020-11-15T20:55:20.690' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10268 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-15T20:57:33.197' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10269 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-15T20:57:33.240' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10270 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T11:38:54.160' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10271 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T11:38:54.223' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10272 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:00.487' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10273 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:00.530' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10274 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:27.070' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10275 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:27.107' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10276 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:28.350' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10277 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:17:28.397' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10278 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:34.910' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10279 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:34.957' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10280 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:40.797' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10281 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:40.840' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10282 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:51.180' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10283 AS Numeric(18, 0)), N'Exception nula', N'Unknown', CAST(N'2020-11-16T15:18:51.227' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10284 AS Numeric(18, 0)), N'Error de conversión al convertir de una cadena de caracteres a uniqueidentifier.', N'Unknown', CAST(N'2020-11-16T17:16:22.173' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10286 AS Numeric(18, 0)), N'Error de conversión al convertir de una cadena de caracteres a uniqueidentifier.', N'Unknown', CAST(N'2020-11-16T17:17:59.477' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10290 AS Numeric(18, 0)), N'Desbordamiento de SqlDateTime. Debe estar entre 1/1/1753 12:00:00 AM y 12/31/9999 11:59:59 PM.', N'DataAccessError', CAST(N'2020-11-16T17:48:33.883' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10291 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:24:19.420' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10292 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:26:08.837' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10294 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:26:20.453' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10296 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:27:19.787' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10297 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:32:22.093' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10298 AS Numeric(18, 0)), N'   en UI.FrmPrincipal.Form1_Load(Object sender, EventArgs e) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Forms\FrmPrincipal.cs:línea 70', N'DebugInformation', CAST(N'2020-11-16T19:32:22.120' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10299 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:33:18.570' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10300 AS Numeric(18, 0)), N'   en UI.FrmPrincipal.Form1_Load(Object sender, EventArgs e) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Forms\FrmPrincipal.cs:línea 70', N'DebugInformation', CAST(N'2020-11-16T19:33:18.593' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10301 AS Numeric(18, 0)), N'Hubo un problema en el chequeo de permisos. Por favor contacte a un administrador.', N'Unknown', CAST(N'2020-11-16T19:34:07.953' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10302 AS Numeric(18, 0)), N'   en UI.FrmPrincipal.Form1_Load(Object sender, EventArgs e) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Forms\FrmPrincipal.cs:línea 70', N'DebugInformation', CAST(N'2020-11-16T19:34:07.983' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10303 AS Numeric(18, 0)), N'Referencia a objeto no establecida como instancia de un objeto.', N'Unknown', CAST(N'2020-11-16T20:43:41.333' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10304 AS Numeric(18, 0)), N'   en UI.FrmPrincipal.GrupoAdminPanel_Click(Object sender, EventArgs e) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Forms\FrmPrincipal.cs:línea 154
   en DevExpress.XtraBars.Navigation.AccordionControlElementBase.RaiseClick()
   en DevExpress.XtraBars.Navigation.AccordionControlElement.RaiseElementClick(MouseButtons mouseButton)
   en DevExpress.XtraBars.Navigation.AccordionElementBaseViewInfo.ProcessMouseClick(Boolean shouldSelectElement, MouseButtons mouseButton)
   en DevExpress.XtraBars.Navigation.AccordionControlHandler.OnMouseUp(MouseEventArgs e)
   en DevExpress.XtraBars.Navigation.AccordionControl.OnMouseUp(MouseEventArgs e)
   en System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   en System.Windows.Forms.Control.WndProc(Message& m)
   en DevExpress.Utils.Controls.ControlBase.WndProc(Message& m)
   en DevExpress.XtraBars.Navigation.AccordionControl.WndProc(Message& msg)
   en System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   en System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   en System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   en System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   en System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   en System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   en System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   en System.Windows.Forms.Application.RunDialog(Form form)
   en System.Windows.Forms.Form.ShowDialog(IWin32Window owner)
   en System.Windows.Forms.Form.ShowDialog()
   en UI.LoginFrm.BtnLogin_Click(Object sender, EventArgs e) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Forms\LoginFrm.cs:línea 125
   en System.Windows.Forms.Control.OnClick(EventArgs e)
   en DevExpress.XtraEditors.BaseButton.OnClick(EventArgs e)
   en DevExpress.XtraEditors.BaseButton.OnMouseUp(MouseEventArgs e)
   en System.Windows.Forms.Control.WmMouseUp(Message& m, MouseButtons button, Int32 clicks)
   en System.Windows.Forms.Control.WndProc(Message& m)
   en DevExpress.Utils.Controls.ControlBase.WndProc(Message& m)
   en DevExpress.XtraEditors.BaseControl.WndProc(Message& msg)
   en System.Windows.Forms.Control.ControlNativeWindow.OnMessage(Message& m)
   en System.Windows.Forms.Control.ControlNativeWindow.WndProc(Message& m)
   en System.Windows.Forms.NativeWindow.DebuggableCallback(IntPtr hWnd, Int32 msg, IntPtr wparam, IntPtr lparam)
   en System.Windows.Forms.UnsafeNativeMethods.DispatchMessageW(MSG& msg)
   en System.Windows.Forms.Application.ComponentManager.System.Windows.Forms.UnsafeNativeMethods.IMsoComponentManager.FPushMessageLoop(IntPtr dwComponentID, Int32 reason, Int32 pvLoopData)
   en System.Windows.Forms.Application.ThreadContext.RunMessageLoopInner(Int32 reason, ApplicationContext context)
   en System.Windows.Forms.Application.ThreadContext.RunMessageLoop(Int32 reason, ApplicationContext context)
   en System.Windows.Forms.Application.RunDialog(Form form)
   en System.Windows.Forms.Form.ShowDialog(IWin32Window owner)
   en System.Windows.Forms.Form.ShowDialog()
   en UI.Program.Main() en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\UI\Program.cs:línea 47', N'DebugInformation', CAST(N'2020-11-16T20:43:41.417' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10305 AS Numeric(18, 0)), N'Sintaxis incorrecta cerca de ''C:''.
Sintaxis incorrecta junto a la palabra clave ''with''. Si esta instrucción es una expresión de tabla común, una cláusula xmlnamespaces o una cláusula de contexto de seguimiento de cambios, la instrucción anterior debe terminarse con punto y coma.
Se están revirtiendo las transacciones no calificadas. Estimación de porcentaje de reversión: 0%.
Se están revirtiendo las transacciones no calificadas. Estimación de porcentaje de reversión: 100%.', N'Unknown', CAST(N'2020-11-17T16:31:29.027' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10306 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Restore(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 58', N'DebugInformation', CAST(N'2020-11-17T16:31:29.063' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10307 AS Numeric(18, 0)), N'Sintaxis incorrecta cerca de ''C:\Users\eze_9\Desktop\WeingandTesting\Backup_AnuncioDB_20201117.BAK''.
Sintaxis incorrecta junto a la palabra clave ''with''. Si esta instrucción es una expresión de tabla común, una cláusula xmlnamespaces o una cláusula de contexto de seguimiento de cambios, la instrucción anterior debe terminarse con punto y coma.', N'Unknown', CAST(N'2020-11-17T16:35:21.550' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10308 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Restore(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 58', N'DebugInformation', CAST(N'2020-11-17T16:35:21.570' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10309 AS Numeric(18, 0)), N'La función o el procedimiento BackupDB tiene demasiados argumentos.', N'Unknown', CAST(N'2020-11-17T17:16:41.657' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10310 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:16:41.717' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10311 AS Numeric(18, 0)), N'La función o el procedimiento BackupDB tiene demasiados argumentos.', N'Unknown', CAST(N'2020-11-17T17:27:11.287' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10312 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:27:11.340' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10313 AS Numeric(18, 0)), N'La función o el procedimiento BackupDB tiene demasiados argumentos.', N'Unknown', CAST(N'2020-11-17T17:27:22.710' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10314 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:27:22.737' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10315 AS Numeric(18, 0)), N'La función o el procedimiento BackupDB tiene demasiados argumentos.', N'Unknown', CAST(N'2020-11-17T17:27:28.250' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10316 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:27:28.277' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10317 AS Numeric(18, 0)), N'''REPLACE'' no es una opción BACKUP reconocida.', N'Unknown', CAST(N'2020-11-17T17:33:17.097' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10318 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:33:17.173' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10319 AS Numeric(18, 0)), N'La base de datos ''AnuncioDB'' ya está abierta y solo puede tener un usuario cada vez.
Fin anómalo de BACKUP DATABASE.', N'Unknown', CAST(N'2020-11-17T17:38:24.253' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10320 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:38:24.277' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10321 AS Numeric(18, 0)), N'La base de datos ''AnuncioDB'' ya está abierta y solo puede tener un usuario cada vez.
Fin anómalo de BACKUP DATABASE.', N'Unknown', CAST(N'2020-11-17T17:38:35.120' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10322 AS Numeric(18, 0)), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 37
   en BaseServices.DAL.Repository.Sql.BackupRestoreRepository.Backup(String name, String path) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Repository\Sql\BackupRestoreRepository.cs:línea 43', N'DebugInformation', CAST(N'2020-11-17T17:38:35.160' AS DateTime), NULL)
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10323 AS Numeric(18, 0)), N'Invalid column name "traza".', N'Unknown', CAST(N'2022-04-20T13:48:20.880' AS DateTime), N'   en System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   en System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   en System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   en System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   en System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   en System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   en System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   en BaseServices.DAL.Tools.SqlHelper.ExecuteNonQuery(String commandText, CommandType commandType, SqlParameter[] parameters) en C:\Users\eze_9\source\repos\PrototipoAnuncioV3\BaseServices\DAL\Tools\SqlHelper.cs:línea 57')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10324 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:14.093' AS DateTime), N'text_myprofile')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10325 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:18.853' AS DateTime), N'text_myprofile')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10326 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:20.030' AS DateTime), N'text_myprofile')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10327 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:21.067' AS DateTime), N'text_myprograms,
text_new,
text_update')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10328 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:26.273' AS DateTime), N'text_allowedit,
text_delete,
text_save,
text_cancel,
text_create')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10329 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:26.287' AS DateTime), N'program_minuteprice,
program_airdays,
program_endtime,
program_starttime')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10330 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:26.293' AS DateTime), N'text_targetgroup')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10331 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:26.303' AS DateTime), N'text_contenttype,
text_description,
text_image_upload')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10332 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:49:26.320' AS DateTime), N'text_monday,
text_tuesday,
text_wednesday,
text_thursday,
text_friday,
text_saturday,
text_sunday')
INSERT [dbo].[Log] ([id_log], [log_message], [severity], [fecha_evento], [traza]) VALUES (CAST(10333 AS Numeric(18, 0)), N'Fallos de traduccion encontrados. Lenguaje actual: es', N'Low', CAST(N'2022-04-20T13:52:58.210' AS DateTime), N'text_myprofile')
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
ALTER TABLE [dbo].[ChangeLogs] ADD  CONSTRAINT [DF_ChangeLogs_fecha_evento]  DEFAULT (getdate()) FOR [fecha_evento]
GO
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_fecha_evento]  DEFAULT (getdate()) FOR [fecha_evento]
GO
