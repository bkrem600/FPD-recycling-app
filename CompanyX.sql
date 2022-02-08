--
-- File generated with SQLiteStudio v3.2.1 on Wed Feb 2 17:57:44 2022
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: Categories
CREATE TABLE Categories (CategoryID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, CategoryName VARCHAR (30) NOT NULL);
INSERT INTO Categories (CategoryID, CategoryName) VALUES (1, 'LCD');
INSERT INTO Categories (CategoryID, CategoryName) VALUES (2, 'LCD (with DVD)');
INSERT INTO Categories (CategoryID, CategoryName) VALUES (3, 'LCD Monitor');
INSERT INTO Categories (CategoryID, CategoryName) VALUES (4, 'LED');
INSERT INTO Categories (CategoryID, CategoryName) VALUES (5, 'LED (with DVD)');
INSERT INTO Categories (CategoryID, CategoryName) VALUES (6, 'LED Monitor');

-- Table: FPDs
CREATE TABLE FPDs (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, CategoryID INTEGER REFERENCES Categories (CategoryID) NOT NULL, Size INTEGER, Make VARCHAR (50) NOT NULL, ModelCode VARCHAR (50) NOT NULL UNIQUE, Year INTEGER (10) CHECK (Year BETWEEN 2000 AND 2020), Origin VARCHAR (30), FrontCasingSorting VARCHAR (20) CHECK (FrontCasingSorting IN ('RECYCLE', 'POPs', 'POP&HAZ')), BackCasingSorting VARCHAR (20) CHECK (BackCasingSorting IN ('RECYCLE', 'POPs', 'POP&HAZ')));
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (1, 1, 26, 'Panasonic', 'TX-26LXD80
', 2008, 'Poland', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (2, 2, 19, 'HITACHI', 'L19DG07U B
', 2011, NULL, 'RECYCLE', 'POP&HAZ');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (3, 3, 19, 'HP', 'LA1905wg
', 2011, 'China', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (4, 4, 50, 'BUSH', '50/211F
', 2013, 'UK', 'RECYCLE', 'POP&HAZ');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (5, 4, 32, 'SAMSUNG', 'UE32F5000AKXXU
', 2013, 'Slovakia', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (6, 5, 32, 'JVC', 'LT-32C675(A)
', NULL, 'Turkey', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (7, 6, 27, 'ASUS', 'VS278Q
', 2014, 'China', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (8, 1, 23, 'TECHNIKA', 'X23/50E-BR-FTCDUP-UK', 2010, 'UK', 'RECYCLE', 'RECYCLE');
INSERT INTO FPDs (ID, CategoryID, Size, Make, ModelCode, Year, Origin, FrontCasingSorting, BackCasingSorting) VALUES (22, 3, NULL, 'TECHNIKA', 'TX-26LXD80', NULL, NULL, NULL, NULL);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
