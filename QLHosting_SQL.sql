create table NguoiDung(
UserId bigint identity primary key,
MaNguoiDung varchar(20),
HoTen nvarchar(200),
NgaySinh date,
GioiTinh nvarchar(10),
SoDT varchar(15),
DiaChi nvarchar(300),
Email varchar(50),
CMTND varchar(20),
TheATM varchar(20),
QuocTich nvarchar(100),
UserType nvarchar(10),
BoPhan nvarchar(100) --NV,KH
)
go

create table TaiKhoan(
UserId bigint primary key,
UserName varchar(20),
Password varchar(50) default '1111',
Quyen int default 0,
constraint b foreign key (UserId) references NguoiDung(UserId) 
)
go

create table Hosting(
ID bigint identity primary key,
HostAdress nvarchar(300),
HostType nvarchar(100),
Price bigint
)
go

create table Domain(
ID bigint identity primary key,
DomainName nvarchar(300),
DomainType nvarchar(100),
Price bigint
)
go

create table Website(
ID int identity primary key,
WebType nvarchar(100),
WebAdress nvarchar(300),
HostID bigint,
DomainID bigint,
Price bigint
)
go




create table DatVe(
IdVe bigint identity primary key,
MaVe varchar(20),
IdTour int,
UserId bigint,
SoNguoi int,
GiaVe decimal(22,6),
NgayDatVe date,
constraint i foreign key (UserId) references NguoiDung(UserId),
constraint e foreign key (IdTour) references Tour(IdTour) 
)
go

create table HoaDon(
IdHoaDon bigint identity primary key,
IdVe bigint,
UserIdKhachHang bigint,
UserIdNV bigint,
NgayThanhToan datetime,
TongTien decimal(22,6),
MaHD varchar(20),
constraint f foreign key (IdVe) references DatVe(IdVe), 
constraint g foreign key (UserIdKhachHang) references NguoiDung(UserId),
constraint h foreign key (UserIdNV) references NguoiDung(UserId)
)
go


--tao stored procedures
create proc USP_Login
@iduser varchar(20),
@password varchar(50)
as
begin 
	select * from dbo.taikhoan where UserName = @iduser and password = @password
end
go

--đổi mật khẩu
create proc USP_UpdateMatKhau @iduser char(10),@password char(10), @newpass char(10)
as
begin 
	update dbo.taikhoan set password = @newpass where UserName = @iduser and password = @password
end
go
 
exec USP_UpdateMatKhau @iduser = 'user1', @password ='user1',  @newpass = 'user'

insert into dbo.NguoiDung (MaNguoiDung,HoTen,NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM,QuocTich,UserType) values (N'chinh_nv',N'chinh_nv', '2020-02-02 00:00:00', N'Nữ', '35653574764', N'sd', 'chinh@gmail.com','24','24242','VN','NV' )
insert into dbo.NguoiDung (MaNguoiDung,HoTen,NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM,QuocTich,UserType) values (N'chinh_boss',N'chinh_boss', '2020-02-02 00:00:00', N'Nữ', '35653574764', N'sd', 'chinh@gmail.com','24','24242','VN','BOSS' )
				
insert into dbo.NguoiDung (MaNguoiDung,HoTen,NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM,QuocTich,UserType) values (N'chinh_nv2',N'chinh_nv2', '2020-02-02 00:00:00', N'Nữ', '35653574764', N'sd', 'chinh@gmail.com','24','24242','VN','NV' )
insert into dbo.NguoiDung (MaNguoiDung,HoTen,NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM,QuocTich,UserType) values (N'chinh_boss2',N'chinh_boss2', '2020-02-02 00:00:00', N'Nữ', '35653574764', N'sd', 'chinh@gmail.com','24','24242','VN','BOSS' )

insert into dbo.taikhoan ( UserId,UserName,password , quyen) values(1,'admin','1',2)
insert into dbo.taikhoan (UserId,UserName,password , quyen) values(2,'admin1','1',1)
insert into dbo.taikhoan (UserId,UserName,password , quyen) values(3,'chinh','1',0)
insert into dbo.taikhoan ( UserId,UserName,password , quyen) values(4,'minh','1',0)



