-- SELECT ... FROM
/*
This
is a 
block 
comment */
-- Selecting the names for all countries
SELECT name FROM country

-- Selecting the name and population of all countries
SELECT name, population FROM country

-- Selecting all columns from the city table
SELECT * from city

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
SELECT name, population 
	FROM city
	WHERE district = 'ohio'

-- Selecting countries that gained independence in the year 1776
SELECT name
	FROM country
	WHERE indepyear = 1776


-- Get a list of unique continent names
SELECT DISTINCT continent 
	FROM country

-- Selecting countries not in Asia
SELECT *
	FROM country
	WHERE continent != 'Asia'


-- Selecting countries that do not have an independence year
SELECT continent, name
	FROM country
	WHERE indepyear IS NULL



-- Selecting countries that do have an independence year
SELECT *
	FROM country
	WHERE indepyear IS NOT NULL


-- Selecting countries that have a population greater than 5 million
SELECT name, lifeexpectancy, population
	FROM country
	WHERE population > 5000000

-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
SELECT *
	FROM city
	WHERE district = 'ohio' AND population > 400000


-- Selecting country names on the continent North America or South America
SELECT name, continent
	FROM country
	WHERE continent = 'north america' OR continent = 'south america'

SELECT name, continent
	FROM country
	WHERE continent IN ('north america', 'south america')

SELECT name, continent
	FROM country
	WHERE continent LIKE '%america'


-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword
SELECT name, population AS 'Number of People', surfacearea, lifeexpectancy, population / surfacearea AS 'Density'
	FROM country


select TOP 1 name, continent from country
