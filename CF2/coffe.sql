CREATE DATABASE CoffeeShop12
GO

USE CoffeeShop12
GO

--Drink
--Drink Menu
--Table
--Account
--Bill
--BillInfo

Create TABLE TableFood
(

id INT IDENTITY PRIMARY KEY,
name NVARCHAR(100) NOT NULL DEFAULT N'No Name',
status NVARCHAR(100) NOT NULL DEFAULT N'Empty',
)
GO

CREATE TABLE Account
(

UserName NVARCHAR(100) PRIMARY KEY,
DisplayName NVARCHAR(100) NOT NULL DEFAULT N'TheNA',
PassWord NVARCHAR(100) NOT NULL DEFAULT N'******',
Type INT NOT NULL DEFAULT 0,
)
GO

CREATE TABLE DrinkCategory
(

id INT IDENTITY PRIMARY KEY,
name NVARCHAR(100) NOT NULL DEFAULT N'No Name',
)
GO

CREATE TABLE Drink
(

id INT IDENTITY PRIMARY KEY,
idCategory INT NOT NULL,
name NVARCHAR(100) NOT NULL DEFAULT N'No Name', -- dat ten hay chua
price money NOT NULL DEFAULT 0,

FOREIGN KEY (idCategory) REFERENCES dbo.DrinkCategory(id)
)
GO


CREATE TABLE Bill
(

id INT IDENTITY PRIMARY KEY,
DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
DateCheckOut DATE,
idTable INT NOT NULL,
status INT NOT NULL DEFAULT 0, --da tinh tien chua
discount INT  NOT NULL DEFAULT 0,
totalPrice FLOAT DEFAULT 0 

FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO
  

CREATE TABLE BillInfo
(

id INT IDENTITY PRIMARY KEY,
idBill INT NOT NULL,
idDrink INT NOT NULL,
count INT NOT NULL DEFAULT 0,

FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
FOREIGN KEY(idDrink) REFERENCES dbo.Drink(id)
)
GO

INSERT INTO dbo.Account
(
UserName,
DisplayName,
PassWord,
Type
)

VALUES 
(
N'staff', -- UserName - nvarchar(100)
N'staff', -- DisplayName - nvarchar(100)
N'123', --Password - nvarchar(100)
1 -- Type - int
)

INSERT INTO dbo.Account
(
UserName,
DisplayName,
PassWord,
Type
)

VALUES 
(
N'na', -- UserName - nvarchar(100)
N'na', -- DisplayName - nvarchar(100)
N'123', --Password - nvarchar(100)
0 -- Type - int
)
GO 

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN

     SELECT * FROM dbo.Account WHERE UserName = @userName AND  PassWord = @passWord

END
GO

--Them tablbe
DECLARE @i INT = 0

WHILE @i <= 10
BEGIN 
     INSERT dbo.TableFood(name) VALUES (N'Bàn: ' + CAST(@i AS NVARCHAR (100)))
	 SET @i = @i + 1
END
GO

CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO

EXEC dbo.USP_GetTableList
GO

--Them Category
INSERT dbo.DrinkCategory
(name)
VALUES (N'Coffee')
INSERT dbo.DrinkCategory
(name)
VALUES (N'Nuoc Ngot')
INSERT dbo.DrinkCategory
(name)
VALUES (N'Sinh To')
INSERT dbo.DrinkCategory
(name)
VALUES (N'Da Xay')

--Thêm nuoc
INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Ca Phe Da',1,15000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Ca Phe Sua',1,99999)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Coca',2,15000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Pepsi',2,15000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Sinh To Dau',3,30000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Sinh To Dua Hau',3,30000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Ca Phe Da Xay',4,35000)

INSERT dbo.Drink
(name,idCategory,price)
VALUES (N'Keo Da Xay',4,35000)

--Them Bill
INSERT dbo.Bill
(DateCheckIn,DateCheckOut,idTable,status)
VALUES (GETDATE(),NULL,1,0)

INSERT dbo.Bill
(DateCheckIn,DateCheckOut,idTable,status)
VALUES (GETDATE(),NULL,2,0)

INSERT dbo.Bill
(DateCheckIn,DateCheckOut,idTable,status)
VALUES (GETDATE(),NULL,4,0)

INSERT dbo.Bill
(DateCheckIn,DateCheckOut,idTable,status)
VALUES (GETDATE(),GETDATE(),5,1)

--Them Bill Info
INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (1,2,4)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (1,1,4)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (2,2,2)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (2,3,1)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (2,4,1)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (3,3,1)

INSERT dbo.BillInfo
(idBill,idDrink,count)
VALUES (3,7,1)



SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.TableFood

SELECT * FROM dbo.Drink
SELECT * FROM dbo.DrinkCategory

GO

