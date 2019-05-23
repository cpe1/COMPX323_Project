--drop statement DO NOT DROP AABNY TLES
--drop table product;
--drop table category;
--drop sequence product_sequence;
--commit;

--sequence for product serial numbers
create sequence product_sequence
minvalue 1
maxvalue 9999999999
start with 1
increment by 1;
commit;

--tables
create table category
(
    name VARCHAR(50) not null primary key,
    description VARCHAR(255) not null
);
commit;
create table product
(
    serial_number NUMBER(10) not null primary key,
    name VARCHAR(256) not null,
    price NUMBER(5) not null,
    weight_unit VARCHAR(10) not null,
    stock NUMBER not null,
    discount NUMBER not null,
    category_name VARCHAR(50),
    foreign key(category_name) references category(name)    
);
commit;

--Get all products
select * from product;

--get all categories
select * from category;