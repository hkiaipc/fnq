set quoted_identifier on 
GO

/****** 对象: 用户 dbo    脚本日期: 2012-11-06 10:19:24 ******/
/****** 对象: 用户 guest    脚本日期: 2012-11-06 10:19:24 ******/
if not exists (select * from dbo.sysusers where name = N'guest' and hasdbaccess = 1)
	EXEC sp_grantdbaccess N'guest'
GO

/****** 对象: 触发器 dbo.InsertGRLastData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertGRLastData]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[InsertGRLastData]
GO

/****** 对象: 触发器 dbo.InsertHeatLastData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertHeatLastData]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[InsertHeatLastData]
GO

/****** 对象: 触发器 dbo.InsertXD100eLastData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertXD100eLastData]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[InsertXD100eLastData]
GO

/****** 对象: 触发器 dbo.InsertOTData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertOTData]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
drop trigger [dbo].[InsertOTData]
GO

/****** 对象: 存储过程 dbo.AAA    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AAA]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AAA]
GO

/****** 对象: 存储过程 dbo.CalcHeat    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CalcHeat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CalcHeat]
GO

/****** 对象: 存储过程 dbo.GetDBInfo    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDBInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDBInfo]
GO

/****** 对象: 存储过程 dbo.StationCalcHeat    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[StationCalcHeat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[StationCalcHeat]
GO

/****** 对象: 视图 dbo.vGRDataLast    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vGRDataLast]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vGRDataLast]
GO

/****** 对象: 视图 dbo.vXd100eDataLast    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vXd100eDataLast]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vXd100eDataLast]
GO

/****** 对象: 视图 dbo.vGRAlarmData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vGRAlarmData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vGRAlarmData]
GO

/****** 对象: 视图 dbo.vGRData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vGRData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vGRData]
GO

/****** 对象: 视图 dbo.vHeatData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vHeatData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vHeatData]
GO

/****** 对象: 视图 dbo.vXd100eData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vXd100eData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vXd100eData]
GO

/****** 对象: 视图 dbo.vXGData    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vXGData]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vXGData]
GO

/****** 对象: 视图 dbo.vStationDevice    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vStationDevice]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vStationDevice]
GO

/****** 对象: 视图 dbo.vStationGRDevice    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vStationGRDevice]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vStationGRDevice]
GO

/****** 对象: 表 [dbo].[tblGRDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGRDataLast]
GO

/****** 对象: 表 [dbo].[tblHeatDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblHeatDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblHeatDataLast]
GO

/****** 对象: 表 [dbo].[tblXd100eDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXd100eDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblXd100eDataLast]
GO

/****** 对象: 表 [dbo].[tblFluxData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblFluxData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblFluxData]
GO

/****** 对象: 表 [dbo].[tblGRAlarmData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRAlarmData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGRAlarmData]
GO

/****** 对象: 表 [dbo].[tblGRData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblGRData]
GO

/****** 对象: 表 [dbo].[tblHeatData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblHeatData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblHeatData]
GO

/****** 对象: 表 [dbo].[tblOTDevice]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOTDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblOTDevice]
GO

/****** 对象: 表 [dbo].[tblXd100eData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXd100eData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblXd100eData]
GO

/****** 对象: 表 [dbo].[tblXGData]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXGData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblXGData]
GO

/****** 对象: 表 [dbo].[tblDevice]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDevice]
GO

/****** 对象: 表 [dbo].[tblCard]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblCard]
GO

/****** 对象: 表 [dbo].[tblConfig]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblConfig]
GO

/****** 对象: 表 [dbo].[tblDBInfo]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDBInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblDBInfo]
GO

/****** 对象: 表 [dbo].[tblOT]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblOT]
GO

/****** 对象: 表 [dbo].[tblStation]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblStation]
GO

/****** 对象: 表 [dbo].[tblUser]    脚本日期: 2012-11-06 10:19:25 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblUser]
GO

/****** 对象: 表 [dbo].[tblCard]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblCard]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblCard] (
	[CardID] [int] IDENTITY (1, 1) NOT NULL ,
	[Deleted] [bit] NULL ,
	[SN] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Person] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Remark] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	 PRIMARY KEY  CLUSTERED 
	(
		[CardID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblConfig]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblConfig]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblConfig] (
	[ConfigID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Enable] [bit] NULL CONSTRAINT [DF_tblConfig_Enable] DEFAULT (1),
	[Content] [nvarchar] (400) COLLATE Chinese_PRC_CI_AS NULL ,
	[Remark] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblDBInfo]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDBInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDBInfo] (
	[DBInfoID] [int] IDENTITY (1, 1) NOT NULL ,
	[Version] [int] NULL ,
	[Project] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DT] [datetime] NULL ,
	 PRIMARY KEY  CLUSTERED 
	(
		[DBInfoID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblOT]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOT]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblOT] (
	[OTID] [int] IDENTITY (1, 1) NOT NULL ,
	[DT] [datetime] NULL ,
	[OT] [real] NULL ,
	CONSTRAINT [PK_tblOT] PRIMARY KEY  CLUSTERED 
	(
		[OTID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblStation]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblStation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblStation] (
	[StationID] [int] IDENTITY (1, 1) NOT NULL ,
	[Street] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[StationOrdinal] [int] NOT NULL CONSTRAINT [DF_tblStation_Ordinal] DEFAULT (0),
	[StationName] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[StationRemark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[StationCPConfig] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK__tblStation__0D0FEE32] PRIMARY KEY  CLUSTERED 
	(
		[StationID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblUser]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblUser] (
	[UserID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Password] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Role] [smallint] NOT NULL CONSTRAINT [DF_tblUser_Role] DEFAULT (0),
	CONSTRAINT [PK_tblUser] PRIMARY KEY  CLUSTERED 
	(
		[UserID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblDevice]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblDevice] (
	[DeviceID] [int] IDENTITY (1, 1) NOT NULL ,
	[StationID] [int] NOT NULL ,
	[DeviceName] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceAddress] [int] NULL ,
	[DeviceType] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceRemark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceExtend] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK__tblDevice__019E3B86] PRIMARY KEY  CLUSTERED 
	(
		[DeviceID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FKD82D792477452016] FOREIGN KEY 
	(
		[StationID]
	) REFERENCES [dbo].[tblStation] (
		[StationID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblFluxData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblFluxData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblFluxData] (
	[FluxDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NOT NULL ,
	[DT] [datetime] NOT NULL ,
	[InstantFlux] [float] NOT NULL CONSTRAINT [DF_tblFluxData_InstantFlux] DEFAULT (0),
	[sum] [float] NOT NULL CONSTRAINT [DF_tblFluxData_Sum] DEFAULT (0),
	CONSTRAINT [PK_tblFluxData] PRIMARY KEY  CLUSTERED 
	(
		[FluxDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblFluxData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblGRAlarmData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRAlarmData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGRAlarmData] (
	[GRAlarmDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DT] [datetime] NULL ,
	[Content] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[Value] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	[DeviceID] [int] NULL ,
	 PRIMARY KEY  CLUSTERED 
	(
		[GRAlarmDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK682B2AEF2B9B4388] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblGRData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGRData] (
	[GRDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	[DT] [datetime] NULL ,
	[GT1] [real] NULL ,
	[BT1] [real] NULL ,
	[S1] [int] NULL ,
	[GT2] [real] NULL ,
	[BT2] [real] NULL ,
	[OT] [real] NULL ,
	[GTBase2] [real] NULL ,
	[GP1] [real] NULL ,
	[BP1] [real] NULL ,
	[WL] [real] NULL ,
	[GP2] [real] NULL ,
	[BP2] [real] NULL ,
	[I1] [real] NULL ,
	[S2] [int] NULL ,
	[I2] [real] NULL ,
	[IR] [real] NULL ,
	[SR] [int] NULL ,
	[OD] [int] NULL ,
	[PA2] [real] NULL ,
	[CM1] [bit] NULL ,
	[CM2] [bit] NULL ,
	[CM3] [bit] NULL ,
	[RM1] [bit] NULL ,
	[RM2] [bit] NULL ,
	CONSTRAINT [PK__tblGRData__075714DC] PRIMARY KEY  CLUSTERED 
	(
		[GRDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FKD98923C92B9B4388] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblHeatData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblHeatData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblHeatData] (
	[HeatDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NOT NULL ,
	[DT] [datetime] NOT NULL ,
	[InstantFlux] [float] NOT NULL ,
	[Sum] [float] NOT NULL ,
	[IH] [float] NOT NULL ,
	[SH] [float] NOT NULL ,
	CONSTRAINT [PK_tblHeatData] PRIMARY KEY  CLUSTERED 
	(
		[HeatDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblHeatData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblOTDevice]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOTDevice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblOTDevice] (
	[OTDeviceID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	CONSTRAINT [PK_tblOTDevice] PRIMARY KEY  CLUSTERED 
	(
		[OTDeviceID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblOTDevice_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblXd100eData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXd100eData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblXd100eData] (
	[XD100eDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NOT NULL ,
	[DT] [datetime] NOT NULL ,
	[AI1] [real] NOT NULL ,
	[AI2] [real] NOT NULL ,
	[AI3] [real] NOT NULL ,
	[AI4] [real] NOT NULL ,
	[AI5] [real] NOT NULL ,
	[AI6] [real] NOT NULL ,
	[AI7] [real] NOT NULL ,
	[AI8] [real] NOT NULL ,
	[DI1] [bit] NOT NULL ,
	[DI2] [bit] NOT NULL ,
	[DI3] [bit] NOT NULL ,
	[DI4] [bit] NOT NULL ,
	[DI5] [bit] NOT NULL ,
	[DI6] [bit] NOT NULL ,
	[DI7] [bit] NOT NULL ,
	[DI8] [bit] NOT NULL ,
	CONSTRAINT [PK_tblXd100eData] PRIMARY KEY  CLUSTERED 
	(
		[XD100eDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblXd100eData_tblDevice] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblXGData]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXGData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblXGData] (
	[XGDataID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeviceID] [int] NULL ,
	[CardID] [int] NULL ,
	[DT] [datetime] NULL ,
	[Person] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [PK__tblXGData__4316F928] PRIMARY KEY  CLUSTERED 
	(
		[XGDataID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FKE224229A80E6C1D5] FOREIGN KEY 
	(
		[DeviceID]
	) REFERENCES [dbo].[tblDevice] (
		[DeviceID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FKE224229AA2047D5B] FOREIGN KEY 
	(
		[CardID]
	) REFERENCES [dbo].[tblCard] (
		[CardID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblGRDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblGRDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblGRDataLast] (
	[GRDataID] [int] NOT NULL ,
	CONSTRAINT [FK_tblGRLastData_tblGRData] FOREIGN KEY 
	(
		[GRDataID]
	) REFERENCES [dbo].[tblGRData] (
		[GRDataID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblHeatDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblHeatDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblHeatDataLast] (
	[HeatDataLastID] [int] IDENTITY (1, 1) NOT NULL ,
	[HeatDataID] [int] NOT NULL ,
	CONSTRAINT [PK_tblHeatDataLast] PRIMARY KEY  CLUSTERED 
	(
		[HeatDataLastID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblHeatDataLast_tblHeatData] FOREIGN KEY 
	(
		[HeatDataID]
	) REFERENCES [dbo].[tblHeatData] (
		[HeatDataID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


/****** 对象: 表 [dbo].[tblXd100eDataLast]    脚本日期: 2012-11-06 10:19:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblXd100eDataLast]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblXd100eDataLast] (
	[XD100eDataID] [int] NOT NULL ,
	CONSTRAINT [FK_tblXd100eDataLast_tblXd100eData] FOREIGN KEY 
	(
		[XD100eDataID]
	) REFERENCES [dbo].[tblXd100eData] (
		[XD100eDataID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
) ON [PRIMARY]
END

GO


SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vStationGRDevice    脚本日期: 2012-11-06 10:19:26 ******/
CREATE VIEW dbo.vStationGRDevice
AS
SELECT dbo.vStationDevice.*
FROM dbo.vStationDevice
WHERE (DeviceType = 'xd1100device')

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vStationDevice    脚本日期: 2012-11-06 10:19:26 ******/
CREATE VIEW dbo.vStationDevice
AS
SELECT dbo.tblStation.StationID, dbo.tblStation.StationName, dbo.tblDevice.DeviceID, 
      dbo.tblDevice.DeviceName, dbo.tblDevice.DeviceAddress, dbo.tblDevice.DeviceType, 
      dbo.tblDevice.DeviceExtend
