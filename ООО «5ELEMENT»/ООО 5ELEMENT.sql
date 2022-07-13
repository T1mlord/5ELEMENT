-- Удаление БД в случае ошибки или если что-то нужно исправить
drop database [ООО 5ELEMENT]
-- Создание БД
create database [ООО 5ELEMENT]
go
use [ООО 5ELEMENT]
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

-- Заполнение БД базовыми данными для теста

insert into Roles (RoleName, RoleLevelOfAccess) Values ('Администратор баз данных', 0)
insert into Roles (RoleName, RoleLevelOfAccess) Values ('Кладовщик', 1)

insert into TableStatus (TableStatusName) Values ('Авторизован')
insert into TableStatus (TableStatusName) Values ('Деавторизован')

insert into Users (UserFIO, UserBirthDate, UserPhone, UserPassport, UserRole, UserLogin, UserPassword) values ('Иванов Дмитрий Петрович', '05-06-2004', '+79174787041', '8018 666777', 1, '1', '1')
insert into Users (UserFIO, UserBirthDate, UserPhone, UserPassport, UserRole, UserLogin, UserPassword) values ('Корзухин Дмитрий Евгеньевич', '05-06-2003', '+79174789090', '8018 676767', 2, '2', '2')

insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1,'Одноместный стол у окна')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, 'Двухместный стол с диваном')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, 'Трёхместный стол у окна')
insert into [Tables] (TableStatus, TableEmployee, TableDescription) values (2, 1, 'Четырёхместный стол со стульями')

insert into DishType (DishTypeTitle) Values ('Салаты')
insert into DishType (DishTypeTitle) Values ('Пицца')
insert into DishType (DishTypeTitle) Values ('Супы')
insert into DishType (DishTypeTitle) Values ('Закуски')
insert into DishType (DishTypeTitle) Values ('Европейская кухня')
insert into DishType (DishTypeTitle) Values ('Напитки')


insert into Ingridients (IngridientName, IngridientQuantity) values ('Помидоры', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Салат "Айсберг"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Огурцы', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Оливки', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Соус тартар', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Масло оливковое', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Сыр "Фета"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Сухари', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('Сыр "Моцарелла"', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Тесто', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Пепперони', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Пицца-соус', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Грибы', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Креветки', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Кольца кальмара', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('Лук', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Наггетсы', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('Картофель', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Приправа "Хмели-сунели"', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('Баранина', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Курица', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Свинина', 100)

insert into Ingridients (IngridientName, IngridientQuantity) values ('Лайм', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Лимон', 100)
insert into Ingridients (IngridientName, IngridientQuantity) values ('Малина', 100)

go
-- Создание представлений
create view TablesView AS select TableID, TableStatusName AS [Status], TableDescription FROM [Tables] JOIN TableStatus ON TableStatus.TableStatusID = [Tables].TableStatus
go

create view UsersView AS select UserID, UserFIO, UserBirthDate, UserPhone, UserPassport, RoleName AS [Role], RoleLevelOfAccess AS [AccessLevel], UserLogin, UserPassword FROM Users JOIN Roles ON Roles.RoleID = Users.UserRole
go

create view DishesView AS select DishID, DishTypeTitle, DishName, DishCost, DishQuantity, DishDescription, DishImage FROM Dishes JOIN DishType ON Dishes.DishType = DishType.DishTypeID
go

create view DishTablePartViewWork AS select IngridientName AS [Название], DishTablePart.IngridientQuantity AS [Количество], Ingridients.IngridientID, DishID FROM DishTablePart JOIN Ingridients ON Ingridients.IngridientID = DishTablePart.IngridientID
go

create view OrderTablePartView AS select Orders.OrderID AS [№ заказа], DishName AS [Блюдо], DishCost AS [Стоимость (Руб.)], OrderDate AS [Дата заказа], OrderTablePart.DishQuantity AS [Количество (Шт.)] FROM OrderTablePart JOIN Orders ON Orders.OrderID = OrderTablePart.OrderID JOIN Dishes ON Dishes.DishID = OrderTablePart.DishID
go