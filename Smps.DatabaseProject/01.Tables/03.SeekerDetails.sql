
CREATE TABLE [dbo].[SeekerDetails](
	[SeekerDetailId] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NULL,
	[ParkingSlotNumber] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[SlotReleasedDate] [datetime] NULL,
	[AllocationType] [int] NOT NULL,
	[OperationType] [smallint] NOT NULL CONSTRAINT [De_SeekerDetails_OperationType]  DEFAULT ((1)),
 CONSTRAINT [Pk_SeekerDetails_SeekerDetailId] PRIMARY KEY CLUSTERED 
(
	[SeekerDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SeekerDetails]  WITH CHECK ADD  CONSTRAINT [Fk_SeekerDetails_Users_EmpNo] FOREIGN KEY([EmpNo])
REFERENCES [dbo].[Users] ([EmpNo])
GO

ALTER TABLE [dbo].[SeekerDetails] CHECK CONSTRAINT [Fk_SeekerDetails_Users_EmpNo]
GO

