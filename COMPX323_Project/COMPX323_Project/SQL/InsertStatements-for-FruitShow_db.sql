drop sequence product_sequence;
commit;

create sequence product_sequence
minvalue 1
maxvalue 9999999999
start with 1
increment by 1;


--Insert Categories Statements for realistic data
insert into category values ('Apples', 'All varieties of Apples');
insert into category values ('Bananas', 'All varieties of Bananas');
insert into category values ('Berrys', 'All varieties of Berry Fruit from Kiwifruit to Strawberry');
insert into category values ('Stone Fruit', 'Season varieties (Nectarines, Plums and Peaches) to all year round (Avocadoes)');
insert into category values ('Tomatoes', 'All varieties of Tomatoes');
insert into category values ('Greens', 'All vegetables that are green leafed');
insert into category values ('Mushrooms', 'All varieties of Mushrooms');
insert into category values ('Dairy', 'Butter, Milk and Cheese Products');

-- Insert Product Statements for realistic data
insert into product values (product_sequence.NEXTVAL, 'Yellow Bananas', 2.99, 'KG', 242.16, 0, 'Bananas');
insert into product values (product_sequence.NEXTVAL, 'Dole Bobby Bananas 850g', 3.29, 'EA', 72, 0, 'Bananas');
insert into product values (product_sequence.NEXTVAL, 'Granny Smith Apples', 3.59, 'KG', 92.42, 0, 'Apples');
insert into product values (product_sequence.NEXTVAL, 'Royal Gala Apples', 3.49, 'KG', 164.19, 0, 'Apples');
insert into product values (product_sequence.NEXTVAL, 'Hass Avocadoes', 2.19, 'EA', 70, 0, 'Stone Fruit');
insert into product values (product_sequence.NEXTVAL, 'Broccoli', 1.99, 'EA', 95, 0, 'misc');
insert into product values (product_sequence.NEXTVAL, 'Tomatoes Truss', 3.99, 'KG', 61.94, 0, 'Tomatoes');
insert into product values (product_sequence.NEXTVAL, 'Tomatoes Loose', 3.99, 'KG', 70.13, 0, 'Tomatoes');
insert into product values (product_sequence.NEXTVAL, 'Beekist Angel Tomatoes 200g', 3.19, 'EA', 0, 0, 'Tomatoes');
insert into product values (product_sequence.NEXTVAL, 'Fancy Lettuce', 2.69, 'EA', 50, 0, 'Greens');
insert into product values (product_sequence.NEXTVAL, 'Iceberg Lettuce', 2.19, 'EA', 91, 0, 'Greens');
insert into product values (product_sequence.NEXTVAL, 'Flat Mushrooms', 12.99, 'KG', 8.53, 0, 'Mushrooms');
insert into product values (product_sequence.NEXTVAL, 'White Button Avocadoes', 10.99, 'KG', 12.01, 0, 'Stone Fruit');
insert into product values (product_sequence.NEXTVAL, 'Gold Kiwifruit', 4.99, 'KG', 0, 0, 'Berrys');
insert into product values (product_sequence.NEXTVAL, 'Green Valley Milk Blue 2L', 3.39, 'EA', 79, 0, 'Dairy');
insert into product values (product_sequence.NEXTVAL, 'Green Valley Milk Light 2L', 3.39, 'EA', 85, 0, 'Dairy');
insert into product values (product_sequence.NEXTVAL, 'Anchor Pure Butter 500g', 5.19, 'EA', 56, 0, 'Dairy');
insert into product values (product_sequence.NEXTVAL, 'Tararua Butter 500g', 5.29, 'EA', 0, 0, 'Dairy');

select distinct(weight_unit) from product;

select * from product;
