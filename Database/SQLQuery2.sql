create database VPP
use VPP
CREATE TABLE [dbo].[tbKhachHang](
    [MaKH] [nchar](10) NOT NULL,
    [TenKH] [nvarchar](50) NOT NULL,
    [SDT] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tbKhachHang] PRIMARY KEY CLUSTERED ([MaKH])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbNhaCungCap](
    [MaNCC] [nchar](10) NOT NULL,
    [TenNCC] [nvarchar](50) NOT NULL,
    [SDT] [varchar](50) NOT NULL,
    [DiaChi] [nvarchar](50) NOT NULL,
    [MaSpCC] [varchar](max) NOT NULL,
    CONSTRAINT [PK_tbNhaCungCap] PRIMARY KEY CLUSTERED ([MaNCC])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

CREATE TABLE [dbo].[tbNhanSu](
    [MaNs] [nchar](10) NOT NULL,
    [Ten] [nvarchar](50) NOT NULL,
    [Tuoi] [int] NOT NULL,
    [SDT] [varchar](50) NOT NULL,
    [DiaChi] [nvarchar](50) NOT NULL,
    [NamSinh] [varchar](50) NOT NULL,
    [TenTaiKhoan] [varchar](50) NOT NULL,
    [MatKhau] [varchar](50) NOT NULL,
    [Quyen] [nchar](10) NOT NULL,
    CONSTRAINT [PK_tbNhanSu] PRIMARY KEY CLUSTERED ([MaNs])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbSanPham](
    [MaSp] [nchar](10) NOT NULL,
    [TenSp] [nvarchar](50) NOT NULL,
    [SoLuong] [int] NOT NULL,
    [DonGia] [float] NOT NULL,
    [LoaiSanPham] [nvarchar](50) NOT NULL,
    CONSTRAINT [PK_tbSanPham] PRIMARY KEY CLUSTERED ([MaSp])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbHoaDonBan](
    [MaHDB] [nchar](10) NOT NULL,
    [TongTien] [float] NOT NULL,
    [NgayBan] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tbHoaDonBan] PRIMARY KEY CLUSTERED ([MaHDB])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbHoaDonNhap](
    [MaHDN] [nchar](10) NOT NULL,
    [TongTien] [float] NOT NULL,
    [NgayNhap] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tbHoaDonNhap] PRIMARY KEY CLUSTERED ([MaHDN])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbChiTietHoaDonBan](
    [MaHDB] [nchar](10) NOT NULL,
    [MaNs] [nchar](10) NOT NULL,
    [MaKH] [nchar](10) NOT NULL,
    [MaSp] [nchar](10) NOT NULL,
    [TenSp] [nvarchar](50) NOT NULL,
    [SoLuong] [int] NOT NULL,
    [DonGia] [float] NOT NULL,
    [GiamGia] [float] NOT NULL,
    [NgayBan] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tbChiTietHoaDonBan] PRIMARY KEY CLUSTERED ([MaHDB], [MaSp]),
    CONSTRAINT [FK_tbChiTietHoaDonBan_tbHoaDonBan] FOREIGN KEY ([MaHDB]) REFERENCES [dbo].[tbHoaDonBan]([MaHDB]),
    CONSTRAINT [FK_tbChiTietHoaDonBan_tbNhanSu] FOREIGN KEY ([MaNs]) REFERENCES [dbo].[tbNhanSu]([MaNs]),
    CONSTRAINT [FK_tbChiTietHoaDonBan_tbKhachHang] FOREIGN KEY ([MaKH]) REFERENCES [dbo].[tbKhachHang]([MaKH]),
    CONSTRAINT [FK_tbChiTietHoaDonBan_tbSanPham] FOREIGN KEY ([MaSp]) REFERENCES [dbo].[tbSanPham]([MaSp])
) ON [PRIMARY];

CREATE TABLE [dbo].[tbChiTietHoaDonNhap](
    [MaHDN] [nchar](10) NOT NULL,
    [MaNCC] [nchar](10) NOT NULL,
    [MaNs] [nchar](10) NOT NULL,
    [MaSp] [nchar](10) NOT NULL,
    [TenSp] [nvarchar](50) NOT NULL,
    [SoLuong] [int] NOT NULL,
    [DonGia] [float] NOT NULL,
    [NgayNhap] [varchar](50) NOT NULL,
    CONSTRAINT [PK_tbChiTietHoaDonNhap] PRIMARY KEY CLUSTERED ([MaHDN], [MaSp]),
    CONSTRAINT [FK_tbChiTietHoaDonNhap_tbHoaDonNhap] FOREIGN KEY ([MaHDN]) REFERENCES [dbo].[tbHoaDonNhap]([MaHDN]),
    CONSTRAINT [FK_tbChiTietHoaDonNhap_tbNhaCungCap] FOREIGN KEY ([MaNCC]) REFERENCES [dbo].[tbNhaCungCap]([MaNCC]),
    CONSTRAINT [FK_tbChiTietHoaDonNhap_tbNhanSu] FOREIGN KEY ([MaNs]) REFERENCES [dbo].[tbNhanSu]([MaNs]),
    CONSTRAINT [FK_tbChiTietHoaDonNhap_tbSanPham] FOREIGN KEY ([MaSp]) REFERENCES [dbo].[tbSanPham]([MaSp])
) ON [PRIMARY];

INSERT INTO dbo.tbNhanSu 
VALUES 
(N'NS001', N'Nguyễn Tự Bắc', 22, N'0836075402', N'Hà Nội', N'2002', N'admin1', N'password123', N'admin'),
(N'NS002', N'Nguyễn Thế Huy', 21, N'0353018517', N'Bắc Giang', N'2003', N'staff1', N'password456', N'staff'),
(N'NS003', N'Đỗ Xuân Phước', 21, N'0835465855', N'Bắc Giang', N'2003', N'admin2', N'password789', N'admin');

