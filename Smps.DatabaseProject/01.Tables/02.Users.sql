/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2085 As a developer I want to create a page with functionalities for Holders to release their Allocated car parking slot,so the Holder access this page to release his/her car parking slot for single (or) multiple days

-- Updated Date:
-- Description:
/*****************************************************************/

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Users' AND type in (N'U')) BEGIN
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[MobileNumber] [int] NULL,
	[EmailAdddress] [varchar](20) NULL,
	[UserTypeName] [varchar](20) NOT NULL,
	[ParkingSlotNumber] [int] NULL,
	[Location] [varchar](50) NOT NULL,
	[OperatinType] [smallint] NOT NULL 
)
END 
GO 

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Pk_Users_UserId' AND type in (N'PK')) BEGIN
ALTER TABLE Users ADD CONSTRAINT Pk_Users_UserId PRIMARY KEY (UserId)
END 
GO 

