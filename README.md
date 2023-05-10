# Inventory-System-API



This is an API project made in C# using Dapper, Swagger, and SQLServer. The project includes tables for users, items, and user items.

![image](https://user-images.githubusercontent.com/82846956/169732711-5a65f141-bd23-4e70-b45d-28d41a64461c.png)

## Tables

The project includes the following tables:

- Users: contains information about users such as name, login, email, birthdate, and password.
- Items: contains information about items such as item icon, value, damage, defense, and weight.
- UserItems: contains information about the items owned by each user.

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository:

```
git clone https://github.com/your-username/Inventory-System-API.git
```

2. Create a SQLServer database and run the tables script provided in the `README.md` file.

3. Update the `appsettings.json` file with your database connection string.

4. Build and run the project.

5. Navigate to `http://localhost:<port>/swagger` to view the Swagger UI and explore the API.

```sql
-- Tables script:
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
