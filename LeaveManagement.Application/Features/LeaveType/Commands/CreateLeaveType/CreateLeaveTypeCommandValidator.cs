using FluentValidation;
using LeaveManagement.Application.Contracts.Persistence;

namespace LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator:AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} is maximum length of 50");
        
        RuleFor(x => x.DefaultDays).LessThan(100).WithMessage("{PropertyName} must be less than 100 days");
        
        RuleFor(x => x.DefaultDays).GreaterThan(0).WithMessage("{PropertyName} must be greater than zero");
        
        RuleFor(q => q).MustAsync(LeaveTypeNameUnique).WithMessage("{PropertyName} must be unique");
        
        RuleFor(q => q.Id).MustAsync(LeaveTypeMustExist).WithMessage("{PropertyName} must be exist");
    }

    private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand request, CancellationToken token)
    {
        return _leaveTypeRepository.LeaveTypeNameUnique(request.Name);
    }

    private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}