-- ORDERING RESULTS

-- Populations of all countries in descending order
SELECT name, population
	FROM country
	ORDER BY population DESC


--Names of countries and continents in ascending order
SELECT continent, name
	FROM country
	ORDER BY continent , name 


-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 name, lifeexpectancy
	FROM country
	ORDER BY lifeexpectancy DESC

SELECT name, population, ROUND(population / surfacearea, 0) AS 'Density'
	FROM country
	--WHERE population / surfacearea > 10000
	ORDER BY Density DESC

SELECT name, LEN(name) AS 'Length of Name'
	FROM country
	ORDER BY LEN(name) DESC


SELECT name, ISNULL(indepyear, 0) AS indepyear
	FROM country


-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
SELECT name + ', ' + district AS 'city, state'
	FROM city
	WHERE district IN ('california', 'oregon', 'washington')
	ORDER BY district, name


-- AGGREGATE FUNCTIONS
-- Count of the number of cites in the table
SELECT COUNT(*)
	FROM city

-- Count of the number of cites in Ohio in the table
SELECT COUNT(*)
	FROM city
	WHERE district = 'ohio'

-- Average Life Expectancy in the World
SELECT AVG(lifeexpectancy) AS 'Average life expectancy'
	FROM country

SELECT ROUND(AVG(lifeexpectancy), 1) AS 'Average life expectancy'
	FROM country

-- Total population in Ohio
SELECT SUM(population) AS 'Ohio Total'
	FROM city
	WHERE district = 'ohio'


-- The surface area of the smallest country in the world
SELECT MIN(surfacearea), MAX(surfacearea), AVG(surfacearea)
	FROM country

-- The 10 largest countries in the world
SELECT TOP 10 name, surfacearea
	FROM country
	ORDER BY surfacearea DESC


-- The number of countries who declared independence in 1991
SELECT COUNT(*) 
	FROM country
	WHERE indepyear = 1991


-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
SELECT language, COUNT(*) AS 'NumberOfCountries'
	FROM countrylanguage
	GROUP BY language
	ORDER BY NumberOfCountries DESC

SELECT language, COUNT(*) AS 'NumberOfCountries'
	FROM countrylanguage
	GROUP BY language
	ORDER BY Count(*) DESC

SELECT language, COUNT(*) AS 'NumberOfCountries'
	FROM countrylanguage
	GROUP BY language
	ORDER BY 2 DESC



-- Average life expectancy of each continent ordered from highest to lowest
SELECT continent, AVG(lifeexpectancy) AS 'Average Life Expectancy'
	FROM country
	GROUP BY continent
	ORDER BY 2 DESC

-- Exclude Antarctica from consideration for average life expectancy
SELECT continent, AVG(lifeexpectancy) AS 'Average Life Expectancy'
	FROM country
--	WHERE continent != 'Antarctica'		-- this works
--	WHERE lifeexpectancy is not null	-- this also works
--	WHERE AVG(lifeexpectancy) is not null	-- But this does not work!!! (An aggregate may not appear in the WHERE clause)
	GROUP BY continent
	HAVING AVG(lifeexpectancy) is not null	-- this is how you can apply a "where" after the aggregation
	ORDER BY AVG(lifeexpectancy) DESC

-- Sum of the population of cities in each state in the USA ordered by state name
SELECT *
	FROM city
	WHERE countrycode = 'USA'
	ORDER BY district ASC


SELECT district AS 'State', SUM(population) AS 'Population'
	FROM city
	WHERE countrycode = 'USA'
	GROUP BY district
	ORDER BY district ASC

SELECT * 
	FROM country
	ORDER BY continent, region
	
SELECT continent, SUM(CAST(population AS bigint))
	FROM country
	GROUP BY continent
	ORDER BY continent --, region

SELECT continent, region, SUM(CAST(population AS bigint))
	FROM country
	GROUP BY continent, region
	ORDER BY continent, region --, region


	


-- The average population of cities in each state in the USA ordered by state name

-- SUBQUERIES
-- Find the names of cities under a given government leader

-- First do it manually
SELECT *
	FROM country
	WHERE headofstate like '%bush%'

select * from city

SELECT name, countrycode
	FROM city
	WHERE countrycode IN ('ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'USA', 'VIR')
	ORDER BY countrycode, name

-- Now do it using a sub-query
SELECT name, countrycode
	FROM city
	WHERE countrycode IN (SELECT code FROM country WHERE headofstate like '%bush%')
	ORDER BY countrycode, name


-- Find the names of cities whose country they belong to has not declared independence yet

Select name, countrycode
	FROM city
	Where countrycode IN (SELECT code from country where indepyear IS NULL)
	ORDER BY countrycode, name



-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
