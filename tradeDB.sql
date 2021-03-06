USE [TradeDb]
GO
/****** Object:  Table [dbo].[DOITAC]    Script Date: 03/26/2020 02:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DOITAC](
	[MaDT] [int] IDENTITY(1,1) NOT NULL,
	[TenDT] [nvarchar](255) NOT NULL,
	[DiaChi] [nvarchar](255) NOT NULL,
	[NguoiDaiDien] [nvarchar](255) NOT NULL,
	[TaiKhoanNHNN] [nvarchar](255) NOT NULL,
	[TaiKhoanHNX] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_madt] PRIMARY KEY CLUSTERED 
(
	[MaDT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DOITAC] ON
INSERT [dbo].[DOITAC] ([MaDT], [TenDT], [DiaChi], [NguoiDaiDien], [TaiKhoanNHNN], [TaiKhoanHNX]) VALUES (6, N'ACB', N'HaNoi', N'Ph?m Anh Phuong', N'20125238phuongdeptrai', N'18021994phuongdeptrai')
SET IDENTITY_INSERT [dbo].[DOITAC] OFF
/****** Object:  Table [dbo].[TRAIPHIEU]    Script Date: 03/26/2020 02:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRAIPHIEU](
	[MaTP] [int] IDENTITY(1,1) NOT NULL,
	[TCPH] [nvarchar](255) NOT NULL,
	[NgayPH] [date] NOT NULL,
	[NgayDH] [date] NOT NULL,
	[LSCoupon] [float] NULL,
 CONSTRAINT [PK_matp] PRIMARY KEY CLUSTERED 
(
	[MaTP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TRAIPHIEU] ON
INSERT [dbo].[TRAIPHIEU] ([MaTP], [TCPH], [NgayPH], [NgayDH], [LSCoupon]) VALUES (1, N'SHB', CAST(0xE3400B00 AS Date), CAST(0xFD410B00 AS Date), 10)
SET IDENTITY_INSERT [dbo].[TRAIPHIEU] OFF
/****** Object:  Table [dbo].[GIAODICH]    Script Date: 03/26/2020 02:41:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAODICH](
	[MaDinhDanh] [int] IDENTITY(1,1) NOT NULL,
	[MaLK] [nvarchar](255) NOT NULL,
	[GiaCoSo] [money] NOT NULL,
	[GiaThucHien] [money] NOT NULL,
	[NgayGiaoDich] [date] NOT NULL,
	[LoaiGiaoDich] [nvarchar](255) NOT NULL,
	[MaDT] [int] NOT NULL,
	[MaTP] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[LoaiRepo] [int] NOT NULL,
 CONSTRAINT [PK_madinhdanh] PRIMARY KEY CLUSTERED 
(
	[MaDinhDanh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GIAODICH] ON
INSERT [dbo].[GIAODICH] ([MaDinhDanh], [MaLK], [GiaCoSo], [GiaThucHien], [NgayGiaoDich], [LoaiGiaoDich], [MaDT], [MaTP], [SoLuong], [LoaiRepo]) VALUES (5, N'0', 1000.0000, 30000.0000, CAST(0x5E3F0B00 AS Date), N'Buy', 6, 1, 30, 0)
SET IDENTITY_INSERT [dbo].[GIAODICH] OFF
/****** Object:  Default [DF__GIAODICH__LoaiRe__1920BF5C]    Script Date: 03/26/2020 02:41:23 ******/
ALTER TABLE [dbo].[GIAODICH] ADD  DEFAULT ((0)) FOR [LoaiRepo]
GO
/****** Object:  ForeignKey [FK_giaodichdt]    Script Date: 03/26/2020 02:41:23 ******/
ALTER TABLE [dbo].[GIAODICH]  WITH CHECK ADD  CONSTRAINT [FK_giaodichdt] FOREIGN KEY([MaDT])
REFERENCES [dbo].[DOITAC] ([MaDT])
GO
ALTER TABLE [dbo].[GIAODICH] CHECK CONSTRAINT [FK_giaodichdt]
GO
/****** Object:  ForeignKey [FK_giaodichtp]    Script Date: 03/26/2020 02:41:23 ******/
ALTER TABLE [dbo].[GIAODICH]  WITH CHECK ADD  CONSTRAINT [FK_giaodichtp] FOREIGN KEY([MaTP])
REFERENCES [dbo].[TRAIPHIEU] ([MaTP])
GO
ALTER TABLE [dbo].[GIAODICH] CHECK CONSTRAINT [FK_giaodichtp]
GO
