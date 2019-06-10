-- The name and population of all cities in the USA with a population of greater than 1 million people
SELECT name, population
	FROM city
	WHERE countrycode = 'USA'
		AND population > 1000000


-- The name and population of all cities in China with a population of greater than 1 million people
SELECT code, code2, name FROM country WHERE name = 'China'


SELECT name, population
	FROM city
	WHERE countrycode = 'CHN'
		AND population > 1000000

-- The name and region of all countries in North or South America
SELECT name, region
	FROM country
	WHERE continent IN ('north america', 'south america')
  
-- The name, continent, and head of state of all countries whose form of government is a monarchy
SELECT name, continent, headofstate, governmentform
	FROM country
	WHERE governmentform like '%monarchy%'

SELECT * from country WHERE name = 'United Kingdom'


-- The name, country code, and population of all cities with a population less than one thousand people


-- The name and region of all countries in North or South America except for countries in the Caribbean
SELECT name, region
	FROM country
	WHERE continent IN ('north america', 'south america')
		AND region != 'Caribbean'

-- The name, population, and GNP of all countries with a GNP greater than $1 trillion dollars and a population of less than 1 billion people

-- The name and population of all cities in Texas that have a population of greater than 1 million people

-- The name and average life expectancy of all countries in southern regions
SELECT name, lifeexpectancy, region
	FROM country
	WHERE region LIKE '%south%'


-- The name and average life expectancy of all countries in southern regions for which an average life expectancy has been provided (i.e. not equal to null)
SELECT name, lifeexpectancy, region
	FROM country
	WHERE region LIKE '%south%'
	AND lifeexpectancy IS NOT NULL

-- The name, continent, GNP, and average life expectancy of all countries in Africa or Asia that have an average life expectancy of at least 70 years and a GNP between $1 million and $100 million dollars
SELECT name, continent, lifeexpectancy
	FROM country
	WHERE continent in ('africa', 'asia')
		AND lifeexpectancy >= 70
		AND gnp BETWEEN 1000000 AND 100000000

SELECT name, continent, lifeexpectancy
	FROM country
	WHERE continent in ('africa', 'asia')
		AND lifeexpectancy >= 70
		AND gnp >= 1000000 AND gnp <= 100000000

