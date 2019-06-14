-- INSERT

-- 1. Add Klingon as a spoken language in the USA
INSERT INTO countrylanguage
	(countrycode, language, isofficial, percentage)
	VALUES ('USA', 'Klingon', 1, 2.04)

Select * from countrylanguage WHERE countrycode = 'USA'

-- 2. Add Klingon as a spoken language in Great Britain
INSERT INTO countrylanguage
	(countrycode, language, isofficial, percentage)
	VALUES ((SELECT code FROM country WHERE name = 'United Kingdom'), 'Klingon', 0, 15.89)

Select * from countrylanguage WHERE countrycode = 'GBR'


-- UPDATE

-- 1. Update the capital of the USA to Houston

--SELECT id from city WHERE name = 'Houston'
--UPDATE country 
--	SET capital = 3796 	WHERE 
--	code = 'USA'
SELECT city.name
	FROM country AS c 
	JOIN city ON c.capital = city.id
	WHERE countrycode = 'USA'
	
UPDATE country 
	SET capital = (SELECT id from city WHERE name = 'Houston') 	WHERE 
	code = 'USA'


-- 2. Update the capital of the USA to Washington DC and the head of state
UPDATE country 
	SET capital = (SELECT id from city WHERE name = 'Washington'),
		headofstate = 'Donald'
	WHERE code = 'USA'

	select * from country where code = 'USA'


-- DELETE

-- 1. Delete English as a spoken language in the USA
	DELETE FROM countrylanguage WHERE countrycode = 'USA' AND language = 'English'


-- 2. Delete all occurrences of the Klingon language 
	DELETE FROM countrylanguage WHERE language = 'Klingon'


-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.
	INSERT INTO countrylanguage (language)
		VALUES ('Elvish')

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?
	INSERT INTO countrylanguage
		(countrycode, language, isofficial, percentage)
		VALUES ('ZZZ', 'English', 1, 65)


-- 3. Try deleting the country USA. What happens?
	DELETE FROM country WHERE code = 'USA'

-- Insert a city into Ohio

SELECT MAX(id) FROM city

INSERT INTO city
	(name, countrycode, district, population)
	VALUES ('Richfield', 'USA', 'Ohio', 8000)



-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
INSERT INTO countrylanguage
	(countrycode, language, isofficial, percentage)
	VALUES('USA', 'English', 1, 86)

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
UPDATE country
	SET continent = 'Outer Space'
WHERE code = 'USA'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRANSACTION
	SELECT * from countrylanguage
	DELETE FROM countrylanguage
	SELECT * from countrylanguage
ROLLBACK TRANSACTION

SELECT * FROM countrylanguage


-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.