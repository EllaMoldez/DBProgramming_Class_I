TRUNCATE TABLE [dbo].[Employees]
ALTER TABLE [dbo].[Employees] 
DROP CONSTRAINT [PK_Employees]
GO
ALTER TABLE [dbo].[Employees] 
ALTER COLUMN [Emp_Id] INT NOT NULL --IDENTITY(1,1) 
GO
ALTER TABLE [dbo].[Employees] 
ADD CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Emp_Id]) 
GO