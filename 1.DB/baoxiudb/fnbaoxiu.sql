set quoted_identifier on 
GO

/****** Object:  User dbo    Script Date: 2012-09-12 16:42:21 ******/
/****** Object:  Table [dbo].[tblFlow]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblFlow]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblFlow]
GO

/****** Object:  Table [dbo].[tblMaintain]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintain]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMaintain]
GO

/****** Object:  Table [dbo].[tblReceive]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReceive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblReceive]
GO

/****** Object:  Table [dbo].[tblReply]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblReply]
GO

/****** Object:  Table [dbo].[tblOperator]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblOperator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblOperator]
GO

/****** Object:  Table [dbo].[tblIntroducer]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblIntroducer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblIntroducer]
GO

/****** Object:  Table [dbo].[tblMaintainLevel]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintainLevel]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblMaintainLevel]
GO

/****** Object:  Table [dbo].[tblRight]    Script Date: 2012-09-12 16:42:21 ******/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblRight]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tblRight]
GO

/****** Object:  Table [dbo].[tblIntroducer]    Script Date: 2012-09-12 16:42:21 ******/
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
 CREATE  INDEX [_WA_Sys_it_address_0B91BA14] ON [dbo].[tblIntroducer]([it_address]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_it_name_0B91BA14] ON [dbo].[tblIntroducer]([it_name]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_it_phone_0B91BA14] ON [dbo].[tblIntroducer]([it_phone]) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblMaintainLevel]    Script Date: 2012-09-12 16:42:21 ******/
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
 CREATE  INDEX [_WA_Sys_ml_arrive_hl_08B54D69] ON [dbo].[tblMaintainLevel]([ml_arrive_hl]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_ml_arrive_ll_08B54D69] ON [dbo].[tblMaintainLevel]([ml_arrive_ll]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_ml_name_08B54D69] ON [dbo].[tblMaintainLevel]([ml_name]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_ml_number_08B54D69] ON [dbo].[tblMaintainLevel]([ml_number]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_ml_reply_hl_08B54D69] ON [dbo].[tblMaintainLevel]([ml_reply_hl]) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblRight]    Script Date: 2012-09-12 16:42:21 ******/
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


/****** Object:  Table [dbo].[tblOperator]    Script Date: 2012-09-12 16:42:21 ******/
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
 CREATE  INDEX [_WA_Sys_op_name_151B244E] ON [dbo].[tblOperator]([op_name]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_op_pwd_151B244E] ON [dbo].[tblOperator]([op_pwd]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_rt_id_151B244E] ON [dbo].[tblOperator]([rt_id]) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblMaintain]    Script Date: 2012-09-12 16:42:21 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblMaintain]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblMaintain] (
	[mt_id] [int] IDENTITY (1, 1) NOT NULL ,
	[it_id] [int] NOT NULL ,
	[ml_id] [int] NOT NULL ,
	[op_id] [int] NOT NULL ,
	[mt_pose_dt] [datetime] NOT NULL ,
	[mt_create_dt] [datetime] NOT NULL ,
	[mt_begin_dt] [datetime] NOT NULL ,
	[mt_timeout_dt] [datetime] NOT NULL ,
	[mt_location] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_content] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[mt_fee_info] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
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
	)
) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_it_id_282DF8C2] ON [dbo].[tblMaintain]([it_id]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_ml_id_282DF8C2] ON [dbo].[tblMaintain]([ml_id]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_mt_begin_dt_282DF8C2] ON [dbo].[tblMaintain]([mt_begin_dt]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_mt_create_dt_282DF8C2] ON [dbo].[tblMaintain]([mt_create_dt]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_mt_pose_dt_282DF8C2] ON [dbo].[tblMaintain]([mt_pose_dt]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_mt_timeout_dt_282DF8C2] ON [dbo].[tblMaintain]([mt_timeout_dt]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_op_id_282DF8C2] ON [dbo].[tblMaintain]([op_id]) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblReceive]    Script Date: 2012-09-12 16:42:21 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReceive]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblReceive] (
	[rc_id] [int] IDENTITY (1, 1) NOT NULL ,
	[rc_dt] [datetime] NOT NULL ,
	[op_id] [int] NOT NULL ,
	CONSTRAINT [PK_Table1] PRIMARY KEY  CLUSTERED 
	(
		[rc_id]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblReceive_tblOperator] FOREIGN KEY 
	(
		[op_id]
	) REFERENCES [dbo].[tblOperator] (
		[op_id]
	)
) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblReply]    Script Date: 2012-09-12 16:42:22 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblReply]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblReply] (
	[rp_id] [int] IDENTITY (1, 1) NOT NULL ,
	[op_id] [int] NULL ,
	[rp_content] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[rp_remark] [nvarchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[rp_end_dt] [datetime] NULL ,
	[rp_worker] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL ,
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
 CREATE  INDEX [_WA_Sys_op_id_19DFD96B] ON [dbo].[tblReply]([op_id]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_rp_end_dt_19DFD96B] ON [dbo].[tblReply]([rp_end_dt]) ON [PRIMARY]
 CREATE  INDEX [_WA_Sys_rp_worker_19DFD96B] ON [dbo].[tblReply]([rp_worker]) ON [PRIMARY]
END

GO


/****** Object:  Table [dbo].[tblFlow]    Script Date: 2012-09-12 16:42:22 ******/
if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tblFlow]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tblFlow] (
	[fl_id] [int] IDENTITY (1, 1) NOT NULL ,
	[fl_status] [int] NOT NULL CONSTRAINT [DF_tblFlow_fl_status] DEFAULT (10),
	[fl_parent] [int] NULL ,
	[mt_id] [int] NULL ,
	[rp_id] [int] NULL ,
	[rc_id] [int] NULL ,
	CONSTRAINT [PK_tblFlow] PRIMARY KEY  CLUSTERED 
	(
		[fl_id]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_tblFlow_tblFlow] FOREIGN KEY 
	(
		[fl_parent]
	) REFERENCES [dbo].[tblFlow] (
		[fl_id]
	),
	CONSTRAINT [FK_tblFlow_tblMaintain] FOREIGN KEY 
	(
		[mt_id]
	) REFERENCES [dbo].[tblMaintain] (
		[mt_id]
	),
	CONSTRAINT [FK_tblFlow_tblReceive] FOREIGN KEY 
	(
		[rc_id]
	) REFERENCES [dbo].[tblReceive] (
		[rc_id]
	),
	CONSTRAINT [FK_tblFlow_tblReply] FOREIGN KEY 
	(
		[rp_id]
	) REFERENCES [dbo].[tblReply] (
		[rp_id]
	)
) ON [PRIMARY]
END

GO


