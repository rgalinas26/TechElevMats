CREATE TABLE dbo.Ingredient
(
    Id INT NOT NULL PRIMARY KEY identity,
    RecipeId int not null,
    Name nvarchar(50) not null,
    Quantity decimal(8,1) not null default 1.0,
    Unit varchar(10) not null default '', 
    CONSTRAINT [FK_Ingredient_Recipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
)
