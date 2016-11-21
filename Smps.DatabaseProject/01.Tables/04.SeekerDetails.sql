/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2087; As a DB Developer, I want to maintain the holder transactions into HolderDetails Table, so that we can Track free slot and allot it to seeker

-- Updated Date:
-- Description:
/*****************************************************************/

IF NOT EXISTS (SELECT * FROM sys.objects WHERE Name='SeekerDetails' AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SeekerDetails](
	[SeekerDetailId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ParkingSlotNumber] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SlotRequestedDate] [datetime] NOT NULL,
	[HolderDetailId] [int] NULL,
	[OperatinType] [smallint] NOT NULL DEFAULT 1
)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Pk_SeekerDetails_SeekerDetailId' AND type in (N'PK')) BEGIN
ALTER TABLE SeekerDetails ADD CONSTRAINT Pk_SeekerDetails_SeekerDetailId PRIMARY KEY (SeekerDetailId)
END 
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Fk_SeekerDetails_Users_UserId' AND type in (N'F')) BEGIN
ALTER TABLE SeekerDetails ADD CONSTRAINT Fk_SeekerDetails_Users_UserID FOREIGN KEY (UserID) REFERENCES Users(UserId)
END 
GO

IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE NAME = 'Fk_SeekerDetails_HolderDetails_HolderDetailId' AND type in (N'F')) BEGIN
ALTER TABLE SeekerDetails ADD CONSTRAINT Fk_SeekerDetails_HolderDetails_HolderDetailId FOREIGN KEY (HolderDetailId) REFERENCES HolderDetails(HolderDetailId)
END 
GO