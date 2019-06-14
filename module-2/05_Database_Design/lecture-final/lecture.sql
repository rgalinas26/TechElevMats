
-- Create a database to store our art purchase information
CREATE DATABASE Gallery
GO

-- Move to the Gallery database to start creating schema
USE Gallery
GO

-- Create the Piece table
--DROP TABLE Piece
CREATE TABLE Piece (
	Id		int		identity(1000, 10),
	Title	nvarchar(100) NOT NULL,
	CONSTRAINT pk_Piece PRIMARY KEY (Id)
)
GO

-- Create the Artist table
CREATE TABLE Artist (
	Id		int		identity(-1, -1),
	Name	nvarchar(100) NOT NULL,
	CONSTRAINT pk_Artist PRIMARY KEY (Id)
)
GO

-- Create the Customer table
Create Table Customer (
	Id		int		identity(1,1),
	Name	nvarchar(100) NOT NULL,
	Address	nvarchar(100),
	Phone	varchar(20),
	CONSTRAINT pk_Customer PRIMARY KEY (Id)
)
GO

-- Create the Purchase table
Create Table Purchase (
	Id			int identity(1,1),
	CustomerId	int NOT NULL,
	PieceId		int NOT NULL,
	PaymentDate	date NOT NULL,
	Price		money NOT NULL,
	Constraint pk_Purchase PRIMARY KEY (Id),
	Constraint fk_PurchaseCustomer FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
	Constraint fk_PurchasePiece FOREIGN KEY (PieceId) REFERENCES Piece(Id)
)
GO

-- Create the association table Artist-Piece
Create Table ArtistPiece (
	ArtistId	int,
	PieceId		int,
	Constraint pk_ArtistPiece PRIMARY KEY (ArtistId, PieceId),
	Constraint fk_ArtistPiece_Artist FOREIGN KEY (ArtistId) References Artist(Id),
	Constraint fk_ArtistPiece_Piece FOREIGN KEY (PieceId) References Piece(Id)
)
GO



-- An example of when we need to use an Alter Table. These two tables (from the world db) reference each other.
-- However, the first cannot reference the second before the second is created.  So we must:
--		Create the first table (country)
--		Create the second table (city). In this Create, we can add the fk reference to country, since it exists.
--		Alter the first table (country) to add a reference to city.
Create table Country (
	code	char(3),
	name	varchar(20),
	capitalid	int,
	Constraint pk_country PRIMARY KEY (code)
)
GO 
Create table City (
	id		int,
	name	varchar(20),
	countrycode	char(3),
	Constraint pk_city PRIMARY KEY (id),
	constraint fk_CityCountry foreign key (countrycode) references country(code)
)

ALTER TABLE Country ADD CONSTRAINT fk_CountryCapital Foreign KEY (capitalid) references city(id)



