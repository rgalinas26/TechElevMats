-- This will be run inside a transaction scope during the tests.

-- IMPORTANT: If you run this in SSMS, you must un-comment the line below (and at the bottom) so you do not permanently remove data!!!
--BEGIN TRANSACTION

-- Delete all of the data
DELETE FROM countrylanguage;
UPDATE country SET capital = NULL;
DELETE FROM city;
DELETE FROM country;


-- Insert a few countries
INSERT INTO country (code, name, continent, region, surfacearea, indepyear, population, lifeexpectancy, gnp, gnpold, localname, governmentform, headofstate, capital, code2)
	VALUES 
	('USA', 'United States of America', 'North America', 'Region', 100, 1776, 280000000, null, null, null, 'United States of America', 'Government', 'Leader', null, 'US'),
	('UTO', 'Utopia', 'North America', 'Region', 100, null, 10000, null, null, null, 'Utopia', 'Government', 'Leader', null, 'UT'),
	('XAN', 'Xanadu', 'South America', 'Region', 100, null, 10000, null, null, null, 'Xanadu', 'Government', 'Leader', null, 'XA');

--Select * from country

-- Insert a city
INSERT INTO city (name, countrycode, district, population)
VALUES ('Smallville', 'USA', 'Iowa', 1);
-- Save of the city Id to make it a capital
DECLARE @smallvilleId int = (SELECT @@IDENTITY);

print Concat('Smallville was added, id was ', Cast( @smallvilleId AS varchar(5)))

-- Insert a few more cities
INSERT INTO city (name, countrycode, district, population)
VALUES 
	('Hooterville', 'USA', 'Indiana', 100),
	('Petticoat Junction', 'USA', 'Indiana', 12),
	('Utopiville', 'UTO', 'Province1', 1000),
	('Lower Xan', 'XAN', 'Province1', 1000);

-- Insert a fake country language
INSERT INTO countrylanguage VALUES 
	('USA', 'Test Language', 1, 100),
	('USA', 'English', 0, 50),
	('UTO', 'Utopian', 1, 100),
	('XAN', 'Xanadutian', 1, 100);

-- Assign the fake city to be the capital of the fake country
UPDATE country SET capital = @smallvilleId Where code = 'USA';

SELECT @smallvilleId As newCityId

--ROLLBACK TRAN