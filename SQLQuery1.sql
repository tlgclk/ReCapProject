create table rentals(
Id int not null primary key,
carId int not null,
CustomerId int not null,
RentDate date,
ReturnDate date,
);

select * from users
alter table users
add primary key (id);

drop table rentals