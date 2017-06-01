create procedure [dbo].[sp_seekerdetails]
  @EmpNo int,
  @ParkingSlotNumber int,
  @CreatedDate nvarchar(50),
  @SlotReleasedDate nvarchar(50),
  @AllocationType int ,
  @OperationType int 
   
 
  As
  begin 
  insert into SeekerDetails (EmpNo,ParkingSlotNumber,CreatedDate,SlotReleasedDate,AllocationType,OperationType)values (@EmpNo,@ParkingSlotNumber,convert(datetime,@CreatedDate,5),convert(datetime,@SlotReleasedDate,5),@AllocationType,@OperationType);
 
  end
