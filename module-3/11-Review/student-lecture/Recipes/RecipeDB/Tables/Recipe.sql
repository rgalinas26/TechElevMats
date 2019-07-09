CREATE TABLE dbo.Recipe
( 
    Id INT NOT NULL PRIMARY KEY Identity,
    Name nvarchar(50) not null,
    CreatedById int not null,
    Description nvarchar(max) null,
    Steps nvarchar(max) null,
    Meal varchar(20) null,
    Cuisine varchar(20) null,
    ImageFile varchar(100) null,
    PrepTime int null,
    CookTime int null,
    Serves int not null Default 1, 
    CONSTRAINT [FK_Recipe_User] FOREIGN KEY (CreatedById) REFERENCES [User](Id),
)
