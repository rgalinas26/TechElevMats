/*** Bonus subquery problems ***/
 
-- Find all of the cities which are not independent (not from an independent country)
-- Find the cities in the following countries
SELECT * 
	FROM city
	WHERE countrycode IN
	(SELECT code FROM country WHERE indepyear IS NULL) -- Find the countries which are not independent
ORDER BY countrycode


-- Find the average population of all countries
SELECT *
	FROM country
	WHERE population >
		(SELECT AVG(CAST(population AS bigint)) FROM country)  -- Find the average population of all countries

SELECT *
	FROM city
	WHERE population >
	(SELECT AVG(CAST(population AS bigint)) FROM city)  -- Find the average population of all cities



select * from city where countrycode in ('USA', 'CAN', 'CHN', 'DEU')
order by countrycode, name



select * from country where code = 'CAN'


/********* Explore the dvdstore database *****************/
select * from film

select * from actor

select * from film_actor




-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
select customer_id
	from payment
	where payment_id = 16666

-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
Select *
	from payment as p
	join customer as c on c.customer_id = p.customer_id
	where p.payment_id = 16666

-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:
Select p.*, c.first_name, c.last_name
	from payment as p
	join customer as c on c.customer_id = p.customer_id
	where p.payment_id = 16666

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
Select p.*, c.first_name, c.last_name, r.return_date
	from payment as p
	join customer as c on c.customer_id = p.customer_id
	join rental as r on p.rental_id = r.rental_id
	where p.payment_id = 16666

-- What did they rent? Film id can be gotten through inventory.
Select p.*, c.first_name, c.last_name, r.return_date, i.film_id, f.title, f.description
	from payment as p
	join customer as c on c.customer_id = p.customer_id
	join rental as r on p.rental_id = r.rental_id
	join inventory as i on r.inventory_id = i.inventory_id
	join film as f on i.film_id = f.film_id
	where p.payment_id = 16666

-- What if we wanted to know who acted in that film?
Select p.*, c.first_name, c.last_name, r.return_date, i.film_id, f.title, a.first_name, a.last_name
	from payment as p
	join customer as c on c.customer_id = p.customer_id
	join rental as r on p.rental_id = r.rental_id
	join inventory as i on r.inventory_id = i.inventory_id
	join film as f on i.film_id = f.film_id
	join film_actor as fa on f.film_id = fa.film_id
	join actor as a on a.actor_id = fa.actor_id
	where p.payment_id = 16666


-- What if we wanted a list of all the films and their categories ordered by film title
select f.title, c.name AS 'Genre'
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as c on fc.category_id = c.category_id
order by f.title

-- Show all the 'Comedy' films ordered by film title
select f.title, c.name AS 'Genre'
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as c on fc.category_id = c.category_id
where c.name = 'Comedy'
order by f.title


-- Finally, let's count the number of films under each category
Select c.name AS Genre, Count(*) as 'Number of films'
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as c on fc.category_id = c.category_id
group by c.name
order by 2 desc


-- ********* LEFT JOIN ***********

-- SWITCH to WORLD db for these

-- Show all countries and their capitals

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.

-- Only 232 rows
-- But we’re missing entries:
Select country.name as 'Country', city.name as 'Capital'
from country
	join city on country.capital = city.id

select count(*) from country

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

Select country.name as 'Country', city.name as 'Capital', *
from country
	LEFT OUTER join city on country.capital = city.id


-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
