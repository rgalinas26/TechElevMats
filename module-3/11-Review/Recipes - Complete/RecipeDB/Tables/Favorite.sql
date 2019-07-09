CREATE TABLE dbo.Favorite
(
    UserId int not null,
    RecipeId int not null,
    constraint PK_Favorite Primary Key (UserId, RecipeId),
    constraint FK_Favorite_User Foreign Key (UserId) references [User](Id), 
    CONSTRAINT [FK_Favorite_Recipe] FOREIGN KEY (RecipeId) REFERENCES Recipe(Id)
)