FROM dbo.tblStation INNER JOIN
      dbo.tblDevice ON dbo.tblStation.StationID = dbo.tblDevice.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vGRAlarmData    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  View dbo.vGRAlarmData    Script Date: 2012-09-05 15:35:36 *****
***** 对象: 视图 dbo.vGRAlarmData    脚本日期: 2011-8-22 16:35:19 ******/
CREATE VIEW dbo.vGRAlarmData
AS
SELECT dbo.tblGRAlarmData.GRAlarmDataID, dbo.tblStation.StationName AS StationName, 
      dbo.tblGRAlarmData.DT, dbo.tblGRAlarmData.Content, dbo.tblStation.Street
FROM dbo.tblGRAlarmData INNER JOIN
      dbo.tblDevice ON 
      dbo.tblGRAlarmData.DeviceID = dbo.tblDevice.DeviceID INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vGRData    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  View dbo.vGRData    Script Date: 2012-09-05 15:35:36 *****
***** 对象: 视图 dbo.vGRData    脚本日期: 2011-8-22 16:35:19 ******/
CREATE VIEW dbo.vGRData
AS
SELECT dbo.tblGRData.GRDataID, dbo.tblStation.Street, dbo.tblStation.StationOrdinal, 
      dbo.tblStation.StationName, dbo.tblDevice.DeviceName, dbo.tblGRData.DT, 
      dbo.tblGRData.GT1, dbo.tblGRData.BT1, dbo.tblGRData.GT2, dbo.tblGRData.BT2, 
      dbo.tblGRData.OT, dbo.tblGRData.GTBase2, dbo.tblGRData.GP1, dbo.tblGRData.BP1, 
      dbo.tblGRData.WL, dbo.tblGRData.GP2, dbo.tblGRData.BP2, dbo.tblGRData.I1, 
      dbo.tblGRData.IR, dbo.tblGRData.S1, dbo.tblGRData.SR, dbo.tblGRData.OD, 
      dbo.tblGRData.PA2, dbo.tblGRData.CM1, dbo.tblGRData.CM2, dbo.tblGRData.CM3, 
      dbo.tblGRData.RM1, dbo.tblGRData.RM2, dbo.tblGRData.S2, dbo.tblGRData.I2
