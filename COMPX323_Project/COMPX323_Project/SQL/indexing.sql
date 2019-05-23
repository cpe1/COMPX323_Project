--To count how many products & categories are in system
--Count Queries

select count(*)
from category

select count(*)
from PRODUCT

--Actual Index DB Statements

--Creating an Index for Products (Serial Number & Name)
CREATE INDEX product_search
ON PRODUCT (serial_number, name);

CREATE INDEX category_search
ON CATEGORY (name, description);


-- Test Queries
select count(*)
from product
where name LIKE '%a%';

select count(*)
from product
where name LIKE '%and%';

select count(*)
from category
where description LIKE '%c%';

select count(*)
from category
where description LIKE '%love%';

--Dropping Index to test queries without indexing.

--Dropping an Index (Product Search)
DROP INDEX product_search;

--Dropping an Index (Category Search)
DROP INDEX category_search;
