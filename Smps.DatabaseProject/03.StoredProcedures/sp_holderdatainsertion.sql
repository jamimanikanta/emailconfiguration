create PROCEDURE [dbo].[sp_holderdatainsertion] 
 
 @EmpNo int,
 @ParkingSlotNumber nvarchar(50),
 @CreatedDate nvarchar(50),
 @SlotReleasedDate nvarchar(50),
 @AllocationType int,
 @OperationType int
 As
 begin

 insert into HolderDetails values (@EmpNo, @ParkingSlotNumber,convert(datetime,@CreatedDate,5),convert(datetime,@SlotReleasedDate,5),@AllocationType,@OperationType);
 end