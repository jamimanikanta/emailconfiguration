create procedure [dbo].[sp_CheckAndAllocateslote]

as
begin
declare 
@totalholder int,
@totalseeker int,
@Holderparkingslotnumber int,
@Holderdetailid int,
@seekerparkingslotnumber int,
@seekerdetailid int
select @totalholder=count(*) from HolderDetails where OperationType=1 and SlotReleasedDate=(SELECT CONVERT(date,SYSDATETIME()))
select @totalseeker=count(*) from SeekerDetails where OperationType=1 and CAST(SlotReleasedDate AS DATE)=(SELECT CONVERT(date,SYSDATETIME()))

begin

if @totalholder>0 and @totalseeker>0
  
 
 select top(1)@Holderparkingslotnumber=ParkingSlotNumber,@Holderdetailid=HolderDetailId from HolderDetails where OperationType=1 and AllocationType=0 and SlotReleasedDate=(SELECT CONVERT(date,SYSDATETIME()))
 update HolderDetails set AllocationType=1 , OperationType=0 where HolderDetailId=@Holderdetailid

 select top(1)@seekerdetailid=SeekerDetailId from SeekerDetails  where OperationType=1and AllocationType=0 and CAST(SlotReleasedDate AS DATE)=(SELECT CONVERT(date,SYSDATETIME()))
 update SeekerDetails set ParkingSlotNumber=@Holderparkingslotnumber,AllocationType=1,OperationType=0 where SeekerDetailId=@seekerdetailid
 
 
end

end