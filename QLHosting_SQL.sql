create table NguoiDung(
UserId bigint identity primary key,
MaNguoiDung varchar(20),
HoTen nvarchar(200),
NgaySinh date,
SoDT varchar(15),
DiaChi nvarchar(300),
Email varchar(50),
UserType nvarchar(10),
BoPhan nvarchar(100) --NV,KH
)
go

create table TaiKhoan(
UserId bigint primary key,
UserName varchar(20),
Password varchar(50) default '1111',
Quyen int default 0
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

create table Hiring(
ID bigint identity primary key,
CustomerId bigint,
HiringType nvarchar(50), -- web/domain/hosting
IDType bigint,
HiringDate datetime,
ExpireDate datetime,
Price bigint
)
go

create table HoaDon(
ID bigint identity primary key,
HiringId bigint,
InvoiceType nvarchar(50), //Host/Domain/Web
Price bigint
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



