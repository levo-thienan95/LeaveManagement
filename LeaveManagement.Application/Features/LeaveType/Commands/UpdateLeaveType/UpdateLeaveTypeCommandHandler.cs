using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler: IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _repository;
    private readonly IMapper _mapper;
    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;   
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeUpdate = _mapper.Map<Domain.LeaveType>(request);
        await _repository.UpdateAsync(leaveTypeUpdate);
        return Unit.Value;
    }
}