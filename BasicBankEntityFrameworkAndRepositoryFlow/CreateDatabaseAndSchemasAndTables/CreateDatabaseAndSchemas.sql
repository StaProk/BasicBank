CREATE DATABASE BBDatabase;
GO

USE BBDatabase;
GO

CREATE SCHEMA BBAppSchema
GO

CREATE TABLE BBAppSchema.Users
(
    UserId INT IDENTITY(1, 1) PRIMARY KEY
    , FirstName NVARCHAR(50)
    , LastName NVARCHAR(50)
    , Email NVARCHAR(50)
);

CREATE TABLE BBAppSchema.Account
(
    UserId INT
    , MoneyStored DECIMAL(18, 4)
);

CREATE TABLE BBAppSchema.Loan
(
    UserId INT
    , MoneyOwed DECIMAL(18, 4)
);
