/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [AutotinklasDB]
GO
SET IDENTITY_INSERT [dbo].[Padalinys] ON 

GO
INSERT [dbo].[Padalinys] ([id], [adresas], [miestas]) VALUES (1, N'A. Juozapavičiaus 18', N'Kaunas')
GO
INSERT [dbo].[Padalinys] ([id], [adresas], [miestas]) VALUES (2, N'Geležinkelio g. 52', N'Vilnius')
GO
INSERT [dbo].[Padalinys] ([id], [adresas], [miestas]) VALUES (3, N'Dubingių g. 24', N'Klaipėda')
GO
INSERT [dbo].[Padalinys] ([id], [adresas], [miestas]) VALUES (4, N'Saulės g. 21', N'Šiauliai')
GO
INSERT [dbo].[Padalinys] ([id], [adresas], [miestas]) VALUES (5, N'Random g.1 ', N'Vilnius')
GO
SET IDENTITY_INSERT [dbo].[Padalinys] OFF
GO
SET IDENTITY_INSERT [dbo].[Darbuotojas] ON 

GO
INSERT [dbo].[Darbuotojas] ([id], [pavarde], [vardas], [adresas], [telefonas], [fk_Padalinys]) VALUES (1, N'Radvilavičius', N'Tadas', N'A. Juozapavičiaus 21-34', N'863728870', 1)
GO
INSERT [dbo].[Darbuotojas] ([id], [pavarde], [vardas], [adresas], [telefonas], [fk_Padalinys]) VALUES (2, N'Jonaitis', N'Jonas', N'Žemgurių g. 17', N'+37063728870', 2)
GO
SET IDENTITY_INSERT [dbo].[Darbuotojas] OFF
GO
SET IDENTITY_INSERT [dbo].[Marke] ON 

GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1, N'Ford')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (2, N'Toyota')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1003, N'BMW')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1004, N'Honda')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1005, N'Mercedes Benz')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1006, N'Opel')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1007, N'Jaguar')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1008, N'Dodge')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1009, N'Renault')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1010, N'Open')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1011, N'Hyundai')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (1012, N'V80')
GO
INSERT [dbo].[Marke] ([id], [pavadinimas]) VALUES (2003, N'BMW')
GO
SET IDENTITY_INSERT [dbo].[Marke] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelis] ON 

GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1, N'Mondeo', 1)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (2, N'Corolla', 2)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1003, N'530', 1003)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1004, N'Fiesta', 1)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1005, N'Avensis', 2)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1006, N'Yaris', 2)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1007, N'Mustang', 1)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1008, N'730', 1003)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1009, N'Clio', 1009)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1010, N'Corsa', 1006)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (1012, N'Volvo', 1012)
GO
INSERT [dbo].[Modelis] ([id], [pavadinimas], [fk_marke]) VALUES (2003, N'530', 2003)
GO
SET IDENTITY_INSERT [dbo].[Modelis] OFF
GO
INSERT [dbo].[Pakaitinis_automobilis] ([valstybinis_numeris], [metai], [degalu_kiekis], [fk_modelis], [fk_padalinys]) VALUES (N'FWA154', N'2011', 60, 1012, 1)
GO
INSERT [dbo].[Pakaitinis_automobilis] ([valstybinis_numeris], [metai], [degalu_kiekis], [fk_modelis], [fk_padalinys]) VALUES (N'VAR114', N'2014', 50, 1004, 1)
GO
INSERT [dbo].[Pakaitinis_automobilis] ([valstybinis_numeris], [metai], [degalu_kiekis], [fk_modelis], [fk_padalinys]) VALUES (N'VAR504', N'2014', 70, 1003, 1)
GO
INSERT [dbo].[Automobilis] ([valstybinis_numeris], [kebulo_tipas], [kebulo_numeris], [metai], [fk_modelis]) VALUES (N'FAQ123', N'Sedanas', N'VP025562525221', N'2012', 1009)
GO
INSERT [dbo].[Automobilis] ([valstybinis_numeris], [kebulo_tipas], [kebulo_numeris], [metai], [fk_modelis]) VALUES (N'KFL654', N'Sedanas', N'VP505035105603', N'2014', 1010)
GO
INSERT [dbo].[Automobilis] ([valstybinis_numeris], [kebulo_tipas], [kebulo_numeris], [metai], [fk_modelis]) VALUES (N'TXT641', N'Kupė', N'VP05228405140651', N'2015', 2003)
GO
INSERT [dbo].[Automobilis] ([valstybinis_numeris], [kebulo_tipas], [kebulo_numeris], [metai], [fk_modelis]) VALUES (N'VAR123', N'Sedanas', N'VP2561561256156415', N'2007', 2)
GO
SET IDENTITY_INSERT [dbo].[Uzsakymas] ON 

