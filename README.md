# Inventory-System-API---Dapper---Swagger---SQLServer

API Project made in C# using Dapper, Swagger and SQLServer

![image](https://user-images.githubusercontent.com/82846956/169732711-5a65f141-bd23-4e70-b45d-28d41a64461c.png)

Tables script:
```
CREATE TABLE Users
(
    userid int IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(120) NOT NULL,
    login NVARCHAR(120) NOT NULL,
    email NVARCHAR(180) NOT NULL,
    birthdate DATETIME NULL,
    password NVARCHAR(120) NOT NULL,
);
GO

CREATE TABLE Items
(
    itemId int IDENTITY(1, 1) PRIMARY KEY,
    itemIcon VARCHAR(500),
    value FLOAT NOT NULL,
    damage int NOT NULL,
    defense int NOT NULL,
    weigth FLOAT NOT NULL
);
GO

CREATE TABLE useritems
(
    invid int IDENTITY(1,1) PRIMARY KEY, 
    userid int,
    itemid int
);
GO
```
