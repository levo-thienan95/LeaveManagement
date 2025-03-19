using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypeDetailHandler:IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }
    public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveTypeDetail = await _leaveTypeRepository.GetByIdAsync(request.id);
        var data = _mapper.Map<LeaveTypeDetailDto>(leaveTypeDetail);
        return data;
    }
}