FROM dbo.tblStation INNER JOIN
      dbo.tblDevice ON dbo.tblStation.StationID = dbo.tblDevice.StationID INNER JOIN
      dbo.tblGRData ON dbo.tblDevice.DeviceID = dbo.tblGRData.DeviceID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vHeatData    脚本日期: 2012-11-06 10:19:26 ******/
CREATE VIEW dbo.vHeatData
AS
SELECT dbo.tblStation.StationID, dbo.tblDevice.DeviceID, dbo.tblFluxData.FluxDataID, 
      dbo.tblHeatData.HeatDataID, dbo.tblStation.StationName, dbo.tblDevice.DeviceType, 
      dbo.tblDevice.DeviceExtend, dbo.tblFluxData.DT, dbo.tblFluxData.InstantFlux, 
      dbo.tblFluxData.[Sum], dbo.tblHeatData.IH, dbo.tblHeatData.SH
FROM dbo.tblHeatData INNER JOIN
      dbo.tblFluxData ON 
      dbo.tblHeatData.FluxDataID = dbo.tblFluxData.FluxDataID INNER JOIN
      dbo.tblStation INNER JOIN
      dbo.tblDevice ON dbo.tblStation.StationID = dbo.tblDevice.StationID ON 
      dbo.tblFluxData.DeviceID = dbo.tblDevice.DeviceID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vXd100eData    脚本日期: 2012-11-06 10:19:26 ******/
