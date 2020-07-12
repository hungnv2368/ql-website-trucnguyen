create table KhachHang(
ID bigint identity primary key,
MaKH varchar(20),
HoTen nvarchar(200),
NgaySinh date,
SoDT varchar(15),
DiaChi nvarchar(300),
Email varchar(50)
)
go
create table NhanVien(
ID bigint identity primary key,
MaNV varchar(20),
HoTen nvarchar(200),
NgaySinh date,
SoDT varchar(15),
UserName varchar(20),
Password varchar(50) default '1111',
Quyen nvarchar(20)  --  Nhân viên,Quản lý
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
HiringType nvarchar(50),
IDType bigint,
HiringDate datetime,
ExpireDate datetime,
Price bigint
)
go

--tao stored procedures
create proc USP_Login
@iduser varchar(20),
@password varchar(50)
as
begin 
	select * from NhanVien where UserName = @iduser and Password = @password
end
go

insert into NhanVien (MaNV,HoTen,UserName,Password,Quyen) values('NV001',N'Truc Nguyen Admin','admin','1',N'Quản lý')
insert into NhanVien (MaNV,HoTen,UserName,Password,Quyen) values('NV002',N'Truc Nguyen User','user1','1',N'Nhân viên')



