USE [qlbandoan]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenban] [nvarchar](30) NOT NULL,
	[tinhtrang] [nvarchar](30) NOT NULL,
	[idhoadon] [int] NOT NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[idHoaDon] [int] NOT NULL,
	[idMonAn] [int] NOT NULL,
	[slban] [int] NOT NULL,
	[chietkhau] [int] NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[idHoaDon] ASC,
	[idMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[idNguyenLieu] [int] IDENTITY(1,1) NOT NULL,
	[idPhieuNhap] [int] NOT NULL,
	[slnhap] [int] NOT NULL,
	[chietkhau] [int] NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[idNguyenLieu] ASC,
	[idPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 25/12/2023 2:22:43 CH ******/
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
/****** Object:  Table [dbo].[DangNhap]    Script Date: 25/12/2023 2:22:43 CH ******/
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
/****** Object:  Table [dbo].[HoaDonBan]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonBan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ngayban] [date] NOT NULL,
	[tongtien] [bigint] NOT NULL,
	[manv] [int] NOT NULL,
	[makh] [int] NULL,
 CONSTRAINT [PK_HoaDonBan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 25/12/2023 2:22:43 CH ******/
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
/****** Object:  Table [dbo].[Menu]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[id] [int] NOT NULL,
	[tenmon] [nvarchar](100) NOT NULL,
	[gia] [bigint] NOT NULL,
	[dvt] [nvarchar](20) NOT NULL,
	[ghichu] [nvarchar](max) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tennguyenlieu] [nvarchar](max) NOT NULL,
	[hsd] [date] NULL,
	[gia] [bigint] NOT NULL,
	[idNcc] [int] NULL,
	[dvt] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NguyenLieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenncc] [nvarchar](100) NOT NULL,
	[diachi] [nvarchar](150) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[sdt] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuDatBan]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuDatBan](
	[id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ngaynhap] [date] NOT NULL,
	[tongtien] [bigint] NULL,
	[idUser] [int] NOT NULL,
	[idNcc] [int] NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25/12/2023 2:22:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
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
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([id], [tencv]) VALUES (1, N'NhanVien')
INSERT [dbo].[ChucVu] ([id], [tencv]) VALUES (2, N'QuanLi')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
GO
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'duc220502', N'123456', 2)
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'hoa123', N'123456', 3)
INSERT [dbo].[DangNhap] ([tendangnhap], [password], [iduser]) VALUES (N'tien123', N'123456', 7)
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([id], [tenncc], [diachi], [email], [sdt]) VALUES (1, N'Anova Seafood Vietnam', N'Tòa nhà Vạn Phúc, 79 Lê Văn Lương, Quận Thanh Xuân, Hà Nội.', N'Anova@gmail.com', N'0323237843')
INSERT [dbo].[NhaCungCap] ([id], [tenncc], [diachi], [email], [sdt]) VALUES (4, N'Saigon Food JSC', N'645-647 Lê Hồng Phong, Phường 10, Quận 10, TP.Hồ Chí Minh', N'SaigonFood@gmail.com', N'0327487545')
INSERT [dbo].[NhaCungCap] ([id], [tenncc], [diachi], [email], [sdt]) VALUES (5, N'CJ Freshway Vietnam', N'Khu Công nghiệp Tân Thới Hiệp, Quận 12, TP.Hồ Chí Minh.', N'Freshway@gmail.com', N'0324675445')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (2, 1, N'Nguyễn Văn Đức', CAST(N'2002-05-22' AS Date), 1, N'Ninh Bình', N'0325353433', N'duc@gmail.com')
INSERT [dbo].[User] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (3, 2, N'Nguyễn Văn Hòa', CAST(N'2001-01-11' AS Date), 1, N'Ninh Bình', N'0372332434', N'hoa@gmail.com')
INSERT [dbo].[User] ([id], [idCv], [hoten], [ngaysinh], [gioitinh], [quequan], [sdt], [email]) VALUES (7, 1, N'Nguyễn Minh Tiến', CAST(N'2003-01-10' AS Date), 1, N'Hà Nội', N'0323948555', N'tien@gmail.com')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Ban]  WITH CHECK ADD  CONSTRAINT [FK_Ban_HoaDonBan] FOREIGN KEY([idhoadon])
REFERENCES [dbo].[HoaDonBan] ([id])
GO
ALTER TABLE [dbo].[Ban] CHECK CONSTRAINT [FK_Ban_HoaDonBan]
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
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_NguyenLieu] FOREIGN KEY([idNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([id])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_NguyenLieu]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap] FOREIGN KEY([idPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([id])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_PhieuNhap]
GO
ALTER TABLE [dbo].[DangNhap]  WITH CHECK ADD  CONSTRAINT [FK_DangNhap_User] FOREIGN KEY([iduser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[DangNhap] CHECK CONSTRAINT [FK_DangNhap_User]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_KhachHang] FOREIGN KEY([makh])
REFERENCES [dbo].[KhachHang] ([id])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonBan]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonBan_User] FOREIGN KEY([manv])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[HoaDonBan] CHECK CONSTRAINT [FK_HoaDonBan_User]
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD  CONSTRAINT [FK_NguyenLieu_NhaCungCap] FOREIGN KEY([idNcc])
REFERENCES [dbo].[NhaCungCap] ([id])
GO
ALTER TABLE [dbo].[NguyenLieu] CHECK CONSTRAINT [FK_NguyenLieu_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuDatBan]  WITH CHECK ADD  CONSTRAINT [FK_PhieuDatBan_Ban] FOREIGN KEY([idBan])
REFERENCES [dbo].[Ban] ([id])
GO
ALTER TABLE [dbo].[PhieuDatBan] CHECK CONSTRAINT [FK_PhieuDatBan_Ban]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCungCap] FOREIGN KEY([idNcc])
REFERENCES [dbo].[NhaCungCap] ([id])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_User] FOREIGN KEY([idUser])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_ChucVu] FOREIGN KEY([idCv])
REFERENCES [dbo].[ChucVu] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_ChucVu]
GO