--tinh tong bill moi ban
--SELECT d.name, b.quantity,d.price, d.price*b.quantity AS totalPrice 
--FROM dbo.BillInfo AS b,  dbo.Bill AS bi, dbo.Drink AS d  
--WHERE b.idBill = bi.id AND bi.status= 0 AND b.idDrink = d.id AND bi.idTable = 5



CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
    INSERT dbo.Bill (DateCheckIn,DateCheckOut,idTable,status, discount)
	VALUES (GETDATE(), NULL , @idTable , 0, 0)
END
GO



CREATE  PROC USP_InsertBillInfo
@idBill INT, @idDrink INT, @count INT
AS 
BEGIN 
     DECLARE @idExitBillInfo INT
	 DECLARE @drinkCount INT =1

	 SELECT @idExitBillInfo = id, @drinkCount = b.count 
	 FROM dbo.BillInfo as b
	 WHERE idBill = @idBill AND idDrink = @idDrink

	 IF(@idExitBillInfo >0)
	 BEGIN 
	      DECLARE @newCount INT = @drinkCount + @count
		  IF(@newCount > 0)
		      UPDATE dbo.BillInfo SET count = @drinkCount + @count WHERE idDrink = @idDrink
           ELSE 
		      DELETE dbo.BillInfo WHERE idBill = @idBill AND idDrink = @idDrink
     END
	 ELSE
	 BEGIN 
	      INSERT dbo.BillInfo(idBill,idDrink,count)
          VALUES (@idBill , @idDrink , @count) 
     END
END
GO

CREATE TRIGGER UTG_UpdateBillInfo
 ON dbo.BillInfo FOR INSERT, UPDATE
 AS 
 BEGIN
      DECLARE @idBill INT

	  SELECT @idBill = idBill FROM inserted

	  DECLARE @idTable INT

	  SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0

	      UPDATE dbo.TableFood SET status = N'Co Nguoi' WHERE id = @idTable 
 END
 GO

 

 Create TRIGGER UTG_UpdateBill
 ON dbo.Bill FOR UPDATE
 AS 
 BEGIN
     DECLARE @idBill INT 

	 SELECT @idBill = id FROM inserted

	 DECLARE @idTable INT

	 SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill 

	 DECLARE @count INT = 0

	 SELECT @count = COUNT (*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0

	 IF(@count = 0)
        UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable
 END
 GO

 SELECT * FROM dbo.Bill
 SELECT * FROM dbo.BillInfo
GO
-- SHOW hoa don

CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS
BEGIN

SELECT t.name as [Ten Ban] ,b.totalPrice as [Tong Tien], DateCheckIn as [Ngay Vao],DateCheckOut as [Ngay Ra],discount as [Giam Gia]
FROM dbo.Bill as b, dbo.TableFood as t, dbo.Drink as d, dbo.BillInfo as bi 
WHERE DateCheckIn >=@checkIn AND DateCheckOut <=@checkOut AND b.status = 1
AND t.id = b.idTable AND bi.idBill = b.id AND bi.idDrink = d.id

END
GO

CREATE PROC USP_UpdateAccount 
@userName NVARCHAR(100), @displayName NVARCHAR(100),
@passWord NVARCHAR(100), @newPassWord NVARCHAR(100)
AS 
BEGIN
     DECLARE @isRightPass INT 
	 SELECT @isRightPass = COUNT(*) FROM dbo.Account WHERE USERName = @userName AND PassWord = @passWord

	 IF(@isRightPass = 1)
	 BEGIN
	      IF(@newPassWord = NULL OR @newPassWord ='')
		  BEGIN 
		       UPDATE dbo.Account SET DisplayName = @displayName WHERE UserName = @userName

          END
		  ELSE
	  	       UPDATE dbo.Account SET DisplayName = @displayName, PassWord = @newPassWord WHERE UserName = @userName
      END 
END
GO

CREATE PROC USP_AccountList
AS SELECT * FROM dbo.Account
GO

CREATE TRIGGER UTG_DeleteBillInfo
ON dbo.BillInfo FOR DELETE
AS
BEGIN 
     DECLARE @idBillInfo INT
	 DECLARE @idBill INT
	 SELECT  @idBillInfo = id, @idBill = deleted.idBill FROM deleted

	 DECLARE @idTable INT 
	 SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill

	 DECLARE @count INT = 0

	 SELECT @count = COUNT(*) FROM dbo.BillInfo AS bi, dbo.Bill AS b WHERE b.id = bi.idBill AND b.id = @idBill AND b.status = 0
	 
	 IF(@count = 0)

	     UPDATE dbo.TableFood SET status = N'Empty' WHERE id = @idTable

END
Go

SELECT * FROM dbo.Bill
SELECT * FROM dbo.BillInfo
SELECT * FROM dbo.Drink
SELECT * FROM dbo.DrinkCategory
SELECT * FROM dbo.TableFood
SELECT * FROM dbo.Account

