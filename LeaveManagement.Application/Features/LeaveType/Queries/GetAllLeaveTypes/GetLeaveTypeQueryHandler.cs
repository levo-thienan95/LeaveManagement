using AutoMapper;
using LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypeQueryHandler:IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository; 
    private readonly IMapper _mapper;
    public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        this._mapper = mapper;
        this._leaveTypeRepository = leaveTypeRepository;
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
    {
        // Query data from database
        var leaveType = await _leaveTypeRepository.GetAsync();
        //Convert data objects to DTO
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveType);
        //Return data
        return data;
    }
}