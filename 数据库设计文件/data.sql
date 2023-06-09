USE [drug]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[customer](
	[uid] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[sex] [bit] NOT NULL,
	[telephone] [varchar](20) NOT NULL,
 CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[drug_info]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[drug_info](
	[drug_id] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[count] [int] NOT NULL,
	[type] [varchar](20) NOT NULL,
 CONSTRAINT [PK_drug_info] PRIMARY KEY CLUSTERED 
(
	[drug_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[employee]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[employee](
	[uid] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[sex] [bit] NOT NULL,
	[telephone] [varchar](20) NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[firm]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[firm](
	[no] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[phone] [varchar](20) NOT NULL,
	[address] [varchar](40) NOT NULL,
 CONSTRAINT [PK_firm] PRIMARY KEY CLUSTERED 
(
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[purchases]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[purchases](
	[id] [varchar](20) NOT NULL,
	[drug_id] [varchar](20) NOT NULL,
	[count] [int] NOT NULL,
	[price] [int] NOT NULL,
	[firm_id] [varchar](20) NOT NULL,
	[store_id] [varchar](20) NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_purchases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sell]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sell](
	[id] [varchar](20) NOT NULL,
	[drug_id] [varchar](20) NOT NULL,
	[count] [int] NOT NULL,
	[price] [int] NOT NULL,
	[customer] [varchar](20) NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_sell] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[store]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[store](
	[store_id] [varchar](20) NOT NULL,
	[name] [varchar](20) NOT NULL,
	[count] [int] NOT NULL,
 CONSTRAINT [PK_store_1] PRIMARY KEY CLUSTERED 
(
	[store_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[id] [varchar](20) NOT NULL,
	[pwd] [varchar](20) NOT NULL,
	[if_admin] [bit] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[customer] ([uid], [name], [sex], [telephone]) VALUES (N'1', N'2', 0, N'3')
INSERT [dbo].[customer] ([uid], [name], [sex], [telephone]) VALUES (N'2', N'cj', 0, N'110')
INSERT [dbo].[customer] ([uid], [name], [sex], [telephone]) VALUES (N'3', N'cj', 1, N'110')
INSERT [dbo].[customer] ([uid], [name], [sex], [telephone]) VALUES (N'4', N'ddx', 1, N'119')
INSERT [dbo].[drug_info] ([drug_id], [name], [count], [type]) VALUES (N'001', N'草酸艾司西酞普兰片', 20, N'抗抑郁药')
INSERT [dbo].[drug_info] ([drug_id], [name], [count], [type]) VALUES (N'002', N'1', 43, N'4')
INSERT [dbo].[drug_info] ([drug_id], [name], [count], [type]) VALUES (N'042', N'
罗红霉素胶囊', 125, N'抗生素类')
INSERT [dbo].[employee] ([uid], [name], [sex], [telephone]) VALUES (N'1', N'1', 0, N'1')
INSERT [dbo].[employee] ([uid], [name], [sex], [telephone]) VALUES (N'2', N'2', 0, N'1')
INSERT [dbo].[employee] ([uid], [name], [sex], [telephone]) VALUES (N'3', N'zyz', 1, N'110')
INSERT [dbo].[employee] ([uid], [name], [sex], [telephone]) VALUES (N'4', N'11123', 1, N'3213')
INSERT [dbo].[firm] ([no], [name], [phone], [address]) VALUES (N'10086', N'某供应商', N'18300000002', N'上海浦东')
INSERT [dbo].[firm] ([no], [name], [phone], [address]) VALUES (N'231', N'黄云', N'110', N'黄河边')
INSERT [dbo].[firm] ([no], [name], [phone], [address]) VALUES (N'289', N'星途', N'17299998888', N'浙江招商')
INSERT [dbo].[purchases] ([id], [drug_id], [count], [price], [firm_id], [store_id], [time]) VALUES (N'0001', N'001', 1, 2, N'231', N'101', CAST(N'1998-01-01 01:02:03.000' AS DateTime))
INSERT [dbo].[purchases] ([id], [drug_id], [count], [price], [firm_id], [store_id], [time]) VALUES (N'676', N'002', 234, 53, N'231', N'123123', CAST(N'2021-01-03 00:00:00.000' AS DateTime))
INSERT [dbo].[purchases] ([id], [drug_id], [count], [price], [firm_id], [store_id], [time]) VALUES (N'677', N'001', 13, 10, N'10086', N'123123', CAST(N'2021-01-03 00:20:12.000' AS DateTime))
INSERT [dbo].[purchases] ([id], [drug_id], [count], [price], [firm_id], [store_id], [time]) VALUES (N'678', N'002', 234, 53, N'231', N'123123', CAST(N'2021-01-03 00:20:12.000' AS DateTime))
INSERT [dbo].[store] ([store_id], [name], [count]) VALUES (N'101', N'beg', 1000)
INSERT [dbo].[store] ([store_id], [name], [count]) VALUES (N'123123', N'', 0)
INSERT [dbo].[store] ([store_id], [name], [count]) VALUES (N'301', N'新场库', 2902)
INSERT [dbo].[users] ([id], [pwd], [if_admin]) VALUES (N'1', N'1', 0)
INSERT [dbo].[users] ([id], [pwd], [if_admin]) VALUES (N'2', N'2', 0)
INSERT [dbo].[users] ([id], [pwd], [if_admin]) VALUES (N'admin', N'admin', 1)
ALTER TABLE [dbo].[purchases]  WITH CHECK ADD  CONSTRAINT [FK_purchases_drug_info] FOREIGN KEY([drug_id])
REFERENCES [dbo].[drug_info] ([drug_id])
GO
ALTER TABLE [dbo].[purchases] CHECK CONSTRAINT [FK_purchases_drug_info]
GO
ALTER TABLE [dbo].[purchases]  WITH CHECK ADD  CONSTRAINT [FK_purchases_firm] FOREIGN KEY([firm_id])
REFERENCES [dbo].[firm] ([no])
GO
ALTER TABLE [dbo].[purchases] CHECK CONSTRAINT [FK_purchases_firm]
GO
ALTER TABLE [dbo].[purchases]  WITH CHECK ADD  CONSTRAINT [FK_purchases_store] FOREIGN KEY([store_id])
REFERENCES [dbo].[store] ([store_id])
GO
ALTER TABLE [dbo].[purchases] CHECK CONSTRAINT [FK_purchases_store]
GO
ALTER TABLE [dbo].[sell]  WITH CHECK ADD  CONSTRAINT [FK_sell_customer] FOREIGN KEY([customer])
REFERENCES [dbo].[customer] ([uid])
GO
ALTER TABLE [dbo].[sell] CHECK CONSTRAINT [FK_sell_customer]
GO
ALTER TABLE [dbo].[sell]  WITH CHECK ADD  CONSTRAINT [FK_sell_drug_info] FOREIGN KEY([drug_id])
REFERENCES [dbo].[drug_info] ([drug_id])
GO
ALTER TABLE [dbo].[sell] CHECK CONSTRAINT [FK_sell_drug_info]
GO
/****** Object:  StoredProcedure [dbo].[GetCID]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetCID]
as 
select drug_id from drug_info 



GO
/****** Object:  StoredProcedure [dbo].[GetGID]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetGID]
as 
select no from firm

GO
/****** Object:  StoredProcedure [dbo].[GetHID]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetHID]
as 
select store_id from store

GO
/****** Object:  StoredProcedure [dbo].[GetTID]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetTID]
as 
select uid from customer

GO
/****** Object:  StoredProcedure [dbo].[GetUID]    Script Date: 2022/6/25 14:01:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GetUID]
as
select id from users
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=man, 1=woman' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'customer', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=man, 1=woman' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'employee', @level2type=N'COLUMN',@level2name=N'sex'
GO
