/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2088; As a DB Developer, I want to maintain Allocation type, so that we can refer this table to know the type and status of allocation.

-- Updated Date:
-- Description:
/*****************************************************************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE Name='AllocationTypes' AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AllocationTypes](
	[AllocationType] [int] NOT NULL,
	[AllocationTypeName] [varchar](50) NULL,
	[OperationType] [int] NULL DEFAULT 1
) 
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Pk_AllocationTypes_AllocationType' AND type in (N'PK')) BEGIN
ALTER TABLE AllocationTypes ADD CONSTRAINT Pk_AllocationTypes_AllocationType PRIMARY KEY (AllocationType)
END 
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[AllocationTypes] WHERE AllocationType = 1) BEGIN  
INSERT INTO AllocationTypes (AllocationType,AllocationTypeName,OperationType) VALUES (1,'Not Alloted',DEFAULT)
END
GO
 
IF NOT EXISTS (SELECT 1 FROM [dbo].[AllocationTypes] WHERE AllocationType = 2) BEGIN  
INSERT INTO AllocationTypes (AllocationType,AllocationTypeName,OperationType) VALUES (2,'Alloted',DEFAULT)
END 
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[AllocationTypes] WHERE AllocationType = 3) BEGIN  
INSERT INTO AllocationTypes (AllocationType,AllocationTypeName,OperationType) VALUES (3,'Mutually Alloted',DEFAULT)
END 
GO