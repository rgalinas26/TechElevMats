-- Switch to the system (aka master) database
USE master;
GO

-- Delete the UserDB Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='UserDB')
DROP DATABASE UserDB;
GO

-- Create a new UserDB Database
CREATE DATABASE UserDB;
GO

-- Switch to the UserDB Database
USE UserDB
GO

BEGIN TRANSACTION;

CREATE TABLE [user]
(
	id			int			identity(1,1),
	username	varchar(50)	not null,
	password	varchar(50)	not null,
	salt		varchar(50)	not null,
	role		varchar(50)	default('user'),

	constraint pk_users primary key (id)
);

Insert [user] (username, password, salt, role)
Values ('admin1@te.com', '0+tE26SG/P2A4F9iGH4CG1gx8ec=', 'GWieJBJgNvY=', 'Admin');

Insert [user] (username, password, salt, role)
Values ('user01@te.com', 'pqnS6B26+p1ii3A6QJPrm6n9GaM=', '3MWN6h0nnUY=', 'User');

COMMIT TRANSACTION;