CREATE VIEW dbo.vXd100eData
AS
SELECT dbo.tblStation.StationID, dbo.tblStation.StationName, dbo.tblDevice.DeviceID, 
      dbo.tblDevice.DeviceName, dbo.tblDevice.DeviceExtend, dbo.tblDevice.DeviceType, 
      dbo.tblXd100eData.XD100eDataID, dbo.tblXd100eData.DT, dbo.tblXd100eData.AI1, 
      dbo.tblXd100eData.AI2, dbo.tblXd100eData.AI3, dbo.tblXd100eData.AI4, 
      dbo.tblXd100eData.AI5, dbo.tblXd100eData.AI6, dbo.tblXd100eData.AI7, 
      dbo.tblXd100eData.AI8, dbo.tblXd100eData.DI1, dbo.tblXd100eData.DI2, 
      dbo.tblXd100eData.DI3, dbo.tblXd100eData.DI4, dbo.tblXd100eData.DI5, 
      dbo.tblXd100eData.DI8, dbo.tblXd100eData.DI7, dbo.tblXd100eData.DI6
FROM dbo.tblXd100eData INNER JOIN
      dbo.tblDevice ON dbo.tblXd100eData.DeviceID = dbo.tblDevice.DeviceID INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vXGData    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  View dbo.vXGData    Script Date: 2012-09-05 15:35:36 *****
