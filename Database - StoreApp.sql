Create Database StudentInformation
Go
use StudentInformation
Go
Create Table tblStudent
(
	Id int primary key,
	Tittle nvarchar(30),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(30),
	MobileNo nvarchar(30),
	CourseName nvarchar(30),
)
Go
Select * from tblStudent
Go
Insert into tblStudent values(001,'Md.','Imran','Haque','mdim@gmail.com','01677355887','c#')
Insert into tblStudent values(002,'Mr.','Imran','Khan','mrik@gmail.com','01677355558','PHP')
Go
Update tblStudent set Tittle='Md.',FirstName='',LastName='',Email='',MobileNo='',CourseName='' where Id=2
GO
Delete from tblStudent where Id=2
GO
