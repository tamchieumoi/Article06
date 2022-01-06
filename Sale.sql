create database sale
go
use sale
create table areas(
id int,
name nvarchar(255)
)
go
insert into areas values(1, 'Bac')
insert into areas values(2, 'Trung')
insert into areas values(3, 'Tay Nguyen')
insert into areas values(4, 'Nam')
insert into areas values(5, 'Dong Nam')

select * from areas

create table customer(
id int,
name nvarchar(255),
id_area int
)
go
insert into customer values(1, 'Nguyen Van A',5)
insert into customer values(2, 'Tran Van B',2)
insert into customer values(3, 'Nguyen Van C',1)
insert into customer values(4, 'Tran Van D',4)
insert into customer values(5, 'Nguyen Van E',3)
insert into customer values(6, 'Tran Van F',2)

select * from customer
Drop table customer
Drop table areas
drop database sale