INSERT INTO [dbo].[tbNhaCungCap] (
    [MaNCC], 
    [TenNCC], 
    [SDT], 
    [DiaChi], 
    [MaSpCC]
) VALUES 
(N'NCC001', N'Hảii Tiến', N'0123456789', N'Hà Nội', N'SP001, SP002'),
(N'NCC002', N'Hồng Hà', N'0987654321', N'TP. HCM', N'SP003, SP004'),
(N'NCC003', N'Sài Gòn', N'0112233445', N'Dà Nẵng', N'SP005, SP006');

INSERT INTO [dbo].[tbHoaDonNhap] (
    [MaHDN], 
    [TongTien], 
    [NgayNhap]
) VALUES 
(N'HDN001', 1500000.00, '2023-10-01'),
(N'HDN002', 2500000.00, '2023-10-05'),
(N'HDN003', 1800000.00, '2023-10-10'),
(N'HDN004', 3200000.00, '2023-10-15'),
(N'HDN005', 2100000.00, '2023-10-20');

INSERT INTO [dbo].[tbSanPham] (
    [MaSp], 
    [TenSp], 
    [SoLuong], 
    [DonGia], 
    [LoaiSanPham]
) VALUES 
(N'SP001', N'Bút bi', 100, 5000.00, N'1'),
(N'SP002', N'Bút chì', 150, 3000.00, N'1'),
(N'SP003', N'Bút máy', 80, 15000.00, N'1'),
(N'SP004', N'Bút dạ', 60, 20000.00, N'1'),
(N'SP005', N'Giấy in A4', 200, 2000.00, N'2'),
(N'SP006', N'Giấy note', 120, 5000.00, N'2'),
(N'SP007', N'Giấy vẽ', 90, 10000.00, N'2'),
(N'SP008', N'Sổ tay', 150, 15000.00, N'2'),
(N'SP009', N'Máy in', 10, 300000.00, N'3'),
(N'SP010', N'Máy photocopy', 5, 500000.00, N'3'),
(N'SP011', N'Kẹp giấy', 200, 1000.00, N'4'),
(N'SP012', N'Băng keo', 150, 2000.00, N'4'),
(N'SP013', N'Hộp đựng tài liệu', 80, 25000.00, N'5'),
(N'SP014', N'Thuộc kẻ', 100, 10000.00, N'7'),
(N'SP015', N'Ghế văn phòng', 20, 700000.00, N'9'),
(N'SP016', N'Mực viết', 200, 3000.00, N'6'),
(N'SP017', N'Bảng trắng', 30, 250000.00, N'6'),
(N'SP018', N'Kẹp tài liệu', 150, 1500.00, N'4'),
(N'SP019', N'Máy hủy tài liệu', 10, 1200000.00, N'3'),
(N'SP020', N'Đèn bàn', 50, 50000.00, N'7');

INSERT INTO [dbo].[tbChiTietHoaDonNhap] (
    [MaHDN], 
    [MaNCC], 
    [MaNs], 
    [MaSp], 
    [TenSp], 
    [SoLuong], 
    [DonGia], 
    [NgayNhap]
) VALUES 
(N'HDN001', N'NCC001', N'NS001', N'SP001', N'Bút bi', 100, 5000.00, N'2023-10-01'),
(N'HDN001', N'NCC001', N'NS001', N'SP002', N'Bút chì', 150, 3000.00, N'2023-10-01'),
(N'HDN002', N'NCC002', N'NS002', N'SP003', N'Giấy in A4', 200, 2000.00, N'2023-10-05'),
(N'HDN002', N'NCC002', N'NS002', N'SP004', N'Bút dạ', 60, 20000.00, N'2023-10-05'),
(N'HDN001', N'NCC001', N'NS001', N'SP005', N'Giấy note', 120, 5000.00, N'2023-10-01'),
(N'HDN002', N'NCC002', N'NS002', N'SP006', N'Máy in', 10, 300000.00, N'2023-10-05');



INSERT INTO [dbo].[tbChiTietHoaDonNhap] (
    [MaHDN], 
    [MaNCC], 
    [MaNs], 
    [MaSp], 
    [TenSp], 
    [SoLuong], 
    [DonGia], 
    [NgayNhap]
) VALUES 
(N'HDN003', N'NCC001', N'NS001', N'SP007', N'Giấy vẽ', 80, 10000.00, N'2023-10-10'),
(N'HDN003', N'NCC001', N'NS001', N'SP008', N'Sổ tay', 150, 15000.00, N'2023-10-10'),
(N'HDN003', N'NCC001', N'NS001', N'SP009', N'Máy photocopy', 5, 500000.00, N'2023-10-10'),
(N'HDN004', N'NCC002', N'NS002', N'SP010', N'Kẹp tài liệu', 200, 1500.00, N'2023-10-15'),
(N'HDN004', N'NCC002', N'NS002', N'SP011', N'Bảng Trắng', 30, 250000.00, N'2023-10-15'),
(N'HDN005', N'NCC001', N'NS001', N'SP012', N'Mực viết', 200, 3000.00, N'2023-10-20'),
(N'HDN005', N'NCC001', N'NS001', N'SP013', N'Hộp đựng tài liệu', 80, 25000.00, N'2023-10-20');

INSERT INTO [dbo].[tbKhachHang] (
    [MaKH], 
    [TenKH], 
    [SDT]
) VALUES 
(N'KH001', N'Đỗ Xuân Phước', N'031232423423'),
(N'KH002', N'Nguyễn Thế Huy', N'0312423434');