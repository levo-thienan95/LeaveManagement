using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using LeaveManagement.Application.Exceptions;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler: IRequestHandler<CreateLeaveTypeCommand, int>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }   
    public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
        var validatorResult = await validationResult.ValidateAsync(request);
        if (validatorResult.IsValid)
        {
            throw new BadRequestException("Invalid LeaveType", validatorResult);
        }
        
        var leaveToCreate = _mapper.Map<Domain.LeaveType>(request);
        
        await _leaveTypeRepository.CreateAsync(leaveToCreate);
        
        return leaveToCreate.Id;
    }
}