create table Cars 
(
Id int, BrandId int, ColorId int, ModelId int, 
ModelYear int,DailyPrice decimal, Descriptions varchar(255)
);

create table Brands
(
Id int, BrandName varchar(255)
);

create table Colors
(
Id int, ColorName varchar(255)
);