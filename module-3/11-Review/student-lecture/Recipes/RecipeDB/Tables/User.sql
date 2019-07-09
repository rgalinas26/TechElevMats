CREATE TABLE [dbo].[User]
(
	Id			int	not null Primary Key identity(1,1),
	UserName	nvarchar(50)	not null,
	Password	nvarchar(50)	not null,
	Salt		varchar(50)	not null,
	Role		varchar(50)	default('user'),
)
