TRUNCATE TABLE [dbo].[Employees]

ALTER TABLE [dbo].[Employees] 
DROP CONSTRAINT [PK_Employees]

ALTER TABLE [dbo].[Employees] 
ALTER COLUMN [Emp_Id] INT NOT NULL --IDENTITY(1,1) 

ALTER TABLE [dbo].[Employees] 
ADD CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Emp_Id]) 
