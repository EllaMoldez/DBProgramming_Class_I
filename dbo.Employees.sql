CREATE TABLE [dbo].[Employees] (
    [Emp_Id]     INT           NOT NULL IDENTITY,
    [First_Name] NVARCHAR (20) NULL,
    [Last_Name]  NVARCHAR (30) NULL,
    [Dept_Id]    INT           NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Emp_Id] ASC),
    CONSTRAINT [FK_Employees_Departments] FOREIGN KEY ([Dept_Id]) REFERENCES [dbo].[Departments] ([Dept_Id])
);