GO
INSERT [dbo].[Uzsakymas] ([uzsakymo_nr], [data], [kliento_vardas], [kliento_pavarde], [kliento_telefonas], [fk_meistras], [fk_automobilis], [fk_pakaitinis_automobilis]) VALUES (6, CAST(0x84380B00 AS Date), N'Tadas', N'Radvilavičius', N'+37063728870', 1, N'VAR123', N'VAR114')
GO
INSERT [dbo].[Uzsakymas] ([uzsakymo_nr], [data], [kliento_vardas], [kliento_pavarde], [kliento_telefonas], [fk_meistras], [fk_automobilis], [fk_pakaitinis_automobilis]) VALUES (7, CAST(0x84380B00 AS Date), N'Petraitis', N'Petras', N'+37068426650', 1, N'FAQ123', N'VAR504')
GO
INSERT [dbo].[Uzsakymas] ([uzsakymo_nr], [data], [kliento_vardas], [kliento_pavarde], [kliento_telefonas], [fk_meistras], [fk_automobilis], [fk_pakaitinis_automobilis]) VALUES (8, CAST(0x573A0B00 AS Date), N'Martynas', N'Martinkūnas', N'+37068741251', 2, N'KFL654', N'FWA154')
GO
INSERT [dbo].[Uzsakymas] ([uzsakymo_nr], [data], [kliento_vardas], [kliento_pavarde], [kliento_telefonas], [fk_meistras], [fk_automobilis], [fk_pakaitinis_automobilis]) VALUES (1003, CAST(0xDC3A0B00 AS Date), N'Henrikas', N'Hendraitis', N'+37063504741', 2, N'TXT641', N'VAR504')
GO
SET IDENTITY_INSERT [dbo].[Uzsakymas] OFF
GO
SET IDENTITY_INSERT [dbo].[Parduotuve] ON 

GO
INSERT [dbo].[Parduotuve] ([id], [pavadinimas], [miestas], [adresas]) VALUES (1, N'Lirosta', N'Kaunas', N'Savanorių pr. 213')
GO
INSERT [dbo].[Parduotuve] ([id], [pavadinimas], [miestas], [adresas]) VALUES (2, N'Intercars', N'Kaunas', N'Taikos pr. 27')
GO
SET IDENTITY_INSERT [dbo].[Parduotuve] OFF
GO
SET IDENTITY_INSERT [dbo].[Autodalis] ON 

GO
INSERT [dbo].[Autodalis] ([id], [pavadinimas], [kaina], [gamintojas], [fk_parduotuve]) VALUES (1, N'Stabdžių diskas', 1499, N'Bosh', 1)
GO
INSERT [dbo].[Autodalis] ([id], [pavadinimas], [kaina], [gamintojas], [fk_parduotuve]) VALUES (2, N'Suportas', 21, N'Bosh', 1)
GO
INSERT [dbo].[Autodalis] ([id], [pavadinimas], [kaina], [gamintojas], [fk_parduotuve]) VALUES (1002, N'Stabdžių kaladėlės', 21, N'Bosh', 1)
GO
SET IDENTITY_INSERT [dbo].[Autodalis] OFF
GO
SET IDENTITY_INSERT [dbo].[Autodalies_uzsakymas] ON 

GO
INSERT [dbo].[Autodalies_uzsakymas] ([id], [kiekis], [fk_autodalis], [fk_uzsakymas]) VALUES (1, 2, 1, 6)
GO
INSERT [dbo].[Autodalies_uzsakymas] ([id], [kiekis], [fk_autodalis], [fk_uzsakymas]) VALUES (2, 4, 1002, 7)
GO
INSERT [dbo].[Autodalies_uzsakymas] ([id], [kiekis], [fk_autodalis], [fk_uzsakymas]) VALUES (3, 2, 1, 8)
GO
SET IDENTITY_INSERT [dbo].[Autodalies_uzsakymas] OFF
GO
INSERT [dbo].[Saskaita] ([saskaitos_numeris], [data], [suma], [fk_uzsakymas]) VALUES (N'2420', CAST(0x84380B00 AS Date), 500, 6)
GO
SET IDENTITY_INSERT [dbo].[Gedimas] ON 

GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (1, N'Padangų keitimas', 8)
GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (2, N'Tepalų keitimas', 6)
GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (4, N'Dirželių keitimas', 6)
GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (5, N'Automobilio diagnostika', 7)
GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (6, N'Test', 7)
GO
INSERT [dbo].[Gedimas] ([id], [pavadinimas], [fk_uzsakymas]) VALUES (8, N'Standartinė apžiūra', 1003)
GO
SET IDENTITY_INSERT [dbo].[Gedimas] OFF
GO
INSERT [dbo].[Login] ([id], [username], [password], [role]) VALUES (1, N'root', N'12345', 0)
GO
INSERT [dbo].[Login] ([id], [username], [password], [role]) VALUES (2, N'user1', N'12345', 1)
GO
INSERT [dbo].[Login] ([id], [username], [password], [role]) VALUES (3, N'shopkeeper', N'12345', 99)
GO

GO
