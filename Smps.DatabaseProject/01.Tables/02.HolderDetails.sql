/*****************************************************************/
-- Author: SAI PATHA 
-- Create Date: 11/21/2016 
-- Description: JIRA: SNLPROJECT-2086; As a DB Developer, I want to maintain the holder transactions into HolderDetails Table, so that we can Track free slot and allot it to seeker

-- Updated Date:
-- Description:
/*****************************************************************/

CREATE TABLE [dbo].[HolderDetails](
	[HolderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NULL,
	[ParkingSlotNumber] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SlotReleasedDate] [datetime] NOT NULL,
	[AllocationType] [int] NOT NULL,
	[OperationType] [smallint] NOT NULL DEFAULT 1
) 

GO



ALTER TABLE HolderDetails ADD CONSTRAINT Pk_HolderDetails_HolderDetailId PRIMARY KEY (HolderDetailId)
GO



ALTER TABLE HolderDetails ADD CONSTRAINT Fk_HolderDetails_UserId_Users_Id FOREIGN KEY ([EmpNo]) REFERENCES Users([EmpNo])

GO