***** 对象: 视图 dbo.vXGData    脚本日期: 2011-8-22 16:35:19 *****
*/
CREATE VIEW dbo.vXGData
AS
SELECT dbo.tblXGData.XGDataID, dbo.tblStation.Street, dbo.tblStation.StationName, 
      dbo.tblXGData.DT, dbo.tblXGData.Person, dbo.tblCard.SN, 
      dbo.tblXGData.DeviceID
FROM dbo.tblCard INNER JOIN
      dbo.tblXGData ON dbo.tblCard.CardID = dbo.tblXGData.CardID INNER JOIN
      dbo.tblDevice ON dbo.tblXGData.DeviceID = dbo.tblDevice.DeviceID INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vGRDataLast    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  View dbo.vGRDataLast    Script Date: 2012-09-05 15:35:36 *****
***** 对象: 视图 dbo.vGRDataLast    脚本日期: 2011-8-22 16:35:19 ******/
CREATE VIEW dbo.vGRDataLast
AS
SELECT dbo.tblGRData.GRDataID, dbo.tblStation.Street, dbo.tblStation.StationName, 
      dbo.tblStation.StationOrdinal, dbo.tblGRData.DT, dbo.tblGRData.GT1, 
      dbo.tblGRData.BT1, dbo.tblGRData.GT2, dbo.tblGRData.BT2, dbo.tblGRData.OT, 
      dbo.tblGRData.GTBase2, dbo.tblGRData.GP1, dbo.tblGRData.BP1, dbo.tblGRData.WL, 
      dbo.tblGRData.GP2, dbo.tblGRData.BP2, dbo.tblGRData.I1, dbo.tblGRData.IR, 
      dbo.tblGRData.S1, dbo.tblGRData.SR, dbo.tblGRData.OD, dbo.tblGRData.PA2, 
      dbo.tblGRData.CM1, dbo.tblGRData.CM2, dbo.tblGRData.RM1, dbo.tblGRData.RM2, 
      dbo.tblGRData.DeviceID, dbo.tblGRData.S2, dbo.tblGRData.I2
FROM dbo.tblGRDataLast INNER JOIN
      dbo.tblGRData ON 
      dbo.tblGRDataLast.GRDataID = dbo.tblGRData.GRDataID INNER JOIN
      dbo.tblDevice ON dbo.tblGRData.DeviceID = dbo.tblDevice.DeviceID INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 视图 dbo.vXd100eDataLast    脚本日期: 2012-11-06 10:19:26 ******/
CREATE VIEW dbo.vXd100eDataLast
AS
SELECT dbo.tblStation.StationName, dbo.tblStation.StationID, dbo.tblDevice.DeviceID, 
      dbo.tblXd100eData.XD100eDataID, dbo.tblXd100eData.DT, dbo.tblXd100eData.AI1, 
      dbo.tblXd100eData.AI2, dbo.tblXd100eData.AI3, dbo.tblXd100eData.AI4, 
      dbo.tblXd100eData.AI5
FROM dbo.tblDevice INNER JOIN
      dbo.tblStation ON dbo.tblDevice.StationID = dbo.tblStation.StationID INNER JOIN
      dbo.tblXd100eData ON 
      dbo.tblDevice.DeviceID = dbo.tblXd100eData.DeviceID INNER JOIN
      dbo.tblXd100eDataLast ON 
      dbo.tblXd100eData.XD100eDataID = dbo.tblXd100eDataLast.XD100eDataID

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** 对象: 存储过程 dbo.AAA    脚本日期: 2012-11-06 10:19:26 ******/

/****** Object:  Stored Procedure dbo.AAA    Script Date: 2012-09-05 15:35:36 ******/

