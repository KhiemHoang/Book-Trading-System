create database Book_controlling


/*===========================================================================================================================*/
drop table book;

create table book(
	book_id int not null identity(1,1) primary key,
	book_name varchar(255),
	book_author varchar(255),
	book_price int,
	create_by varchar(255),
	create_date date,
	update_by varchar(255),
	update_date date
);

select * from book;
insert into book values('Life of Pi', 'Yans Martell', 500000, 'Khiem', '2019-01-29', 'Khiem', '2019-01-29');
insert into book values('Les Miseraible', 'Victor Hugo', 800000, 'Khiem', '2019-02-15', 'Khiem', '2019-02-15');
insert into book values('Mat Biec', 'Nhat Anh Nguyen', 150000, 'Khiem', '2019-02-18', 'Khiem', '2019-02-18');
insert into book values('Nhat Ky Trong Tu', 'Ho Chi Minh', 250000, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into book values('The Rise and the Fallen of Third Reich', 'William L. Shirer', 400000, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into book values('I see yellow flowers on green grass', 'Nhat Anh Nguyen', 85000, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into book values('I am Beto', 'Nhat Anh Nguyen', 90000, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into book values('Harry Potter and the Philosopher Stone', 'J.K.Rowling', 300000, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');


/*===========================================================================================================================*/
drop table stock;

create table stock(
	stock_id int not null identity(1,1) primary key,
	book_id int foreign key references book(book_id),
	quantity int,
	create_by varchar(255),
	create_date date,
	update_by varchar(255),
	update_date date
)

select * from stock;
insert into stock values(1, 20, 'Khiem', '2019-01-29', 'Khiem', '2019-01-29');
insert into stock values(2, 20, 'Khiem', '2019-02-15', 'Khiem', '2019-02-15');
insert into stock values(3, 20, 'Khiem', '2019-02-18', 'Khiem', '2019-02-18');
insert into stock values(4, 20, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into stock values(5, 20, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into stock values(6, 20, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into stock values(7, 20, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');
insert into stock values(8, 20, 'Khiem', '2019-03-07', 'Khiem', '2019-03-07');


/*===========================================================================================================================*/
drop table customer;

create table customer(
	cus_id int not null identity(1,1) primary key,
	cus_username varchar(255),
	cus_pass varchar(255),
	cus_email varchar(255),
	cus_address varchar(255),
	ban_flag int,
	create_by varchar(255),
	create_date date,
	update_by varchar(255),
	update_date date
)

select * from customer;
insert into customer values('Teddy_Bear', '1', 'teddy_bear@gmail.com', '31 Saint.St USA', 0, 'Khiem', '2019-01-29', 'Khiem', '2019-01-29');
insert into customer values('Danny Rock', '1', 'danny_rock@gmail.com', '31 Saint.St USA', 0, 'Khiem', '2019-08-12', 'Khiem', '2019-08-12');


/*===========================================================================================================================*/
drop table staff;

create table staff(
	stf_id int not null identity(1,1) primary key,
	stf_username varchar(255),
	stf_pass varchar(255),
	stf_email varchar(255),
	admin_flag int,
	create_by varchar(255),
	create_date date,
	update_by varchar(255),
	update_date date
)

select * from staff;
insert into staff values('Khiem', '1', 'khiemhm120998@gmail.com', 1, 'Khiem', '2019-01-29', 'Khiem', getdate());
insert into staff values('Long', '1', 'endlessghostlove@gmail.com', 0, 'Khiem', '2019-01-29', 'Khiem', getdate());


/*===========================================================================================================================*/
drop table cart;

create table cart(
	cart_id int not null identity(1,1) primary key,
	cus_id int,
	cart_flag int,	
	cart_day date,
)

select * from cart;

/*===========================================================================================================================*/
/*Display which book customer choose (not buy yet)*/
drop table pick_temp;

create table pick_temp(
	cart_id int foreign key references cart(cart_id),
	book_id int,
	quantity int,
	total_price int,
	constraint PK_pick primary key(cart_id)
)

select * from pick_temp;

/*===========================================================================================================================*/
drop table purchase;

create table purchase(
	purchase_id int not null identity(1,1) primary key,
	cus_id int,
	purchase_date date,
	total_price int
)

select * from purchase;


/*===========================================================================================================================*/
drop table history;

create table history(
	purchase_id int foreign key references purchase(purchase_id),
	cus_id int,
	book_id int,
	quantity int,
	price int,
	constraint PK_hsitory primary key(purchase_id)
)

select * from history;

select h.book_id, b.book_name, h.quantity, h.price from history as h, book as b, purchase as p where h.book_id = b.book_id and h.purchase_id = p.purchase_id and p.purchase_id = 3

select h.book_id, b.book_name, h.quantity, h.price from history as h, book as b, purchase as p where h.book_id = b.book_id and h.purchase_id = p.purchase_id and p.purchase_id = 1;

---------------------------

---------------------------
select h.book_id, b.book_name, h.quantity, h.price, p.purchase_id from history as h, book as b, purchase as p where h.book_id = b.book_id and h.purchase_id = p.purchase_id and p.purchase_id = 1;

select * from history as h, book as b, purchase as p where h.purchase_id = p.purchase_id and h.book_id = b.book_id and p.purchase_id = 1
---------------------------
---------------------------

---------------------------
select * from V_Test as v, book as b where v.book_id = b.book_id
---------------------------
OK   
---------------------------
select * from purchase
---------------------------


select b.book_id as SKU1, b.book_name as Title1, sum(distinct h.quantity) as 'Total Purchase1', sum(distinct h.price) as 'Profit1'
from book as b
join history h on h.book_id = b.book_id
group by b.book_name, b.book_id

select b.book_id as SKU, b.book_name as Title, sum(distinct h.quantity + s.quantity) as 'Total', sum(distinct h.quantity) as 'Total Sale', s.quantity as 'Left'
from book as b
join stock s on s.book_id = b.book_id
join history h on h.book_id = b.book_id
group by b.book_name, b.book_id, s.quantity

select s.stf_id as ID, s.stf_username as 'User Name', s.admin_flag as 'Is Admin', s.create_date as 'Join Date'
from staff as s

select c.cus_id as ID, c.cus_username as 'User Name', c.ban_flag as 'Status', sum(distinct p.purchase_id) as 'Total Purchase'
from customer as c
join purchase as p on p.cus_id = c.cus_id
group by c.cus_id, c.cus_username, c.ban_flag