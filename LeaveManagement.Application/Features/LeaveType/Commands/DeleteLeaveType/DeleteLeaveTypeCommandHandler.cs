using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler: IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;
    
    public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeDelete = await _repository.GetByIdAsync(request.Id);
        if (leaveTypeDelete == null)
        {
          throw new NotFoundException(nameof(LeaveType),request.Id);
        }
        
        await _repository.DeleteAsync(leaveTypeDelete);
        
        return Unit.Value;
    }
}