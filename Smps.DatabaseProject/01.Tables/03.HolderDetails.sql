/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2086; As a DB Developer, I want to maintain the holder transactions into HolderDetails Table, so that we can Track free slot and allot it to seeker

-- Updated Date:
-- Description:
/*****************************************************************/

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE Name = 'HolderDetails' AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HolderDetails](
	[HolderDetailId] [int] NOT NULL,
	[UserID] [int] NULL,
	[ParkingSlotNumber] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SlotReleasedDate] [datetime] NOT NULL,
	[AllocationType] [int] NOT NULL,
	[OperatinType] [smallint] NOT NULL
) 
END
GO



IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Pk_HolderDetails_HolderDetailId' AND type in (N'PK')) BEGIN
ALTER TABLE HolderDetails ADD CONSTRAINT Pk_HolderDetails_HolderDetailId PRIMARY KEY (HolderDetailId)
END 
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE NAME = 'Fk_HolderDetails_Users_UserId' AND type in (N'F')) BEGIN
ALTER TABLE HolderDetails ADD CONSTRAINT Fk_HolderDetails_Users_UserId FOREIGN KEY (UserID) REFERENCES Users(UserId)
END 
GO

