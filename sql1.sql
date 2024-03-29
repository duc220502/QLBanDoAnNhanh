USE [qlbandoan]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenban] [nvarchar](30) NOT NULL,
	[tinhtrang] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[idHoaDon] [int] NOT NULL,
	[idMonAn] [int] NOT NULL,
	[slban] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC,
	[idMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tencv] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[tendangnhap] [nvarchar](50) NOT NULL,
	[password] [nvarchar](30) NOT NULL,
	[iduser] [int] NOT NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[tendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ngayban] [date] NULL,
	[tongtien] [bigint] NULL,
	[trangthai] [nvarchar](30) NULL,
	[chietkhau] [int] NULL,
	[slkhach] [int] NULL,
	[idNv] [int] NOT NULL,
	[idBan] [int] NULL,
	[idKh] [int] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoten] [nvarchar](50) NOT NULL,
	[sdt] [nvarchar](10) NOT NULL,
	[diachi] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loaimonan]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loaimonan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Loaimonan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idLoaimonan] [int] NOT NULL,
	[tenmon] [nvarchar](100) NOT NULL,
	[gia] [bigint] NOT NULL,
	[soluong] [int] NOT NULL,
	[dvt] [nvarchar](20) NOT NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCv] [int] NOT NULL,
	[hoten] [nvarchar](50) NOT NULL,
	[ngaysinh] [date] NULL,
	[gioitinh] [bit] NULL,
	[quequan] [nvarchar](50) NULL,
	[sdt] [nvarchar](10) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDatBan]    Script Date: 29/12/2023 1:02:31 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDatBan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBan] [int] NULL,
	[tenkhach] [nvarchar](50) NOT NULL,
	[sdt] [nvarchar](10) NOT NULL,
	[thoigian] [datetime] NOT NULL,
	[ghichu] [nvarchar](100) NULL,
 CONSTRAINT [PK_PhieuDatBan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Ban] ON 

INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (1, N'Bàn 1', N'Có người')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (2, N'Bàn 2', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (3, N'Bàn 3', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (5, N'Bàn 4', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (8, N'Bàn 5', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (9, N'Bàn 6', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (10, N'Bàn 7', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (11, N'Bàn 8', N'Trống')
INSERT [dbo].[Ban] ([id], [tenban], [tinhtrang]) VALUES (12, N'Bàn 9', N'Trống')
SET IDENTITY_INSERT [dbo].[Ban] OFF
GO
INSERT [dbo].[ChiTietHoaDon] ([idHoaDon], [idMonAn], [slban]) VALUES (3, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([idHoaDon], [idMonAn], [slban]) VALUES (8, 7, 4)
INSERT [dbo].[ChiTietHoaDon] ([idHoaDon], [idMonAn], [slban]) VALUES (8, 9, 12)
INSERT [dbo].[ChiTietHoaDon] ([idHoaDon], [idMonAn], [slban]) VALUES (8, 11, 4)
INSERT [dbo].[ChiTietHoaDon] ([idHoaDon], [idMonAn], [slban]) VALUES (9, 9, 1)
GO
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([id], [tencv]) VALUES (1, N'NhanVien')
INSERT [dbo].[ChucVu] ([id], [tencv]) VALUES (2, N'QuanLi')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'duc220502', N'123456', 2)
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'hoa123', N'123456', 3)
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'tien123', N'123456', 7)
GO
SET IDENTITY_INSERT [dbo].[HoaDonBan] ON 

INSERT [dbo].[HoaDonBan] ([id], [ngayban], [tongtien], [trangthai], [chietkhau], [slkhach], [idNv], [idBan], [idKh]) VALUES (3, CAST(N'2002-11-11' AS Date), 30000, N'Đã thanh toán', NULL, 3, 2, 1, NULL)
INSERT [dbo].[HoaDonBan] ([id], [ngayban], [tongtien], [trangthai], [chietkhau], [slkhach], [idNv], [idBan], [idKh]) VALUES (8, CAST(N'2023-12-27' AS Date), 300000, N'Ðã thanh toán', 0, 2, 7, 8, NULL)
INSERT [dbo].[HoaDonBan] ([id], [ngayban], [tongtien], [trangthai], [chietkhau], [slkhach], [idNv], [idBan], [idKh]) VALUES (9, CAST(N'2023-12-27' AS Date), 10000, N'Đã thanh toán', 0, 1, 7, 2, NULL)
SET IDENTITY_INSERT [dbo].[HoaDonBan] OFF
GO
SET IDENTITY_INSERT [dbo].[Loaimonan] ON 

INSERT [dbo].[Loaimonan] ([id], [tenloai]) VALUES (1, N'Đồ ăn vặt')
INSERT [dbo].[Loaimonan] ([id], [tenloai]) VALUES (2, N'Bánh')
INSERT [dbo].[Loaimonan] ([id], [tenloai]) VALUES (3, N'Nước')
SET IDENTITY_INSERT [dbo].[Loaimonan] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (1, 1, N'Xúc xích rán', 10000, 1000, N'cái', N'ngon')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (6, 1, N'Nem chua rán', 6000, 1000, N'cái', N'ngon')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (7, 2, N'Bánh mì', 15000, 1000, N'cái', N'siêu ngon')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (8, 2, N'Bánh bao', 12000, 1000, N'cái', N'siêu ngon')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (9, 3, N'Trà chanh', 10000, 998, N'cốc', N'mát')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (10, 3, N'Trà đào', 10000, 1015, N'cốc', N'mát')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (11, 2, N'Bánh đồng xu', 30000, 1000, N'cái', N'không ngon')
INSERT [dbo].[Menu] ([id], [idLoaimonan], [tenmon], [gia], [soluong], [dvt], [ghichu]) VALUES (15, 3, N'Trà matcha', 35000, 1000, N'cốc', N'ngon')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (2, 1, N'Nguyễn Văn Đức', CAST(N'2002-05-22' AS Date), 1, N'Ninh Bình', N'0325353433', N'duc@gmail.com')
INSERT [dbo].[NhanVien] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (3, 2, N'Nguyễn Văn Hòa', CAST(N'2001-01-11' AS Date), 1, N'Ninh Bình', N'0372332434', N'hoa@gmail.com')
INSERT [dbo].[NhanVien] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (7, 1, N'Nguyễn Minh Tiến', CAST(N'2003-01-10' AS Date), 1, N'Hà Nội', N'0323948555', N'tien@gmail.com')
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[PhieuDatBan] ON 

INSERT [dbo].[PhieuDatBan] ([id], [idBan], [tenkhach], [sdt], [thoigian], [ghichu]) VALUES (1, 1, N'Đức', N'0325436436', CAST(N'2023-12-26T12:30:00.000' AS DateTime), N'không')
INSERT [dbo].[PhieuDatBan] ([id], [idBan], [tenkhach], [sdt], [thoigian], [ghichu]) VALUES (3, 5, N'Dương', N'0234738434', CAST(N'2023-12-27T14:30:00.000' AS DateTime), N'Không')
SET IDENTITY_INSERT [dbo].[PhieuDatBan] OFF
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDonBan] FOREIGN KEY([idHoaDon])
REFERENCES [dbo].[HoaDonBan] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDonBan]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Menu] FOREIGN KEY([idMonAn])
REFERENCES [dbo].[Menu] ([id])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Menu]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_User] FOREIGN KEY([iduser])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_User]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_Ban] FOREIGN KEY([idBan])
REFERENCES [dbo].[Ban] ([id])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_Ban]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_KhachHang] FOREIGN KEY([idKh])
REFERENCES [dbo].[KhachHang] ([id])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_User] FOREIGN KEY([idNv])
REFERENCES [dbo].[NhanVien] ([id])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_User]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Loaimonan] FOREIGN KEY([idLoaimonan])
REFERENCES [dbo].[Loaimonan] ([id])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Loaimonan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_User_ChucVu] FOREIGN KEY([idCv])
REFERENCES [dbo].[ChucVu] ([id])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_User_ChucVu]
GO
ALTER TABLE [dbo].[PhieuDatBan]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDatBan_Ban] FOREIGN KEY([idBan])
REFERENCES [dbo].[Ban] ([id])
GO
ALTER TABLE [dbo].[PhieuDatBan] CHECK CONSTRAINT [FK_PhieuDatBan_Ban]
GO
