create sequence test_sequence
minvalue 1
start with 1
increment by 1;

create table test (
     id integer primary key,
     description varchar(256),
     outcome varchar(256)
);

select * from test;
select * from products;

insert into products values (4011, 'Yellow Bananas', 2.99, 'KG', 242.16, 0);
insert into products values (8809069300708, 'Dole Bobby Bananas 850g', 3.29, 'EA', 72, 0);
insert into products values (4139, 'Granny Smith Apples', 3.59, 'KG', 92.42, 0);
insert into products values (4133, 'Royal Gala Apples', 3.49, 'KG', 164.19, 0);
insert into products values (4224, 'Hass Avocadoes', 2.19, 'EA', 70, 0);
insert into products values (4060, 'Broccoli', 1.99, 'EA', 95, 0);
insert into products values (4664, 'Tomatoes Truss', 3.99, 'KG', 61.94, 0);
insert into products values (4064, 'Tomatoes Loose', 3.99, 'KG', 70.13, 0);
insert into products values (9414582382408, 'Beekist Angel Tomatoes 200g', 3.19, 'EA', 0, 0);
insert into products values (3325, 'Fancy Lettuce', 2.69, 'EA', 50, 0);
insert into products values (4061, 'Iceberg Lettuce', 2.19, 'EA', 91, 0);
insert into products values (4650, 'Flat Mushrooms', 12.99, 'KG', 8.53, 0);
insert into products values (4645, 'White Button Avocadoes', 10.99, 'KG', 12.01, 0);
insert into products values (3279, 'Gold Kiwifruit', 4.99, 'KG', 0, 0);
insert into products values (9421017730048, 'Green Valley Milk Blue 2L', 3.39, 'EA', 79, 0);
insert into products values (9421017730062, 'Green Valley Milk Light 2L', 3.39, 'EA', 85, 0);
insert into products values (9414342140101, 'Anchor Pure Butter 500g', 5.19, 'EA', 56, 0);
insert into products values (9421017730062, 'Tararua Butter 500g', 5.29, 'EA', 0, 0);