/****** 对象: 存储过程 dbo.AAA    脚本日期: 2011-03-03 17:29:54 ******/

CREATE PROCEDURE AAA 
	@displayname nvarchar(50),
	@beginDT datetime,
	@endDT datetime
AS
select
	street,
	DisplayName, 
	avg(gt1) as gt1,
	avg(bt1) as bt1, 
	avg(gt2) as gt2,
	avg(bt2) as bt2,
avg(gp1) as gp1,
avg(bp1) as bp1,
avg(gp2) as gp2,
avg(bp2) as bp2,
	min(s1) as s1begin, 
	max(s1) as s1end,
	min(dt) as dtbegin, 
	max(dt) as dtend ,
avg(supportArea) as supportArea,
avg(registeredArea) as registeredArea
	from vgrdatahelper 
	where displayname = @displayname and  (dt between @beginDT and @endDT) and (s1 > 0)
	group by street, DisplayName
	order by street, DisplayName


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/****** 对象: 存储过程 dbo.CalcHeat    脚本日期: 2012-11-06 10:19:26 ******/

/****** Object:  Stored Procedure dbo.CalcHeat    Script Date: 2012-09-05 15:35:36 ******/

/****** 对象: 存储过程 dbo.CalcHeat    脚本日期: 2011-8-22 16:35:19 ******/

CREATE PROCEDURE CalcHeat 
	@beginDT datetime,
	@endDT datetime
AS
select
	street,
	DisplayName, 
	avg(gt1) as gt1,
	avg(bt1) as bt1, 
	avg(gt2) as gt2,
	avg(bt2) as bt2,
avg(gp1) as gp1,
avg(bp1) as bp1,
avg(gp2) as gp2,
avg(bp2) as bp2,
	min(s1) as s1begin, 
	max(s1) as s1end,
	min(dt) as dtbegin, 
	max(dt) as dtend ,
	min(sr) as srbegin,
	max(sr) as srend,
avg(supportArea) as supportArea,
avg(registeredArea) as registeredArea
	from vgrdatahelper 
	where (dt between @beginDT and @endDT) and (s1 > 0)
	group by street, DisplayName
	order by street, DisplayName


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** 对象: 存储过程 dbo.GetDBInfo    脚本日期: 2012-11-06 10:19:26 ******/
CREATE PROCEDURE [GetDBInfo] AS

select 'fngrdb' as DBName, '1.0' as DBVersion
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/****** 对象: 存储过程 dbo.StationCalcHeat    脚本日期: 2012-11-06 10:19:26 ******/

/****** Object:  Stored Procedure dbo.StationCalcHeat    Script Date: 2012-09-05 15:35:36 ******/

/****** 对象: 存储过程 dbo.StationCalcHeat    脚本日期: 2011-8-22 16:35:19 ******/


CREATE PROCEDURE StationCalcHeat 
	@displayName nvarchar(50),
	@beginDT datetime,
	@endDT datetime
AS
select
	street,
	DisplayName, 
	avg(gt1) as gt1,
	avg(bt1) as bt1, 
	avg(gt2) as gt2,
	avg(bt2) as bt2,
avg(gp1) as gp1,
avg(bp1) as bp1,
avg(gp2) as gp2,
avg(bp2) as bp2,
	min(s1) as s1begin, 
	max(s1) as s1end,
	min(dt) as dtbegin, 
	max(dt) as dtend ,
	min(sr) as srbegin,
	max(sr) as srend,
avg(supportArea) as supportArea,
avg(registeredArea) as registeredArea
	from vgrdatahelper 
	where DisplayName = @displayName and (dt between @beginDT and @endDT) and (s1 > 0)
	group by street, DisplayName
	order by street, DisplayName


GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 触发器 dbo.InsertOTData    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  Trigger dbo.InsertOTData    Script Date: 2012-09-05 15:35:36 ******/
/****** 对象: 触发器 dbo.InsertOTData    脚本日期: 2011-8-22 16:35:19 ******/
/****** 对象: 触发器 dbo.InsertOTData    脚本日期: 2010-11-04 15:53:17 ******/
--
-- 添加室外温度数据到tblOT表中, 
-- 当使用某个供热控制器上室外温度测点作为标准室外温度时
--
CREATE TRIGGER [InsertOTData] ON dbo.tblGRData 
FOR INSERT
AS

