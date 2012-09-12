set quoted_identifier on 
GO

/****** Object:  User dbo    Script Date: 2012-09-12 16:08:23 ******/
/****** Object:  Table [dbo].[tblMaintain]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintain]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMaintain]
GO

/****** Object:  Table [dbo].[tblReply]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblReply]
GO

/****** Object:  Table [dbo].[tblOperator]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOperator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblOperator]
GO

/****** Object:  Table [dbo].[tblIntroducer]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblIntroducer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblIntroducer]
GO

/****** Object:  Table [dbo].[tblMaintainLevel]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintainLevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMaintainLevel]
GO

/****** Object:  Table [dbo].[tblRight]    Script Date: 2012-09-12 16:08:24 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblRight]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblRight]
GO

/****** Object:  Table [dbo].[tblIntroducer]    Script Date: 2012-09-12 16:08:24 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblIntroducer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblIntroducer] (
	[it_id] [int] IDENTITY (1, 1) NOT NULL ,
	[it_name] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[it_address] [nvarchar] (400) COLLATE Chinese_PRC_CI_AS NULL ,
	[it_phone] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[it_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [tblIntroducer_PK] PRIMARY KEY  CLUSTERED 
	(
		[it_id]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblMaintainLevel]    Script Date: 2012-09-12 16:08:24 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintainLevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblMaintainLevel] (
	[ml_id] [int] IDENTITY (1, 1) NOT NULL ,
	[ml_name] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[ml_arrive_ll] [int] NULL ,
	[ml_arrive_hl] [int] NULL ,
	[ml_reply_hl] [int] NULL ,
	[ml_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[ml_number] [int] NULL ,
	CONSTRAINT [tblMaintainLevel_PK] PRIMARY KEY  CLUSTERED 
	(
		[ml_id]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblRight]    Script Date: 2012-09-12 16:08:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblRight]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblRight] (
	[rt_id] [int] IDENTITY (1, 1) NOT NULL ,
	[rt_value] [int] NOT NULL CONSTRAINT [DF_tblRight_rt_value] DEFAULT (0),
	CONSTRAINT [tblRight_PK] PRIMARY KEY  CLUSTERED 
	(
		[rt_id]
	)  ON [PRIMARY] 
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblOperator]    Script Date: 2012-09-12 16:08:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOperator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblOperator] (
	[op_id] [int] IDENTITY (1, 1) NOT NULL ,
	[op_name] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[rt_id] [int] NULL ,
	[op_pwd] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	CONSTRAINT [tblOperator_PK] PRIMARY KEY  CLUSTERED 
	(
		[op_id]
	)  ON [PRIMARY] ,
	CONSTRAINT [tblRight_tblOperator_FK1] FOREIGN KEY 
	(
		[rt_id]
	) REFERENCES [dbo].[tblRight] (
		[rt_id]
	)
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblReply]    Script Date: 2012-09-12 16:08:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblReply] (
	[rp_id] [int] IDENTITY (1, 1) NOT NULL ,
	[op_id] [int] NULL ,
	[rp_content] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[rp_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[rp_end_dt] [datetime] NULL ,
	[rp_worker] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
	[rp_receive_dt] [datetime] NULL ,
	CONSTRAINT [tblReply_PK] PRIMARY KEY  CLUSTERED 
	(
		[rp_id]
	)  ON [PRIMARY] ,
	CONSTRAINT [tblOperator_tblReply_FK1] FOREIGN KEY 
	(
		[op_id]
	) REFERENCES [dbo].[tblOperator] (
		[op_id]
	)
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblMaintain]    Script Date: 2012-09-12 16:08:25 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintain]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblMaintain] (
	[it_id] [int] NULL ,
	[mt_id] [int] IDENTITY (1, 1) NOT NULL ,
	[ml_id] [int] NOT NULL ,
	[rp_id] [int] NULL ,
	[op_id] [int] NOT NULL ,
	[mt_pose_dt] [datetime] NULL ,
	[mt_create_dt] [datetime] NOT NULL ,
	[mt_begin_dt] [datetime] NULL ,
	[mt_timeout_dt] [datetime] NULL ,
	[mt_status] [int] NOT NULL ,
	[mt_location] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_content] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_parent] [int] NULL ,
	[mt_fee_info] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_mark] [int] NULL ,
	CONSTRAINT [tblMaintain_PK] PRIMARY KEY  CLUSTERED 
	(
		[mt_id]
	)  ON [PRIMARY] ,
	CONSTRAINT [tblIntroducer_tblMaintain_FK1] FOREIGN KEY 
	(
		[it_id]
	) REFERENCES [dbo].[tblIntroducer] (
		[it_id]
	),
	CONSTRAINT [tblMaintain_tblMaintain_FK1] FOREIGN KEY 
	(
		[mt_parent]
	) REFERENCES [dbo].[tblMaintain] (
		[mt_id]
	),
	CONSTRAINT [tblMaintainLevel_tblMaintain_FK1] FOREIGN KEY 
	(
		[ml_id]
	) REFERENCES [dbo].[tblMaintainLevel] (
		[ml_id]
	),
	CONSTRAINT [tblOperator_tblMaintain_FK1] FOREIGN KEY 
	(
		[op_id]
	) REFERENCES [dbo].[tblOperator] (
		[op_id]
	),
	CONSTRAINT [tblReply_tblMaintain_FK1] FOREIGN KEY 
	(
		[rp_id]
	) REFERENCES [dbo].[tblReply] (
		[rp_id]
	)
) ON [PRIMARY]
END

GO


