create procedure [dbo].[sp_UpdatingOperationaAndAllocation]
@EmpNo int ,
@CreatedDate nvarchar(50)
As
Begin

Update HolderDetails set OperationType=0,AllocationType=1 where EmpNo=@EmpNo and CreatedDate=convert(datetime,@CreatedDate,5)
end
GO

