-- �������� �� � ������ ������ ��� ���� ���-�� ����� ���������
drop database [��� 5ELEMENT]
-- �������� ��
create database [��� 5ELEMENT]
go
use [��� 5ELEMENT]
go
create table TableStatus
(
TableStatusID int primary key identity,
TableStatusName nvarchar(max) not null
)
--drop table TableStatus

create table Roles
(
RoleID int primary key identity,
RoleName nvarchar(max) not null,
RoleLevelOfAccess int not null
)
--drop table Roles

create table Users
(
UserID int primary key identity,
UserFIO nvarchar(max) not null,
UserBirthDate date not null,
UserPhone nvarchar(max) not null,
UserPassport nvarchar(max) not null,
UserRole int references Roles(RoleID) not null,
UserLogin nvarchar(max) not null,
UserPassword nvarchar(max) not null
)
--drop table Users

create table [Tables]
(
TableID int primary key identity,
TableStatus int references TableStatus(TableStatusID) not null,
TableEmployee int references Users(UserID) not null,
TableDescription nvarchar(max) null
)
--drop table [Tables]

create table [Orders]
(
OrderID int primary key identity,
OrderTable int references [Tables](TableID) not null,
OrderDate date not null
)
--drop table [Orders]

create table Ingridients
(
IngridientID int primary key identity,
IngridientName nvarchar(max) not null,
IngridientQuantity int not null
)
--drop table Ingridients

create table DishType
(
[DishTypeID] int primary key identity,
[DishTypeTitle] nvarchar(max) not null
)
--drop table DishType

create table Dishes
(
DishID int primary key identity,
[DishType] int references [DishType] (DishTypeID) not null,
[DishName] nvarchar(max) not null,
DishCost int not null,
DishQuantity int not null,
DishDescription nvarchar(max) not null,
DishImage image
)
--drop table Dishes

create table [DishTablePart]
(
[DishTablePartEntryID] int primary key identity,
[DishID] int references Dishes([DishID]) not null,
[IngridientID] int references Ingridients([IngridientID]) not null,
IngridientQuantity int not null
)
--drop table [DishTablePart]

create table [OrderTablePart]
(
[OrderTablePartID] int primary key identity,
[DishID] int references Dishes([DishID]) not null,
[OrderID] int references [Orders]([OrderID]) not null,
DishQuantity int not null
)
--drop table [OrderTablePart]

-- ���������� �� �������� ������� ��� �����

insert into Roles (RoleName, RoleLevelOfAccess) Values ('������������� ��� ������', 0)
insert into Roles (RoleName, RoleLevelOfAccess) Values ('���������', 1)

insert into TableStatus (TableStatusName) Values ('�����������')
insert into TableStatus (TableStatusName) Values ('�������������')

insert into Users (UserFIO, UserBirthDate, UserPhone, UserPassport, UserRole, UserLogin, UserPassword) values ('������ ������� ��������', '05-06-2004', '+79174787041', '8018 666777', 1, '1', '1')
insert into Users (UserFIO, UserBirthDate, UserPhone, UserPassport, UserRole, UserLogin, UserPassword) values ('�������� ������� ����������', '05-06-2003', '+79174789090', '8018 676767', 2, '2', '2')

insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1,'����������� ���� � ����')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, '����������� ���� � �������')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, '���������� ���� � ����')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, '������������� ���� �� ��������')

insert into DishType (DishTypeTitle) Values ('������')
insert into DishType (DishTypeTitle) Values ('�����')
insert into DishType (DishTypeTitle) Values ('����')
insert into DishType (DishTypeTitle) Values ('�������')
insert into DishType (DishTypeTitle) Values ('����������� �����')
insert into DishType (DishTypeTitle) Values ('�������')


insert into Ingridients (IngridientName, IngridientQuantity) values ('��������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('����� "�������"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('���� ������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('����� ���������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('��� "����"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('��� "���������"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�����', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('���������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�����-����', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�����', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('��������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������ ��������', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('���', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('��������', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('���������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�������� "�����-������"', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('��������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�������', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('����', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('�����', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('������', 100)

go
-- �������� �������������
create view TablesView AS select TableID, TableStatusName AS [Status], TableDescription FROM [Tables] JOIN TableStatus ON TableStatus.TableStatusID = [Tables].TableStatus
go

create view UsersView AS select UserID, UserFIO, UserBirthDate, UserPhone, UserPassport, RoleName AS [Role], RoleLevelOfAccess AS [AccessLevel], UserLogin, UserPassword FROM Users JOIN Roles ON Roles.RoleID = Users.UserRole
go

create view DishesView AS select DishID, DishTypeTitle, DishName, DishCost, DishQuantity, DishDescription, DishImage FROM Dishes JOIN DishType ON Dishes.DishType = DishType.DishTypeID
go

create view DishTablePartViewWork AS select IngridientName AS [��������], DishTablePart.IngridientQuantity AS [����������], Ingridients.IngridientID, DishID FROM DishTablePart JOIN Ingridients ON Ingridients.IngridientID = DishTablePart.IngridientID
go

create view OrderTablePartView AS select Orders.OrderID AS [� ������], DishName AS [�����], DishCost AS [��������� (���.)], OrderDate AS [���� ������], OrderTablePart.DishQuantity AS [���������� (��.)] FROM OrderTablePart JOIN Orders ON Orders.OrderID = OrderTablePart.OrderID JOIN Dishes ON Dishes.DishID = OrderTablePart.DishID
go