declare @m_DT			datetime,
	@m_OT			real,
	@m_standardGRDeviceID	int,
	@m_DeviceID		int

select @m_DeviceID = DeviceID from inserted
select @m_standardGRDeviceID = DeviceID from tblOTDevice

if ( @m_DeviceID = @m_standardGRDeviceID )
BEGIN
	select @m_DT = DT, @m_OT = OT from inserted
	insert into tblOT(DT, OT) values(@m_DT, @m_OT)
END

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 触发器 dbo.InsertGRLastData    脚本日期: 2012-11-06 10:19:26 ******/
/****** Object:  Trigger dbo.InsertGRLastData    Script Date: 2012-09-05 15:35:36 ******/
/****** 对象: 触发器 dbo.InsertGRLastData    脚本日期: 2011-8-22 16:35:19 ******/
CREATE TRIGGER [InsertGRLastData] ON dbo.tblGRData 
FOR INSERT
-- , UPDATE, DELETE 
AS



declare @m_GRDataID 	int,
    	@m_DeviceID     int,
	@m_SameDeviceDataID	int
	
	  

select  top 1 	@m_GRDataID = GRDataID, 
		@m_DeviceID = DeviceID 
		from inserted

-- delete from tblGRDataLast where GRDataID in ( 
	--select GRDataID from v_grstlastrd where grstation_id = @m_grstation_id )
-- insert last gr real data id to tblGRDataLast


select grdataid, deviceid into #temp from tblGRData where GRDataID in (select grdataid from tblgrdatalast)
select @m_SameDeviceDataID = grdataid from #temp where deviceID = @m_deviceID

-- 删除该设备以有的数据
DELETE From tblGRDataLast WHERE GRDataID = @m_SameDeviceDataID


-- 插入 设备ID 和 供热数据ID
INSERT INTO tblGRDataLast(GRDataID) VALUES (@m_GRDataID)




GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 触发器 dbo.InsertHeatLastData    脚本日期: 2012-11-06 10:19:26 ******/
CREATE TRIGGER [InsertHeatLastData] ON dbo.tblHeatData 
FOR INSERT
AS

declare @m_HeatDataID 	int,
    	@m_DeviceID     int,
	@m_SameDeviceDataID	int
	--@m_fluxDataID	int
	
	  

select  top 1 	@m_HeatDataID = HeatDataID, 
		@m_DeviceID = DeviceID 
		--@m_fluxDataID = FluxDataID
		from inserted


select HeatDataID, deviceid into #temp from tblHeatData where HeatDataID in (select Heatdataid from tblHeatDataLast)
select @m_SameDeviceDataID = HeatDataid from #temp where deviceID = @m_deviceID

-- 删除该设备以有的数据
DELETE From tblHeatDataLast WHERE HeatDataID = @m_SameDeviceDataID


-- 插入
INSERT INTO tblHeatDataLast(HeatDataID) VALUES (@m_HeatDataID)

GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/****** 对象: 触发器 dbo.InsertXD100eLastData    脚本日期: 2012-11-06 10:19:26 ******/


CREATE TRIGGER [InsertXD100eLastData] ON dbo.tblxd100eData 
FOR INSERT
-- , UPDATE, DELETE 
AS



declare @m_Xd100eDataID 	int,
    	@m_DeviceID     int,
	@m_SameDeviceDataID	int
	
	  

select  top 1 	@m_XD100eDataID = xd100eDataID, 
		@m_DeviceID = DeviceID 
		from inserted

-- delete from tblGRDataLast where GRDataID in ( 
	--select GRDataID from v_grstlastrd where grstation_id = @m_grstation_id )
-- insert last gr real data id to tblGRDataLast


select xd100edataid, deviceid into #temp from tblxd100eData where xd100eDataID in (select xd100edataid from tblxd100edatalast)
select @m_SameDeviceDataID = xd100edataid from #temp where deviceID = @m_deviceID

-- 删除该设备以有的数据
DELETE From tblxd100eDataLast WHERE xd100eDataID = @m_SameDeviceDataID


-- 插入 设备ID 和 供热数据ID
INSERT INTO tblxd100eDataLast(xd100eDataID) VALUES (@m_Xd100eDataID)




GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

